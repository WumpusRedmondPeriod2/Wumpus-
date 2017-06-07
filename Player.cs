using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace WumpusTest
{
    class Player
    {
        //the player's name
        private String playerName;
        //num of turns
        private int numOfTurns;
        //player inventory
        private int gold;
        private int arrows;
        //maximum earnable coins - 100 gold
        public int maxGold;

        //constructor
        public Player()
        {
            //initializes instance variables
            arrows = 3;
            maxGold = 100;
            numOfTurns = 0;
            gold = 5;
        }
        //important getters and setters
        //sets player's name
        public void setPlayerName(String name)
        {
            playerName = name;
        }
        //returns player's name
        public String getPlayerName()
        {
            return playerName;
        }
        //returns player's arrows
        public int getNumOfArrows()
        {
            return arrows;
        }
        //returns player's gold
        public int getGold()
        {
            return gold;
        }
        //returns number of turns
        public int getNumOfTurns()
        {
            return numOfTurns;
        }

        //increase turn count
        public void addTurn()
        {
            numOfTurns++;
        }

        //increases the player's gold, decreases maxGold
        //if maxGold == 0, nothing happens
        public void incGold()
        {
            if (!(maxGold == 0))
            {
                gold++;
                maxGold--;
            }
        }

        //adds or removes arrows and gold from the player's inventory
        public void updateInventory(int numOfArrows, int numOfGold)
        {
            arrows += numOfArrows;
            gold += numOfGold;
        }

        //calculates and returns player's current score
        public int playerScore()
        {
            return 100 - numOfTurns + gold + (10 * arrows);
        }
    }
}

