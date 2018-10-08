using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace TCPServer
{
    class Program
    {
        private static readonly int PORT = 8080;
        static void Main(string[] args)
        {
            IPAddress localAddress = IPAddress.Loopback;
            //it is the server and the port of server
            TcpListener serverSocket = new TcpListener(localAddress, PORT);
            //start of the server
            serverSocket.Start();
            Console.WriteLine("TCP Server runs on port"+ PORT);
            while (true)
            {
                try
                {
                    TcpClient client = serverSocket.AcceptTcpClient();
                    Console.WriteLine("incoming client");

                    //now allows multiple clients
                    Task.Run(() => clientaction.DoIt(client));


                }
                catch (IOException ex)
                {
                    Console.WriteLine("Exception will continue");
                    
                }
            }
            
                
            
        }
    }
}
