using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
namespace MyTcp
{
    class TcpClient
    {
        //客戶端套接字
        private Socket clientSocket;
        //服務端套接字
        private Socket serverSocket;
        /// <summary>
        /// 連接到服務器
        /// </summary>
        /// <param name="srvIP">服務器IP</param>
        /// <param name="srvPort">服務器端口</param>
        public void Connect(string srvIP, int srvPort)
        {

 
        }
    }
}
