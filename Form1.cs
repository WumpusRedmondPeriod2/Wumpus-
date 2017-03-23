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
    public partial class Form1 : Form
    {
        public UI ui = new UI();

        public Form1()
        {
            InitializeComponent();
            ui = new UI();
        }
        

     

        private void HighScoreButton_Click(object sender, EventArgs e)
        {
           ui.game.getHighScores();
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            //InGameRenderInfo returnInfo = _gameController.startGame();
            //enderScene(returnInfo);
        }

        private void RenderScene(InGameRenderInfo info)
        {
            label1.Text = info.ArrowCount.ToString();

            label2.Text = info.GoldCount.ToString();

            button1.Text = info.CaveConnections[13,1].ToString();
        }

        private void GoldCount_Click(object sender, EventArgs e)
        {

        }

        private void ArrowCount_Click(object sender, EventArgs e)
        {

        }

      

        private void button7_Click(object sender, EventArgs e)
        {
            bool isVisible = panel1.Visible;

            if(isVisible)
            {
                panel1.Visible = false;
            }
            else
            { panel1.Visible = true; }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            ui.game.movePlayer(1);
        }
        private void button5_Click(object sender, EventArgs e)
        {
            ui.game.movePlayer(2);
        }
        private void button3_Click(object sender, EventArgs e)
        {
            ui.game.movePlayer(3);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ui.game.movePlayer(4);

        }
        private void button4_Click(object sender, EventArgs e)
        {
            ui.game.movePlayer(5);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            ui.game.movePlayer(6);
        }

        

     

       
    }
}
    



