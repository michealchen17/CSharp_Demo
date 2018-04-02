using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MyTcp;
namespace WindowsFormsApplication2
{

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public void OnTest1(string str)
        {
//          str = "delegate event test!\n";
            textBox1.Text += str+" 1\n";
        }
        public void OnTest2(string str)
        {
            //          str = "delegate event test!\n";
            textBox1.Text += str+ " 2\n";
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Class1 class1 = new Class1();
            class1.OnTest += new Class1.delegTest(this.OnTest1);
            class1.OnTest += new Class1.delegTest(this.OnTest2);
            class1.TestEvent("delegate event test!\n");
        }

        private void btnGetHostIP_Click(object sender, EventArgs e)
        {
            List<string> IPList = TcpServer.GetHostIPs();
        }
    }
}
