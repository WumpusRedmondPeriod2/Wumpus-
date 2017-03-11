using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WumpusTest
{
    class Map
    {
        private int wumpusLocation;
        private int playerLocation;
        private int[] batsLocations;
        private int[] bottomlesspitlocations;
        
        public Map()
        {
            //Sets random starting points for player and hazards
            //and ensures that player, wumpus, both bats, and bottomlesspits start in different locations
            Random gen = new Random();
            playerLocation = gen.Next(30) + 1;
            wumpusLocation = gen.Next(30) + 1;
            while(wumpusLocation == playerLocation)
            {
                wumpusLocation = gen.Next(30) + 1;
            }
            batsLocations[0] = gen.Next(30) + 1;
            while(batsLocations[0] == playerLocation || batsLocations[0] == wumpusLocation)
            {
                batsLocations[0] = gen.Next(30) + 1;
            }
            batsLocations[1] = gen.Next(30) + 1;
            while (batsLocations[1] == playerLocation || batsLocations[1] == wumpusLocation || batsLocations[1] == batsLocations[0])
            {
                batsLocations[1] = gen.Next(30) + 1;
            }
            bottomlesspitlocations[0] = gen.Next(30) + 1;
            while (bottomlesspitlocations[0] == playerLocation || bottomlesspitlocations[0] == wumpusLocation || bottomlesspitlocations[0] == batsLocations[0] || bottomlesspitlocations[0] == batsLocations[1])
            {
                bottomlesspitlocations[0] = gen.Next(30) + 1;
            }
            bottomlesspitlocations[1] = gen.Next(30) + 1;
            while (bottomlesspitlocations[1] == playerLocation || bottomlesspitlocations[1] == wumpusLocation || bottomlesspitlocations[1] == batsLocations[1] || bottomlesspitlocations[1] == batsLocations[1] || bottomlesspitlocations[1] == bottomlesspitlocations[0])
            {
                bottomlesspitlocations[1] = gen.Next(30) + 1;
            }
        }
        public void movesForward(int room_number)
        {
            playerLocation = room_number;
            //updates player location
        }
        public int encounterHazard()
        {
            
            //returns -1 if no hazards encountered
            //returns 0 if bats
            //returns 1 if bottmoless pit
            //return 2 if wumpus
            if(playerLocation == wumpusLocation)
            {
                return 2;
            }
            else if(playerLocation== bottomlesspitlocations[0] || playerLocation == bottomlesspitlocations[1])
            {
                return 1;
            }
            else if(playerLocation == batsLocations[0] || playerLocation == batsLocations[1])
            {
                return 0;
            }
            else
            {
                return -1;
            }
      
        }
        public bool[] checkForHazards()
        {
            //returns true or false for hazards that are close by to the user
            //if wumpus is two rooms away the first element will be true else false
            //If one of the bats is two rooms away the second element will be true else false
            //If both of the bats are two rooms away the third element will also be true
            //Same algorithm for the bottomless pits
            //array will look like [(isWumpusCloseTrueOrFalse), (isABatCloseTrueOrFalse), (isTheOtherBatCloseTrueOrFalse), 
            //(is theBottomLessPitCloseTrueOrFalse, IsTheOtherBottomLessPitCloseTrueOrFalse)
            bool[] hazards = new bool[5];
            if(distanceBetweenRooms(playerLocation, wumpusLocation) <= 2)
            {
                hazards[0] = true;
            }
            else
            {
                hazards[0] = false;
            }
            if(distanceBetweenRooms(playerLocation, batsLocations[0]) <= 2)
            {
                hazards[1] = true;
            }
            else
            {
                hazards[1] = false;
            }
            if (distanceBetweenRooms(playerLocation, batsLocations[1]) <= 2)
            {
                hazards[2] = true;
            }
            else
            {
                hazards[2] = false;
            }
            if (distanceBetweenRooms(playerLocation, bottomlesspitlocations[0]) <= 2)
            {
                hazards[3] = true;
            }
            else
            {
                hazards[3] = false;
            }
            if (distanceBetweenRooms(playerLocation, bottomlesspitlocations[1]) <= 2)
            {
                hazards[4] = true;
            }
            else
            {
                hazards[4] = false;
            }
            return hazards;
        }
        public int getPlayerLocation()
        {
            return playerLocation;
        }
        public int getWumpusLocation()
        {
            return wumpusLocation;
        }
        public int[] getBatsLocations()
        {
            return batsLocations;
        }
        public int[] getBottomLessPitLocations()
        {
            return bottomlesspitlocations;
        }
        public static int distanceBetweenRooms(int room1, int room2)
        {
            //find distance between two rooms and return as an integer
            return 0;
        }

    }
}
