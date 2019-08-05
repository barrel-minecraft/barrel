using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barrel.Networking
{
    enum ConnectionState
    {
        Initial,    // Initial connection state
        Handshake,  // Handshake with the client
        Status,     // Polling for status in the server list
        Login,      // Login with Minecraft
        Play,       // Play events (unimplemented yet)
    }
}
