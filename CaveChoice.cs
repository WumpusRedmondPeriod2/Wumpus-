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
    public partial class CaveChoice : Form
    {
        private String userName;
        public CaveChoice()
        {
            InitializeComponent();
            enterButton.Enabled = false;
            label1.BackColor = System.Drawing.Color.Transparent;
            playerName.BackColor = System.Drawing.Color.Transparent;
            radioButton1.BackColor = System.Drawing.Color.Transparent;
            radioButton2.BackColor = System.Drawing.Color.Transparent;
            radioButton3.BackColor = System.Drawing.Color.Transparent;
            radioButton4.BackColor = System.Drawing.Color.Transparent;
            radioButton5.BackColor = System.Drawing.Color.Transparent;
        }

        private void enterButton_Click(object sender, EventArgs e)
        {
            int caveChosen = 0;
            if (radioButton1.Checked)
            {
                caveChosen = 1;
            }
           else if (radioButton2.Checked)
            {
                caveChosen = 2;
            }
           else if (radioButton3.Checked)
            {
                caveChosen = 3;
            }
           else if (radioButton4.Checked)
            {
                caveChosen = 4;
            }
           else if (radioButton5.Checked)
            {
                caveChosen = 5;
            }
            this.Hide();
            var form1 = new Form1(caveChosen);
            form1.Closed += (s, args) => this.Close();
            form1.Show();
        }
        private void enableEnterButton()
        {
            if(playerNameInput.Text.Length != 0 && (radioButton1.Checked || radioButton2.Checked ||radioButton3.Checked || radioButton4.Checked || radioButton5.Checked))
            {
                enterButton.Enabled = true;
            }
        }
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            enableEnterButton();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            enableEnterButton();
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            enableEnterButton();
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            enableEnterButton();
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            enableEnterButton();
        }

        private void playerNameInput_TextChanged(object sender, EventArgs e)
        {
            enableEnterButton();
            userName = playerName.Text;
        }
    }
}
