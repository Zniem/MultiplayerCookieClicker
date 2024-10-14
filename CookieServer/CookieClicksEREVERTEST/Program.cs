using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Xml.Linq;
using CookieCount;

namespace Test
{
    class Program
    {
        static cookie c = new cookie(0);
        static void Main(string[] args)
        {            
            TcpListener listener = new TcpListener(IPAddress.Any, 1330);
            listener.Start();
            while (true)
            {
                Console.WriteLine("Waiting for connection");

                TcpClient client = listener.AcceptTcpClient();

                Thread thread = new Thread(HandleOutgoingMessages);
                thread.Start(client);
                Thread thread1 = new Thread(HandleIncomingMessages);
                thread1.Start(client);
            }

        }
        static void HandleOutgoingMessages(object obj)
        {
            TcpClient client = obj as TcpClient;

            bool done = false;
            while (!done)
            {               
                WriteTextMessage(client, "" + c); 
                Console.WriteLine("message send" + c);
                Thread.Sleep(10);
                
            }
        }
        static void HandleIncomingMessages(object obj)
        {
            TcpClient client = obj as TcpClient;

            bool done = false;
            while (!done)
            {
                string msg = ReadTextMessage(client);
                if (msg == "test")
                {
                    c.addcookies();
                    Console.WriteLine("cookies added");
                }
               
            }
        }

        public static void WriteTextMessage(TcpClient client, string message)
        {
            var stream = new StreamWriter(client.GetStream(), Encoding.ASCII, -1, true);
            {
                stream.WriteLine(message);
                stream.Flush();
            }
        }

        public static string ReadTextMessage(TcpClient client)
        {
            var stream = new StreamReader(client.GetStream(), Encoding.ASCII);
            {
                
                return stream.ReadLine();
            }
        }

    }
}
