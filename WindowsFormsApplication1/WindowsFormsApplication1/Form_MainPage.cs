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
    public partial class Form_MainPage : Form
    {
        public Form_MainPage()
        {
            InitializeComponent();
        }

        private void Form_MainPage_Load(object sender, EventArgs e)
        {
            //使窗口與父窗口的尺寸保持一致
            this.Width = Parent.Width;
            this.Height = Parent.Height;
        }


    }
}
