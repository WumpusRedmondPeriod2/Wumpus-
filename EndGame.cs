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
    public partial class EndGame : Form
    {
        public EndGame(int endEvent, int score)
        {
            InitializeComponent();
            switch(endEvent){
                case 0:
                    label1.Text = "You defeated the Wumpus!";
                    break;
                case 1:
                    label1.Text = "You ran out of gold!";
                    break;
                case 2:
                    label1.Text = "You ran out of arrows!";
                    break;
                case 3:
                    label1.Text = "You fell to your death!";
                    break;
                case 4:
                    label1.Text = "You were eaten by the Wumpus!";
                    break;
            }
            label2.Text = "Score: " + score.ToString();
        }

        private void EndGame_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            var form1 = new StartGame();
            form1.Closed += (s, args) => this.Close();
            form1.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();  
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
        }
    }
}
