using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Threading;
namespace MyTcp
{
    public class TcpServer
    {
        //服務端套接字
        Socket serverSocket;
        
        //提取主機中可用的IP地址
        public static List<string> GetHostIPs()
        {
            string addressIp = string.Empty;
            List<string> IPList = new List<string>();
            try
            {
                foreach (IPAddress _IPAdress in Dns.GetHostEntry(Dns.GetHostName()).AddressList)
                {
                    if (_IPAdress.AddressFamily.ToString() == "InterNetwork")
                    {
                        IPList.Add(_IPAdress.ToString());
                    }

                }
            }
            catch (Exception ex)
            {
                 
            }
            return IPList;
        } 
        //開啟端口偵聽
        /// <summary>
        /// 開啟網絡端口
        /// </summary>
        /// <param name="IPStr">IP地址字符串，""表示偵聽所有網絡</param>
        /// <param name="port">端口</param>
        /// <param name="maxConn">允許的最大連接數</param>
        public void ListenSocket(string IPStr, int port, int maxConn)
        {
            serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            if (IPStr == "")
            {
                serverSocket.Bind(new IPEndPoint(IPAddress.Any, port));
            }
            else
            {
                serverSocket.Bind(new IPEndPoint(IPAddress.Parse(IPStr), port));
            }
            serverSocket.Listen(maxConn);
            //開啟接收客戶端連接線程
            new Thread(ListenClientConnect).Start(this);
        }
        //監聽客戶端線程
        private static void ListenClientConnect(object server)
        {
            TcpServer myServer = (TcpServer)server;
            
 
        }



    }
}
