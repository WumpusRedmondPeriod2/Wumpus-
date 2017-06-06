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
    public partial class ScoreScreen : Form
    {
        public ScoreScreen()
        {
            InitializeComponent();
            HighScore hscores = new HighScore();
            String[] scoreNames = hscores.getNames();
            int[] highScores = hscores.getScores();
            
            for (int i = 0; i < 5; i++)
            {
                names.Text += scoreNames[i] + "\n";
                scores.Text += highScores[i] + "\n";
            }
        }

        private void ScoreScreen_Load(object sender, EventArgs e)
        {

        }
    }
}
