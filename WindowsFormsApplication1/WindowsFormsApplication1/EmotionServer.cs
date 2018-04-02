using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyTcpServer;
namespace WindowsFormsApplication1
{
    public class EmotionServer:MyTcpServer.MyTcpServer
    {
        public override void ReceivedDataProcess(object sender, MyTcpServer.MyTcpServer.TcpReceiveEvent e)
        {
           // throw new NotImplementedException();
            NewOneThreadSendDataToClient(e.clientSocket, e.data, e.length);
        }

    }
}
