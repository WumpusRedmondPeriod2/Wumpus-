using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WumpusTest
{
    class GameControl
    {
        public GameControl()
        {

        }

        //called by UI to get update info when player enters new room
        //returns a set of data values that are used to update the GUI 
        public int[] updateUI()
        {
            //
            return new int[0];
        }

        //updates player's items - gold and arrows
        //returns array {gold,arrows}
        public int[] updateItems()
        {
            return new int[2];
        }

        //runs the trivia game
        //returns result of game
        public Boolean playTrivia()
        {
            return false;
        } 
    }

}
