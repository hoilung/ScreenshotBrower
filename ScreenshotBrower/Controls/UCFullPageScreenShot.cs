using System;
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

namespace ScreenshotBrower.Controls
{
    public partial class UCFullPageScreenShot : UserControl
    {
        public UCFullPageScreenShot()
        {
            InitializeComponent();
            tableLayoutPanel1.Dock = groupBox1.Dock = groupBox2.Dock = DockStyle.Fill;
            tbx_text.Text = DateTime.Now.ToString("yyyy/MM/dd");


            this.Load += UCFullPageScreenShot_Load;
        }

        private ToolStripStatusLabel toolStripStatus;
        private ToolStripProgressBar progressBar;
        private void UCFullPageScreenShot_Load(object sender, EventArgs e)
        {
            if (this.FindForm() != null)
            {
                var cl = this.FindForm().Controls.Find("statusStrip1", true);
                if (cl != null)
                {
                    var statusStrip1 = cl[0] as StatusStrip;
                    toolStripStatus = statusStrip1.Items.Find("toolStripStatusLabel1", true)[0] as ToolStripStatusLabel;
                    progressBar = statusStrip1.Items.Find("toolStripProgressBar1", true)[0] as ToolStripProgressBar;
                }
            }
        }

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
            toolStripStatus.Text = "0/" + urls.Count();
            progressBar.Maximum = urls.Count();
            progressBar.Value = 0;
            var dirpath = Path.Combine(tbx_path.Text, DateTime.Now.ToString("yyyy-MM-dd"));
            Directory.CreateDirectory(dirpath);
            Task.Run(() => BulidPdfAsync(urls.ToArray(), dirpath, cbx_city.Checked, cbx_text.Checked ? tbx_text.Text : string.Empty, cbx_his.Checked));

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="urls"></param>
        /// <param name="path"></param>
        /// <param name="changeCity">切换城市</param>
        /// <param name="addText">添加页眉/页脚内容</param>
        /// <returns></returns>
        private async Task BulidPdfAsync(Uri[] urls, string path, bool changeCity, string addText, bool saveHis)
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
                    Args = new[] {
                        "--no-sandbox",
                        "--disable-setuid-sandbox",
                        "--lang=en-US,en"
                        //    "--disable-dev-shm-usage",
                        //   "--disable-extensions",
                        //  "--disable-gpu",
                        // "--disable-infobars",
                        //"--disable-local-storage",
                        // "--no-zygote",
                        // "--disable-bundled-ppapi-flash"
                    },
                    IgnoreHTTPSErrors = true,
                };
                using (var browser = await Puppeteer.LaunchAsync(option))
                {
                    var page = await browser.NewPageAsync();
                    await page.SetViewportAsync(new ViewPortOptions
                    {
                        Width = Screen.PrimaryScreen.WorkingArea.Width,
                        Height = Screen.PrimaryScreen.WorkingArea.Height
                    });


                    if (changeCity)
                    {
                        this.Invoke(new MethodInvoker(() =>
                        {
                            if (toolStripStatus != null)
                            {
                                toolStripStatus.Text = "初始化内容,切换地区";
                            }
                        }));

                        var zips = Properties.Resources.zip.Split(new[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
                        var zip = zips.OrderBy(m => Guid.NewGuid()).First();
                        await page.GoToAsync("https://www.amazon.com/");
                        await page.EvaluateFunctionAsync(Properties.Resources.oChange, zip);
                        await Task.Delay(10000);
                    }
                    int count = 0;


                    foreach (var item in urls)
                    {
                        var ht = $"<div style=\"top:0px;font-size:10px;margin-left: 10px\"><span style=\"margin-left: 20px;\">{item}</span><span style=\"margin-left: 25%;\">{addText}</span><span style=\"margin-left: 25%;\">{addText}</span></div>";
                        var ft = $"<div style=\"top:0px;font-size:10px;margin-left: 10px\"><span style=\"margin-left: 20px;\">{item}</span><span style=\"margin-left: 25%;\">{addText}</span><span style=\"margin-left: 25%;\">{addText}</span></div>";

                        try
                        {
                            this.Invoke(new MethodInvoker(() =>
                            {
                                if (toolStripStatus != null)
                                {
                                    toolStripStatus.Text = "开始加载页面 " + item;
                                    progressBar.PerformStep();
                                }
                            }));

                            //搜索记录
                            if (saveHis)
                            {
                                var preurl = Properties.Resources.preload.Split(new[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries).OrderBy(m => Guid.NewGuid()).Take(6).ToList();
                                for (int i = 0; i < preurl.Count; i++)
                                {
                                    var url = preurl[i];
                                    this.Invoke(new MethodInvoker(() =>
                                    {
                                        if (toolStripStatus != null)
                                        {
                                            toolStripStatus.Text = $"增加浏览记录 {(i + 1)}/{preurl.Count} {url}";
                                        }
                                    }));

                                }
                            }
                            this.Invoke(new MethodInvoker(() =>
                            {
                                if (toolStripStatus != null)
                                {
                                    toolStripStatus.Text = $"打开目标页面 " + item.ToString();
                                }
                            }));
                            //目标页面
                            await page.GoToAsync(item.ToString());
                            if (saveHis)
                            {
                                this.Invoke(new MethodInvoker(() =>
                                {
                                    if (toolStripStatus != null)
                                    {
                                        toolStripStatus.Text = $"展示浏览记录";
                                    }
                                }));
                                var result = await page.EvaluateFunctionAsync<string>("()=>{try{window.scrollBy(0,document.querySelector('.navFooterBackToTopText').getBoundingClientRect().top-600);return 1;}catch(ex){console.log(ex);return 0;}}");
                                await Task.Delay(5000);
                            }
                            var file = Path.Combine(path, item.AbsolutePath.Replace("/dp/", "").Replace("/", "") + ".pdf");
                            this.Invoke(new MethodInvoker(() =>
                            {
                                if (toolStripStatus != null)
                                {
                                    toolStripStatus.Text = "开始生成PDF " + file;
                                }
                            }));
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
                                Format = PaperFormat.A4

                            });
                            count += 1;
                        }
                        catch (Exception ex)
                        {
                            this.Invoke(new MethodInvoker(() =>
                            {
                                if (toolStripStatus != null)
                                {
                                    toolStripStatus.Text = ex.Message + "操作失败 " + item;
                                }
                            }));
                            continue;
                            // throw;
                        }
                    }

                    if (saveHis)
                    {
                        var ck = await page.GetCookiesAsync("https://www.amazon.com");
                        await page.DeleteCookieAsync(ck);
                    }


                    this.Invoke(new MethodInvoker(() =>
                    {
                        if (toolStripStatus != null)
                        {
                            toolStripStatus.Text = $"操作完成 {count}/{urls.Length}";
                            progressBar.Value = 0;
                        }
                    }));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
                //throw;
            }




        }





    }
}
