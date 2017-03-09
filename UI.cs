 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WumpusTest
{
    class UI
    {
        public UI()
        {

        }
        //This starts the game if the user enter yes 
        public static Boolean startGame(int start)
        {
            return false;
        }
        //This moves the player if wasd are pressed
        public static void movePlayer(int player)
        {
            player.movePlayer;
        }
        //This controls the score for the player
        public static void score (int playerScore)
        {
            GameControl.getScore;
        }
        //This keeps track of number of arrows
        public static void numberOfArrows(int arrowCount)
        {
            movePlayer.arrowCount;

        }
        //This draws the caves when you enter a new room
        public static void drawCave(int cave)
        {
            GameControl.getPathways();
        }
        //This displays the warnings for a player encountering an object
        public static void encounterHazard(int hazard)
        {
            Map.displayWarningMessage;  
        }
        //This shows the high score in the menu when playing the game
        public static void highScore (int score)
        {
            GameControl.displayHighScore;   
        }
        //This updates the game after every new move is made
        public static void updateGame(int update)
        {
            GameControl.updateUI();
        }
    }
}
