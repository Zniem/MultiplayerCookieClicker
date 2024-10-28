using CookieClicksEREVERTEST;
using CookieCount;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;

namespace Test {
    class Program {
        public static CookieCount.Cookie Cookie;
        static List<String> players = new List<String>();
        static FileStorage fs = new FileStorage();
         public static async Task Main(string[] args) {
            await fs.LoadFromFile();

            TcpListener listener = new TcpListener(IPAddress.Any, 1330);
            listener.Start();

            while (true) {
                Console.WriteLine("Waiting for new connections");
                TcpClient client = listener.AcceptTcpClient();

                Thread OutgoingMessagesThread = new Thread(() => HandleOutgoingMessages(client));
                Thread IncomingMessagesThread = new Thread(() => HandleIncomingMessages(client));
                OutgoingMessagesThread.Start();
                IncomingMessagesThread.Start();
                await CookieCount();
            }

        }

        private static async Task CookieCount() {
            while (true) {
                Cookie.Cookies = Cookie.Cookies + (Cookie.Finger * 0.1) + (Cookie.Grandma * 1) + (Cookie.Farm * 8) + (Cookie.Mine * 47) + (Cookie.Factory * 260) + (Cookie.Bank * 1400);
                await Task.Delay(1000);
                Cookie.Cps = (Cookie.Finger * 0.1) + (Cookie.Grandma * 1) + (Cookie.Farm * 8) + (Cookie.Mine * 47) + (Cookie.Factory * 260) + (Cookie.Bank * 1400);
                await fs.SaveToFile();
            }
        }

        static void HandleOutgoingMessages(TcpClient tcpClient) {
            while (true) {
                String Message = JsonSerializer.Serialize<CookieCount.Cookie>(Program.Cookie);
                WriteTextMessage(tcpClient, Message);
                foreach (String s in players) {
                    WriteTextMessage(tcpClient, "Player: " + s);
                    Thread.Sleep(5);
                }
                Thread.Sleep(5);
            }
        }
        static void HandleIncomingMessages(TcpClient tcpClient) {
            while (true) {
                string msg = ReadTextMessage(tcpClient);
                if (msg == "COOKIE") {
                    Cookie.addcookies();
                } else if (msg == "FINGER") {
                    if (Cookie.Cookies >= Cookie.FingerPrice) {
                        Cookie.Cookies = Cookie.Cookies - (int)Cookie.FingerPrice;
                        Cookie.addFinger();
                    }
                } else if (msg == "GRANDMA") {
                    if (Cookie.Cookies >= Cookie.GrandmaPrice) {
                        Cookie.Cookies = Cookie.Cookies - (int)Cookie.GrandmaPrice;
                        Cookie.addGrandma();
                    }
                } else if (msg == "FARM") {
                    if (Cookie.Cookies >= Cookie.FingerPrice) {
                        Cookie.Cookies = Cookie.Cookies - (int)Cookie.FarmPrice;
                        Cookie.addFarm();
                    }
                } else if (msg == "MINE") {
                    if (Cookie.Cookies >= Cookie.MinePrice) {
                        Cookie.Cookies = Cookie.Cookies - (int)Cookie.MinePrice;
                        Cookie.addMine();
                    }
                } else if (msg == "FACTORY") {
                    if (Cookie.Cookies >= Cookie.FactoryPrice) {
                        Cookie.Cookies = Cookie.Cookies - (int)Cookie.FactoryPrice;
                        Cookie.addFactory();
                    }
                } else if (msg == "BANK") {
                    if (Cookie.Cookies >= Cookie.BankPrice) {
                        Cookie.Cookies = Cookie.Cookies - (int)Cookie.BankPrice;
                        Cookie.addBank();
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
