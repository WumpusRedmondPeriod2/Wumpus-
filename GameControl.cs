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

        //constructor - initializes all objects
        public GameControl()
        {
            //initialization
            render = new InGameRenderInfo();
            render.IsGameOver = false;
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
        
        public startGame(){

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

        //shoots an arrow at specified room
        private bool shoot(int room)
        {

            if (player.getNumOfArrows() > 0)
            {
                player.updateInventory(-1, 0);
                if (map.hasWumpus(room))
                {
                    return true;
                }
                return false;
            }

            ////TODO remove this
            return true;
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

        public buyArrows(){

        }
        //encounters a hazard and asks questions accordingly 
        private void encounterHazard(int hazard)
        {

        }

        //asks a question
        private void updateQuestion()
        {
            question = trivia.getQuestion();
            answers = trivia.getPossibleAnswers();
        }

        private Boolean checkAnswer(int playerChoice)
        {
            ////TODO UI needs to get an answer from the player and return as char
            if (trivia.isAnswerCorrect(answers[playerChoice]))
            {
                updateQuestion();
                return true;
            }
            return false;
        }
    }
}
