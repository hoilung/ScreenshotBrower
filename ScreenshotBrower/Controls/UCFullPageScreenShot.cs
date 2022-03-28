﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PuppeteerSharp;
using System.IO;
using Microsoft.SqlServer.Server;
using PuppeteerSharp.Media;
using System.Security.Policy;

using Newtonsoft.Json;

namespace ScreenshotBrower.Controls
{
    public partial class UCFullPageScreenShot : UserControl
    {
        private List<Models.CountryModel> _CountryModels;
        public UCFullPageScreenShot()
        {
            InitializeComponent();
            tableLayoutPanel1.Dock = groupBox1.Dock = groupBox2.Dock = DockStyle.Fill;
            tbx_text.Text = DateTime.Now.ToString("yyyy/MM/dd");

            cbx_pagetype.SelectedIndex = 2;
            //     this.Load += UCFullPageScreenShot_Load;


            _CountryModels = JsonConvert.DeserializeObject<List<Models.CountryModel>>(Properties.Resources.country);

            cb_country.Items.Add("请选择国家地区");
            foreach (var item in _CountryModels)
            {
                cb_country.Items.Add(item.Text);
            }
            cb_country.SelectedIndex = 0;

#if !DEBUG
            cb_country.Visible = false;
#endif
        }

        public delegate void ShowTooltipInfoHandler(string info);
        public delegate void SetProcessMaxHandler(int val);
        public delegate void SetProcessValueHanlder(int val);

        public event ShowTooltipInfoHandler ShowTooltipInfo;
        public event SetProcessMaxHandler SetProcessMax;
        public event SetProcessValueHanlder SetProcessValue;


        protected virtual void OnShowTooltipInfo(string info) => this.ShowTooltipInfo?.Invoke(info);

        protected virtual void OnSetProcessMax(int val) => this.SetProcessMax?.Invoke(val);

        protected virtual void OnSetProcessValue(int val) => this.SetProcessValue?.Invoke(val);

        //private ToolStripStatusLabel toolStripStatus;
        //private ToolStripProgressBar progressBar;
        //private void UCFullPageScreenShot_Load(object sender, EventArgs e)
        //{
        //    if (this.FindForm() != null)
        //    {
        //        var cl = this.FindForm().Controls.Find("statusStrip1", true);
        //        if (cl != null)
        //        {
        //            var statusStrip1 = cl[0] as StatusStrip;
        //            toolStripStatus = statusStrip1.Items.Find("toolStripStatusLabel1", true)[0] as ToolStripStatusLabel;
        //            progressBar = statusStrip1.Items.Find("toolStripProgressBar1", true)[0] as ToolStripProgressBar;
        //        }
        //    }
        //}

        private void btn_path_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                tbx_path.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void btn_start_Click(object sender, EventArgs e)
        {
            if (!System.IO.Directory.Exists(tbx_path.Text))
            {
                MessageBox.Show("请正确选择要保存的文件路径", "提示");
                return;
            }
            var urls = tbx_urls.Lines.Where(m => m.Contains(".") && m.Length > 10).Where(m => m.StartsWith("http://") || m.StartsWith("https://")).Select(m =>
            {

                try
                {
                    return new Uri(m.ToString());
                }
                catch (Exception)
                {
                    return null;
                }
            }).Where(m => m != null);
            if (!urls.Any())
            {
                MessageBox.Show("请正确填写网址，http开头每行一个", "提示");
                return;
            }

            OnShowTooltipInfo("0/" + urls.Count());
            OnSetProcessMax(urls.Count());
            OnSetProcessValue(0);
            var dirpath = Path.Combine(tbx_path.Text,DateTime.Now.ToString("yyyyMMdd"));
            Directory.CreateDirectory(dirpath);

            var randomCity = cbx_changecity2.Checked;//随机切换地区
            var country = cb_country.Text;//固定地区
            var pagetype = cbx_pagetype.SelectedIndex;
            Task.Run(() =>
                BulidPdfAsync(urls.ToArray(), dirpath, country, randomCity, cbx_text.Checked ? tbx_text.Text : string.Empty, cbx_his.Checked, GetPaperFormat(pagetype)
            ));

        }

        private readonly string _userAgent = $"Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/{new Random().Next(79, 84)}.0.{new Random().Next(3000, 4000)}.0 Safari/537.36";
        /// <summary>
        /// 
        /// </summary>
        /// <param name="urls"></param>
        /// <param name="path"></param>
        /// <param name="changeCountry">选择切换的国家</param>
        /// <param name="randomCity">随机切换城市</param>
        /// <param name="addText">添加页眉/页脚内容</param>
        /// <returns></returns>
        private async Task BulidPdfAsync(Uri[] urls, string path, string changeCountry, bool randomCity, string addText, bool saveHis, PaperFormat paperFormat)
        {

            try
            {
                await new BrowserFetcher(new BrowserFetcherOptions()
                {
                    Host = "http://cdn.npm.taobao.org/dist"
                }).DownloadAsync(BrowserFetcher.DefaultRevision);

                var option = new LaunchOptions
                {
                    UserDataDir = $"{System.IO.Directory.GetCurrentDirectory()}/UserData",
                    Headless = true,
                    DefaultViewport = null,
                    Args = new[] {
                        "--no-sandbox",
                        "--disable-setuid-sandbox",
                        "--lang=en-US,en",
                        "--start-maximized",
                        //    "--disable-dev-shm-usage",
                        //   "--disable-extensions",
                        //  "--disable-gpu",
                        // "--disable-infobars",
                        //"--disable-local-storage",
                        // "--no-zygote",
                        // "--disable-bundled-ppapi-flash"
                        //$"--user-agent={_userAgent}"
                    },
                    IgnoreHTTPSErrors = true,
                };
                using (var browser = await Puppeteer.LaunchAsync(option))
                {
                    BrowserContext browserContext = browser.DefaultContext;
                    //if (saveHis)
                    //{
                    //    browserContext = await browser.CreateIncognitoBrowserContextAsync();

                    //}

                    var page = await browserContext.NewPageAsync();
                    await page.SetUserAgentAsync(_userAgent);

                    await page.SetViewportAsync(new ViewPortOptions
                    {
                        Width = Screen.PrimaryScreen.WorkingArea.Width,
                        Height = Screen.PrimaryScreen.WorkingArea.Height
                    });
                    

                    if (!changeCountry.Contains("请选择") && _CountryModels.Any())
                    {
                        OnShowTooltipInfo("初始化首页内容,开始切换国家");
                        //var zips = Properties.Resources.zip.Split(new[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
                        //var zip = zips.OrderBy(m => Guid.NewGuid()).First();                       

                        await page.GoToAsync("https://www.amazon.com/");
                        var pagetitle = await page.GetTitleAsync();
                        try
                        {
                            var docid = _CountryModels.Find(m => m.Text.Contains(changeCountry));
                            if (docid != null)
                            {
                                await page.EvaluateFunctionAsync(Properties.Resources.oChange2, docid.Id);
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("访问网址受限,自动切换地区失败,\r\n请等待亚马逊解封或切换新ip后再尝试\r\n" + ex.Message, pagetitle);
                            return;
                        }
                        await Task.Delay(8000);
                    }
                    else if (randomCity)//没有选择国家的情况，选择地区切换地区
                    {

                        OnShowTooltipInfo("初始化首页内容,开始切换地区");


                        var zips = Properties.Resources.zip.Split(new[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
                        var zip = zips.OrderBy(m => Guid.NewGuid()).First();
                        await page.GoToAsync("https://www.amazon.com/");
                        var pagetitle = await page.GetTitleAsync();
                        try
                        {
                            await InputMatchCaptch(page);
                            await page.EvaluateFunctionAsync(Properties.Resources.oChange, zip);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("访问网址受限,自动切换地区失败,\r\n请等待亚马逊解封或切换新ip后再尝试", pagetitle);
                            throw ex;
                        }
                        await Task.Delay(10000);
                    }


                    int index = 0;
                    int max = urls.Length;

                    var prelist = Properties.Resources.preload.Split(new[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
                    var maxwidth = Screen.PrimaryScreen.WorkingArea.Width;
                    foreach (var item in urls)
                    {
                        index += 1;
                        var ht = $"<div style=\"top:0px;font-size:10px;margin-left:10px;width:{maxwidth}px;\" ><span style=\"margin-left: 20px;\">{item}</span><span style=\"margin-left: 25%;\"></span><span style=\"margin-left:25%;\">{addText}</span></div>";
                        var ft = $"<div style=\"top:0px;font-size:10px;margin-left: 10px;width:{maxwidth}px;\"><span style=\"margin-left: 20px;\">{item}</span><span style=\"margin-left: 25%;\"></span><span style=\"margin-left:25%;\">{addText}</span></div>";

                        try
                        {
                            OnShowTooltipInfo($"开始加载页面{item}");
                            // progressBar.PerformStep();


                            //搜索记录
                            if (saveHis)
                            {
                                var preurl = prelist.OrderBy(m => Guid.NewGuid()).Take(6).ToList();
                                for (int i = 0; i < preurl.Count; i++)
                                {
                                    await InputMatchCaptch(page);
                                    var url = preurl[i];
                                    OnShowTooltipInfo($"增加浏览记录 {(i + 1)}/{preurl.Count}");

                                    await page.GoToAsync(url);

                                }
                            }
                            OnShowTooltipInfo("打开目标页面 " + item.ToString());
                            //目标页面
                            await page.GoToAsync(item.ToString());
                            await page.EvaluateFunctionAsync<string>("()=>{try{document.querySelector('#productTitle').click(); document.querySelector('.nav-signin-tt.nav-flyout').remove();return 1;}catch(ex){return 0;}}");
                            if (saveHis)
                            {
                                OnShowTooltipInfo("展示浏览记录");

                                var result = await page.EvaluateFunctionAsync<string>("()=>{try{window.scrollBy(0,document.querySelector('.navFooterBackToTopText').getBoundingClientRect().top-600);return 1;}catch(ex){console.log(ex);return 0;}}");

                                await Task.Delay(3000);
                                result = await page.EvaluateFunctionAsync<string>(Properties.Resources.oRandom);
                                await Task.Delay(5000);


                            }
                            var file = Path.Combine(path, item.AbsolutePath.Replace("/dp/", "").Replace("/", "") + ".pdf");
                            OnShowTooltipInfo("开始生成PDF " + file);

                            if (option.Headless)
                            {
                                await page.PdfAsync(file, new PdfOptions()
                                {
                                    PrintBackground = true,
                                    DisplayHeaderFooter = !string.IsNullOrEmpty(addText),
                                    HeaderTemplate = ht,
                                    FooterTemplate = ft,
                                    MarginOptions = new PuppeteerSharp.Media.MarginOptions()
                                    {
                                        Top = "40",
                                        Bottom = "40",
                                        Left = "30",
                                        Right = "30"

                                    },                                    
                                    Format = paperFormat

                                });
                            }

                            OnSetProcessValue(index);
                        }
                        catch (Exception ex)
                        {
                            OnShowTooltipInfo(ex.Message + "操作失败 " + item);
                            continue;
                            // throw;
                        }
                    }

                    //if (saveHis)
                    //{
                    //    var ck = await page.GetCookiesAsync("https://www.amazon.com");
                    //    await page.DeleteCookieAsync(ck);
                    //}

                    OnShowTooltipInfo($"操作完成 {index}/{urls.Length}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
                //throw;
            }




        }

        private static async Task InputMatchCaptch(Page page)
        {
            try
            {
                var input_captch = await page.QuerySelectorAsync("#captchacharacters");
                if (input_captch != null)
                {
                    var img_captch = await page.EvaluateFunctionAsync<string>("()=>{try{ return document.querySelector('form img').src;}catch(e){return '';}}");
                    var btnsubmit = await page.QuerySelectorAsync("button[type='submit']");

                    var capthForm = new Form()
                    {
                        Text = "请在文本框内输入图片上的验证码！",
                        FormBorderStyle = FormBorderStyle.FixedSingle,
                        MaximizeBox = false,
                        ShowIcon = false,
                        Height = 300,
                        Width = 450,
                        TopLevel = true
                    };

                    var macthCaptch = new MatchCaptch();
                    macthCaptch.LoadImage(img_captch);
                    capthForm.Controls.Add(macthCaptch);
                    if (capthForm.ShowDialog() == DialogResult.OK)
                    {
                        await input_captch.TypeAsync(macthCaptch.InputStr, new PuppeteerSharp.Input.TypeOptions { Delay = 500 });//输入验证码
                        await btnsubmit.ClickAsync();
                        await page.WaitForTimeoutAsync(5000);

                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "输入验证码异常错误", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        public PaperFormat GetPaperFormat(int index)
        {
            switch (index)
            {
                case 0:
                    return PaperFormat.A0;
                case 1:
                    return PaperFormat.A1;
                case 2:
                    return PaperFormat.A2;
                case 3:
                    return PaperFormat.A3;
                case 4:
                    return PaperFormat.A4;
                case 5:
                    return PaperFormat.A5;
                case 6:
                    return PaperFormat.A6;
                default:
                    return PaperFormat.A2;

            }
        }

    }
}
