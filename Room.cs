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
    public partial class Room : Form
    {
        public GameControl game;
        InGameRenderInfo renderInformation = new InGameRenderInfo();
        String[] playerChoice;
        private int currentQ = 0;
        private int click = 0;
        private int cavenum;
        public Room(int cavenum)
        {
            InitializeComponent();
            this.cavenum = cavenum;
            game = new GameControl(cavenum);
            renderInformation = game.updateRender();
            playerChoice = new String[renderInformation.numOfQuestions];
            room1.Visible = false;
            room2.Visible = false;
            room3.Visible = false;
            room4.Visible = false;
            room5.Visible = false;
            room6.Visible = false;
            //correctness.Text = ""; To implement later
        }
        private void changeSize()
        {
            this.Size = new Size(976, 582);
        }
        private void Room_Load(object sender, EventArgs e)
        {
            changeSize();
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            game.startGame();
            RenderScene(game.render);
            StartButton.Visible = false;
            StartButton.Enabled = false;
        }
        private void RenderScene(InGameRenderInfo info)
        {
            label1.Text = "Gold Count: " + info.GoldCount.ToString();
            label2.Text = "Arrow Count: " + info.ArrowCount.ToString();
            turnLabel.Text = "Number of Turns: " + info.numberOfTurns.ToString();
            playerScore.Text = "Score: " + info.score.ToString();
            RoomNum.Text = "Room: " + info.roomNum;
            renderPop(info);
            if (info.currentPaths[0] > 0)
            {
                room1.Visible = true;
            }
            else
            {
                room1.Visible = false;
            }

            if (info.currentPaths[1] > 0)
            {
                room2.Visible = true;
            }
            else
            {
                room2.Visible = false;
            }

            if (info.currentPaths[2] > 0)
            {
                room3.Visible = true;
            }
            else
            {
                room3.Visible = false;
            }
            if (info.currentPaths[3] > 0)
            {
                room4.Visible = true;
            }
            else
            {
                room4.Visible = false;
            }
            if (info.currentPaths[4] > 0)
            {
                room5.Visible = true;
            }
            else
            {
                room5.Visible = false;
            }
            if (info.currentPaths[5] > 0)
            {
                room6.Visible = true;
            }
            else
            {
                room6.Visible = false;
            }

            //if (info.askQuestion)
            //{
            //    renderQuestion(info);
            //    panel1.Visible = true;
            //}
            //else
            //{
            //    panel1.Visible = false;
            //}
            //textDisplay.Text = "";
            //for (int i = 0; i < info.warnings.Count; i++)
            //{
            //    textDisplay.Text += renderPop(info);
            //    textDisplay.Text += info.warnings[i] + "\n";
            //}
            //renderQuestion(info);
        }

        private void room1_Click(object sender, EventArgs e)
        {
            game.updateTurns();
            game.movePlayer(1);
            RenderScene(game.render);
        }

        private void room2_Click(object sender, EventArgs e)
        {
            game.updateTurns();
            game.movePlayer(5);
            RenderScene(game.render);
        }

        private void room3_Click(object sender, EventArgs e)
        {
            game.updateTurns();
            game.movePlayer(3);
            RenderScene(game.render);
        }

        private void room4_Click(object sender, EventArgs e)
        {
            game.updateTurns();
            game.movePlayer(2);
            RenderScene(game.render);
        }

        private void room5_Click(object sender, EventArgs e)
        {
            game.updateTurns();
            game.movePlayer(4);
            RenderScene(game.render);
        }

        private void room6_Click(object sender, EventArgs e)
        {
            game.updateTurns();
            game.movePlayer(6);
            RenderScene(game.render);
        }
        //public void renderQuestion(InGameRenderInfo info)
        //{
        //    if (info.askQuestion)
        //    {
        //        question(info.question[currentQ]);
        //        answerChoices(info.answers[currentQ]);
        //    }
        //}
        private String renderPop(InGameRenderInfo info)
        {
            String message = "";
            switch (info.popUp)
            {
                case 0:
                    message = "";
                    break;
                case 1:
                    message = "You encounter bats. You have been moved to a random room.";
                    break;
                case 2:
                    message = "You fall into a pit! Answer two of three questions correctly to escape.";
                    break;
                case 3:
                    message = "You encounter the Wumpus! Answer three of his five questions to wound him!";
                    break;
                case 4:
                    message = "You escape the pit! You've been returned to where you started.";
                    break;
                case 5:
                    message = "You fall to your death.";
                    break;
                case 6:
                    message = "You wound the Wumpus and he escapes";
                    break;
                case 7:
                    message = "You are eaten by the Wumpus";
                    break;
            }
            return message;
        }
    }
}
