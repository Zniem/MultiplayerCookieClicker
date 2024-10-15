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
                WriteTextMessage(client, "Cookies: " + c);
                Thread.Sleep(5);
                WriteTextMessage(client, "Grandmas:" + c.GRANDMA + " Price: " + (int)c.GRANDMAPRICE);
                Thread.Sleep(5);
                WriteTextMessage(client, "Farm:" + c.FARM);
                Thread.Sleep(5);
                WriteTextMessage(client, "Mine:" + c.MINE);
                Thread.Sleep(5);
                WriteTextMessage(client, "Factory:" + c.FACTORY);
                Thread.Sleep(5);
                WriteTextMessage(client, "Wizard:" + c.WIZARDTOWER);
                Console.WriteLine("message send" + c.GRANDMAPRICE);
                Thread.Sleep(5);
                c.COOKIES = c.COOKIES + c.GRANDMA;
                
            }
        }
        static void HandleIncomingMessages(object obj)
        {
            TcpClient client = obj as TcpClient;

            bool done = false;
            while (!done)
            {
                string msg = ReadTextMessage(client);
                if (msg == "COOKIE")
                {
                    c.addcookies();
                    Console.WriteLine("cookies added");
                }
                else if (msg == "GRANDMA") {
                    if (c.COOKIES >= c.GRANDMAPRICE) {
                        c.addGrandma();
                        c.COOKIES = c.COOKIES - (int)c.GRANDMAPRICE;
                        c.GRANDMAPRICE = c.GRANDMAPRICE * 1.5;
                        Console.WriteLine("GRANDMA added");
                    }   
                }
                else if (msg == "FARM")
                {
                    c.addFarm();
                    Console.WriteLine("FARM added");
                }
                else if (msg == "MINE")
                {
                    c.addMine();
                    Console.WriteLine("MINE added");
                }
                else if (msg == "FACTORY")
                {
                    c.addFactory();
                    Console.WriteLine("FACTORY added");
                }
                else if (msg == "WIZZARD")
                {
                    c.addWizzardTower();
                    Console.WriteLine("WIZZARD added");
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
