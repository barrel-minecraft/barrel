using Barrel.Networking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barrel
{
    class Program
    {
        private static Server server;

        static void Main(string[] args)
        {
            server = new Server();

            server.Start(25569);
            Console.Read();
        }
    }
}
