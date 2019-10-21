using System;

namespace TcpServer
{
    class Program
    {
        static void Main(string[] args)
        {
            // Setup book collection
            BookCollection.PopulateCollection();

            // Start server
            Server server = new Server();
            server.Start();
        }
    }
}
