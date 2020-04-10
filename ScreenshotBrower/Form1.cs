
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


namespace ScreenshotBrower
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            this.Text += " v" + this.ProductVersion.ToLower();
            lb_computerInfo.Text = $"{lb_computerInfo.Text}：{new ComputerInfo().OSFullName} {Screen.PrimaryScreen.Bounds.Width}x{Screen.PrimaryScreen.Bounds.Height}";

        }

        private void btn_start_ClickAsync(object sender, EventArgs e)
        {
            var dirBase = tbx_path.Text;
            var taskMax = tb_num.Value;
            Task.Run(async () =>
            {
                var browser = await Puppeteer.LaunchAsync(new LaunchOptions
                {
                    UserDataDir = $"{System.IO.Directory.GetCurrentDirectory()}/UserData",
                    Headless = true,
                    Args = new[] { "--no-sandbox", "--disable-setuid-sandbox", "--disable-infobars" }

                });


                var page = await browser.NewPageAsync();

                await page.SetViewportAsync(new ViewPortOptions
                {
                    Width = Screen.PrimaryScreen.WorkingArea.Width,
                    Height = Screen.PrimaryScreen.WorkingArea.Height
                });

                var newdir = Path.Combine(dirBase, DateTime.Now.ToString("yyyy-MM-dd HHmmss"));
                Directory.CreateDirectory(newdir);

                this.Invoke(new MethodInvoker(() =>
                {
                    toolStripStatusLabel1.Text = "正在生成列表截图";
                }));
                //列表
                await page.GoToAsync(orderList.OrderLink);
                var listname = newdir + "/list.png";
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


                for (int i = 0; i < orderList.Orders.OrderBy(m => Guid.NewGuid()).ToList().Count; i++)
                {
                    if (i >= taskMax)
                        break;

                    this.Invoke(new MethodInvoker(() =>
                    {
                        toolStripStatusLabel1.Text = $"正在生成第{(i + 1)}个订单详情截图";
                        toolStripProgressBar1.PerformStep();
                    }));

                    OrderModel item = orderList.Orders[i];
                    var navurl = new Uri(orderList.OrderLink + item.DetailLink);
                    await page.GoToAsync(navurl.ToString());
                    var detailname = newdir + $"/detail-{item.DetailNum}.png";
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
                    this.Invoke(new MethodInvoker(() =>
                    {
                        toolStripStatusLabel1.Text = $"正在生成第{(i + 1)}个订单发票截图";
                    }));

                    navurl = new Uri(orderList.OrderLink + item.InvoiceLink);
                    await page.GoToAsync(navurl.ToString());
                    var invoicename = newdir + $"/invoice-{item.DetailNum}.pdf";
                    await page.PdfAsync(invoicename, new PdfOptions()
                    {
                        Height = 600,// Screen.PrimaryScreen.WorkingArea.Height,
                        Width = 800// Screen.PrimaryScreen.WorkingArea.Width

                    }); ;

                }

                await browser.CloseAsync();
                this.Invoke(new MethodInvoker(() =>
                {
                    toolStripStatusLabel1.Text = $"全部生成完毕";
                    MessageBox.Show("当前操作已经执行完成", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            int h = image1.Height + image2.Height;
            int w = image1.Width;
            var bitmap = new Bitmap(w, h);
            Graphics gr = Graphics.FromImage(bitmap);
            gr.DrawImage(image1, new Rectangle(0, 0, image1.Width, image1.Height));
            gr.DrawImage(image2, new Rectangle(0, image1.Height, image2.Width, image2.Height));

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
            newhead.DrawImage(bmptext, new Rectangle(180, 30, bmptext.Width, bmptext.Height));
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

        private OdrderList orderList;
        /// <summary>
        /// 设置任务订单数量
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_order_Click(object sender, EventArgs e)
        {

            if (!tbx_order.Text.StartsWith("http"))
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
                orderList = new OdrderList();
                orderList.OrderLink = client.BaseUrl.ToString();
                orderList.OrderHtml = resp.Content;
                orderList.OrderPase();

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
    }
}
