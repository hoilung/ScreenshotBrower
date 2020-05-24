namespace ScreenshotBrower.Controls
{
    partial class UCFullPageScreenShot
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
            this.tbx_urls = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cbx_city = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_start = new System.Windows.Forms.Button();
            this.cbx_text = new System.Windows.Forms.CheckBox();
            this.tbx_text = new System.Windows.Forms.TextBox();
            this.btn_path = new System.Windows.Forms.Button();
            this.tbx_path = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbx_urls
            // 
            this.tbx_urls.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbx_urls.Location = new System.Drawing.Point(3, 17);
            this.tbx_urls.Multiline = true;
            this.tbx_urls.Name = "tbx_urls";
            this.tbx_urls.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbx_urls.Size = new System.Drawing.Size(623, 159);
            this.tbx_urls.TabIndex = 0;
            this.tbx_urls.WordWrap = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cbx_city);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.btn_start);
            this.groupBox2.Controls.Add(this.cbx_text);
            this.groupBox2.Controls.Add(this.tbx_text);
            this.groupBox2.Controls.Add(this.btn_path);
            this.groupBox2.Controls.Add(this.tbx_path);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(3, 188);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(629, 156);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "操作选项";
            // 
            // cbx_city
            // 
            this.cbx_city.AutoSize = true;
            this.cbx_city.Checked = true;
            this.cbx_city.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbx_city.Location = new System.Drawing.Point(483, 30);
            this.cbx_city.Name = "cbx_city";
            this.cbx_city.Size = new System.Drawing.Size(72, 16);
            this.cbx_city.TabIndex = 9;
            this.cbx_city.Text = "切换地区";
            this.cbx_city.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(14, 99);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(581, 36);
            this.label2.TabIndex = 8;
            this.label2.Text = "操作提示：\r\n\r\n网址列表，每行一个必须http或https开头的网页地址，为避免冲突（订单截图/全网页截图）请勿同时操作。";
            // 
            // btn_start
            // 
            this.btn_start.Location = new System.Drawing.Point(486, 64);
            this.btn_start.Name = "btn_start";
            this.btn_start.Size = new System.Drawing.Size(75, 23);
            this.btn_start.TabIndex = 7;
            this.btn_start.Text = "开始";
            this.btn_start.UseVisualStyleBackColor = true;
            this.btn_start.Click += new System.EventHandler(this.btn_start_Click);
            // 
            // cbx_text
            // 
            this.cbx_text.AutoSize = true;
            this.cbx_text.Checked = true;
            this.cbx_text.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbx_text.Location = new System.Drawing.Point(405, 30);
            this.cbx_text.Name = "cbx_text";
            this.cbx_text.Size = new System.Drawing.Size(72, 16);
            this.cbx_text.TabIndex = 6;
            this.cbx_text.Text = "添加内容";
            this.cbx_text.UseVisualStyleBackColor = true;
            // 
            // tbx_text
            // 
            this.tbx_text.Location = new System.Drawing.Point(85, 28);
            this.tbx_text.Name = "tbx_text";
            this.tbx_text.Size = new System.Drawing.Size(307, 21);
            this.tbx_text.TabIndex = 5;
            // 
            // btn_path
            // 
            this.btn_path.Location = new System.Drawing.Point(405, 64);
            this.btn_path.Name = "btn_path";
            this.btn_path.Size = new System.Drawing.Size(75, 23);
            this.btn_path.TabIndex = 4;
            this.btn_path.Text = "选择路径";
            this.btn_path.UseVisualStyleBackColor = true;
            this.btn_path.Click += new System.EventHandler(this.btn_path_Click);
            // 
            // tbx_path
            // 
            this.tbx_path.Location = new System.Drawing.Point(85, 65);
            this.tbx_path.Name = "tbx_path";
            this.tbx_path.ReadOnly = true;
            this.tbx_path.Size = new System.Drawing.Size(307, 21);
            this.tbx_path.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 31);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "文本内容：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "保存路径：";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tbx_urls);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(629, 179);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "网址列表";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.groupBox2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 13);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 51.78571F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 48.21429F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(670, 358);
            this.tableLayoutPanel1.TabIndex = 4;
            // 
            // UCFullPageScreenShot
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "UCFullPageScreenShot";
            this.Size = new System.Drawing.Size(695, 394);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TextBox tbx_urls;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_path;
        private System.Windows.Forms.TextBox tbx_path;
        private System.Windows.Forms.TextBox tbx_text;
        private System.Windows.Forms.CheckBox cbx_text;
        private System.Windows.Forms.Button btn_start;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox cbx_city;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}
