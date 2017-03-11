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
        private static int numOfTurns = 0;
        public Player(int gold, int numOfArrows)
        {
            //initializes instance variables
            this.gold = gold;
            this.numOfArrows = numOfArrows;
            numOfTurns++;
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
        public static int getNumOfTurns()
        {
            return numOfTurns;
        }
        public void updateInventory(int numOfArrows, int numOfGold)
        {
            //updates instance variables in class
            //that pertain to how many of each item
            //user has. 
            this.numOfArrows = numOfArrows;
            gold = numOfGold;
        }
        public int endingScoreOfPlayer()
        {
            return 100 - numOfArrows + gold + (10 * numOfArrows);
        }
    }
}
