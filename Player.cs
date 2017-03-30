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
            //initializes instance variables
            numOfArrows = 3;
            gold = 0;
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
        public void updateInventory(int numOfArrows, int numOfGold)
        {
            //updates instance variables in class
            //that pertain to how many of each item
            //user has. 
            this.numOfArrows += numOfArrows;
            gold += numOfGold;
        }
        public int endingScoreOfPlayer(int numOfTurns)
        {
            return 100 - numOfTurns + gold + (10 * numOfArrows);
        }

    }
}
