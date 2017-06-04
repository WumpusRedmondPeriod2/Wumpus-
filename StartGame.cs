using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WumpusTest
{
    public partial class StartGame : Form
    {
        public StartGame()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            var frm = new CaveChoice();
            frm.Closed += (s, args) => this.Close();
            frm.Show();
        }

        private void instructionButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            var frm = new Instructions();
            frm.Closed += (s, args) => this.Close();
            frm.Show();
        }
    }
}
