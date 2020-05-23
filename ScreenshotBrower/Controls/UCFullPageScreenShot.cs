using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScreenshotBrower.Controls
{
    public partial class UCFullPageScreenShot : UserControl
    {
        public UCFullPageScreenShot()
        {
            InitializeComponent();
            tbx_text.Text = DateTime.Now.ToString("yyyy/MM/dd");

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




        }


    }
}
