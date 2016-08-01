namespace classExp
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
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btnProDir = new System.Windows.Forms.Button();
            this.txtProDir = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtClassDir = new System.Windows.Forms.TextBox();
            this.btnRelaseDir = new System.Windows.Forms.Button();
            this.txtReleaseDir = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtIgnore = new System.Windows.Forms.TextBox();
            this.btnRelase = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtList = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtFinalDir = new System.Windows.Forms.TextBox();
            this.btnOpenDir = new System.Windows.Forms.Button();
            this.txtResult = new System.Windows.Forms.TextBox();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // btnProDir
            // 
            this.btnProDir.Location = new System.Drawing.Point(21, 24);
            this.btnProDir.Name = "btnProDir";
            this.btnProDir.Size = new System.Drawing.Size(70, 25);
            this.btnProDir.TabIndex = 0;
            this.btnProDir.Text = "工程目录";
            this.btnProDir.UseVisualStyleBackColor = true;
            this.btnProDir.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtProDir
            // 
            this.txtProDir.Location = new System.Drawing.Point(97, 26);
            this.txtProDir.Name = "txtProDir";
            this.txtProDir.Size = new System.Drawing.Size(270, 21);
            this.txtProDir.TabIndex = 1;
            this.txtProDir.TextChanged += new System.EventHandler(this.txtProDir_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 24);
            this.label1.TabIndex = 2;
            this.label1.Text = "ide编译\r\nclass路径";
            // 
            // txtClassDir
            // 
            this.txtClassDir.Location = new System.Drawing.Point(97, 58);
            this.txtClassDir.Name = "txtClassDir";
            this.txtClassDir.Size = new System.Drawing.Size(270, 21);
            this.txtClassDir.TabIndex = 3;
            this.txtClassDir.Text = "WebRoot\\WEB-INF\\classes";
            // 
            // btnRelaseDir
            // 
            this.btnRelaseDir.Location = new System.Drawing.Point(21, 91);
            this.btnRelaseDir.Name = "btnRelaseDir";
            this.btnRelaseDir.Size = new System.Drawing.Size(69, 23);
            this.btnRelaseDir.TabIndex = 4;
            this.btnRelaseDir.Text = "发布目录";
            this.btnRelaseDir.UseVisualStyleBackColor = true;
            this.btnRelaseDir.Click += new System.EventHandler(this.btnRelaseDir_Click);
            // 
            // txtReleaseDir
            // 
            this.txtReleaseDir.Location = new System.Drawing.Point(96, 93);
            this.txtReleaseDir.Name = "txtReleaseDir";
            this.txtReleaseDir.Size = new System.Drawing.Size(271, 21);
            this.txtReleaseDir.TabIndex = 5;
            this.txtReleaseDir.Text = "C:\\Users\\admin\\Desktop\\release";
            this.txtReleaseDir.TextChanged += new System.EventHandler(this.txtReleaseDir_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(392, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(263, 12);
            this.label2.TabIndex = 6;
            this.label2.Text = "发布时忽略的路径(如\\main\\java),英文逗号分隔";
            this.label2.MouseHover += new System.EventHandler(this.label2_MouseHover);
            // 
            // txtIgnore
            // 
            this.txtIgnore.Location = new System.Drawing.Point(418, 60);
            this.txtIgnore.Name = "txtIgnore";
            this.txtIgnore.Size = new System.Drawing.Size(237, 21);
            this.txtIgnore.TabIndex = 7;
            this.txtIgnore.Text = "\\main\\java";
            // 
            // btnRelase
            // 
            this.btnRelase.Location = new System.Drawing.Point(414, 87);
            this.btnRelase.Name = "btnRelase";
            this.btnRelase.Size = new System.Drawing.Size(99, 26);
            this.btnRelase.TabIndex = 8;
            this.btnRelase.Text = "发布";
            this.btnRelase.UseVisualStyleBackColor = true;
            this.btnRelase.Click += new System.EventHandler(this.btnRelase_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(33, 132);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 12);
            this.label3.TabIndex = 9;
            this.label3.Text = "发布文件列表：";
            // 
            // txtList
            // 
            this.txtList.AllowDrop = true;
            this.txtList.Location = new System.Drawing.Point(40, 158);
            this.txtList.Multiline = true;
            this.txtList.Name = "txtList";
            this.txtList.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtList.Size = new System.Drawing.Size(614, 210);
            this.txtList.TabIndex = 10;
            this.txtList.TextChanged += new System.EventHandler(this.txtList_TextChanged);
            this.txtList.DragDrop += new System.Windows.Forms.DragEventHandler(this.txtFileList_DragDrop);
            this.txtList.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtList_KeyUp);
            this.txtList.DragEnter += new System.Windows.Forms.DragEventHandler(this.txtFileList_DragEnter);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(37, 390);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 11;
            this.label4.Text = "发布结果";
            // 
            // txtFinalDir
            // 
            this.txtFinalDir.Location = new System.Drawing.Point(285, 390);
            this.txtFinalDir.Name = "txtFinalDir";
            this.txtFinalDir.ReadOnly = true;
            this.txtFinalDir.Size = new System.Drawing.Size(261, 21);
            this.txtFinalDir.TabIndex = 12;
            // 
            // btnOpenDir
            // 
            this.btnOpenDir.Location = new System.Drawing.Point(568, 391);
            this.btnOpenDir.Name = "btnOpenDir";
            this.btnOpenDir.Size = new System.Drawing.Size(87, 21);
            this.btnOpenDir.TabIndex = 13;
            this.btnOpenDir.Text = "打开发布目录";
            this.btnOpenDir.UseVisualStyleBackColor = true;
            this.btnOpenDir.Click += new System.EventHandler(this.btnOpenDir_Click);
            // 
            // txtResult
            // 
            this.txtResult.Location = new System.Drawing.Point(45, 418);
            this.txtResult.Multiline = true;
            this.txtResult.Name = "txtResult";
            this.txtResult.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtResult.Size = new System.Drawing.Size(609, 130);
            this.txtResult.TabIndex = 14;
            this.txtResult.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtResult_KeyUp);
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(609, 9);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(29, 12);
            this.linkLabel1.TabIndex = 15;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "帮助";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(708, 572);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.txtResult);
            this.Controls.Add(this.btnOpenDir);
            this.Controls.Add(this.txtFinalDir);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtList);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnRelase);
            this.Controls.Add(this.txtIgnore);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtReleaseDir);
            this.Controls.Add(this.btnRelaseDir);
            this.Controls.Add(this.txtClassDir);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtProDir);
            this.Controls.Add(this.btnProDir);
            this.HelpButton = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Resize += new System.EventHandler(this.Form1_SizeChanged);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnProDir;
        private System.Windows.Forms.TextBox txtProDir;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtClassDir;
        private System.Windows.Forms.Button btnRelaseDir;
        private System.Windows.Forms.TextBox txtReleaseDir;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtIgnore;
        private System.Windows.Forms.Button btnRelase;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtList;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtFinalDir;
        private System.Windows.Forms.Button btnOpenDir;
        private System.Windows.Forms.TextBox txtResult;
        private System.Windows.Forms.LinkLabel linkLabel1;
    }
}

