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
        TcpClient client = new TcpClient("145.49.17.96", 1330);

        public MainGame()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
            timer.Interval = (10); // 10 seconds in milliseconds
            timer.Tick += new EventHandler(timer_Tick);
            timer.Start();
        }
        private void timer_Tick(object sender, EventArgs e)
        {
            label1.Text = "" + Program.ReadTextMessage(client);
        }
        
        

        private void achievementsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            (new Achievements()).Show(); this.Hide();
        }

        private void leaderboardsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            (new Leaderbord()).Show(); this.Hide(); 
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Program.WriteTextMessage(client, "test");
        }

        private void messagesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            (new MessageForm()).Show(); this.Hide();    
        }

        private void GrandmaButton_Click(object sender, EventArgs e)
        {

        }

        private void FarmButton_Click(object sender, EventArgs e)
        {

        }

        private void MineButton_Click(object sender, EventArgs e)
        {

        }

        private void FactoryButton_Click(object sender, EventArgs e)
        {

        }

        private void WizardButton_Click(object sender, EventArgs e)
        {

        }
    }
}
