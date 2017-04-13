using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//3.8.2017 - updated stubbed methods
//3.23.2017 kys

namespace WumpusTest
{
    class GameControl
    {
        
        InGameRenderInfo render;
        private Trivia trivia;
        private HighScore scores;
        private Map map;
        private Player player;
        private String question;
        private String[] answers;

        private bool qStatus;

        //constructor - initializes all objects
        public GameControl()
        {
            //initialization
            render = new InGameRenderInfo();
            render.IsGameOver = false;
            render.CaveConnections = map.getConnections();
            trivia = new Trivia();
            scores = new HighScore();
            map = new Map();
            player = new Player();

        }

        public InGameRenderInfo updateInfo()
        {
            render.ArrowCount = player.getNumberOfArrows();
            render.GoldCount = player.getGold();
            render.numberOfTurns = player.getNumOfTurns();
            return render;
        }
        
        public void startGame(){

        }

        //logs the high score if it is one, then ends game
        private void endGame()
        { 
            //TODO create a calculate score function here
            //TODO high score method should write a score if it is a high score

            /*
            if (scores.checkHighScore(score)
            {   
                scores.newHighScore(player.getScore());
            }
             */
        }

        //encounters a hazard and asks questions accordingly 
        private void encounterHazard(int hazard)
        {

        }
        //moves the Player
        public InGameRenderInfo movePlayer(int room)
        {
            //player gets gold, updates render for UI
            player.updateInventory(0, 1);
            render.GoldCount = player.getGold();
            //updates location of player
            map.move(room);
            render.CaveConnections = map.getConnections();
            if (player.getGold < 1)
            {
                render.IsGameOver = true;
            }
            return render;
        }

        public InGameRenderInfo buyArrows(String[] playerChoice, int numOfQ)
        {

            if (checkAnswer(playerChoice, numOfQ))
            {
                player.updateInventory(2, 0);
            }
            return updateInfo();
        }

        //shoots an arrow at specified room
        public bool shoot(int room)
        {

            if (player.getNumOfArrows() > 0)
            {
                player.updateInventory(-1, 0);
                if (map.hasWumpus(room))
                {
                    return true;
                }
            }
            return false;
        }

        //asks a question
        public void updateQuestion(int numOfQ)
        {
            for (int i = 0; i < numOfQ; i++)
            {
                render.question[i] = trivia.getQuestion();
                render.answers[i] = trivia.getPossibleAnswers();
            }
            render.numOfQuestions = numOfQ;
            render.askQuestion = true;
        }

        public Boolean checkAnswer(String[] playerChoice, int numOfQ)
        {
            int correct = 0;
            for (int i = 0; i < numOfQ; i++)
            {
                if (playerChoice[i] == render.answers[i][5])
                {
                    correct++;
                }
                else
                {
                    correct--;
                }
            }
            render.askQuestion = false;
            if (correct > 0)
            {
                return true;
            }
            return false;
        }
    }
}