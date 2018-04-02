using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using XmlConfig;
using MyTcpServer;
namespace WindowsFormsApplication1
{
    public partial class Form_ServerSetting : Form
    {
        public EmotionServer myTcpServer = new EmotionServer();

        /// <summary>
        /// 重新佈局窗口控件
        /// </summary>
        private void ReLayoutControls()
        {
            this.Height = Parent.Height;
            this.Width = Parent.Width;
            
        }
        public Form_ServerSetting()
        {
            InitializeComponent();
        }

        private void Form_ServerSetting_Load(object sender, EventArgs e)
        {
            ReLayoutControls();
            //初始化端口
            //查找配置文件
            string port = XmlConfig.XmlConfig.Read("tcp", "port");
            if(port == null)
            {
                port = "2020";
            }
            txbTcpPort.Text = port;
        }

        private void btnStartService_Click(object sender, EventArgs e)
        {
            //保存端口配置
            switch (btnStartService.Text)
            {
                case "啟動服務":
                    {
                        XmlConfig.XmlConfig.Write(txbTcpPort.Text, "tcp", "port");
                        myTcpServer.OpenServer("127.0.0.1",  Convert.ToInt32(txbTcpPort.Text));
                        btnStartService.Text = "停止服務";
                        break;
                    }
                case "停止服務":
                    {
                        myTcpServer.CloseServer();
                        btnStartService.Text = "啟動服務";
                        break;
                    }
                default: break;
            }

                        
        }
    }
}
