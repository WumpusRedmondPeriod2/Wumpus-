using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WumpusTest
{
    //Wumpus object will control wumpus states and behavior
    //Lazy Wumpus has two states, asleep and moving 
    //If user misses the Wumpus, Wumpus will move two-four rooms away using two-dimensional connection array
    //If defeated in trivia, will move 1, 2, or 3 rooms away
    class Wumpus
    {
        private bool asleep; 
        private bool moving;
        public Wumpus()
        {
            //By default, constructor sets asleep to true, and moving
            //and awake to false
            asleep = true;
            moving = false;
        }
        public void setAsleep(bool asleep)
        {
            this.asleep = asleep;
        }
        public void setMoving(bool moving)
        {
            this.moving = moving;
        }
        public bool[] getStates()
        {
            bool[] states = { asleep, moving };
            return states;
        }
    }
}
