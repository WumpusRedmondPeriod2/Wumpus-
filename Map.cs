using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WumpusTest
{
    class Map
    {

        public Map()
        {

        }
        public room movesForward()
        {
            //returns current location of player
        }
        public Boolean encounterBats()
        {
            //Checks if user is in the same room as bats
            //If so returns true, else it returns false
            return true;
        }
        public Boolean encounterWumpus()
        {
            //Checks if user is in same room as Wumpus
            //If so returns true, else it returns false
            return true;
        }
        public Boolean bottomlessPit()
        {
            //Checks if user is in the same room as bottomlessPit
            //If so returns true, else it returns false
            return true;
        }
        public Boolean checkForWumpus()
        {
            //Checks if Wumpus is two rooms or closer
            //If so returns true, else returns false
            return true;
        }
        public Boolean checkForBottomlessPit()
        {
            //Checks if bottomless pit is two rooms or closer
            //If so returns true, else returns false
            return true;
        }
        public Boolean checkForBats()
        {
            //Checks if bats are two rooms or closer
            //If so returns true, else returns false
            return true;
        }
    }
}
