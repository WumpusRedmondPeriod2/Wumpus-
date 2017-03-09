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
            //TODO subtract arrows from player
            //TODO need method to get location of WUMPUS
            if (player.getNumOfArrows() > 0)
            {
                if (map.getWumpusLocation == room)
                {
                    endGame();
                    return true;
                }
                else
                {
                    return false;
                }
                //if yes, kill, return true
                //if no, return false;
            }
        }

        //sends high scores to be displayed
        public void getHighScores()
        {
            //TODO UI needs to fix their highScore method to accept an array of integers
            //UI.highScore(scores.highScores());
        }

        //moves the Player - returns int of what occurred
        public int movePlayer(int room)
        {   
            map.updateLocation(room);

            //this updates the room
            UI.updateRoom(Map.getRoom());
            
            encounterHazard();

            if (askQuestion())
            {
                //TODO player needs to keep track of values
                player.addGold();
            }

            getWarnings();
        }

        private bool[] getWarnings()
        {
            return map.getWarnings();
        }

        //encounters a hazard and asks questions accordingly
        public void encounterHazard(int hazard)
        {
            switch (hazard){
                case 0: encounterBat();
                case 1: encounterPit();
                case 2: encounterWumpus();
            }
        }

        public void encounterBat()
        {

        }

        public void encounterPit()
        {

        }

        public void encounterWumpus()
        {

        }

        //asks a question
        private bool askQuestion()
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