 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WumpusTest
{
    class UI
    {
        private bool start = false;
        public UI()
        {

        }
        public void setStart(bool accepted)
        {
            start = accepted;
        }

        //This starts the game if the user enter yes 
        public Boolean startGame(bool start)
        {
            return true;
        }
        //This moves the player if wasd are pressed
        //public static void movePlayer(int )
        //{
            //GameControl.movePlayer;
        //}
       
        //This draws the caves when you enter a new room
        public static void drawCave(int cave)
        {
            //GameControl.getPathways();
        }
       
        //This shows the high score in the menu when playing the game
        public static void highScore (int score)
        {
            //GameControl.displayHighScore;   
        }
        //This updates the game after every new move is made
        public static void updateGame(int update)
        {
            //GameControl.updateUI();
        }

        internal static int displayMenu()
        {
            throw new NotImplementedException();
        }
    }
}
