

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

        private Trivia trivia;
        private HighScore scores;
        private Map map;
        private Player player;
        
        //constructor - initializes all objects
        public GameControl()
        {
            //initialization
            trivia = new Trivia();
            scores = new HighScore();
            map = new Map();
            player = new Player();

        }


        //logs the high score if it is one, then ends game
        public void endGame()
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

        //shoots an arrow at specified room
        public bool shoot(int room)
        {
            
            if (player.getNumOfArrows() > 0)
            {
                player.updateInventory(-1,0);
                if(map.hasWumpus(room)){
                    return true;
                } 
                return false;
            }

            ////TODO remove this
            return true;
        }

        //sends high scores to be displayed
        public void getHighScores()
        {
       //UI.highScore(scores.highScores());
        }

        //moves the Player
        public InGameRenderInfo movePlayer(int room)
        {
            InGameRenderInfo render = new InGameRenderInfo();
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
        }


        //encounters a hazard and asks questions accordingly 
        public void encounterHazard(int hazard)
        {

        }

        //asks a question
        private bool askQuestion()
        {
            ////TODO implement a Question object
            ////Question q = trivia.generateQuestion();
            //String q = trivia.getQuestion();

            ////TODO UI needs a method to display the question and get the selected answer
            ////UI.displayQuestion(q);

            //char a = trivia.getAnswer();

            ////TODO UI needs to get an answer from the player and return as char
            //if (WumpusTest.UI.getAnswer() == a)
            //{
            //    return true;
            //}
            //else
            //{
            //    return false;
            //}

            ////returns if player got question right
        }
    }
}
