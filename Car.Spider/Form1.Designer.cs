namespace Car.Spider
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
            this.components = new System.ComponentModel.Container();
            this.btnStart = new System.Windows.Forms.Button();
            this.Literal1 = new System.Windows.Forms.Label();
            this.TextBox1 = new System.Windows.Forms.TextBox();
            this.TextBox2 = new System.Windows.Forms.TextBox();
            this.TextBox3 = new System.Windows.Forms.TextBox();
            this.btnGet = new System.Windows.Forms.Button();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(682, 401);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(141, 47);
            this.btnStart.TabIndex = 0;
            this.btnStart.Text = "开始";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // Literal1
            // 
            this.Literal1.AutoSize = true;
            this.Literal1.Location = new System.Drawing.Point(58, 377);
            this.Literal1.Name = "Literal1";
            this.Literal1.Size = new System.Drawing.Size(41, 12);
            this.Literal1.TabIndex = 1;
            this.Literal1.Text = "label1";
            // 
            // TextBox1
            // 
            this.TextBox1.Location = new System.Drawing.Point(60, 12);
            this.TextBox1.Multiline = true;
            this.TextBox1.Name = "TextBox1";
            this.TextBox1.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.TextBox1.Size = new System.Drawing.Size(429, 28);
            this.TextBox1.TabIndex = 2;
            // 
            // TextBox2
            // 
            this.TextBox2.Location = new System.Drawing.Point(60, 46);
            this.TextBox2.Multiline = true;
            this.TextBox2.Name = "TextBox2";
            this.TextBox2.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.TextBox2.Size = new System.Drawing.Size(429, 112);
            this.TextBox2.TabIndex = 3;
            // 
            // TextBox3
            // 
            this.TextBox3.Location = new System.Drawing.Point(60, 174);
            this.TextBox3.Multiline = true;
            this.TextBox3.Name = "TextBox3";
            this.TextBox3.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.TextBox3.Size = new System.Drawing.Size(429, 183);
            this.TextBox3.TabIndex = 4;
            // 
            // btnGet
            // 
            this.btnGet.Location = new System.Drawing.Point(885, 401);
            this.btnGet.Name = "btnGet";
            this.btnGet.Size = new System.Drawing.Size(141, 47);
            this.btnGet.TabIndex = 0;
            this.btnGet.Text = "提取";
            this.btnGet.UseVisualStyleBackColor = true;
            this.btnGet.Click += new System.EventHandler(this.btnGet_Click);
            // 
            // webBrowser1
            // 
            this.webBrowser1.Location = new System.Drawing.Point(515, 12);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(662, 345);
            this.webBrowser1.TabIndex = 5;
            // 
            // timer1
            // 
            this.timer1.Interval = 5000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1201, 473);
            this.Controls.Add(this.webBrowser1);
            this.Controls.Add(this.TextBox3);
            this.Controls.Add(this.TextBox2);
            this.Controls.Add(this.TextBox1);
            this.Controls.Add(this.Literal1);
            this.Controls.Add(this.btnGet);
            this.Controls.Add(this.btnStart);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Label Literal1;
        private System.Windows.Forms.TextBox TextBox2;
        private System.Windows.Forms.TextBox TextBox1;
        private System.Windows.Forms.TextBox TextBox3;
        private System.Windows.Forms.Button btnGet;
        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.Timer timer1;
    }
}

