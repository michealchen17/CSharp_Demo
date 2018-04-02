namespace WindowsFormsApplication1
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
            this.pnlNavigation = new System.Windows.Forms.Panel();
            this.btnExitSystem = new System.Windows.Forms.Button();
            this.btnShowServerSetting = new System.Windows.Forms.Button();
            this.btnShowLightSetting = new System.Windows.Forms.Button();
            this.btnShowMainPage = new System.Windows.Forms.Button();
            this.pnlMainDisplay = new System.Windows.Forms.Panel();
            this.pnlNavigation.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlNavigation
            // 
            this.pnlNavigation.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.pnlNavigation.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlNavigation.Controls.Add(this.btnExitSystem);
            this.pnlNavigation.Controls.Add(this.btnShowServerSetting);
            this.pnlNavigation.Controls.Add(this.btnShowLightSetting);
            this.pnlNavigation.Controls.Add(this.btnShowMainPage);
            this.pnlNavigation.Location = new System.Drawing.Point(1, 1);
            this.pnlNavigation.Name = "pnlNavigation";
            this.pnlNavigation.Size = new System.Drawing.Size(100, 461);
            this.pnlNavigation.TabIndex = 0;
            // 
            // btnExitSystem
            // 
            this.btnExitSystem.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnExitSystem.Location = new System.Drawing.Point(-1, 146);
            this.btnExitSystem.Name = "btnExitSystem";
            this.btnExitSystem.Size = new System.Drawing.Size(100, 50);
            this.btnExitSystem.TabIndex = 3;
            this.btnExitSystem.Text = "退出";
            this.btnExitSystem.UseVisualStyleBackColor = true;
            this.btnExitSystem.Click += new System.EventHandler(this.btnExitSystem_Click);
            // 
            // btnShowServerSetting
            // 
            this.btnShowServerSetting.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnShowServerSetting.Location = new System.Drawing.Point(-1, 97);
            this.btnShowServerSetting.Name = "btnShowServerSetting";
            this.btnShowServerSetting.Size = new System.Drawing.Size(100, 50);
            this.btnShowServerSetting.TabIndex = 2;
            this.btnShowServerSetting.Text = "服務";
            this.btnShowServerSetting.UseVisualStyleBackColor = true;
            this.btnShowServerSetting.Click += new System.EventHandler(this.btnShowServerSetting_Click);
            // 
            // btnShowLightSetting
            // 
            this.btnShowLightSetting.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnShowLightSetting.Location = new System.Drawing.Point(-1, 48);
            this.btnShowLightSetting.Name = "btnShowLightSetting";
            this.btnShowLightSetting.Size = new System.Drawing.Size(100, 50);
            this.btnShowLightSetting.TabIndex = 1;
            this.btnShowLightSetting.Text = "光源";
            this.btnShowLightSetting.UseVisualStyleBackColor = true;
            this.btnShowLightSetting.Click += new System.EventHandler(this.btnShowLightSetting_Click);
            // 
            // btnShowMainPage
            // 
            this.btnShowMainPage.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnShowMainPage.Location = new System.Drawing.Point(-1, -1);
            this.btnShowMainPage.Name = "btnShowMainPage";
            this.btnShowMainPage.Size = new System.Drawing.Size(100, 50);
            this.btnShowMainPage.TabIndex = 0;
            this.btnShowMainPage.Text = "首頁";
            this.btnShowMainPage.UseVisualStyleBackColor = true;
            // 
            // pnlMainDisplay
            // 
            this.pnlMainDisplay.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlMainDisplay.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlMainDisplay.Location = new System.Drawing.Point(108, 1);
            this.pnlMainDisplay.Name = "pnlMainDisplay";
            this.pnlMainDisplay.Size = new System.Drawing.Size(634, 461);
            this.pnlMainDisplay.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(745, 464);
            this.Controls.Add(this.pnlMainDisplay);
            this.Controls.Add(this.pnlNavigation);
            this.Name = "Form1";
            this.Text = "瑕疵檢測";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResizeBegin += new System.EventHandler(this.Form1_ResizeBegin);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.pnlNavigation.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlNavigation;
        private System.Windows.Forms.Button btnShowMainPage;
        private System.Windows.Forms.Button btnShowLightSetting;
        private System.Windows.Forms.Button btnShowServerSetting;
        private System.Windows.Forms.Button btnExitSystem;
        private System.Windows.Forms.Panel pnlMainDisplay;
    }
}

