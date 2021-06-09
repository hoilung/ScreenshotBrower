
namespace ScreenshotBrower.Controls
{
    partial class MatchCaptch
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.pic_capth = new System.Windows.Forms.PictureBox();
            this.btn_verify = new System.Windows.Forms.Button();
            this.tbx_inputCaptch = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pic_capth)).BeginInit();
            this.SuspendLayout();
            // 
            // pic_capth
            // 
            this.pic_capth.Location = new System.Drawing.Point(172, 31);
            this.pic_capth.Name = "pic_capth";
            this.pic_capth.Size = new System.Drawing.Size(200, 70);
            this.pic_capth.TabIndex = 0;
            this.pic_capth.TabStop = false;
            // 
            // btn_verify
            // 
            this.btn_verify.Location = new System.Drawing.Point(297, 187);
            this.btn_verify.Name = "btn_verify";
            this.btn_verify.Size = new System.Drawing.Size(75, 23);
            this.btn_verify.TabIndex = 1;
            this.btn_verify.Text = "提交验证";
            this.btn_verify.UseVisualStyleBackColor = true;
            this.btn_verify.Click += new System.EventHandler(this.btn_verify_Click);
            // 
            // tbx_inputCaptch
            // 
            this.tbx_inputCaptch.Location = new System.Drawing.Point(172, 139);
            this.tbx_inputCaptch.Name = "tbx_inputCaptch";
            this.tbx_inputCaptch.Size = new System.Drawing.Size(200, 21);
            this.tbx_inputCaptch.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(170, 124);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(149, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "请正确输入图片上的验证码";
            // 
            // MatchCaptch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbx_inputCaptch);
            this.Controls.Add(this.btn_verify);
            this.Controls.Add(this.pic_capth);
            this.Name = "MatchCaptch";
            this.Size = new System.Drawing.Size(430, 239);
            ((System.ComponentModel.ISupportInitialize)(this.pic_capth)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pic_capth;
        private System.Windows.Forms.Button btn_verify;
        private System.Windows.Forms.TextBox tbx_inputCaptch;
        private System.Windows.Forms.Label label1;
    }
}
