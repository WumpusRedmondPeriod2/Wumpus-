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
        public static Boolean movePlayer(int player)
        {
            return false;
        }
        //This controls the score for the player
        public static int score(int playerScore)
        {
            Console.WriteLine("Return 0;");
            return playerScore;
        }
        //This keeps track of number of arrows
        public static int numberOfArrows(int arrowCount)
        {
            Console.WriteLine("Return 0;");
            return arrowCount;
        }
        //This draws the caves when you enter a new room
        public static Boolean drawCave(int cave)
        {
            return false;
        }
        //This displays the warnings for a player encountering an object
        public static Boolean encounterHazard(int hazard)
        {
            return false;
        }
        //This shows the high score in the menu when playing the game
        public static int highScore(int score)
        {
            Console.WriteLine("Return 0;");
            return score;
        }
        //This updates the game after every new move is made
        public static void updateGame(int update)
        {

        }
    }
}
