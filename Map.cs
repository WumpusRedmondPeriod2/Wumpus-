using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WumpusTest
{
    class Map
    {
        private Room wumpusLocation;
        private Room playerLocation;
        private Room batsLocations;
        private Room bottomlesspitlocations;
        public Map()
        {

        }
        public Room movesForward()
        {
            Room a = new Room();
            return a;
            //returns current location of player
        }
        public int encounterHazard()
        {
            
            //returns -1 if no hazards encountered
            //returns 0 if bats
            //returns 1 if bottmoless pit
            //return 2 if wumpus
            if (distanceBetweenRooms(playerLocation, wumpusLocation) == 0)
            {
                return 2;
            }
            if (distanceBetweenRooms(playerLocation, batsLocations) == 0)
            {
                return 0;
            }
            if (distanceBetweenRooms(playerLocation, bottomlesspitlocations) == 0)
            {
                return 1;
            }
            else
            {
                return -1;
            }
        }
        public int checkForWumpus()
        {
            //Checks if Wumpus is two rooms or closer
            //If so returns 2
            //returns 1 if bottomless pit is two rooms or closer
            //returns 0 if bats are two rooms or closer
            if (distanceBetweenRooms(playerLocation, wumpusLocation) <= 2)
            {
                return 2;
            }
            if (distanceBetweenRooms(playerLocation, batsLocations) <= 2)
            {
                return 0;
            }
            if (distanceBetweenRooms(playerLocation, bottomlesspitlocations) <= 2)
            {
                return 1;
            }
            else
            {
                return -1;
            }
        }
        public static int distanceBetweenRooms(Room room1, Room room2)
        {
            //find distance between two rooms and return as an integer
            return 0;
        }

    }
}
