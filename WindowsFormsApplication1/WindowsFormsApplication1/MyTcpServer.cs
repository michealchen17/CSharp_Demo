using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Windows.Forms;

namespace MyTcpServer
{
    abstract public class MyTcpServer
    {
        //監聽客戶端連接線程
        private Thread threadWatchs = null;
        //服務器套接字
        private Socket socketServer = null;
        //服務器監聽客戶端連接情況的線程
        private Thread monitoThread = null;
        //客戶端與IP套接字的字典
        private Dictionary<string, Socket> dictSocket = new Dictionary<string, Socket>();
        //客戶端IP與線程字典
        private Dictionary<string, Thread> dictThread = new Dictionary<string, Thread>();
        //客戶端連接線程的數量
        private long numThreadVal = 0;
        //服務器IP
//        private string strServerIP = "127.0.0.1";
        //服務器端口
//        private int serverPort = 8080;
        //緩存數據長度
        private int receiveDataValLength = 1024;
        //Ping客戶端
        private Ping monitoPing = new Ping();
        //異常斷開的客戶端
        private Dictionary<string, string> dictBodClient = new Dictionary<string, string>();
        //指示釋放線程
        private bool isClearThread = false;
        //接收客戶端消息委託
        public delegate void DelegateReceiveDataFromClient(object sender, TcpReceiveEvent e);
        //接收客戶端消息事件
        public event DelegateReceiveDataFromClient OnReceiveDataFromClient;
        //構造函數
        public MyTcpServer()
        {
            OnReceiveDataFromClient += new DelegateReceiveDataFromClient(ReceivedDataProcess);
 
        }

        //

        //客戶端連接情況監控
        public void MonitoThreadsDynamic()
        {
            while (true)
            {
                Thread.Sleep(3000);
                try
                {
                    foreach (var vv in dictSocket)
                    {
                        PingReply reply = monitoPing.Send(vv.Key.Split(':')[0], 1000);
                        if (reply.Status == IPStatus.Success)
                        {
                            //客戶端連接正常
                        }
                        else
                        {
                            //添加到異常客戶端
                            dictBodClient.Add(vv.Key, "old");
                        }
                    }
                    //釋放異常連接線程
                    foreach (var vvv in dictThread)
                    {
                        isClearThread = false;
                        foreach (var vvvv in dictBodClient)
                        {
                            if (vvv.Key == vvv.Key)
                            {
                                isClearThread = true;
                                break;
                            }
                        }
                        if (isClearThread)
                        {
                            vvv.Value.Abort();
                        }
                    }
                    //移除異常客戶端
                    foreach (var vvv in dictBodClient)
                    {
                        dictSocket.Remove(vvv.Key);
                        dictThread.Remove(vvv.Key);
                        //DeleteClientSocket(vvv.key);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message,"tcp server error");                                        
                }
                dictBodClient.Clear();
                numThreadVal = dictThread.LongCount();
            }
        }
        //開啟服務器
        public void OpenServer(string serverIP, int serverPort)
        {
            socketServer = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
//            IPEndPoint ipAndPort = new IPEndPoint(IPAddress.Parse(serverIP), serverPort);
            IPEndPoint ipAndPort = new IPEndPoint(IPAddress.Any, serverPort);
            try
            {
                socketServer.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);
                socketServer.Bind(ipAndPort);
            }
            catch (SocketException ex)
            {
                MessageBox.Show(ex.Message, "錯誤");
                return;
            }
            //指定最大客戶端數
            socketServer.Listen(10000);
            //實例化服務器偵聽客戶端連接的線程
            threadWatchs = new Thread(WatchClientConnecting);
            //後台運行線程
            threadWatchs.IsBackground = true;
            //啟動線程
            threadWatchs.Start();

            monitoThread = new Thread(MonitoThreadsDynamic);
            monitoThread.IsBackground = true;
            monitoThread.Start();
        }
        private void WatchClientConnecting()
        {
            while (true)
            {
                //偵聽新的客戶端連接請求
                Socket newClientConnecting = socketServer.Accept();
                //添加遠端列表
                //AddClientSocket(newClientConnecting.RemoteEndPoint.ToString());
                //新建一條新的客戶端線程
                Thread newClientThread = new Thread(ReceiveData);
                //後台運行客戶端
                newClientThread.IsBackground = true;
                //啟動線程，綁定套接字
                newClientThread.Start(newClientConnecting);
                //添加客戶端套接字
                dictSocket.Add(newClientConnecting.RemoteEndPoint.ToString(), newClientConnecting);
                dictThread.Add(newClientConnecting.RemoteEndPoint.ToString(), newClientThread);
            }
        }
        //接收數據
        private void ReceiveData(object socketConnecting)
        {
            //獲取客戶端套接字
            Socket socketClient = socketConnecting as Socket;
            while (true)
            {
                byte[] receiveDataVal = new byte[receiveDataValLength];
                int receiveDataLength = -1;
                try
                {
                    receiveDataLength = socketClient.Receive(receiveDataVal);
                    //接收到數據
                    if (receiveDataLength > 0)
                    {
                        //處理接收到的數據
                        //ReceivedDataProcess(socketClient,receiveDataVal, receiveDataLength);
                        TcpReceiveEvent rEvent = new TcpReceiveEvent();
                        rEvent.clientSocket = socketClient;
                        rEvent.data = receiveDataVal;
                        rEvent.length = receiveDataLength;

                        OnReceiveDataFromClient(this, rEvent);
                    }
                    else
                    {
                        dictSocket.Remove(socketClient.RemoteEndPoint.ToString());
                        dictThread.Remove(socketClient.RemoteEndPoint.ToString());
                        //DeleteClientSocket(socketClient.RemoteEndPoint.ToString());
                        return;

                    }
                }
                catch
                {
                    dictSocket.Remove(socketClient.RemoteEndPoint.ToString());
                    dictThread.Remove(socketClient.RemoteEndPoint.ToString());
                    //DeleteClientSocket(socketClient.RemoteEndPoint.ToString());
                    return; 
                }
            }
        }
        /*
        private void ReceivedDataProcess(Socket clientSocket, byte[] datas, int lenght)
        {

            NewOneThreadSendDataToClient(clientSocket ,datas, lenght);
 
        }
        */

        public abstract void ReceivedDataProcess(object sender, TcpReceiveEvent e);
 
        protected void NewOneThreadSendDataToClient(Socket clientSocket, byte[] datas, int length)
        {
            DataSendArgsMode sendDataArgs = new DataSendArgsMode();
            sendDataArgs.sockets = clientSocket;
            sendDataArgs.datas = datas;
            sendDataArgs.length = length;
            //新建發送數據的線程
            Thread threadSendDataToClient = new Thread(SendDataToClient);
            threadSendDataToClient.IsBackground = true;
            threadSendDataToClient.Start(sendDataArgs);
            
        }
        private void SendDataToClient(object obj)
        {
            DataSendArgsMode args = obj as DataSendArgsMode;
            try
            {
                args.sockets.Send(args.datas, 0, args.length, SocketFlags.None);
                return;
            }
            catch
            {
                dictSocket.Remove(args.sockets.RemoteEndPoint.ToString());
                dictThread.Remove(args.sockets.RemoteEndPoint.ToString());
                return;
            }
        }
        public void CloseServer()
        {
            socketServer.Close();            
            threadWatchs.Abort();
            monitoThread.Abort();            
            foreach (var vv in dictThread)
            {
                vv.Value.Abort();                
            }

        }
        
        public class DataSendArgsMode
        {
            public Socket sockets;
            public byte[] datas;
            public int length;
        }
        public class TcpReceiveEvent : EventArgs
        {
            public Socket clientSocket;
            public byte[] data;
            public int length;
        }

    }
}
