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
        //render contains all information that needs to be displayed by UI
        public InGameRenderInfo render;
        
        private Trivia trivia;
        private HighScore scores;
        private Map map;
        private Player player;

        //array of the random facts that appear whenever the player moves
        private string[] factArray;
        //index that the factArray is currently displaying
        private int factnum;
       
        //tells checkAnswer what method called it, what should happen
        //0 - nothing, 1 - player bought arrows, 2 - player fell into pit
        //3 - player found wumpus, 4 - player bought secrets
        private int reason = 0;

        //constructor
        public GameControl(int cavenum, String playerName)
        {
            //re-initializes values
            startGame(cavenum);
            //sets player's name for current playthrough
            player.setPlayerName(playerName);
        }

        //resets all objects to initial states, takes the number of cave as parameter
        public void startGame(int cavenum)
        {
            //initializes fields
            map = new Map(cavenum);
            render = new InGameRenderInfo();
            trivia = new Trivia();
            scores = new HighScore();
            player = new Player();
            reason = 0;
            loadFact();

            //loads cave pathways into render to be displayed
            render.CaveConnections = map.getConnections();
            //updates render to be displayed           
            updateRender();
        }
        
        //increments turn count
        public void updateTurns()
        {
            player.addturn();
        }
        //returns the number of turns taken
        public int returnTurns()
        {
            return player.getNumOfTurns();
        }
        //return the player's current score
        public int returnScore()
        {
            return player.playerScore();
        }
        //controls Wumpus behavior, moves the Wumpus randomly
        private void moveWumpus()
        {
            map.moveWumpusAtRandom();
        }
        //returns the player's current room number
        public int room()
        {
            return map.getPlayerLocation();
        }

        //sets render values to get UI to end the game, adds score to high scores if it is a top ten score
        public void endGame(int cause)
        {
            render.IsGameOver = true;
            render.cause = cause;
            render.score = returnScore();
            scores.addNewHighScore(player.getPlayerName(), render.score);
        }

        //adds a message to the messages that are displayed
        //0 - none, 1 - moved by bats, 2 - fall into pit, 3 - encounter Wumpus
        //4 - escape pit, 5- death by pit, 6 - defeat wumpus in trivia, 7 - eaten by Wumpus
        //8 - shot the wumpus, 9 - missed the Wumpus
        public void updatePop(int message)
        {
            render.popUp.Add(message);
        }
        //removes all messages from the display
        private void resetPop()
        {
            render.popUp = new ArrayList();
        }

        //encounters a hazard and acts accordingly 
        private InGameRenderInfo encounterHazard(int hazard)
        {
            //displays hazard's message
            updatePop(hazard);
            //1 - bats, 2 - pit, 3 - Wumpus
            //resolves in that order - hazards have priority over Wumpus
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
            //returns the render info to UI
            return render;
        }
        private void encounterBats()
        {
            //randomly moves the bat
            map.moveBatRandom();
            //randomly moves the player
            map.movePlayerRandom();
            //reset the messages
            resetPop();
            //display "moved by bats"
            updatePop(1);
            //update the render for UI
            updateRender();
        }
        private void encounterPit()
        {
            //asks three questions
            updateQuestion(3);
            //tells checkAnswer that questions are for the pit
            reason = 2;
        }
        private void encounterWumpus()
        {
            //asks five questions
            updateQuestion(5);
            //tells checkAnswer that questions are for Wumpus
            reason = 3;
        }

        //moves the Player to an adjacent room
        public InGameRenderInfo movePlayer(int room)
        {
            //resets the messages
            resetPop();
            //player gets gold, updates render for UI
            player.incGold();
            //updates location of player, actually moves player
            map.updatePlayerLocation(room);
            //updates and returns render to UI
            updateRender();
            return render;
        }
        //logic check after moving - checks player inventory
        //checks for hazards, then updates render
        public InGameRenderInfo moveCheck()
        {
            //ends game if player runs out of gold
            if (player.getGold() < 0)
            {
                endGame(1);
            }
            //ends game if player runs out of arrows
            if (player.getNumOfArrows() <= 0)
            {
                endGame(2);
            }
            //checks for hazards and acts accordingly
            encounterHazard(map.encounterHazard());
            //updates and returns render info
            updateRender();
            return render;
        }

        //loads all the facts into fact array, sets current fact to first one
        private void loadFact()
        {
            factnum = 0;
            factArray = System.IO.File.ReadAllLines(@"Facts.txt");

        }
        //updates the current displayed fact
        public void updateFact()
        {
            //cycles fact every 100 facts
            if (factnum >= 100)
            {
                factnum -= 100;
            }
            //sets fact to be displayed
            render.fact = factArray[factnum];
            //increases for next fact
            factnum++;
        }

        //updates InGameRenderInfo render - UI uses this to know what to display
        public InGameRenderInfo updateRender()
        {
            //moves the Wumpus
            moveWumpus();
            //updates locations of hazards and player in render
            render.wumpusLocation = map.getWumpusLocation();
            int[] pitlocations = map.getBottomLessPitLocations();
            int[] batlocations = map.getBatsLocations();
            render.pitlocation1 = pitlocations[0];
            render.pitlocation2 = pitlocations[1];
            render.batlocation1 = batlocations[0];
            render.batlocation2 = batlocations[1];
            render.roomNum = map.getPlayerLocation();
            //updates warnings to be displayed
            render.warnings = map.checkForHazards();
            //updates the current pathways that player can travel through
            render.currentPaths = map.getCurrentConnections(map.getPlayerLocation());
            //updates the inventory
            render.ArrowCount = player.getNumOfArrows();
            render.GoldCount = player.getGold();
            //updates the player's score and the number turns 
            render.numberOfTurns = player.getNumOfTurns();
            render.score = player.playerScore();
            //returns the render info
            return render;
        }

        //player is prompted questions, sets reason for checkAnswer for arrows
        public InGameRenderInfo buyArrows()
        {
            //prompts three questions, sets reason for arrows
            updateQuestion(3);
            reason = 1;
            //update and return render info
            updateRender();
            return render;
        }
        //player is prompted questions, sets reason for checkAnswer for a secret
        public InGameRenderInfo buySecret()
        {
            //prompts three questions, set reason for secrets
            updateQuestion(3);
            reason = 4;
            //update and return render info
            updateRender();
            return render;
        }
        //updates the secret that is displayed to the one last purchased
        private InGameRenderInfo updateSecret()
        {
            String sec = "";
            //generates a random secret - you can get the same one twice!
            Random rnd = new Random();
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
            //updates secret in render info and returns it
            render.secret = sec;
            return render;
        }

        //shoots an arrow at specified adjacent room
        //returns true if it hits, false if it missses
        public bool shoot(int room)
        {
            //does player have arrows
            if (player.getNumOfArrows() > 0)
            {
                //removes arrow
                player.updateInventory(-1, 0);
                //checks to see if hit
                if (map.getWumpusLocation() == room)
                {
                    //returns true when hit
                    return true;
                }
            }
            //returns false when miss
            return false;
        }
        //moves the Wumpus away if you miss your shot
        private void moveWumpusIfArrowMissed()
        {
            map.moveWumpusAway();
            //updates render info
            updateRender();
        }

        //asks a series of questions, numOfQ is questions asked
        public void updateQuestion(int numOfQ)
        {
            //creates an array of questions and answers in render info
            //creates blank arrays
            render.question = new String[numOfQ];
            render.answers = new String[numOfQ][];
            //fills each array with questions and answers
            for (int i = 0; i < numOfQ; i++)
            {
                //gets current question info
                render.question[i] = trivia.getQuestion();
                render.answers[i] = trivia.getPossibleAnswers();
                //gets next question in set
                trivia.newQuestion();
            }
            //tells the UI how many questions to display
            render.numOfQuestions = numOfQ;
            //tells UI that questions should be asked
            render.askQuestion = true;
        }
        //checks the player's responses
        //takes the player's responses and checks to see if they passed the test
        //gives reward/punishment based on reason, which tells which method called checkAnswer
        public void checkAnswer(String[] playerChoice)
        {
            //sets number correct to 0
            int correct = 0;
            //increases correct if correct, decreases if incorrect
            //if correct > 0, player got best 2/3 or 3/5
            for (int i = 0; i < playerChoice.Length; i++)
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
            //resets render info to state where questions are not asked
            render.askQuestion = false;
            //resets messages to be displayed
            resetPop();
            //if player won
            if (correct > 0)
            {
                switch (reason)
                {
                    //player gets arrow
                    case 1:
                        player.updateInventory(1, 0);
                        break;
                    //player beat pit, returns to original room
                    case 2:
                        map.moveToInitial();
                        //displays message
                        updatePop(4);
                        break;
                    //player beat Wumpus, moves wumpus away
                    case 3:
                        map.moveWumpusAway();
                        //displays message
                        updatePop(6);
                        break;
                    //player recieves a secret
                    case 4:
                        updateSecret();
                        break;
                }
                //resets reason for checkAnswer
                reason = 0;
            }
            //if player lost
            else
            {
                switch (reason)
                {
                    //ends game, 3 - due to pit
                    case 2:
                        endGame(3);
                        break;
                    //ends game, 4 - due to wumpus
                    case 3:
                        endGame(4);
                        break;
                }
            }
            //removes gold for each question answered
            player.updateInventory(0, 0 - playerChoice.Length);
            //updates render for ui display
            updateRender();
        }
    }

}
