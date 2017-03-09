 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WumpusTest
{
    class Player
    {
        private int gold;
        private int numOfArrows;
        public Player()
        {

        }
        public int endGame()
        {
            //returns score of player if player defeats wumpus, loses to wumpus or fails to get out of bottomless pit
            return 0;
        }
        public int getNumOfArrows()
        {
            //returns number of arrows that the user has
            return numOfArrows;
        }
        public int getGold()
        {
            //returns amount of gold player has
            return gold;
        }
        public void userPurchase(int numOfArrows)
        {
            //updates instance variables in class
            //that pertain to how many of each item
            //user has. 
            this.numOfArrows += numOfArrows;
            
        }
    }
}
