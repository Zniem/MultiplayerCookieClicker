using CookieClicksEREVERTEST;
using CookieCount;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Test {
    class Program {
        public static CookieCount.Cookie Cookie;
        static List<String> players = new List<String>();
        static FileStorage fs = new FileStorage();
        static async Task Main(string[] args) {
            await fs.LoadFromFile();


            TcpListener listener = new TcpListener(IPAddress.Any, 1330);
            listener.Start();
            while (true) {
                Console.WriteLine("Waiting for connection");

                TcpClient client = listener.AcceptTcpClient();

                Thread thread = new Thread(HandleOutgoingMessages);
                thread.Start(client);
                Thread thread1 = new Thread(HandleIncomingMessages);
                thread1.Start(client);
                await CookieCount();
            }

        }

        private static async Task CookieCount() {
            while (true) {
                Cookie.COOKIES = Cookie.COOKIES + (Cookie.FINGER * 0.1) + (Cookie.GRANDMA * 1) + (Cookie.FARM * 8) + (Cookie.MINE * 47) + (Cookie.FACTORY * 260) + (Cookie.BANK * 1400);
                await Task.Delay(1000);
                Cookie.CPS = (Cookie.FINGER * 0.1) + (Cookie.GRANDMA * 1) + (Cookie.FARM * 8) + (Cookie.MINE * 47) + (Cookie.FACTORY * 260) + (Cookie.BANK * 1400);
                await fs.SaveToFile(); 
            }
        }

        static void HandleOutgoingMessages(object obj) {
            TcpClient client = obj as TcpClient;

            bool done = false;
            while (!done) {
                WriteTextMessage(client, "Cookies: " + (int)Cookie.COOKIES);
                Thread.Sleep(5);
                WriteTextMessage(client, "CPS: " + Cookie.CPS);
                Thread.Sleep(5);
                WriteTextMessage(client, "Fingers:" + Cookie.FINGER + " Price: " + (int)Cookie.FINGERPRICE);
                Thread.Sleep(5);
                WriteTextMessage(client, "Grandmas:" + Cookie.GRANDMA + " Price: " + (int)Cookie.GRANDMAPRICE);
                Thread.Sleep(5);
                WriteTextMessage(client, "Farm:" + Cookie.FARM + " Price: " + (int)Cookie.FARMPRICE);
                Thread.Sleep(5);
                WriteTextMessage(client, "Mine:" + Cookie.MINE + " Price: " + (int)Cookie.MINEPRICE);
                Thread.Sleep(5);
                WriteTextMessage(client, "Factory:" + Cookie.FACTORY + " Price: " + (int)Cookie.FACTORYPRICE);
                Thread.Sleep(5);
                WriteTextMessage(client, "Bank:" + Cookie.BANK + " Price: " + (int)Cookie.BANKPRICE);
                Thread.Sleep(5);
                foreach (String s in players) {
                    WriteTextMessage(client, "Player: " + s);
                    Console.WriteLine("message send" + s);
                    Thread.Sleep(5);

                }

                Thread.Sleep(5);


            }
        }
        static void HandleIncomingMessages(object obj) {
            TcpClient client = obj as TcpClient;

            bool done = false;
            while (!done) {
                string msg = ReadTextMessage(client);
                if (msg == "COOKIE") {
                    Cookie.addcookies();
                    Console.WriteLine("cookies added");
                } else if (msg == "FINGER") {
                    if (Cookie.COOKIES >= Cookie.FINGERPRICE) {
                        Cookie.addFinger();
                        Cookie.COOKIES = Cookie.COOKIES - (int)Cookie.FINGERPRICE;
                        Cookie.FINGERPRICE = Cookie.FINGERPRICE * 1.15;
                        Console.WriteLine("FINGER added");
                    }
                } else if (msg == "GRANDMA") {
                    if (Cookie.COOKIES >= Cookie.GRANDMAPRICE) {
                        Cookie.addGrandma();
                        Cookie.COOKIES = Cookie.COOKIES - (int)Cookie.GRANDMAPRICE;
                        Cookie.GRANDMAPRICE = Cookie.GRANDMAPRICE * 1.15;
                        Console.WriteLine("GRANDMA added");
                    }
                } else if (msg == "FARM") {
                    if (Cookie.COOKIES >= Cookie.FARMPRICE) {
                        Cookie.addFarm();
                        Cookie.COOKIES = Cookie.COOKIES - (int)Cookie.FARMPRICE;
                        Cookie.FARMPRICE = Cookie.FARMPRICE * 1.15;
                        Console.WriteLine("FARM added");
                    }
                } else if (msg == "MINE") {
                    if (Cookie.COOKIES >= Cookie.MINEPRICE) {
                        Cookie.addMine();
                        Cookie.COOKIES = Cookie.COOKIES - (int)Cookie.MINEPRICE;
                        Cookie.MINEPRICE = Cookie.MINEPRICE * 1.15;
                        Console.WriteLine("MINE added");
                    }
                } else if (msg == "FACTORY") {
                    if (Cookie.COOKIES >= Cookie.FACTORYPRICE) {
                        Cookie.addFactory();
                        Cookie.COOKIES = Cookie.COOKIES - (int)Cookie.FACTORYPRICE;
                        Cookie.FACTORYPRICE = Cookie.FACTORYPRICE * 1.15;
                        Console.WriteLine("FACTORY added");
                    }
                } else if (msg == "BANK") {
                    if (Cookie.COOKIES >= Cookie.BANKPRICE) {
                        Cookie.addBank();
                        Cookie.COOKIES = Cookie.COOKIES - (int)Cookie.BANKPRICE;
                        Cookie.BANKPRICE = Cookie.BANKPRICE * 1.15;
                        Console.WriteLine("BANK added");
                    }
                } else if (msg.Contains("Player")) {
                    msg = msg.Substring(8);
                    players.Add(msg);
                }

            }
        }

        public static void WriteTextMessage(TcpClient client, string message) {
            var stream = new StreamWriter(client.GetStream(), Encoding.ASCII, -1, true);
            stream.WriteLine(message);
            stream.Flush();
        }

        public static string ReadTextMessage(TcpClient client) {
            var stream = new StreamReader(client.GetStream(), Encoding.ASCII);
            return stream.ReadLine();
        }

    }

}
