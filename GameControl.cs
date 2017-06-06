using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



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
        int reason = 0;
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
            reason = 0;
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
            render.popUp.Add(message);
        }
        public void resetPop()
        {
            render.popUp = new ArrayList();
        }

        public void encounterBats()
        {
            map.moveBatRandom();
            map.movePlayerRandom();
            resetPop();
            updatePop(1);
            updateRender();
        }
        public void encounterPit()
        {
            updateQuestion(3);
            reason = 2;
        }
        public void encounterWumpus()
        {
            updateQuestion(5);
            reason = 3;
        }
        //encounters a hazard and asks questions accordingly 
        private InGameRenderInfo encounterHazard(int hazard)
        {
            updatePop(hazard);
            switch (hazard)
            {
                case 1:
                    encounterBats();
                    break;
                case 2:
                    encounterPit();
                    break;
                case 3:
                    encounterWumpus();
                    break;
            }
            return render;
        }
         
        //moves the Player
        public InGameRenderInfo movePlayer(int room)
        {
            resetPop();
            //player gets gold, updates render for UI
            player.incGold();
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

        public bool[] hazards()
        {
            //returns a bool array
            //First element indicates presence of wumpus in rooms
            //subsequent elements indicate presence of pits or bats
            bool[] hazards = new bool[3];
            if (map.encounterHazard() == 3)
            {
                hazards[0] = true;
            }
            if (map.encounterHazard() == 2)
            {
                hazards[1] = true;
            }
            if (map.encounterHazard() == 0)
            {
                hazards[2] = true;
            }
            return hazards;
        }

        public InGameRenderInfo updateRender()
        {
            render.warnings = map.checkForHazards();
            render.wumpusLocation = map.getWumpusLocation();
            int[] pitlocations = map.getBottomLessPitLocations();
            int[] batlocations = map.getBatsLocations();
            render.pitlocation1 = pitlocations[0];
            render.pitlocation2 = pitlocations[1];
            render.batlocation1 = batlocations[0];
            render.batlocation2 = batlocations[1];
            render.currentPaths = map.getCurrentConnections(map.getPlayerLocation());
            render.ArrowCount = player.getNumOfArrows();
            render.GoldCount = player.getGold();
            render.score = player.playerScore();
            render.numberOfTurns = player.getNumOfTurns();
            render.roomNum = map.getPlayerLocation();
            return render;
        }

        public InGameRenderInfo buyArrows()
        {
            updateQuestion(3);
            reason = 1;
            updateRender();
            return render;
        }
        public InGameRenderInfo buySecret()
        {
            updateQuestion(3);
            reason = 4;
            updateRender();
            return render;
        }
        public InGameRenderInfo updateSecret()
        {
            Random rnd = new Random();
            String sec = "";
            switch (rnd.Next(10))
            {
                case 0:
                    sec = "Not all secrets are useful. Some secrets are the same!";
                    break;
                case 1:
                    sec = "The UK Royal coat of arms has a unicorn and an English lion.";
                    break;
                case 2:
                    sec = "Try drawing the pathways on a piece of paper. For a challenge, map the cave!";
                    break;
                case 3:
                    sec = "Doom was released the same year the EU was formally established.";
                    break;
                case 4:
                    sec = "Beware! There is a pit in room " + map.getBottomLessPitLocations()[0];
                    break;
                case 5:
                    sec = "The original Hunt the Wumpus was written in BASIC!";
                    break;
                case 6:
                    sec = "It costs three gold coins to buy a secret. Was it worth it?";
                    break;
                case 7:
                    sec = "Nirvana's first album isn't actually used to remove stains.";
                    break;
                case 8:
                    sec = "During World War II, the filling of Twinkies was replaced with vanilla cream.";
                    break;
                case 9:
                    sec = "Be careful! Falling into a pit may return you to your starting room, room " + map.getInitialLoc();
                    break;
                    
            }
            render.secret = sec;
            return render;
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
            render.correct = false;
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
        public void checkAnswer(String[] playerChoice, int numOfQ)
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
            resetPop();
            if (correct > 0)
            {
                render.correct = true;
                switch (reason)
                {
                    case 1:
                        player.updateInventory(1, 0);
                        break;
                    case 2:
                        map.moveToInitial();
                        updatePop(4);
                        break;
                    case 3:
                        map.moveWumpusAway();
                        updatePop(6);
                        break;
                    case 4:
                        updateSecret();
                        break;
                }
                reason = 0;
            }
            else
            {
                switch (reason)
                {
                    case 2:
                        updatePop(5);
                        break;
                    case 3:
                        updatePop(7);
                        break;
                }
                render.correct = false;
            }
            player.updateInventory(0, 0 - numOfQ);
            updateRender();

        }
    }
}