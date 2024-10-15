using CookieclickerGUITEST.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CookieclickerGUITEST
{
    public partial class MainGame : Form
    {
        

        public MainGame()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
            timer.Interval = (10); 
            timer.Tick += new EventHandler(timer_Tick);
            timer.Start();
        }
        private void timer_Tick(object sender, EventArgs e)
        {
            String msg = Program.ReadTextMessage(Program.client);
            if (msg.Contains("Cookies")) { 
                label1.Text = msg;
            }
            else if (msg.Contains("CPS"))
            {
                CPSLabel.Text = msg;
            }
            else if (msg.Contains("Fingers"))
            {
                FingerLabel.Text = msg;
            }
            else if (msg.Contains("Grandmas"))
            {
                GrandmaLabel.Text = msg;
            }
            else if (msg.Contains("Farm"))
            {
                FarmLabel.Text = msg;
            }
            else if (msg.Contains("Mine"))
            {
                MineLabel.Text = msg;
            }
            else if (msg.Contains("Factory"))
            {
                FactoryLabel.Text = msg;
            }
            else if (msg.Contains("Wizard"))
            {
                WizardTowerLabel.Text = msg;
            }



        }

        //sending messages to server
        
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Program.WriteTextMessage(Program.client, "COOKIE");

        }
        private void FingerButton_Click(object sender, EventArgs e)
        {
            Program.WriteTextMessage(Program.client, "FINGER");
        }

        private void GrandmaButton_Click(object sender, EventArgs e)
        {
            Program.WriteTextMessage(Program.client, "GRANDMA");
        }

        private void FarmButton_Click(object sender, EventArgs e)
        {
            Program.WriteTextMessage(Program.client, "FARM");
        }

        private void MineButton_Click(object sender, EventArgs e)
        {
            Program.WriteTextMessage(Program.client, "MINE");
        }

        private void FactoryButton_Click(object sender, EventArgs e)
        {
            Program.WriteTextMessage(Program.client, "FACTORY");
        }

        private void WizardButton_Click(object sender, EventArgs e)
        {
            Program.WriteTextMessage(Program.client, "WIZZARD");
        }

        //all methods leading to different forms
        private void achievementsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            (new Achievements()).Show(); this.Hide();
        }

        private void leaderboardsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            (new Leaderbord()).Show(); this.Hide();
        }
        private void messagesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            (new MessageForm()).Show(); this.Hide();
        }

        
    }
}
