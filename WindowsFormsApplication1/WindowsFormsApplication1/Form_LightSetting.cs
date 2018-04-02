using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using CSharp_OPTControllerAPI;
using XmlConfig;
namespace WindowsFormsApplication1
{
    
    public partial class Form_LightSetting : Form
    {
        //串口類實例
        private OPTControllerAPI optController = new OPTControllerAPI();

        /// <summary>
        /// 重新佈局控件
        /// </summary>
        private void ReLayoutControls()
        {
            this.Height = Parent.Height;
            this.Width = Parent.Width;
            gbxSerialPortSetting.Width = 100;
            gbxSerialPortSetting.Height = this.Height - 10;
            tbpIntensitySetting.Height = gbxSerialPortSetting.Height;
            tbpIntensitySetting.Width = this.Width - gbxSerialPortSetting.Width - 10;
        }
        /// <summary>
        /// 配置當前串口名
        /// </summary>
        private void SetCurrentSerialPort()
        {
            string[] serialNames = SerialPort.GetPortNames();
            if (serialNames == null)
            {
                btnConnectSerialPort.Enabled = false;
                MessageBox.Show("本機未檢測到串口！", "Error");
                return;
            }
            cbxSerialPort.Items.Clear();
            foreach (string sn in serialNames)
            {
                cbxSerialPort.Items.Add(sn);
            }
            //讀取配置文件中保存的串口名
            string lastSelectedPort = XmlConfig.XmlConfig.Read("serialport","port");
            if (lastSelectedPort == null)
            {
                cbxSerialPort.SelectedIndex = 0;
            }
            else
            {
                cbxSerialPort.SelectedText = lastSelectedPort;
            }
 
        }
        public Form_LightSetting()
        {
            InitializeComponent();
            //配置當前串口
            



        }

        private void Form_LightSetting_Load(object sender, EventArgs e)
        {
            //佈局控件
            ReLayoutControls();
            //獲取系統可用串口
            SetCurrentSerialPort();

        }

        private void Form_LightSetting_SizeChanged(object sender, EventArgs e)
        {
            ReLayoutControls();
        }

        private void btnConnectSerialPort_Click(object sender, EventArgs e)
        {
            switch (btnConnectSerialPort.Text)
            {
                case "連接":
                    {
                        XmlConfig.XmlConfig.Write(cbxSerialPort.SelectedItem.ToString(), "serialport","port");
                        int lRet = optController.InitSerialPort(cbxSerialPort.SelectedItem.ToString());
                        if (0 != lRet)
                        {
                            MessageBox.Show("串口初始化失敗！", "Error");
                            return;
                        }
                        cbxSerialPort.Enabled = false;
                        btnConnectSerialPort.Text = "斷開";
                        
                        break;
                    }
                case "斷開":
                    {
                        int lRet = optController.ReleaseSerialPort();
                        if (0 != lRet)
                        {
                            MessageBox.Show("釋放端口失敗！", "Error");
                            return;
                        }
                        btnConnectSerialPort.Text = "連接";
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
            
        }
    }
}
