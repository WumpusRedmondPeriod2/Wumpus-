using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//3.8.2017 - updated stubbed methods


namespace Wumpus
{
    class GameControl
    {   
        //TODO replace all "UI" in code with "ui" after the UI fixes error of using static

        private Trivia trivia;
        private HighScore scores;
        private Map map;
        private Player player;
        private UI ui;

        Boolean isRunning;

        //constructor - initializes all objects
        public GameControl()
        {   
            //initialization
            trivia = new Trivia();
            scores = new HighScore();
            map = new Map();
            player = new Player();
            ui = new UI();

            isRunning = true;
        }

        //runs the game
        public void gameLoop()
        {
            while (isRunning)
            {   

                //TODO make the checks all the same method in map
                //TODO give each hazard a better number than already assigned
                //TODO make encounter hazard seperate than display warning
                //encounters hazards
                if (map.encounterBats())
                {
                    UI.encounterHazard(0);
                }
                else if (map.encounterWumpus())
                {
                    UI.encounterHazard(1);
                }
                else if (map.bottomlessPit())
                {
                    UI.encounterHazard(2);
                }

                //checks for hazards
                if (map.checkForBats())
                {
                    UI.encounterHazard(0);
                }
                else if (map.checkForWumpus())
                {
                    UI.encounterHazard(1);
                }
                else if (map.checkForBottomlessPit())
                {
                    UI.encounterHazard(2);
                }

                //TODO UI needs a player purchased arrow method, need to get arrows purchased
                //TODO purchase is not supposed to need 2 parameters - get rid of gold parameter
                player.userPurchase(0,0);
                
                //TODO UI needs a make player shoot method, get room number of room shot at from UI
                if (shoot(0) == true)
                {
                    endGame();
                }

                //TODO make movePlayer more detailed
                //TODO get the room moved into by the UI
                movePlayer(0);
            }

        }
        
        //the menu function - allows to go to see high score or to run gameloop
        public void menu()
        {   
            //TODO UI needs to add a displayMenu method
            int selection = UI.displayMenu();
            if (selection == 0)
            {
                gameLoop();
            }
            else if (selection == 1)
            {
                getHighScores();
            }
            else
            {
                //close program here
            }
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
        public Boolean shoot(int room){
            //TODO subtract arrows from player
            //TODO need method to get location of WUMPUS
            if (player.getNumOfArrows() > 0)
            {
                //check if room has WUMPUS
                //if yes, kill, return true
                //if no, return false;
            }

            //TODO remove this
            return true;
        }

        //sends high scores to be displayed
        public void getHighScores(){
            //TODO UI needs to fix their highScore method to accept an array of integers
           //UI.highScore(scores.highScores());
        }
        
        //moves the Player
        public void movePlayer(int room)
        {
            //TODO write a method in map to update the location of the palyer
            //map.move(room)
            if (askQuestion())
            {
                //TODO player needs to keep track of values
                player.addGold();
            }
        }

        //encounters a hazard and asks questions accordingly
        public void encounterHazard(int hazard)
        {

        }
        
        //asks a question
        private Boolean askQuestion()
        {
            //TODO implement a Question object
            //Question q = trivia.generateQuestion();
            String q = trivia.getQuestion();

            //TODO UI needs a method to display the question and get the selected answer
            //UI.displayQuestion(q);

            char a = trivia.getAnswer();

            //TODO UI needs to get an answer from the player and return as char
            if (UI.getAnswer() == a)
            {
                return true;
            }
            else
            {
                return false;
            }

            //returns if player got question right
        }
    }
}
