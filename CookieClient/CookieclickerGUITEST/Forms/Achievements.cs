using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CookieclickerGUITEST.Forms
{
    public partial class Achievements : Form
    {
        public Achievements()
        {
            InitializeComponent();
        }

        private void cookieToolStripMenuItem_Click(object sender, EventArgs e)
        {
            (new MainGame()).Show(); this.Hide();
        }
    }
}
