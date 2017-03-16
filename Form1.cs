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
        private WumpusTest.GameControl _gameController;

        public Form1()
        {
            InitializeComponent();
            _gameController = new WumpusTest.GameControl();
        }

        private UI _UI;

     

        private void HighScoreButton_Click(object sender, EventArgs e)
        {
            _gameController.getHighScores();
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            //InGameRenderInfo returnInfo = _gameController.startGame();
            //enderScene(returnInfo);
        }

        private void RenderScene(InGameRenderInfo info)
        {
            label1.Text = info.ArrowCount.ToString();

            // Add more updates here.
        }

        private void GoldCount_Click(object sender, EventArgs e)
        {

        }

        private void ArrowCount_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
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
    }
}
    



