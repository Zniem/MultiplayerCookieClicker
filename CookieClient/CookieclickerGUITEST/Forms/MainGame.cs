using CookieServer;
using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Windows.Forms;

namespace CookieclickerGUITEST {
    public partial class MainGame : Form {
        List<String> players = new List<String>();
        String playerstring = "";

        public MainGame() {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e) {
            System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
            timer.Interval = (10);
            timer.Tick += new EventHandler(timer_Tick);
            timer.Start();
        }
        private void timer_Tick(object sender, EventArgs e) {
            String msg = Program.ReadTextMessage(Program.client);
            if (msg.StartsWith("{") && msg.EndsWith("}")) {
                ProgressionData cookie = JsonSerializer.Deserialize<ProgressionData>(msg);
                label1.Text = $"Cookies: {(int)cookie.Cookies}";
                CPSLabel.Text = $"CPS: {cookie.Cps}";
                FingerLabel.Text = $"amount {cookie.Finger} : price {(int)cookie.FingerPrice}";
                GrandmaLabel.Text = $"amount {cookie.Grandma} : price {(int)cookie.GrandmaPrice}";
                FarmLabel.Text = $"amount {cookie.Farm} : price {(int)cookie.FarmPrice}";
                MineLabel.Text = $"amount {cookie.Mine} : price {(int)cookie.MinePrice}";
                FactoryLabel.Text = $"amount {cookie.Factory} : price {(int)cookie.FactoryPrice}";
                BankLabel.Text = $"amount {cookie.Bank} : price {(int)cookie.BankPrice}";

            } else if (msg.Contains("Player")) {
                if (players.Contains(msg)) {

                } else {
                    players.Add(msg);
                    playerstring = playerstring + msg + "\n";
                    PlayerLabel.Text = playerstring;
                }
            }
        }

        //sending messages to server
        private void FingerButton_Click(object sender, EventArgs e) {
            Program.WriteTextMessage(Program.client, "FINGER");
        }

        private void GrandmaButton_Click(object sender, EventArgs e) {
            Program.WriteTextMessage(Program.client, "GRANDMA");
        }

        private void FarmButton_Click(object sender, EventArgs e) {
            Program.WriteTextMessage(Program.client, "FARM");
        }

        private void MineButton_Click(object sender, EventArgs e) {
            Program.WriteTextMessage(Program.client, "MINE");
        }

        private void FactoryButton_Click(object sender, EventArgs e) {
            Program.WriteTextMessage(Program.client, "FACTORY");
        }
        private void BankButton_Click(object sender, EventArgs e) {
            Program.WriteTextMessage(Program.client, "BANK");
        }

        private void button1_Click(object sender, EventArgs e) {
            Program.WriteTextMessage(Program.client, "COOKIE");
        }
    }
}
