using log4net;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Barrel.Networking
{
    class Server
    {
        public ConnectionState connectionState;
        public TcpListener listener;

        //private readonly ILog logger = LogManager.GetLogger(typeof(Server));

        private void HandleClient(object o)
        {
            TcpClient client = (TcpClient)o;

            BinaryReader binaryReader = new BinaryReader(client.GetStream());
            BinaryWriter binaryWriter = new BinaryWriter(client.GetStream());

            // Assume that a handshake will take place
            connectionState = ConnectionState.Handshake;

        }

        public void Start(int port)
        {
            // Create the socket
            IPEndPoint endpoint = new IPEndPoint(IPAddress.Any, port);
            listener = new TcpListener(endpoint);

            Console.WriteLine("Barrel 0.1 written by dhilln");
            Console.WriteLine($"SERVER: Started listening on port '{port}'");
            listener.Start();

            while (true)
            {
                TcpClient client = listener.AcceptTcpClient();
                Thread thread = new Thread(new ParameterizedThreadStart(HandleClient));

                IPEndPoint remote = (IPEndPoint)client.Client.RemoteEndPoint;
                Console.WriteLine($"SERVER: Received connection from {remote.Address}");
                thread.Start();
            }
        }
    }
}
