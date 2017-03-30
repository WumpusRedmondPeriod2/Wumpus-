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
            InGameRenderInfo returnInfo = ui.game.startGame();
            RenderScene(returnInfo);
        }

        private void RenderScene(InGameRenderInfo info)
        {
            label1.Text = info.ArrowCount.ToString();

            label2.Text = info.GoldCount.ToString();

            button1.Text = info.CaveConnections[13,1].ToString();

            button2.Text = info.CaveConnections[14, 2].ToString();

            button3.Text = info.CaveConnections[15, 3].ToString();

            button4.Text = info.CaveConnections[16, 4].ToString();

            button5.Text = info.CaveConnections[17, 5].ToString();

            button6.Text = info.CaveConnections[18, 6].ToString();
        }

        private void GoldCount_Click(object sender, EventArgs e)
        {
            int startingGoldCount = 100;
        }

        private void ArrowCount_Click(object sender, EventArgs e)
        {
            int startingArrowAmount = 30;
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
            InGameRenderInfo renderInformation = ui.game.movePlayer(1);
            RenderScene(renderInformation);

        }
        private void button5_Click(object sender, EventArgs e)
        {
            InGameRenderInfo renderInformation = ui.game.movePlayer(2);
            RenderScene(renderInformation);
        }
        private void button3_Click(object sender, EventArgs e)
        {
            InGameRenderInfo renderInformation = ui.game.movePlayer(3);
            RenderScene(renderInformation);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            InGameRenderInfo renderInformation = ui.game.movePlayer(4);
            RenderScene(renderInformation);

        }
        private void button4_Click(object sender, EventArgs e)
        {
            InGameRenderInfo renderInformation = ui.game.movePlayer(5);
            RenderScene(renderInformation);

        }

        private void button6_Click(object sender, EventArgs e)
        {
            InGameRenderInfo renderInformation = ui.game.movePlayer(6);
            RenderScene(renderInformation);
        }

        //private void HealthBar_Click(object sender, EventArgs e)
        //{
        //    int maxHealth = 100;
        //    int minHealth = 0;
        //}
        public String question(String q)
        {
            return q;
        }
        public  int [,] answerChoices(int [,] a)
        {
            return a;
        }

        
    }
}
    



