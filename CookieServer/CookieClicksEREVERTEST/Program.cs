using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;

namespace CookieServer {
    class Program {
        public static ProgressionData cookie;
        static List<String> players = new List<String>();
        static DateTime lastUpdate = DateTime.Now;

        public static async Task Main(string[] args) {
            cookie = await FileStorage.LoadFromFile(FileStorage.path);

            TcpListener listener = new TcpListener(IPAddress.Any, 1330);
            listener.Start();
            Console.WriteLine("Waiting for new connections");
            while (true) {
                if (listener.Pending()) {
                    TcpClient client = listener.AcceptTcpClient();

                    Thread OutgoingMessagesThread = new Thread(() => HandleOutgoingMessages(client));
                    Thread IncomingMessagesThread = new Thread(() => HandleIncomingMessages(client));
                    OutgoingMessagesThread.Start();
                    IncomingMessagesThread.Start();
                }
                await CookieCount();
            }
        }

        private static async Task CookieCount() {

            TimeSpan timeSinceLastUpdate = DateTime.Now - lastUpdate;
            if (timeSinceLastUpdate.Seconds >= 1) {
                cookie.Cookies = cookie.Cookies + (long)cookie.Cps;
                await FileStorage.SaveToFile(FileStorage.path, cookie);

                lastUpdate = DateTime.Now;
            }

        }

        static void HandleOutgoingMessages(TcpClient tcpClient) {
            while (tcpClient.Connected) {
                String Message = JsonSerializer.Serialize<ProgressionData>(cookie);
                WriteTextMessage(tcpClient, Message);

                foreach (String s in players.ToList()) {
                    WriteTextMessage(tcpClient, "Player: " + s);
                    Thread.Sleep(5);
                }
                Thread.Sleep(5);
            }
        }

        static void HandleIncomingMessages(TcpClient tcpClient) {
            String player = "";
            while (tcpClient.Connected) {
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
                    player = msg.Substring(8);
                    players.Add(player);
                }

            }

            players.Remove(player);
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
