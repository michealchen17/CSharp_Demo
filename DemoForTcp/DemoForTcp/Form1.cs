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
using System.Net.Sockets;

namespace DemoForTcp
{
    public partial class Form1 : Form
    {
        TcpServer server = new TcpServer();
        public Form1()
        {
            InitializeComponent();
        }

        private void btnStartServer_Click(object sender, EventArgs e)
        {
            if (btnStartServer.Text == "啟動")
            {
                try
                {
                    server.ServerStartup(Convert.ToInt32(textBox1.Text), 10);
                    btnStartServer.Text = "關閉";
                }
                
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                 
            }
            else
            {
//                try
                {
                    server.CloseServer();
                    btnStartServer.Text = "啟動";
                }
                
//                catch (Exception ex)
                {
//                    MessageBox.Show(ex.Message);
                }
                 
 
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {

            textBox1.Text = "2020";

            server.OnReceiveDataFromClient += OnReceiveDataString; 
        }
        private void OnReceiveDataString(object sender, MyTcp.TcpServer.SocketEvent ev)
        {

 //         textBox2.Text += ev.data.ToString()+"\n";
            //textBox2.Text = "receove sucess!\n";
            //外部線程調用函數
            if (textBox2.InvokeRequired)
            {
                //lamba表達式形式
                /*
                Action<string> actionDelegate = (x) => {
                    textBox2.Text += ev.data.ToString();                
                };
                 */
                //或者
                Action<string> actionDelegate = delegate(string x)
                {
                    textBox2.AppendText(x+"\r\n");
                    
                };
                //激活委託
                string dataStr = ASCIIEncoding.ASCII.GetString(ev.data).Split('\0')[0];
                textBox2.Invoke(actionDelegate, (ev.socket.RemoteEndPoint.ToString()+": " + dataStr));
                server.SendStringToClient(ev.socket, "Receive data from " + ev.socket.RemoteEndPoint.ToString()+" sucessfully!");
            }

        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            Dictionary<string, Socket> clients = server.GetClientSockets();
            listBox1.Items.Clear();
            foreach (var cl in clients)
            {
                string clName = cl.Key;
                listBox1.Items.Add(clName);
            }
        }
    }
}
