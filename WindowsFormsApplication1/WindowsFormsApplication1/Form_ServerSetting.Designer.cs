namespace WindowsFormsApplication1
{
    partial class Form_ServerSetting
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnStartService = new System.Windows.Forms.Button();
            this.txbTcpPort = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lbxTcpClients = new System.Windows.Forms.ListBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lbxTcpClients);
            this.panel1.Controls.Add(this.btnStartService);
            this.panel1.Controls.Add(this.txbTcpPort);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(-1, -1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(160, 461);
            this.panel1.TabIndex = 0;
            // 
            // btnStartService
            // 
            this.btnStartService.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnStartService.Location = new System.Drawing.Point(15, 47);
            this.btnStartService.Name = "btnStartService";
            this.btnStartService.Size = new System.Drawing.Size(128, 24);
            this.btnStartService.TabIndex = 2;
            this.btnStartService.Text = "啟動服務";
            this.btnStartService.UseVisualStyleBackColor = true;
            this.btnStartService.Click += new System.EventHandler(this.btnStartService_Click);
            // 
            // txbTcpPort
            // 
            this.txbTcpPort.Location = new System.Drawing.Point(53, 13);
            this.txbTcpPort.Name = "txbTcpPort";
            this.txbTcpPort.Size = new System.Drawing.Size(90, 22);
            this.txbTcpPort.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "端口";
            // 
            // lbxTcpClients
            // 
            this.lbxTcpClients.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbxTcpClients.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lbxTcpClients.FormattingEnabled = true;
            this.lbxTcpClients.ItemHeight = 12;
            this.lbxTcpClients.Location = new System.Drawing.Point(0, 84);
            this.lbxTcpClients.Name = "lbxTcpClients";
            this.lbxTcpClients.Size = new System.Drawing.Size(160, 372);
            this.lbxTcpClients.TabIndex = 1;
            // 
            // Form_ServerSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(665, 459);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form_ServerSetting";
            this.Text = "Form_ServerSetting";
            this.Load += new System.EventHandler(this.Form_ServerSetting_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txbTcpPort;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnStartService;
        private System.Windows.Forms.ListBox lbxTcpClients;
    }
}