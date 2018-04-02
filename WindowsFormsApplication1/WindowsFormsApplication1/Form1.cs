using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        //瑕疵標註主窗口
        public Form_MainPage formMainPage = new Form_MainPage();
        //光源配置窗口
        public Form_LightSetting formLightSetting = new Form_LightSetting();
        //Emotion通訊配置窗口
        public Form_ServerSetting formServerSetting = new Form_ServerSetting();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadFormToMainDisplayPanel(formMainPage);            
        }
        /// <summary>
        /// 加載子窗口到主顯示面板
        /// </summary>
        /// <param name="childForm"></param>
        private void LoadFormToMainDisplayPanel(Form childForm)
        {
            childForm.TopLevel = false;
            pnlMainDisplay.Controls.Clear();
            pnlMainDisplay.Controls.Add(childForm);
            childForm.Show();
        }
        private void btnExitSystem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnShowServerSetting_Click(object sender, EventArgs e)
        {
            LoadFormToMainDisplayPanel(formServerSetting);

        }

        private void btnShowLightSetting_Click(object sender, EventArgs e)
        {
            LoadFormToMainDisplayPanel(formLightSetting);
        }

        private void Form1_ResizeBegin(object sender, EventArgs e)
        {

        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            foreach (Control ctr in pnlMainDisplay.Controls)
            {
                ctr.Width = pnlMainDisplay.Width;
                ctr.Height = pnlMainDisplay.Height;
                ctr.Invalidate();
            }
        }
    }
}
