namespace ScreenshotBrower
{
    partial class Form1
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

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btn_start = new System.Windows.Forms.Button();
            this.tbx_order = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lb_computerInfo = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tb_num = new System.Windows.Forms.TrackBar();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_order = new System.Windows.Forms.Button();
            this.lb_num = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tbx_path = new System.Windows.Forms.TextBox();
            this.btn_path = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.label3 = new System.Windows.Forms.Label();
            this.cbx_list = new System.Windows.Forms.CheckBox();
            this.cbx_invoice = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tb_num)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_start
            // 
            this.btn_start.Enabled = false;
            this.btn_start.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_start.Location = new System.Drawing.Point(497, 200);
            this.btn_start.Name = "btn_start";
            this.btn_start.Size = new System.Drawing.Size(95, 29);
            this.btn_start.TabIndex = 6;
            this.btn_start.Text = "开始截图";
            this.btn_start.UseVisualStyleBackColor = true;
            this.btn_start.Click += new System.EventHandler(this.btn_start_ClickAsync);
            // 
            // tbx_order
            // 
            this.tbx_order.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(178)))), ((int)(((byte)(224)))), ((int)(((byte)(247)))));
            this.tbx_order.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbx_order.Location = new System.Drawing.Point(141, 105);
            this.tbx_order.Name = "tbx_order";
            this.tbx_order.Size = new System.Drawing.Size(350, 29);
            this.tbx_order.TabIndex = 3;
            this.tbx_order.Text = "http://";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(12, 109);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 21);
            this.label1.TabIndex = 4;
            this.label1.Text = "订单列表地址";
            // 
            // lb_computerInfo
            // 
            this.lb_computerInfo.AutoSize = true;
            this.lb_computerInfo.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lb_computerInfo.Location = new System.Drawing.Point(12, 21);
            this.lb_computerInfo.Name = "lb_computerInfo";
            this.lb_computerInfo.Size = new System.Drawing.Size(106, 21);
            this.lb_computerInfo.TabIndex = 5;
            this.lb_computerInfo.Text = "当前系统信息";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripProgressBar1,
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 334);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(647, 22);
            this.statusStrip1.TabIndex = 6;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripProgressBar1
            // 
            this.toolStripProgressBar1.Maximum = 0;
            this.toolStripProgressBar1.Name = "toolStripProgressBar1";
            this.toolStripProgressBar1.Size = new System.Drawing.Size(100, 16);
            this.toolStripProgressBar1.Step = 1;
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(32, 17);
            this.toolStripStatusLabel1.Text = "准备";
            // 
            // tb_num
            // 
            this.tb_num.Enabled = false;
            this.tb_num.LargeChange = 3;
            this.tb_num.Location = new System.Drawing.Point(141, 156);
            this.tb_num.Maximum = 0;
            this.tb_num.Name = "tb_num";
            this.tb_num.Size = new System.Drawing.Size(350, 45);
            this.tb_num.TabIndex = 5;
            this.tb_num.Scroll += new System.EventHandler(this.tb_num_Scroll);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(12, 156);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 21);
            this.label2.TabIndex = 8;
            this.label2.Text = "最大截图数量";
            // 
            // btn_order
            // 
            this.btn_order.Enabled = false;
            this.btn_order.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_order.Location = new System.Drawing.Point(497, 105);
            this.btn_order.Name = "btn_order";
            this.btn_order.Size = new System.Drawing.Size(95, 29);
            this.btn_order.TabIndex = 4;
            this.btn_order.Text = "获取订单";
            this.btn_order.UseVisualStyleBackColor = true;
            this.btn_order.Click += new System.EventHandler(this.btn_order_Click);
            // 
            // lb_num
            // 
            this.lb_num.AutoSize = true;
            this.lb_num.Font = new System.Drawing.Font("宋体", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lb_num.Location = new System.Drawing.Point(497, 157);
            this.lb_num.Name = "lb_num";
            this.lb_num.Size = new System.Drawing.Size(19, 19);
            this.lb_num.TabIndex = 10;
            this.lb_num.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(12, 64);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(106, 21);
            this.label4.TabIndex = 11;
            this.label4.Text = "保存截图路径";
            // 
            // tbx_path
            // 
            this.tbx_path.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbx_path.Location = new System.Drawing.Point(141, 61);
            this.tbx_path.Name = "tbx_path";
            this.tbx_path.ReadOnly = true;
            this.tbx_path.Size = new System.Drawing.Size(350, 26);
            this.tbx_path.TabIndex = 1;
            // 
            // btn_path
            // 
            this.btn_path.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_path.Location = new System.Drawing.Point(497, 60);
            this.btn_path.Name = "btn_path";
            this.btn_path.Size = new System.Drawing.Size(95, 29);
            this.btn_path.TabIndex = 2;
            this.btn_path.Text = "选择路径";
            this.btn_path.UseVisualStyleBackColor = true;
            this.btn_path.Click += new System.EventHandler(this.btn_path_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(14, 294);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(440, 17);
            this.label3.TabIndex = 14;
            this.label3.Text = "提示：选择路径=》填写订单网址=》获取订单=》设置截图数量=》开始截图任务";
            // 
            // cbx_list
            // 
            this.cbx_list.AutoSize = true;
            this.cbx_list.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbx_list.Location = new System.Drawing.Point(141, 202);
            this.cbx_list.Name = "cbx_list";
            this.cbx_list.Size = new System.Drawing.Size(93, 25);
            this.cbx_list.TabIndex = 15;
            this.cbx_list.Text = "订单列表";
            this.cbx_list.UseVisualStyleBackColor = true;
            // 
            // cbx_invoice
            // 
            this.cbx_invoice.AutoSize = true;
            this.cbx_invoice.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbx_invoice.Location = new System.Drawing.Point(266, 202);
            this.cbx_invoice.Name = "cbx_invoice";
            this.cbx_invoice.Size = new System.Drawing.Size(61, 25);
            this.cbx_invoice.TabIndex = 16;
            this.cbx_invoice.Text = "发票";
            this.cbx_invoice.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(14, 204);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(106, 21);
            this.label5.TabIndex = 17;
            this.label5.Text = "截图生成选项";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(647, 356);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cbx_invoice);
            this.Controls.Add(this.cbx_list);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btn_path);
            this.Controls.Add(this.tbx_path);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lb_num);
            this.Controls.Add(this.btn_order);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tb_num);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.lb_computerInfo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbx_order);
            this.Controls.Add(this.btn_start);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "订单自动截图";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tb_num)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_start;
        private System.Windows.Forms.TextBox tbx_order;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lb_computerInfo;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.TrackBar tb_num;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_order;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
        private System.Windows.Forms.Label lb_num;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbx_path;
        private System.Windows.Forms.Button btn_path;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox cbx_list;
        private System.Windows.Forms.CheckBox cbx_invoice;
        private System.Windows.Forms.Label label5;
    }
}

