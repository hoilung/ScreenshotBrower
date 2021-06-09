using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScreenshotBrower.Controls
{
    public partial class MatchCaptch : UserControl
    {
        public MatchCaptch()
        {
            InitializeComponent();            
        }

        public string InputStr { get; set; }
        public void LoadImage(string url)
        {
            this.pic_capth.Load(url);
        }

        private void btn_verify_Click(object sender, EventArgs e)
        {
            this.InputStr = tbx_inputCaptch.Text;
            if(string.IsNullOrEmpty(InputStr))
            {
                tbx_inputCaptch.Focus();
                return;
            }
            this.ParentForm.DialogResult = DialogResult.OK;
        }
    }
}
