 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace WumpusTest
{
    //Calculate number of turns 
    class Player
    {
        private String playerName;
        private int numOfTurns;
        private int gold;
        private int arrows;
        public int maxGold;
        public Player()
        {
            //initializes instance variables
            arrows = 3;
            maxGold = 100;
            numOfTurns = 0;
            gold = 5;
        }
        public void setPlayerName(String name)
        {
            playerName = name;
        }
        public String getPlayerName()
        {
            return playerName;
        }
        public void addturn()
        {
            numOfTurns++;
        }
        public int getNumOfArrows()
        {
            //returns number of arrows that the user has
            return arrows;
        }
        public int getGold()
        {
            //returns amount of gold player has
            return gold;
        }
        public void incGold()
        {
            if (!(maxGold == 0))
            {
                gold++;
                maxGold--;
            }
        }
        public void updateInventory(int numOfArrows, int numOfGold)
        {
            //updates instance variables in class
            //that pertain to how many of each item
            //user has. 
            arrows += numOfArrows;
            gold += numOfGold;
        }
        public int getNumOfTurns()
        {
            return numOfTurns;
        }
        public int playerScore()
        {
            return 100 - numOfTurns + gold + (10 * arrows);
        }
    }
}
