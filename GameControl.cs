using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//3.8.2017 - updated stubbed methods

namespace WumpusTest
{
    public class GameControl
    {
        
        public InGameRenderInfo render;
        private Trivia trivia;
      //  private HighScore scores;
        private Map map;
        private Player player;
        private int cavenum;       
        //constructor - initializes all objects
        public GameControl(int cavenum)
        {
            this.cavenum = cavenum;
            startGame();
        }
        
        public void startGame()
        {
            map = new Map(cavenum);
            //initialization
            render = new InGameRenderInfo();
            render.IsGameOver = true;
            render.CaveConnections = map.getConnections();
              trivia = new Trivia();
            //   scores = new HighScore();

            player = new Player();
            render.currentPaths = map.getCurrentConnections(map.getPlayerLocation());
            updateRender();
        }
        public void updateTurns()
        {
            player.addturn();
        }
        public int returnTurns()
        {
            return player.getNumOfTurns();
        }
        public int returnScore()
        {
            return player.playerScore();
        }
        public int room()
        {
            return map.getPlayerLocation();
        }
        //logs the high score if it is one, then ends game
        private void endGame(int cause)
        { 
            //0 - no more coins, 1 - pit, 2 - wumpus
            //TODO create a calculate score function here
            //TODO high score method should write a score if it is a high score

            /*
            if (scores.checkHighScore(score)
            {   
                scores.newHighScore(player.getScore());
            }
             */
        }

        public void updatePop(int message)
        {
            render.popUp = message;
        }
        public ArrayList returnSecrets()
        {
           ArrayList secrets = map.returnSecrets();
           
           return secrets;
        }
        //encounters a hazard and asks questions accordingly 
        private InGameRenderInfo encounterHazard(int hazard)
        {
            updatePop(hazard);
            switch (hazard)
            {
                case 1:
                    break;
                case 2:
                    updateQuestion(3);
                    break;
                case 3:
                    updateQuestion(5);
                    break;
            }
            return render;
        }
      
        //TODO
        public InGameRenderInfo responseHazard(int hazard)
        {
            updatePop(0);
            if (render.correct)
            {
                switch (hazard)
                {
                    case 1:
                        break;
                    case 2:
                        map.moveToInitial();
                        updatePop(4);
                        break;
                    case 3:
                        updatePop(6);
                        map.moveWumpusAway();
                        break;
                }
            }
            else
            {
                switch (hazard)
                {
                    case 2:
                        updatePop(5);
                        endGame(1);
                        break;
                    case 3:
                        updatePop(7);
                        endGame(2);
                        break;
                }
            }

            updateRender();
            return render;
            
        }        
        //moves the Player
        public InGameRenderInfo movePlayer(int room)
        {
            //player gets gold, updates render for UI
            player.updateInventory(0, 1);
            //updates location of player
            map.updatePlayerLocation(room);
            updateRender();
            return render;
        }

        public InGameRenderInfo moveCheck()
        {
            if (player.getGold() < 0)
            {
                endGame(0);
            }
            encounterHazard(map.encounterHazard());
            updateRender();
            return render;
        }

        public InGameRenderInfo updateRender()
        {
            render.warnings = map.checkForHazards();
            render.currentPaths = map.getCurrentConnections(map.getPlayerLocation());
            render.ArrowCount = player.getNumOfArrows();
            render.GoldCount = player.getGold();
            render.score = player.playerScore();
            render.numberOfTurns = player.getNumOfTurns();
            render.roomNum = map.getPlayerLocation();
            return render;
        }

        public InGameRenderInfo buyArrows(String[] playerChoice, int numOfQ)
        {

            if (checkAnswer(playerChoice, numOfQ))
            {
                player.updateInventory(2, 0);
            }
            return updateRender();
        }

        //shoots an arrow at specified room
        public bool shoot(int room)
        {

            if (player.getNumOfArrows() > 0)
            {
                player.updateInventory(-1, 0);
                if (map.getWumpusLocation() == room)
                {
                    return true;
                }
            }
            return false;
        }
        
        //asks a question
        public void updateQuestion(int numOfQ)
        {
            render.question = new String[numOfQ];
            render.answers = new String[numOfQ][];
            for (int i = 0; i < numOfQ; i++)
            {
                render.question[i] = trivia.getQuestion();
                render.answers[i] = trivia.getPossibleAnswers();
                trivia.newQuestion();
            }
            render.numOfQuestions = numOfQ;
            render.askQuestion = true;
        }
        

        public Boolean checkAnswer(String[] playerChoice, int numOfQ)
        {
            int correct = 0;
            for (int i = 0; i < numOfQ; i++)
            {
                if (playerChoice[i].Equals(render.answers[i][4])) 
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