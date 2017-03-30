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
        private int[] bottomlesspitLocations;
        private Cave cave;
        private int[,] arrayOfRooms;
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
            bottomlesspitLocations[0] = gen.Next(30) + 1;
            while (bottomlesspitLocations[0] == playerLocation || bottomlesspitLocations[0] == wumpusLocation || bottomlesspitLocations[0] == batsLocations[0] || bottomlesspitLocations[0] == batsLocations[1])
            {
                bottomlesspitLocations[0] = gen.Next(30) + 1;
            }
            bottomlesspitLocations[1] = gen.Next(30) + 1;
            while (bottomlesspitLocations[1] == playerLocation || bottomlesspitLocations[1] == wumpusLocation || bottomlesspitLocations[1] == batsLocations[1] || bottomlesspitLocations[1] == batsLocations[1] || bottomlesspitLocations[1] == bottomlesspitLocations[0])
            {
                bottomlesspitLocations[1] = gen.Next(30) + 1;
            }
            cave = new Cave(1);
            arrayOfRooms = cave.getRoomConnections();
        }
        public Map(int playerLocation, int wumpusLocation, int[] batsLocations, int[] bottomlesspitLocations)
        {
            this.playerLocation = playerLocation;
            this.wumpusLocation = wumpusLocation;
            this.batsLocations = batsLocations;
            this.bottomlesspitLocations = bottomlesspitLocations;
            cave = new Cave(1);
            arrayOfRooms = cave.getRoomConnections();
        }
        public void updatePlayerLocation(int user_input)
        {
            int[] surroundingRooms = new int[6];
            //Creates an array to get surrounding rooms to the player location
            for (int i = 0; i < surroundingRooms.Length; i++)
            {
                surroundingRooms[i] = Math.Abs(arrayOfRooms[playerLocation - 1, i]);
                //transfers data from connections 2D Array to surroundingRooms
            }
            playerLocation = surroundingRooms[(user_input + 1) % 6];
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
            else if(playerLocation== bottomlesspitLocations[0] || playerLocation == bottomlesspitLocations[1])
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
            bool[] hazards = { false, false, false, false, false };
            if(distanceBetweenRooms(playerLocation, wumpusLocation) == true)
            {
                hazards[0] = true;
            }
            if(distanceBetweenRooms(playerLocation, batsLocations[0]) == true)
            {
                hazards[1] = true;
            }
        
            if (distanceBetweenRooms(playerLocation, batsLocations[1]) == true)
            {
                hazards[2] = true;
            }
           
            if (distanceBetweenRooms(playerLocation, bottomlesspitLocations[0]) == true)
            {
                hazards[3] = true;
            }
            
            if (distanceBetweenRooms(playerLocation, bottomlesspitLocations[1]) == true)
            {
                hazards[4] = true;
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
            return bottomlesspitLocations;
        }
        public int[,] getConnections()
        {
            return arrayOfRooms;
        }
        public void setPlayerLocation(int playerLocation)
        {
            this.playerLocation = playerLocation;
        }
        public void setWumpusLocation(int wumpusLocation)
        {
            this.wumpusLocation = wumpusLocation;
        }
        public void setBatsLocations(int[] batsLocations)
        {
            for (int i = 0; i < batsLocations.Length; i++)
            {
                this.batsLocations[i] = batsLocations[i];
            }
        }
        public void setBottomLessPitsLocations(int[] bottomlesspitLocations)
        {
            for (int i = 0; i < bottomlesspitLocations.Length; i++)
            {
                this.bottomlesspitLocations[i] = bottomlesspitLocations[i];
            }
        }
        public bool isWumpusInRoom(int user_input)
        {
            //This method checks if an arrow
            //that the user shoots hits the
            //wumpus. If it does the method 
            //returns true, or the method
            //returns false
            bool wumpus = false;
            //Sets the return variable to valse
            int[] surroundingRooms = new int[6];
            //Creates an array to get surrounding rooms to the player location
            for (int i = 0; i < surroundingRooms.Length; i++)
            {
                surroundingRooms[i] = Math.Abs(arrayOfRooms[playerLocation - 1, i]);
                //transfers data from connections 2D Array to surroundingRooms
            }
            if (wumpusLocation == surroundingRooms[(user_input + 1) % 6])
            {
                wumpus = true;
            } 
            return wumpus;
        }
        public bool distanceBetweenRooms(int room1, int room2)
        {
            //If distance between rooms is equal to 1, or 2 returns true
          
            //Gets room connection array from cave
            int[] roomArray = new int[6];
            //Creates connection array for first room
            bool hazard = false;
            //Sets return variable to false so if hazard is not two rooms away, method
            //will return false
            for (int i = 0; i < roomArray.Length; i++)
            {
                roomArray[i] = Math.Abs(arrayOfRooms[room1 - 1, i]);
                //gets connections of room1 from 2D array returned by Cave Object
            }
            for(int i = 0; i < roomArray.Length; i++)
            {
                if(room2 == roomArray[i])
                {
                    hazard = true;
                }
            }
            //Above for loop checks if room2 can be found in rooms that are one room away from room1
            int[] roomArray1 = new int[6];
            for(int i = 0; i < roomArray.Length; i++)
            {
                roomArray1[i] = arrayOfRooms[roomArray[0], i];
            }
            //Gets connections for first room in roomArray
            int[] roomArray2 = new int[6];
            for (int i = 0; i < roomArray.Length; i++)
            {
                roomArray2[i] = arrayOfRooms[roomArray[1], i];

            }
            //Gets connections for second room in roomArray
            int[] roomArray3 = new int[6];
            for (int i = 0; i < roomArray.Length; i++)
            {
                roomArray3[i] = arrayOfRooms[roomArray[2], i];
            }
            //Gets connections for third room in roomArray
            int[] roomArray4 = new int[6];
            for (int i = 0; i < roomArray.Length; i++)
            {
                roomArray1[i] = arrayOfRooms[roomArray[3], i];
            }
            //Gets connections for fourth room in roomArray
            int[] roomArray5 = new int[6];
            for (int i = 0; i < roomArray.Length; i++)
            {
                roomArray5[i] = arrayOfRooms[roomArray[4], i];
            }
            //gets connections for fifth room in roomArray
            int[] roomArray6 = new int[6];
            for (int i = 0; i < roomArray.Length; i++)
            {
                roomArray6[i] = arrayOfRooms[roomArray[5], i];
            }
            //gets connections for sixth room in roomArray
            int[][] roomsTwoAway = new int[][] { roomArray1, roomArray2, roomArray3, roomArray4, roomArray5, roomArray6 };
            //creates an array of arrays for rooms that are a distance 
            //of two rooms away from room1
            for(int i = 0; i < roomsTwoAway.Length; i++)
            {
                for(int j = 0; j < roomsTwoAway[i].Length; j++)
                {
                    if(roomsTwoAway[i][j] == room2)
                    {
                        hazard = true;
                    }
                }
            }
            //Checks to see if room2 is in any of the arrays.
            //If so sets hazard to true
            return hazard;
        }
    }

}
