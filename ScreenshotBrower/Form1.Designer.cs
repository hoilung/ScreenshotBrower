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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader10 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader11 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.btn_build = new System.Windows.Forms.Button();
            this.btn_clear = new System.Windows.Forms.Button();
            this.btn_import = new System.Windows.Forms.Button();
            this.btn_login = new System.Windows.Forms.Button();
            this.tbx_userpass = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tbx_loginname = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tbx_adminurl = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tb_num)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_start
            // 
            this.btn_start.Enabled = false;
            this.btn_start.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_start.Location = new System.Drawing.Point(490, 195);
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
            this.tbx_order.Location = new System.Drawing.Point(135, 101);
            this.tbx_order.Name = "tbx_order";
            this.tbx_order.Size = new System.Drawing.Size(350, 29);
            this.tbx_order.TabIndex = 3;
            this.tbx_order.Text = "http://";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(6, 105);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(122, 21);
            this.label1.TabIndex = 4;
            this.label1.Text = "订单列表地址：";
            // 
            // lb_computerInfo
            // 
            this.lb_computerInfo.AutoSize = true;
            this.lb_computerInfo.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lb_computerInfo.Location = new System.Drawing.Point(6, 17);
            this.lb_computerInfo.Name = "lb_computerInfo";
            this.lb_computerInfo.Size = new System.Drawing.Size(122, 21);
            this.lb_computerInfo.TabIndex = 5;
            this.lb_computerInfo.Text = "当前系统信息：";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripProgressBar1,
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 401);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(682, 22);
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
            this.tb_num.Location = new System.Drawing.Point(135, 152);
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
            this.label2.Location = new System.Drawing.Point(6, 152);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(122, 21);
            this.label2.TabIndex = 8;
            this.label2.Text = "最大截图数量：";
            // 
            // btn_order
            // 
            this.btn_order.Enabled = false;
            this.btn_order.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_order.Location = new System.Drawing.Point(490, 100);
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
            this.lb_num.Location = new System.Drawing.Point(490, 152);
            this.lb_num.Name = "lb_num";
            this.lb_num.Size = new System.Drawing.Size(19, 19);
            this.lb_num.TabIndex = 10;
            this.lb_num.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(6, 60);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(122, 21);
            this.label4.TabIndex = 11;
            this.label4.Text = "保存截图路径：";
            // 
            // tbx_path
            // 
            this.tbx_path.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbx_path.Location = new System.Drawing.Point(134, 59);
            this.tbx_path.Name = "tbx_path";
            this.tbx_path.ReadOnly = true;
            this.tbx_path.Size = new System.Drawing.Size(350, 26);
            this.tbx_path.TabIndex = 1;
            // 
            // btn_path
            // 
            this.btn_path.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_path.Location = new System.Drawing.Point(490, 55);
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
            this.label3.Location = new System.Drawing.Point(8, 290);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(440, 17);
            this.label3.TabIndex = 14;
            this.label3.Text = "提示：选择路径=》填写订单网址=》获取订单=》设置截图数量=》开始截图任务";
            // 
            // cbx_list
            // 
            this.cbx_list.AutoSize = true;
            this.cbx_list.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbx_list.Location = new System.Drawing.Point(135, 198);
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
            this.cbx_invoice.Location = new System.Drawing.Point(260, 198);
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
            this.label5.Location = new System.Drawing.Point(8, 200);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(122, 21);
            this.label5.TabIndex = 17;
            this.label5.Text = "截图生成选项：";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lb_computerInfo);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.btn_start);
            this.groupBox1.Controls.Add(this.cbx_invoice);
            this.groupBox1.Controls.Add(this.tbx_order);
            this.groupBox1.Controls.Add(this.cbx_list);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.tb_num);
            this.groupBox1.Controls.Add(this.btn_path);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.tbx_path);
            this.groupBox1.Controls.Add(this.btn_order);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.lb_num);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(668, 369);
            this.groupBox1.TabIndex = 18;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "生成选项";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(682, 401);
            this.tabControl1.TabIndex = 19;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(674, 375);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "截图设置";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBox3);
            this.tabPage2.Controls.Add(this.groupBox2);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(674, 375);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "网站设置";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.listView1);
            this.groupBox3.Location = new System.Drawing.Point(6, 129);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(662, 240);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "生成信息";
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7,
            this.columnHeader8,
            this.columnHeader9,
            this.columnHeader10,
            this.columnHeader11});
            this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView1.FullRowSelect = true;
            this.listView1.GridLines = true;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(3, 17);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(656, 220);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "#";
            this.columnHeader1.Width = 40;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "商标号";
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "商标名";
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "地址";
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "邮箱";
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "电话";
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "店铺名";
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "Asin";
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "开始时间";
            // 
            // columnHeader10
            // 
            this.columnHeader10.Text = "结束时间";
            // 
            // columnHeader11
            // 
            this.columnHeader11.Text = "订单数";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.btn_build);
            this.groupBox2.Controls.Add(this.btn_clear);
            this.groupBox2.Controls.Add(this.btn_import);
            this.groupBox2.Controls.Add(this.btn_login);
            this.groupBox2.Controls.Add(this.tbx_userpass);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.tbx_loginname);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.tbx_adminurl);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Location = new System.Drawing.Point(6, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(659, 117);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "后台设置";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.Color.Red;
            this.label9.Location = new System.Drawing.Point(324, 26);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(329, 12);
            this.label9.TabIndex = 10;
            this.label9.Text = "注意：操作当前功能，需要提前配置好【截图设置】中的选项";
            // 
            // btn_build
            // 
            this.btn_build.Enabled = false;
            this.btn_build.Location = new System.Drawing.Point(568, 75);
            this.btn_build.Name = "btn_build";
            this.btn_build.Size = new System.Drawing.Size(75, 23);
            this.btn_build.TabIndex = 9;
            this.btn_build.Text = "批量生成";
            this.btn_build.UseVisualStyleBackColor = true;
            this.btn_build.Click += new System.EventHandler(this.btn_build_Click);
            // 
            // btn_clear
            // 
            this.btn_clear.Location = new System.Drawing.Point(487, 75);
            this.btn_clear.Name = "btn_clear";
            this.btn_clear.Size = new System.Drawing.Size(75, 23);
            this.btn_clear.TabIndex = 8;
            this.btn_clear.Text = "清空";
            this.btn_clear.UseVisualStyleBackColor = true;
            this.btn_clear.Click += new System.EventHandler(this.btn_clear_Click);
            // 
            // btn_import
            // 
            this.btn_import.Location = new System.Drawing.Point(406, 75);
            this.btn_import.Name = "btn_import";
            this.btn_import.Size = new System.Drawing.Size(75, 23);
            this.btn_import.TabIndex = 7;
            this.btn_import.Text = "导入";
            this.btn_import.UseVisualStyleBackColor = true;
            this.btn_import.Click += new System.EventHandler(this.btn_import_Click);
            // 
            // btn_login
            // 
            this.btn_login.Cursor = System.Windows.Forms.Cursors.Default;
            this.btn_login.Location = new System.Drawing.Point(325, 75);
            this.btn_login.Name = "btn_login";
            this.btn_login.Size = new System.Drawing.Size(75, 23);
            this.btn_login.TabIndex = 6;
            this.btn_login.Text = "登 录";
            this.btn_login.UseVisualStyleBackColor = true;
            this.btn_login.Click += new System.EventHandler(this.btn_login_Click);
            // 
            // tbx_userpass
            // 
            this.tbx_userpass.Location = new System.Drawing.Point(78, 77);
            this.tbx_userpass.Name = "tbx_userpass";
            this.tbx_userpass.PasswordChar = '*';
            this.tbx_userpass.Size = new System.Drawing.Size(227, 21);
            this.tbx_userpass.TabIndex = 5;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 80);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 12);
            this.label8.TabIndex = 4;
            this.label8.Text = "管理密码：";
            // 
            // tbx_loginname
            // 
            this.tbx_loginname.Location = new System.Drawing.Point(78, 50);
            this.tbx_loginname.Name = "tbx_loginname";
            this.tbx_loginname.Size = new System.Drawing.Size(227, 21);
            this.tbx_loginname.TabIndex = 3;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 53);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 12);
            this.label7.TabIndex = 2;
            this.label7.Text = "管理账号：";
            // 
            // tbx_adminurl
            // 
            this.tbx_adminurl.Location = new System.Drawing.Point(78, 23);
            this.tbx_adminurl.Name = "tbx_adminurl";
            this.tbx_adminurl.Size = new System.Drawing.Size(227, 21);
            this.tbx_adminurl.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 26);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 12);
            this.label6.TabIndex = 0;
            this.label6.Text = "后台地址：";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(682, 423);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.statusStrip1);
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
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
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
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox tbx_adminurl;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbx_userpass;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tbx_loginname;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btn_login;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btn_import;
        private System.Windows.Forms.Button btn_clear;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Button btn_build;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.ColumnHeader columnHeader10;
        private System.Windows.Forms.ColumnHeader columnHeader11;
        private System.Windows.Forms.Label label9;
    }
}

