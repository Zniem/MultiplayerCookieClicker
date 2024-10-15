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
        static cookie c = new cookie(1000);
        static List<String> players = new List<String>();
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
                Thread thread2 = new Thread(CookieCount);
                thread2.Start();
            }

        }

        private static void CookieCount()
        {
            while (true)
            {
                c.COOKIES = c.COOKIES + (c.FINGER * 0.1) + (c.GRANDMA * 1) + (c.FARM * 8) + (c.MINE * 47) + (c.FACTORY * 260) + (c.BANK * 1400);
                Thread.Sleep(1000);
                c.CPS = (c.FINGER * 0.1) + (c.GRANDMA * 1) + (c.FARM * 8) + (c.MINE * 47) + (c.FACTORY * 260) + (c.BANK * 1400);
            }
        }

        static void HandleOutgoingMessages(object obj)
        {
            TcpClient client = obj as TcpClient;

            bool done = false;
            while (!done)
            {               
                WriteTextMessage(client, "Cookies: " + (int)c.COOKIES);
                Thread.Sleep(5);
                WriteTextMessage(client, "CPS: " + c.CPS);
                Thread.Sleep(5);
                WriteTextMessage(client, "Fingers:" + c.FINGER + " Price: " + (int)c.FINGERPRICE);
                Thread.Sleep(5);
                WriteTextMessage(client, "Grandmas:" + c.GRANDMA + " Price: " + (int)c.GRANDMAPRICE);
                Thread.Sleep(5);
                WriteTextMessage(client, "Farm:" + c.FARM + " Price: " + (int)c.FARMPRICE);
                Thread.Sleep(5);
                WriteTextMessage(client, "Mine:" + c.MINE + " Price: " + (int)c.MINEPRICE);
                Thread.Sleep(5);
                WriteTextMessage(client, "Factory:" + c.FACTORY + " Price: " + (int)c.FACTORYPRICE);
                Thread.Sleep(5);
                WriteTextMessage(client, "Bank:" + c.BANK + " Price: " + (int)c.BANKPRICE);
                Thread.Sleep(5);
                foreach (String s in players) {
                    WriteTextMessage(client, "Player: " + s);
                    Thread.Sleep(5);
                }
                Console.WriteLine("message send" + c.GRANDMAPRICE);
                Thread.Sleep(5);
                
                
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
                else if (msg == "FINGER")
                {
                    if (c.COOKIES >= c.FINGERPRICE)
                    {
                        c.addFinger();
                        c.COOKIES = c.COOKIES - (int)c.FINGERPRICE;
                        c.FINGERPRICE = c.FINGERPRICE * 1.15;
                        Console.WriteLine("FINGER added");
                    }
                }
                else if (msg == "GRANDMA") {
                    if (c.COOKIES >= c.GRANDMAPRICE) {
                        c.addGrandma();
                        c.COOKIES = c.COOKIES - (int)c.GRANDMAPRICE;
                        c.GRANDMAPRICE = c.GRANDMAPRICE * 1.15;
                        Console.WriteLine("GRANDMA added");
                    }
                }
                else if (msg == "FARM")
                {
                    if (c.COOKIES >= c.FARMPRICE)
                    {
                        c.addFarm();
                        c.COOKIES = c.COOKIES - (int)c.FARMPRICE;
                        c.FARMPRICE = c.FARMPRICE * 1.5;
                        Console.WriteLine("FARM added");
                    }
                }
                else if (msg == "MINE")
                {
                    if (c.COOKIES >= c.MINEPRICE)
                    {
                        c.addMine();
                        c.COOKIES = c.COOKIES - (int)c.MINEPRICE;
                        c.MINEPRICE = c.MINEPRICE * 1.5;
                        Console.WriteLine("MINE added");
                    }
                }
                else if (msg == "FACTORY")
                {
                    if (c.COOKIES >= c.FACTORYPRICE)
                    {
                        c.addFactory();
                        c.COOKIES = c.COOKIES - (int)c.FACTORYPRICE;
                        c.FACTORYPRICE = c.FACTORYPRICE * 1.5;
                        Console.WriteLine("FACTORY added");
                    }
                }
                else if (msg == "BANK")
                {
                    if (c.COOKIES >= c.BANKPRICE)
                    {
                        c.addBank();
                        c.COOKIES = c.COOKIES - (int)c.BANKPRICE;
                        c.BANKPRICE = c.BANKPRICE * 1.5;
                        Console.WriteLine("BANK added");
                    }
                }
                else if (msg.Contains("Player")) {
                    msg = msg.Substring(8);
                    players.Add(msg);
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
