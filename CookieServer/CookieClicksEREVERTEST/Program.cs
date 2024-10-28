using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;

namespace CookieServer {
    class Program {
        public static ProgressionData cookie;
        static List<String> players = new List<String>();
        public static async Task Main(string[] args) {
            cookie = await FileStorage.LoadFromFile(FileStorage.path);

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
                cookie.Cookies = cookie.Cookies + (long)cookie.Cps;
                await Task.Delay(1000);
                await FileStorage.SaveToFile(FileStorage.path, cookie);
            }
        }

        static void HandleOutgoingMessages(TcpClient tcpClient) {
            while (true) {
                String Message = JsonSerializer.Serialize<ProgressionData>(cookie);
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
                    cookie.addcookies();
                } else if (msg == "FINGER") {
                    if (cookie.Cookies >= cookie.FingerPrice) {
                        cookie.Cookies = cookie.Cookies - (int)cookie.FingerPrice;
                        cookie.addFinger();
                    }
                } else if (msg == "GRANDMA") {
                    if (cookie.Cookies >= cookie.GrandmaPrice) {
                        cookie.Cookies = cookie.Cookies - (int)cookie.GrandmaPrice;
                        cookie.addGrandma();
                    }
                } else if (msg == "FARM") {
                    if (cookie.Cookies >= cookie.FingerPrice) {
                        cookie.Cookies = cookie.Cookies - (int)cookie.FarmPrice;
                        cookie.addFarm();
                    }
                } else if (msg == "MINE") {
                    if (cookie.Cookies >= cookie.MinePrice) {
                        cookie.Cookies = cookie.Cookies - (int)cookie.MinePrice;
                        cookie.addMine();
                    }
                } else if (msg == "FACTORY") {
                    if (cookie.Cookies >= cookie.FactoryPrice) {
                        cookie.Cookies = cookie.Cookies - (int)cookie.FactoryPrice;
                        cookie.addFactory();
                    }
                } else if (msg == "BANK") {
                    if (cookie.Cookies >= cookie.BankPrice) {
                        cookie.Cookies = cookie.Cookies - (int)cookie.BankPrice;
                        cookie.addBank();
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
