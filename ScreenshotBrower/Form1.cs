
using PuppeteerSharp;
using RestSharp;
using ScreenshotBrower.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic.Devices;

using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using RestSharp.Serialization.Xml;
using OfficeOpenXml;
using System.Net;
using PuppeteerSharp.Helpers;
using System.Text.RegularExpressions;
using System.Security.Policy;

namespace ScreenshotBrower
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            this.Text += " v" + this.ProductVersion.ToLower();
            lb_computerInfo.Text = $"{lb_computerInfo.Text}{new ComputerInfo().OSFullName} {Screen.PrimaryScreen.Bounds.Width}x{Screen.PrimaryScreen.Bounds.Height}";
            tbx_path.Focus();

            label1.DoubleClick += (s, e) =>
            {
                tbx_order.Text = "http://47.92.99.30/";
            };
        }

        private void btn_start_ClickAsync(object sender, EventArgs e)
        {
            var dirBase = tbx_path.Text;
            var taskMax = tb_num.Value;
            var button = sender as Button;
            Task.Run(async () =>
            {

                this.Invoke(new MethodInvoker(() =>
                {
                    toolStripStatusLabel1.Tag = "1";
                    toolStripStatusLabel1.Text = "初始化插件";
                }));
                await new BrowserFetcher(new BrowserFetcherOptions()
                {
                    Host = "http://cdn.npm.taobao.org/dist"
                }).DownloadAsync(BrowserFetcher.DefaultRevision);
                this.Invoke(new MethodInvoker(() =>
                {
                    toolStripStatusLabel1.Text = "初始化浏览器";
                }));
                Browser browser = null;

                try
                {

                    browser = await Puppeteer.LaunchAsync(new LaunchOptions
                    {
                        UserDataDir = $"{System.IO.Directory.GetCurrentDirectory()}/UserData",
                        Headless = true,
                        Args = new[] {
                        "--no-sandbox",
                        "--disable-setuid-sandbox",
                    //    "--disable-dev-shm-usage",
                     //   "--disable-extensions",
                      //  "--disable-gpu",
                       // "--disable-infobars",
                       //"--disable-local-storage",
                       // "--no-zygote",
                       // "--disable-bundled-ppapi-flash"
                        },
                        IgnoreHTTPSErrors = true,
                    });
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                    //throw;
                }

                var page = await browser.NewPageAsync();

                await page.SetViewportAsync(new ViewPortOptions
                {
                    Width = Screen.PrimaryScreen.WorkingArea.Width,
                    Height = Screen.PrimaryScreen.WorkingArea.Height
                });
                this.Invoke(new MethodInvoker(() =>
                {
                    toolStripStatusLabel1.Text = "创建新的文件目录";
                }));

                var newdir = Path.Combine(dirBase, DateTime.Now.ToString("yyyy-MM-dd HHmmss"));
                if (button.Tag != null)
                {
                    newdir = Path.Combine(dirBase, DateTime.Now.ToString("yyyy-MM-dd"), button.Tag.ToString());//批量过来的指定目录 
                }
                Directory.CreateDirectory(newdir);

                //每次重新加载列表页面,获得最新内容
                await page.GoToAsync(tbx_order.Text);
                var html = await page.GetContentAsync();
                var orderList = GetOdrderList(html, new Uri(page.Url));
                orderList.OrderPase();
                if (cbx_list.Checked)
                {

                    this.Invoke(new MethodInvoker(() =>
                    {
                        toolStripProgressBar1.Value = 0;
                        toolStripProgressBar1.Maximum = taskMax;
                        toolStripStatusLabel1.Text = "正在生成列表截图";
                    }));
                    //列表

                    var listname = newdir + "/list.jpg";
                    using (var liststream = await page.ScreenshotStreamAsync(new ScreenshotOptions()
                    {
                        FullPage = true,
                        Type = ScreenshotType.Png
                    }))
                    {
                        //合并头
                        var listiamge = Image.FromStream(liststream);
                        this.MergeImage(Properties.Resources.list_head, listiamge, listname);
                    };
                }
                var domainUrl = orderList.OrderLink;
                //var topList = orderList.Orders.OrderBy(m => Guid.NewGuid()).Take(taskMax).ToList();
                var topList = new List<OrderModel>();
                if (taskMax > 2)
                {
                    topList.Add(orderList.Orders.First());
                    topList.Add(orderList.Orders.Last());
                    taskMax = taskMax - 2;
                }
                topList.AddRange(orderList.Orders.GetRange(1, orderList.Orders.Count - 1).OrderBy(m => Guid.NewGuid()).Take(taskMax).ToList());
                for (int i = 0; i < topList.Count; i++)
                {
                    try
                    {
                        this.Invoke(new MethodInvoker(() =>
                        {
                            toolStripStatusLabel1.Text = $"正在生成第{(i + 1)}个订单详情截图";
                            toolStripProgressBar1.PerformStep();
                        }));

                        OrderModel item = topList[i];
                        var navurl = new Uri(domainUrl + item.DetailLink);
                        await page.SetViewportAsync(new ViewPortOptions()
                        {
                            Width = Screen.PrimaryScreen.WorkingArea.Width,
                            Height = Screen.PrimaryScreen.WorkingArea.Height
                        });
                        await page.GoToAsync(navurl.ToString());
                        var detailname = newdir + $"/detail-{item.DetailNum}.jpg";
                        using (var detailstream = await page.ScreenshotStreamAsync(new ScreenshotOptions()
                        {
                            FullPage = true,
                            Type = ScreenshotType.Png
                        }))
                        {
                            var detailimage = Image.FromStream(detailstream);
                            //重写头
                            var detailheaderImage = this.ReWirteImage(Properties.Resources.detail_head, item.DetailNumLink);
                            //合并文件
                            MergeImage(detailheaderImage, detailimage, detailname);
                        }

                        if (cbx_invoice.Checked)
                        {
                            this.Invoke(new MethodInvoker(() =>
                            {
                                toolStripStatusLabel1.Text = $"正在生成第{(i + 1)}个订单发票截图";
                            }));

                            navurl = new Uri(domainUrl + item.InvoiceLink);
                            //图片大小
                            await page.SetViewportAsync(new ViewPortOptions()
                            {
                                Width = 1024,
                                Height = 768
                            });
                            await page.GoToAsync(navurl.ToString());
                            var invoicename = newdir + $"/invoice-{item.DetailNum}.png";
                            await page.ScreenshotAsync(invoicename, new ScreenshotOptions()
                            {
                                Type = ScreenshotType.Png,
                            });

                            //生成pdf
                            //var invoicename = newdir + $"/invoice-{item.DetailNum}.pdf";
                            //await page.PdfAsync(invoicename, new PdfOptions()
                            //{
                            //    Height = 600,// Screen.PrimaryScreen.WorkingArea.Height,
                            //    Width = 800// Screen.PrimaryScreen.WorkingArea.Width
                            //});
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    }

                }

                await browser.CloseAsync();


                this.Invoke(new MethodInvoker(() =>
                {
                    toolStripStatusLabel1.Tag = "0";
                    toolStripStatusLabel1.Text = $"全部生成完毕";
                    if (button.Tag == null)
                    {
                        if (MessageBox.Show("当前操作已经执行完成,是否打开文件夹", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                        {
                            try
                            {
                                Process.Start("explorer.exe", newdir);
                            }
                            catch (Exception)
                            {
                                MessageBox.Show("打开文件夹失败\r\n文件路径：" + newdir, "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                    }
                }));

            });


        }


        /// <summary>
        /// 合并图片
        /// </summary>
        /// <param name="image1"></param>
        /// <param name="image2"></param>
        private void MergeImage(Image image1, Image image2, string newfilename)
        {
            var image3 = ScreenBootomImage();

            int h = image1.Height + image2.Height + image3.Height;
            int w = image3.Width;//以当前屏幕比例制定图片宽度
            var bitmap = new Bitmap(w, h);
            using (Graphics gr = Graphics.FromImage(bitmap))
            {
                gr.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
                gr.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                gr.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;

                double ratio = (double)w / image1.Width;
                gr.DrawImage(image1, new Rectangle(0, 0, w, Convert.ToInt32(image1.Height * ratio)), new Rectangle(0, 0, image1.Width, image1.Height), GraphicsUnit.Pixel);//自动伸缩头图
                gr.DrawImage(image2, new Rectangle(0, Convert.ToInt32(image1.Height * ratio), image2.Width, image2.Height));
                gr.DrawImage(image3, new Rectangle(0, image1.Height + image2.Height, image3.Width, image3.Height));
            }
            bitmap.Save(newfilename, ImageFormat.Png);


        }

        /// <summary>
        /// 图片附加文字
        /// </summary>
        /// <param name="sourceImage">图片源</param>
        /// <param name="text">文字</param>
        private Image ReWirteImage(Image sourceImage, string text)
        {
            Bitmap bmptext = TextToBitmap(text, this.tbx_order.Font, Rectangle.Empty, this.tbx_order.ForeColor, this.tbx_order.BackColor);
            //合并文字到订单头
            // var newimage = Properties.Resources.detail_head;
            var newhead = Graphics.FromImage(sourceImage);
            newhead.DrawImage(bmptext, new Rectangle(180, 32, bmptext.Width, bmptext.Height));
            return sourceImage;
        }


        /// <summary>
        /// 文字转图片
        /// </summary>
        /// <param name="text"></param>
        /// <param name="font"></param>
        /// <param name="rect"></param>
        /// <param name="fontcolor"></param>
        /// <param name="backColor"></param>
        /// <returns></returns>
        private Bitmap TextToBitmap(string text, Font font, Rectangle rect, Color fontcolor, Color backColor)
        {
            Graphics g;
            Bitmap bmp;
            StringFormat format = new StringFormat(StringFormatFlags.NoClip);
            if (rect == Rectangle.Empty)
            {
                bmp = new Bitmap(1, 1);
                g = Graphics.FromImage(bmp);
                //计算绘制文字所需的区域大小（根据宽度计算长度），重新创建矩形区域绘图
                SizeF sizef = g.MeasureString(text, font, PointF.Empty, format);

                int width = (int)(sizef.Width + 1);
                int height = (int)(sizef.Height + 1);
                rect = new Rectangle(0, 0, width, height);
                bmp.Dispose();

                bmp = new Bitmap(width, height);
            }
            else
            {
                bmp = new Bitmap(rect.Width, rect.Height);
            }

            g = Graphics.FromImage(bmp);

            //使用ClearType字体功能
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            g.FillRectangle(new SolidBrush(backColor), rect);
            g.DrawString(text, font, Brushes.Black, rect, format);
            return bmp;
        }


        /// <summary>
        /// 获得当前屏幕底部的图片
        /// </summary>
        /// <returns></returns>
        private Image ScreenBootomImage()
        {
            // Graphics g1 = Graphics.FromHwnd(IntPtr.Zero);
            // float factor = g1.DpiX / 96;
            // Rectangle rc = new Rectangle(0, 0, (int)(Screen.PrimaryScreen.Bounds.Width * factor), (int)(Screen.PrimaryScreen.Bounds.Height - Screen.PrimaryScreen.WorkingArea.Height * factor));
            // var s = this.CreateGraphics().DpiX;
            Image baseImage = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height - Screen.PrimaryScreen.WorkingArea.Height);
            Graphics g = Graphics.FromImage(baseImage);
            g.CopyFromScreen(new Point(0, Screen.PrimaryScreen.WorkingArea.Height), new Point(0, 0), Screen.PrimaryScreen.Bounds.Size);
            g.Dispose();
            return baseImage;
        }

        /// <summary>
        /// 选择路径
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_path_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                tbx_path.Text = folderBrowserDialog1.SelectedPath;
                toolStripProgressBar1.Value = 0;
                toolStripProgressBar1.Maximum = 0;
                toolStripStatusLabel1.Text = "准备";
                tbx_order.Focus();
                btn_order.Enabled = Directory.Exists(folderBrowserDialog1.SelectedPath);
            }
        }

        // private OdrderList orderList;
        /// <summary>
        /// 设置任务订单数量
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_order_Click(object sender, EventArgs e)
        {

            if (!tbx_order.Text.StartsWith("http://") || tbx_order.Text.IndexOf(".") < 0)
            {
                MessageBox.Show("请输入正常可访问的订单列表地址", "提示");
                return;
            }
            toolStripProgressBar1.Value = tb_num.Value = 0;
            toolStripProgressBar1.Maximum = tb_num.Maximum = 0;

            var client = new RestSharp.RestClient();
            client.BaseUrl = new Uri(tbx_order.Text);
            var request = new RestSharp.RestRequest();
            var resp = client.Get(request);
            if (resp.IsSuccessful)
            {
                var orderList = GetOdrderList(resp.Content, client.BaseUrl);

                tb_num.Maximum = orderList.Orders.Count();
                tb_num.Enabled = true;
                lb_num.Text = $"{tb_num.Value}/{tb_num.Maximum}";
                toolStripStatusLabel1.Text = "获取订单数量完毕，最大可截图数量为：" + tb_num.Maximum;

            }
            else
            {
                toolStripStatusLabel1.Text = "获取订单数量异常，请检查是否生成";
            }
        }

        private OdrderList GetOdrderList(string html, Uri uri)
        {
            var orderList = new OdrderList();
            orderList.OrderLink = $"{uri.Scheme}://{uri.Host}";
            orderList.OrderHtml = html;
            orderList.OrderPase();

            return orderList;
        }

        private void tb_num_Scroll(object sender, EventArgs e)
        {
            lb_num.Text = $"{tb_num.Value}/{tb_num.Maximum}";
            toolStripProgressBar1.Maximum = tb_num.Value;
            btn_start.Enabled = tb_num.Value > 0;


        }

        private void Form1_Load(object sender, EventArgs e)
        {


            toolStripProgressBar1.Maximum = 100;
            toolStripProgressBar1.Value = 0;
            Task.Run(async () =>
            {
                var browserFetcher = new BrowserFetcher(new BrowserFetcherOptions()
                {
                    Host = "http://cdn.npm.taobao.org/dist"
                });

                try
                {
                    var cp = Process.GetProcessesByName("chrome");
                    if (cp.Length > 0)
                    {
                        foreach (var item in cp)
                        {
                            if (!item.HasExited && item.MainModule.FileName == browserFetcher.GetExecutablePath(BrowserFetcher.DefaultRevision))
                            {
                                item.Kill();
                            }
                        }
                    }
                }
                catch (Exception)
                {

                }
                browserFetcher.DownloadProgressChanged += Bf_DownloadProgressChanged;
                await browserFetcher.DownloadAsync(BrowserFetcher.DefaultRevision);

            });
        }

        private void Bf_DownloadProgressChanged(object sender, System.Net.DownloadProgressChangedEventArgs e)
        {
            try
            {

                this.Invoke(new MethodInvoker(() =>
                {
                    toolStripProgressBar1.Value = e.ProgressPercentage;
                    toolStripStatusLabel1.Text = $"初始化... {e.BytesReceived}/{e.TotalBytesToReceive}";
                    if (toolStripProgressBar1.Value == toolStripProgressBar1.Maximum)
                    {
                        toolStripStatusLabel1.Text = "准备";
                    }
                }));


            }
            catch (Exception ex)
            {

            }
        }

        private bool LoginState;
        private Uri LoginUri;
        private CookieContainer CookieContainer;

        private void btn_login_Click(object sender, EventArgs e)
        {


#if DEBUG
            tbx_adminurl.Text = "http://139.129.97.67/site/login";
            tbx_loginname.Text = "admin";
            tbx_userpass.Text = "amaz123456";
#endif
            var loginurl = tbx_adminurl.Text.Trim();
            var username = tbx_loginname.Text.Trim();
            var userpass = tbx_userpass.Text.Trim();

            if (!loginurl.StartsWith("http:"))
            {
                MessageBox.Show("请正确填写后台登录地址");
                return;
            }
            else if (string.IsNullOrEmpty(username))
            {
                MessageBox.Show("请正确填写后台登录账号");
                return;
            }
            else if (string.IsNullOrEmpty(userpass))
            {
                MessageBox.Show("请正确填写后台登录密码");
                return;
            }

            try
            {
                LoginUri = new Uri(loginurl);

                var client = new RestClient();
                client.CookieContainer = new CookieContainer();
                //     client.UseNewtonsoftJson();
                client.BaseUrl = LoginUri;
                var request = new RestRequest();
                //  request.Resource = "login";
                request.AddHeader("Accept", "application/json");
                //request.AddHeader("Content-Type", "application/x-www-form-urlencoded; charset=UTF-8");
                request.AddParameter("username", username);
                request.AddParameter("password", userpass);
                var resp = client.Post(request);
                if (!resp.IsSuccessful)
                {
                    MessageBox.Show("请求无效，登录失败", "提示");
                    return;
                }
                else if (resp.Content == "no")
                {
                    MessageBox.Show("登录失败，账号/密码 错误", "提示");
                    return;
                }

                tbx_order.Text = "http://" + LoginUri.Host;

                var login = Newtonsoft.Json.JsonConvert.DeserializeObject<LoginResult>(resp.Content);
                btn_build.Enabled = true;
                LoginState = true;
                CookieContainer = client.CookieContainer;
                MessageBox.Show("登录成功，进行批量生成操作之前，请先配置截图设置", "提示");
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "错误");
            }



        }


        public bool ChangeShop(string shopName, string address, string email, string tel)
        {

            var client = new RestClient();
            client.CookieContainer = CookieContainer;
            var request = new RestRequest();
            request.Resource = $"http://{LoginUri.Host}/shop/index";

            request.AddParameter("id", "1");
            request.AddParameter("shop_name", shopName);
            request.AddParameter("address", address);
            request.AddParameter("email", email);
            request.AddParameter("tel", tel);
            var resp = client.Post(request);
            return resp.IsSuccessful;

        }


        public bool ChangeOrder(string asin, string startTime, string endTime, string num, string sku = "")
        {

            this.Invoke(new MethodInvoker(() =>
            {
                toolStripStatusLabel1.Text += $" 获取商品详情";
            }));
            var shopinfo = GetShopInfo(asin);
            if (!shopinfo.state)
            {
                return false;
            }
            try
            {
                if (string.IsNullOrEmpty(sku))
                {
                    sku = shopinfo.data.sku + new Random().Next(10000, 99999);
                }

                var client = new RestClient();
                client.CookieContainer = CookieContainer;
                var request = new RestRequest();
                request.Resource = $"http://{LoginUri.Host}/order/create";

                request.AddParameter("start_date", startTime);
                request.AddParameter("end_date", endTime);
                request.AddParameter("order[sale_channel]", "Amazon.com");
                request.AddParameter("order[distribution_channel]", "Amazon");
                request.AddParameter("order[page_img]", shopinfo.data.imgfirst);
                request.AddParameter("order[info]", shopinfo.data.title);
                request.AddParameter("order[asin]", asin);
                request.AddParameter("order[sku]", sku);
                request.AddParameter("order[issuer]", shopinfo.data.sku);
                request.AddParameter("order[num]", "1");
                request.AddParameter("order[money]", shopinfo.data.price.Replace("$", ""));
                request.AddParameter("do_num", num);
                request.AddParameter("do_clear", "on");

                var resp = client.Post(request);
                if (resp.IsSuccessful)
                {
                    var result = JsonConvert.DeserializeObject<CreateResult>(resp.Content);
                    return result.code == 200;
                }
            }
            catch (Exception ex)
            {

                return false;
            }

            return false;
        }


        /// <summary>
        /// 获得商品详情
        /// </summary>
        /// <param name="asin"></param>
        /// <returns></returns>
        public Result<ShopModel> GetShopInfo(string asin)
        {
            var result = new Result<ShopModel>();
            var client = new RestClient();
            var request = new RestRequest();
            request.Resource = $"http://47.254.92.81/1.php?asin={asin}";

            var resp = client.Get(request);
            if (resp.IsSuccessful)
            {
                result = Newtonsoft.Json.JsonConvert.DeserializeObject<Result<ShopModel>>(resp.Content);
                result.data.price = result.data.price ?? "10";
                result.data.price = Regex.Match(result.data.price, "[\\d\\.]+$").Value;
            }

            return result;

        }

        private void btn_import_Click(object sender, EventArgs e)
        {

            var open = new OpenFileDialog();
            open.Filter = "97-2003 Excel(*.xls)|*.xls|Excel(*.xlsx)|*.xlsx";
            open.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            if (open.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;
                    using (var package = new ExcelPackage(new FileInfo(open.FileName)))
                    {
                        var ws = package.Workbook.Worksheets.FirstOrDefault();
                        if (ws != null)
                        {

                            int minColumnNum = ws.Dimension.Start.Column;//工作区开始列
                            int maxColumnNum = ws.Dimension.End.Column; //工作区结束列
                            int minRowNum = ws.Dimension.Start.Row; //工作区开始行号
                            int maxRowNum = ws.Dimension.End.Row; //工作区结束行号

                            for (int i = minRowNum + 1; i <= maxRowNum; i++)
                            {

                                ListViewItem lvi = null;

                                for (int j = minColumnNum; j <= maxColumnNum; j++)
                                {
                                    var obj = ws.GetValue(i, j);
                                    if (obj == null)
                                        break;
                                    if (lvi == null)
                                        lvi = new ListViewItem();

                                    var value = obj.ToString();
                                    if (j == 8 || j == 9)
                                    {
                                        value = ws.GetValue<DateTime>(i, j).ToString("yyyy-MM-dd");
                                    }

                                    lvi.Text = (listView1.Items.Count + 1).ToString();
                                    lvi.SubItems.Add(value);

                                }
                                if (i > 1 && lvi != null)
                                    listView1.Items.Add(lvi);
                            }
                            MessageBox.Show("导入成功,列表现有数量为：" + listView1.Items.Count, "提示");

                        }
                    }
                }
                catch (Exception ex)
                {

                    MessageBox.Show("打开导入模板文件错误，" + ex.Message, "错误");
                }
            }

        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
        }

        private void btn_build_Click(object sender, EventArgs e)
        {
            if (!LoginState || CookieContainer == null)
            {
                MessageBox.Show("请先登陆后台", "提示");
                return;
            }
            if (!Directory.Exists(tbx_path.Text))
            {
                MessageBox.Show("请设置截图保存路径", "提示");
                return;
            }
            if (tb_num.Value < 1)
            {
                MessageBox.Show("请设置截图生成数量", "提示");
                return;
            }


            var list = new List<BulidModel>();
            for (int i = 0; i < listView1.Items.Count; i++)
            {
                var bulidModel = new BulidModel()
                {
                    orderModel = new BuildOrderModel(),
                    shopModel = new BulidShopModel()
                };
                var item = listView1.Items[i];
                if (item.SubItems.Count > 10)
                {
                    bulidModel.shopModel.address = item.SubItems[3].Text;
                    bulidModel.shopModel.email = item.SubItems[4].Text;
                    bulidModel.shopModel.tel = item.SubItems[5].Text;
                    bulidModel.shopModel.shopname = item.SubItems[6].Text;

                    bulidModel.orderModel.trademarkNo = item.SubItems[1].Text;
                    bulidModel.orderModel.trademarkName = item.SubItems[2].Text;

                    bulidModel.orderModel.Asin = item.SubItems[7].Text;
                    bulidModel.orderModel.startTime = item.SubItems[8].Text;
                    bulidModel.orderModel.endTime = item.SubItems[9].Text;
                    bulidModel.orderModel.OrderNum = item.SubItems[10].Text;
                    bulidModel.orderModel.Sku = item.SubItems[11].Text;

                    list.Add(bulidModel);
                }
            }
            if (!list.Any())
            {
                MessageBox.Show("当前列表没有可生成的内容", "提示");
                return;
            }

            var successNum = 0;

            btn_build.Enabled = false;
            Task.Run(async () =>
            {
                for (int i = 0; i < list.Count; i++)
                {
                    while (toolStripStatusLabel1.Tag != null && toolStripStatusLabel1.Tag.Equals("1"))
                    {
                        await Task.Delay(2000);
                        continue;
                    }

                    var item = list[i];


                    this.Invoke(new MethodInvoker(() =>
                    {
                        toolStripStatusLabel1.Tag = "1";
                        toolStripStatusLabel1.Text = $"批量生成进度{i}/{list.Count}，设置店铺信息：{ item.shopModel.shopname}";
                    }));
                    var shopstatus = ChangeShop(item.shopModel.shopname, item.shopModel.address, item.shopModel.email, item.shopModel.tel);


                    this.Invoke(new MethodInvoker(() =>
                    {
                        toolStripStatusLabel1.Text = $"批量生成进度{i}/{list.Count}，设置订单信息：" + item.orderModel.Asin;
                    }));
                    var orderstat = ChangeOrder(item.orderModel.Asin, item.orderModel.startTime, item.orderModel.endTime, item.orderModel.OrderNum, item.orderModel.Sku);

                    if (shopstatus && orderstat)
                    {
                        successNum += 1;
                        this.Invoke(new MethodInvoker(() =>
                        {
                            listView1.Items[i].ForeColor = Color.Green;
                            btn_build.Tag = $"{item.orderModel.trademarkName}-{item.orderModel.trademarkNo}";
                            btn_start_ClickAsync(btn_build, null);
                        }));
                    }
                    else
                    {
                        this.Invoke(new MethodInvoker(() =>
                        {
                            listView1.Items[i].ForeColor = Color.Red;
                            toolStripStatusLabel1.Tag = "0";
                        }));
                    }
                }


                if (MessageBox.Show("批量生成结束，成功生成：" + successNum + "，是否打开文件夹", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    try
                    {
                        Process.Start("explorer.exe", Path.Combine(tbx_path.Text, DateTime.Now.ToString("yyyy-MM-dd")));
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("打开文件夹失败\r\n文件路径：" + tbx_path.Text, "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }

                this.Invoke(new MethodInvoker(() =>
                {
                    btn_build.Enabled = true;
                }));
            });


        }
    }
}
