using System;
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
        public Form1(int cavenum)
        {
            InitializeComponent(); 
            game = new GameControl(cavenum);
            playerChoice = new String[game.render.numOfQuestions];
            this.cavenum = cavenum;
            button1.Visible = false;
            button1.Enabled = false;
            button2.Visible = false;
            button2.Enabled = false;
            button3.Visible = false;
            button3.Enabled = false;
            button4.Visible = false;
            button4.Enabled = false;
            button5.Visible = false;
            button5.Enabled = false;
            button6.Visible = false;
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
            if(info.roomNum == info.wumpusLocation)
            {
                wumpusPicture.Visible = true;
            }
            else
            {
                wumpusPicture.Visible = false;
            }
            if(info.roomNum == info.pitlocation1 || info.roomNum == info.pitlocation2)
            {
                pitPicture.Visible = true;
                playerImage.Visible = false;
            }
            else
            {
                playerImage.Visible = true;
                pitPicture.Visible = false;
            }
            if(info.roomNum == info.batlocation1 || info.roomNum == info.batlocation2)
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
            renderPop(info);
            if (info.currentPaths[0] > 0)
            {
                button1.Visible = true;
                button1.Text = info.currentPaths[0].ToString();
                button1.Enabled = true;
            }
            else
            {
                button1.Visible = false;
            }

            if (info.currentPaths[1] > 0)
            {
                button2.Visible = true;
                button2.Text = info.currentPaths[1].ToString();
                button2.Enabled = true;
            }
            else
            {
                button2.Visible = false;
            }

            if (info.currentPaths[2] > 0)
            {
                button3.Visible = true;
                button3.Text = info.currentPaths[2].ToString();
                button3.Enabled = true;
            }
            else
            {
                button3.Visible = false;
            }
            if (info.currentPaths[3] > 0)
            {
                button4.Visible = true;
                button4.Text = info.currentPaths[3].ToString();
                button4.Enabled = true;
            }
            else
            {
                button4.Visible = false;
            }
            if (info.currentPaths[4] > 0)
            {
                button5.Visible = true;
                button5.Text = info.currentPaths[4].ToString();
                button5.Enabled = true;
            }
            else
            {
                button5.Visible = false;
            }
            if (info.currentPaths[5] > 0)
            {
                button6.Visible = true;
                button6.Text = info.currentPaths[5].ToString();
                button6.Enabled = true;
            }
            else
            {
                button6.Visible = false;
            }

            if (info.askQuestion)
            {
                panel1.Visible = true;
            }
            else
            {
                panel1.Visible = false;
            }
            textDisplay.Text += renderPop(info) + "\n";
            textDisplay.Text = "Warnings: \n";
            for (int i = 0; i < info.warnings.Count; i++)
            {
                textDisplay.Text += info.warnings[i] + "\n";
            }
        }

        private void GoldCount_Click(object sender, EventArgs e)
        {
            label1.Text = "Gold Count: " + game.render.GoldCount;
        }

        private void ArrowCount_Click(object sender, EventArgs e)
        {
            label2.Text = "Arrow Count: " + game.render.ArrowCount;
        }
        private void move(int room){
            game.updateTurns();
            game.movePlayer(room);
            game.moveCheck();
            renderQuestion(game.render);
            RenderScene(game.render);
        }
        private void Room1_Click(object sender, EventArgs e)
        {
            move(1);
            implementHazardPics(game.render);
        }
        private void Room2_Click(object sender, EventArgs e)
        {
            move(5);
            implementHazardPics(game.render);

        }
        private void Room3_Click(object sender, EventArgs e)
        {
            move(3);
            implementHazardPics(game.render);

        }
        private void Room4_Click(object sender, EventArgs e)
        {
            move(2);
            implementHazardPics(game.render);
        }
        private void Room5_Click(object sender, EventArgs e)
        {
            move(4);
            implementHazardPics(game.render);
        }
        private void Room6_Click(object sender, EventArgs e)
        {
            move(6);
            implementHazardPics(game.render);
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
                        message = "";
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
                    case 5:
                        message = "You fall to your death.";
                        break;
                    case 6:
                        message = "You wound the Wumpus and he escapes";
                        break;
                    case 7:
                        message = "You are eaten by the Wumpus";
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
            game.startGame();
            RenderScene(game.render);
            string fileMovement = "tutorialMovement.txt";
            if (!File.Exists(fileMovement))
            {
                disableButtons();
                tutorialButton.Text = "Click on the sides of the hexagon \nto move between rooms. \nIf there is a hazard nearby you will get a \nwarning at the top of the screen. \nYou can purchase arrows and secrets and \nshoot arrows using the buttons on the right \nClick on the text to continue";
            }
        }
        private void Form1_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            
            int mouseX = e.X;
            int mouseY = e.Y;

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
            }
            else
            {
                if (currentQ + 1 == game.render.numOfQuestions)
                {
                    game.render.askQuestion = false;
                    panel1.Visible = false;
                    correctness.Visible = false;
                    game.checkAnswer(playerChoice, numOfQ);
                    currentQ = 0;
                    enableButtons();
                    RenderScene(game.render);
                }
                else
                {
                    correctness.Visible = false;
                    currentQ++;
                    renderQuestion(game.render);
                }
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
        }

        private void shootArrow_Click(object sender, EventArgs e)
        {
            disableButtons();
            shootArrowPanel.Visible = true;
            shootArrowPanel.Enabled = true;
            if (game.render.currentPaths[0] > 0)
            {
                room1.Visible = true;
                room1.Text = game.render.currentPaths[0].ToString();
                room1.Enabled = true;
            }
            else
            {
                room1.Visible = false;
            }

            if (game.render.currentPaths[1] > 0)
            {
                room2.Visible = true;
                room2.Text = game.render.currentPaths[1].ToString();
                room2.Enabled = true;
            }
            else
            {
                room2.Visible = false;
            }

            if (game.render.currentPaths[2] > 0)
            {
                room3.Visible = true;
                room3.Text = game.render.currentPaths[2].ToString();
                room3.Enabled = true;
            }
            else
            {
                room3.Visible = false;
            }
            if (game.render.currentPaths[3] > 0)
            {
                room4.Visible = true;
                room4.Text = game.render.currentPaths[3].ToString();
                room4.Enabled = true;
            }
            else
            {
                room4.Visible = false;
            }
            if (game.render.currentPaths[4] > 0)
            {
                room5.Visible = true;
                room5.Text = game.render.currentPaths[4].ToString();
                room5.Enabled = true;
            }
            else
            {
                room5.Visible = false;
            }
            if (game.render.currentPaths[5] > 0)
            {
                room6.Visible = true;
                room6.Text = game.render.currentPaths[5].ToString();
                room6.Enabled = true;
            }
            else
            {
                room6.Visible = false;
            }

        }

        private void shootArrowPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void room2_Click_1(object sender, EventArgs e)
        {
            bool shot = game.shoot(game.render.currentPaths[1]);
            resolveConflictWithWumpus(shot);
            enableButtons();
            shootArrowPanel.Enabled = false;
            shootArrowPanel.Visible = false;
        }

        private void room1_Click_1(object sender, EventArgs e)
        {
            bool shot = game.shoot(game.render.currentPaths[0]);
            resolveConflictWithWumpus(shot);
            enableButtons();
            shootArrowPanel.Enabled = false;
            shootArrowPanel.Visible = false;
        }

        private void room3_Click_1(object sender, EventArgs e)
        {
            bool shot = game.shoot(game.render.currentPaths[2]);
            resolveConflictWithWumpus(shot);
            enableButtons();
            shootArrowPanel.Enabled = false;
            shootArrowPanel.Visible = false;
        }

        private void room5_Click_1(object sender, EventArgs e)
        {
            bool shot = game.shoot(game.render.currentPaths[4]);
            resolveConflictWithWumpus(shot);
            enableButtons();
            shootArrowPanel.Enabled = false;
            shootArrowPanel.Visible = false;
        }

        private void room4_Click_1(object sender, EventArgs e)
        {
            bool shot = game.shoot(game.render.currentPaths[3]);
            resolveConflictWithWumpus(shot);
            enableButtons();
            shootArrowPanel.Enabled = false;
            shootArrowPanel.Visible = false;
        }

        private void room6_Click_1(object sender, EventArgs e)
        {
            bool shot = game.shoot(game.render.currentPaths[5]);
            resolveConflictWithWumpus(shot);
            enableButtons();
            shootArrowPanel.Enabled = false;
            shootArrowPanel.Visible = false;
        }
        private void resolveConflictWithWumpus(bool shot)
        {
            if(shot == true)
            {
                this.Hide();
                game.updatePop(8);
                renderPop(game.render);
                var form1 = new EndGame(game.render.score);
                form1.Closed += (s, args) => this.Close();
                form1.Show();
            }
            else
            {
                game.updatePop(9);
                renderPop(game.render);
            }
        }
    }
}




