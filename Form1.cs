﻿using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
namespace WumpusTest
{
    public partial class Form1 : Form
    {
        public GameControl game;
        String[] playerChoice;
        private int currentQ = 0;
        private int numOfQ;
        private int click = 0;
        private int cavenum;
        public Form1(int cavenum, String playerName)
        {
            InitializeComponent();
            game = new GameControl(cavenum, playerName);

            playerChoice = new String[game.render.numOfQuestions];
            this.cavenum = cavenum;
            button1.Visible = true;
            button1.Enabled = false;
            button2.Visible = true;
            button2.Enabled = false;
            button3.Visible = true;
            button3.Enabled = false;
            button4.Visible = true;
            button4.Enabled = false;
            button5.Visible = true;
            button5.Enabled = false;
            button6.Visible = true;
            button6.Enabled = false;
            wumpusPicture.Visible = false;
            batPicture.Visible = false;
            pitPicture.Enabled = false;
            shootArrowPanel.Visible = false;
            shootArrowPanel.Enabled = false;
            correctness.Text = "";
            textDisplay.BackColor = System.Drawing.Color.Transparent;
            //wumpusPicture.Visible = false;
            //batPicture.Visible = false;
            pitPicture.Visible = false;
        }
        private void implementHazardPics(InGameRenderInfo info)
        {
            if (info.roomNum == info.wumpusLocation)
            {
                wumpusPicture.Visible = true;
            }
            else
            {
                wumpusPicture.Visible = false;
            }
            if (info.roomNum == info.pitlocation1 || info.roomNum == info.pitlocation2)
            {
                pitPicture.Visible = true;
                playerImage.Visible = false;
            }
            else
            {
                playerImage.Visible = true;
                pitPicture.Visible = false;
            }
            if (info.roomNum == info.batlocation1 || info.roomNum == info.batlocation2)
            {
                batPicture.Visible = true;
            }
            else
            {
                batPicture.Visible = false;
            }
            //if (info.popUp == 1)
            //{
            //    batPicture.Visible = true;
            //    pitPicture.Visible = false;
            //}
            //else if(info.popUp == 2)
            //{
            //    pitPicture.Visible = true;
            //    playerImage.Visible = false;
            //}
            //else if(info.popUp == 3)
            //{
            //    wumpusPicture.Visible = true;
            //}

        }
        private void StartButton_Click(object sender, EventArgs e)
        {

        }
        private void RenderScene(InGameRenderInfo info)
        {
            //game.updateFact();
            label1.Text = "Gold Count: " + info.GoldCount.ToString();
            label2.Text = "Arrow Count: " + info.ArrowCount.ToString();
            turnLabel.Text = "Number of Turns: " + info.numberOfTurns.ToString();
            playerScore.Text = "Score: " + info.score.ToString();
            roomLabel.Text = info.roomNum.ToString();
            label5.Text = info.wumpusLocation.ToString();
            label6.Text = info.pitlocation1.ToString();
            label7.Text = info.pitlocation2.ToString();
            label8.Text = info.batlocation1.ToString();
            label9.Text = info.batlocation2.ToString();
            button1.Text = Math.Abs(info.currentPaths[0]).ToString();
            button2.Text = Math.Abs(info.currentPaths[1]).ToString();
            button3.Text = Math.Abs(info.currentPaths[2]).ToString();
            button4.Text = Math.Abs(info.currentPaths[3]).ToString();
            button5.Text = Math.Abs(info.currentPaths[4]).ToString();
            button6.Text = Math.Abs(info.currentPaths[5]).ToString();
            implementHazardPics(game.render);
            if (info.currentPaths[0] > 0)
            {
                button1.Visible = true;
                button1.Enabled = true;
            }
            else
            {
                button1.Enabled = false;
            }

            if (info.currentPaths[1] > 0)
            {
                button2.Visible = true;
                button2.Enabled = true;
            }
            else
            {
                button2.Enabled = false;
            }

            if (info.currentPaths[2] > 0)
            {
                button3.Visible = true;
                button3.Enabled = true;
            }
            else
            {
                button3.Enabled = false;
            }
            if (info.currentPaths[3] > 0)
            {
                button4.Visible = true;
                button4.Enabled = true;
            }
            else
            {
                button4.Enabled = false;
            }
            if (info.currentPaths[4] > 0)
            {
                button5.Visible = true;
                button5.Enabled = true;
            }
            else
            {
                button5.Enabled = false;
            }
            if (info.currentPaths[5] > 0)
            {
                button6.Visible = true;
                button6.Enabled = true;
            }
            else
            {
                button6.Enabled = false;
            }

            if (info.askQuestion)
            {
                panel1.Visible = true;
            }
            else
            {
                panel1.Visible = false;
            }
            textDisplay.Text = renderPop(info) + "\n";
            textDisplay.Text += "Warnings: \n";
            for (int i = 0; i < info.warnings.Count; i++)
            {
                textDisplay.Text += info.warnings[i] + "\n";
            }
            if (!game.render.secret.Equals(""))
            {
                textDisplay.Text += "Last Secret Bought:\n" + game.render.secret;
            }

            textDisplay.Text += "Trivia: " + game.render.fact;
            endGameScreen();
        }
        private void GoldCount_Click(object sender, EventArgs e)
        {
            label1.Text = "Gold Count: " + game.render.GoldCount;
        }
        private void ArrowCount_Click(object sender, EventArgs e)
        {
            label2.Text = "Arrow Count: " + game.render.ArrowCount;
        }
        private void endGameScreen()
        {
            if (game.render.IsGameOver)
            {
                this.Hide();
                var form1 = new EndGame(game.render.cause, game.render.score);
                form1.Closed += (s, args) => this.Close();
            }
        }
        private void move(int room)
        {
            game.updateTurns();
            game.movePlayer(room);
            game.moveCheck();
            RenderScene(game.render);
            //renderQuestion needs to be last in method - doesn't disable buttons otherwise
            renderQuestion(game.render);
        }
        private void Room1_Click(object sender, EventArgs e)
        {
            move(1);
        }
        private void Room2_Click(object sender, EventArgs e)
        {
            move(5);
        }
        private void Room3_Click(object sender, EventArgs e)
        {
            move(3);
        }
        private void Room4_Click(object sender, EventArgs e)
        {
            move(2);
        }
        private void Room5_Click(object sender, EventArgs e)
        {
            move(4);
        }
        private void Room6_Click(object sender, EventArgs e)
        {
            move(6);
        }
        public void renderQuestion(InGameRenderInfo info)
        {
            if (info.askQuestion)
            {
                if (currentQ == 0)
                {
                    numOfQ = info.numOfQuestions;
                    playerChoice = new String[numOfQ];
                }
                panel1.Visible = true;
                question(info.question[currentQ]);
                answerChoices(info.answers[currentQ]);
                disableButtons();
            }
        }
        private String renderPop(InGameRenderInfo info)
        {
            String message = "";
            for (int i = 0; i < info.popUp.Count; i++)
            {
                switch ((int)info.popUp[i])
                {
                    case 0:
                        message += "";
                        break;
                    case 1:
                        message = "You have been moved to a random room by bats.";
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
                    case 6:
                        message = "You wound the Wumpus and he escapes";
                        break;
                    case 8:
                        message = "You hit the Wumpus!";
                        break;
                    case 9:
                        message = "You miss the Wumpus, it has now moved to a different room";
                        break;
                }
            }
            return message;
        }
        public void question(String q)
        {
            label3.Text = q;
        }
        public void answerChoices(String[] a)
        {
            radioButton1.Text = a[0];
            radioButton2.Text = a[1];
            radioButton3.Text = a[2];
            radioButton4.Text = a[3];
        }
        private void disableButtons()
        {
            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
            button5.Enabled = false;
            button6.Enabled = false;
            purchaseArrow.Enabled = false;
            purchaseSecrets.Enabled = false;
            shootArrow.Enabled = false;
        }
        private void enableButtons()
        {
            button1.Enabled = true;
            button2.Enabled = true;
            button3.Enabled = true;
            button4.Enabled = true;
            button5.Enabled = true;
            button6.Enabled = true;
            purchaseArrow.Enabled = true;
            purchaseSecrets.Enabled = true;
            shootArrow.Enabled = true;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            //changeSize();
            game.startGame(cavenum);
            RenderScene(game.render);
            string fileMovement = "tutorialMovement.txt";
            if (!File.Exists(fileMovement))
            {
                disableButtons();
                tutorialButton.Text = "Click on the sides of the hexagon \nto move between rooms. \nIf there is a hazard nearby you will get a \nwarning to the left of the room. \nYou can purchase arrows and secrets and \nshoot arrows using the buttons on the right \nClick on the text to continue";
            }
        }
        private void Form1_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
        {

        }
        private void EnterButton_Click(object sender, EventArgs e)
        {
            click++;
            if (click % 2 == 1)
            {
                String response;
                if (radioButton1.Checked)
                {
                    response = radioButton1.Text;
                }
                else if (radioButton2.Checked)
                {
                    response = radioButton2.Text;
                }
                else if (radioButton3.Checked)
                {
                    response = radioButton3.Text;
                }
                else if (radioButton4.Checked)
                {
                    response = radioButton4.Text;
                }
                else
                {
                    response = "n/a";
                }
                playerChoice[currentQ] = response;

                if (response.Equals(game.render.answers[currentQ][4]))
                {
                    correctness.Text = "Correct!";
                    correctness.Visible = true;
                }
                else
                {
                    correctness.Text = "Incorrect!";
                    correctness.Visible = true;
                }
                radioButton1.Checked = false;
                radioButton2.Checked = false;
                radioButton3.Checked = false;
                radioButton4.Checked = false;
                EnterButton.Text = "Next";
                radioButton1.Visible = false;
                radioButton2.Visible = false;
                radioButton3.Visible = false;
                radioButton4.Visible = false;
            }
            else
            {
                if (currentQ + 1 == game.render.numOfQuestions)
                {
                    game.render.askQuestion = false;
                    panel1.Visible = false;
                    correctness.Visible = false;
                    game.checkAnswer(playerChoice);
                    currentQ = 0;
                    enableButtons();
                    game.moveCheck();
                    RenderScene(game.render);
                }
                else
                {
                    correctness.Visible = false;
                    currentQ++;
                    renderQuestion(game.render);
                }
                radioButton1.Visible = true;
                radioButton2.Visible = true;
                radioButton3.Visible = true;
                radioButton4.Visible = true;
                radioButton1.Checked = false;
                radioButton2.Checked = false;
                radioButton3.Checked = false;
                radioButton4.Checked = false;
                EnterButton.Text = "Enter";
            }


        }

        private void correctness_Click(object sender, EventArgs e)
        {

        }

        private void RoomNum_Click(object sender, EventArgs e)
        {

        }

        private void textDisplay_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void purchaseArrow_Click(object sender, EventArgs e)
        {
            game.buyArrows();
            game.updateTurns();
            renderQuestion(game.render);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            //purchaseSecrets Method
            //Asks three trivia questions, if user gets two or more right gives random secret
            game.buySecret();
            game.updateTurns();
            renderQuestion(game.render);
        }

        private void playerScore_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void tutorialButton_Click(object sender, EventArgs e)
        {
            enableButtons();
            tutorialButton.Enabled = false;
            tutorialButton.Visible = false;
            RenderScene(game.render);
        }

        private void shootArrow_Click(object sender, EventArgs e)
        {
            disableButtons();
            shootArrowPanel.Visible = true;
            shootArrowPanel.Enabled = true;
            room1.Text = Math.Abs(game.render.currentPaths[0]).ToString();
            room2.Text = Math.Abs(game.render.currentPaths[1]).ToString();
            room3.Text = Math.Abs(game.render.currentPaths[2]).ToString();
            room4.Text = Math.Abs(game.render.currentPaths[3]).ToString();
            room5.Text = Math.Abs(game.render.currentPaths[4]).ToString();
            room6.Text = Math.Abs(game.render.currentPaths[5]).ToString();
            RenderScene(game.render);
        }

        private void shootArrowPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void shootClick(int direction)
        {
            bool shot = game.shoot(Math.Abs(game.render.currentPaths[direction]));
            resolveConflictWithWumpus(shot);
            enableButtons();
            shootArrowPanel.Enabled = false;
            shootArrowPanel.Visible = false;
            game.moveCheck();
            RenderScene(game.render);
        }

        private void room2_Click_1(object sender, EventArgs e)
        {
            shootClick(1);
        }

        private void room1_Click_1(object sender, EventArgs e)
        {
            shootClick(0);
        }

        private void room3_Click_1(object sender, EventArgs e)
        {
            shootClick(2);
        }

        private void room5_Click_1(object sender, EventArgs e)
        {
            shootClick(4);
        }

        private void room4_Click_1(object sender, EventArgs e)
        {
            shootClick(3);
        }

        private void room6_Click_1(object sender, EventArgs e)
        {
            shootClick(5);
        }
        private void resolveConflictWithWumpus(bool shot)
        {
            if (shot)
            {
                game.updatePop(8);
                game.endGame(0);
                endGameScreen();
            }
            else
            {
                game.updatePop(9);
                game.moveWumpusIfArrowMissed();
            }
            RenderScene(game.render);
        }

        private void button7_Click_1(object sender, EventArgs e)
        {
            shootArrowPanel.Visible = false;
            shootArrowPanel.Enabled = false;
            enableButtons();
            RenderScene(game.render);
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }
    }
}
