﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CookieclickerGUITEST
{
    public partial class TitleScreen : Form
    {
        public TitleScreen()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Program.WriteTextMessage(Program.client, "Player: " + NameTextBox.Text);
            (new MainGame()).Show(); this.Hide();
        }

        private void TitleScreen_Load(object sender, EventArgs e)
        {

        }
    }
}
