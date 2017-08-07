using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;

namespace NetworkInterface
{
    public interface INetworkInterface
    {
        void SendData();

        string RecvData();
    }
}
