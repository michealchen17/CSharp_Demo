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
    /// <summary>
    /// 服務器TCP
    /// </summary>
    public class TcpServer
    {
        //服務器套接字
        private Socket serverSocket = null;
        //處理客戶端連接的線程
        Thread clientConnThread = null;
        //接收緩存長度
        private int recvBuffLen = 1024;
        //客戶端套接字字典
        private Dictionary<string, Socket> dicClientSocket = new Dictionary<string, Socket>();
        //客戶端連接線程字典
        private Dictionary<string, Thread> dicClientThread = new Dictionary<string, Thread>();
        //離線客戶端
        private Dictionary<string, string> dicClientOld = new Dictionary<string, string>();
        //接收客戶端消息委託
        public delegate void DelegateReceiveDataFromClient(object sender, SocketEvent e);
        //客戶端上線
        public delegate void DelegateNewClientConnected(object sender, SocketEvent e);
        //客戶端下線
        public delegate void DelegateClientDisconnected(object sender, SocketEvent e);
        //接收客戶端消息事件
        public event DelegateReceiveDataFromClient OnReceiveDataFromClient;
        //客戶端上線
        public event DelegateNewClientConnected OnNewClientConnected;
        //客戶端下線
        public event DelegateClientDisconnected OnClientDisconnected;

        private bool closeServer = false;
        
        /// <summary>
        /// 開啟服務器
        /// </summary>
        /// <param name="port">端口</param>
        /// <param name="max">允許最大連接數</param>
        public void ServerStartup(int port, int max)
        {
            dicClientSocket.Clear();
            dicClientThread.Clear();
            closeServer = false;
            serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            serverSocket.Bind(new IPEndPoint(IPAddress.Any, port));
            serverSocket.Listen(max);
            //新建處理客戶端連接的線程
            clientConnThread = new Thread(ThreadWatchClientConncting);
            clientConnThread.Start();
        }
        private void ThreadWatchClientConncting()
        {
            while (true)
            {
                if (closeServer == true)
                {
                    return;
                }
                //接受新的客戶端連接請求
                Socket newClientSocket = serverSocket.Accept();
                //新建一條客戶端線程
                Thread newClientThread = new Thread(ThreadReceiveClientData);
                newClientThread.IsBackground = true;
                newClientThread.Start(newClientSocket);
                dicClientSocket.Add(newClientSocket.RemoteEndPoint.ToString(), newClientSocket);
                dicClientThread.Add(newClientSocket.RemoteEndPoint.ToString(),newClientThread);
                SocketEvent socketEvent = new SocketEvent();
                socketEvent.socket = newClientSocket;
                if (OnNewClientConnected != null)
                {
                    OnNewClientConnected(this, socketEvent); 
                }
//                OnNewClientConnected(this, socketEvent);
            }
        }
        //接收客戶端數據的線程
        private void ThreadReceiveClientData(object client)
        {
            //客戶端套接字
            Socket clientSocket = client as Socket;
            while (true)
            {
                if (closeServer == true)
                {
                    return;
                }
                SocketEvent recvEvent = new SocketEvent();
                recvEvent.socket = clientSocket;
                byte[] recvData = new byte[recvBuffLen];
                //實際接收到的數據長度
                int recvDataLen = -1;
                try
                {
                    recvDataLen = clientSocket.Receive(recvData);
                    //接收是否正常
                    recvEvent.data = recvData;
                    recvEvent.dataLen = recvDataLen;
                    if (recvDataLen > 0)
                    {
                        //處理正常接收到的數據
                        
                        //發佈接收到客戶端數據的消息
                        if (OnReceiveDataFromClient != null)
                        {
                            OnReceiveDataFromClient(this, recvEvent); 
                        }
                        
                    }
                    else
                    {
                        //客戶端連接異常處理
                        dicClientSocket.Remove(clientSocket.RemoteEndPoint.ToString());
                        dicClientThread.Remove(clientSocket.RemoteEndPoint.ToString());
                        if (OnClientDisconnected != null)
                        {
                            OnClientDisconnected(this, recvEvent);
                        }
                        return;
                    }
                }
                catch
                {
                    dicClientSocket.Remove(clientSocket.RemoteEndPoint.ToString());
                    dicClientThread.Remove(clientSocket.RemoteEndPoint.ToString());
                    if (OnClientDisconnected != null)
                    {
                        OnClientDisconnected(this, recvEvent);
                    }
                    return;
                }
            }
 
        }
        //接收客戶端數據的消息參數
        public class SocketEvent : EventArgs
        {
            public Socket socket;
            public byte[] data;
            public int dataLen;
        }
        //客戶端套接字
        public Dictionary<string, Socket> GetClientSockets()
        {
            return dicClientSocket;
        }
        //客戶端線程
        public Dictionary<string, Thread> GetClientsThreads()
        {
            return dicClientThread;
        }
        //向客戶端發送字符串
        public void SendStringToClient(Socket client, string str)
        {
            byte[] sendBuff = ASCIIEncoding.ASCII.GetBytes(str);
            SendDataToClient(client, sendBuff, sendBuff.Length);
        }
        //向客戶端發送數據
        public void SendDataToClient(Socket client, byte[] data, int dataLen)
        {

            try
            {
                client.Send(data, 0, dataLen, SocketFlags.None);
                return;
            }
            catch//客戶端連接異常
            {
                Thread clientThread = null;
                dicClientThread.TryGetValue(client.RemoteEndPoint.ToString(), out clientThread);
                if (clientThread != null)
                {
                    clientThread.Abort();
                }
                dicClientSocket.Remove(client.RemoteEndPoint.ToString());
                dicClientThread.Remove(client.RemoteEndPoint.ToString());
                SocketEvent socketEvent = new SocketEvent();
                socketEvent.socket = client;
                if (OnNewClientConnected != null)
                {
                    OnNewClientConnected(this, socketEvent);
                }
                return;
            }
        }
        public void CloseServer()
        {
            closeServer = true;
            serverSocket.Close();
            clientConnThread.Abort();
            List<string> listThread = new List<string>(dicClientThread.Keys);

            for (int i = 0; i < dicClientThread.Count; i++)
            {
                dicClientThread[listThread[i]].Abort();
            }
                
        }

    }
}
