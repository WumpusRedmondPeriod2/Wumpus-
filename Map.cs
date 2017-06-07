using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace WumpusTest
{
    class Map
    {
        private int wumpusLocation; //keeps track of Wumpus location
        private int playerLocation; //keeps track of player location
        private int[] batsLocations; //keeps track of the location of the bats
        private int[] bottomlesspitLocations; //keeps track of the bottomless pits
        private Cave cave; //Defines cave object to get room connections
        private int[,] arrayOfRooms;  //two-dimensional array of room connections
        private Wumpus wumpus;  //Wumpus object to keep track of objects
        private int initialPlayerLocation; //keeps track of starting location of the player
        private Player player;
        private ArrayList num;
        public Map(int cavenum)
        {
            //Sets random starting points for player and hazards
            //and ensures that player, wumpus, both bats, and bottomlesspits start in different locations
            //Creates an arraylist of numbers from 1 to 30
            //Sets a random index from 0 to the length of the arraylist and uses index to access value in arraylist
            //Removes value in Arraylist once set to a location
            num = new ArrayList();
            for (int i = 1; i <= 30; i++)
            {
                num.Add(i);
            }
            batsLocations = new int[2];
            bottomlesspitLocations = new int[2];
            Random gen = new Random();
            int index = gen.Next(0, num.Count);
            playerLocation = (int)num[index];
            initialPlayerLocation = playerLocation;
            num.RemoveAt(index);
            index = gen.Next(0, num.Count);
            wumpusLocation = (int)num[index];
            num.RemoveAt(index);
            index = gen.Next(0, num.Count);
            batsLocations[0] = (int)num[index];
            num.RemoveAt(index);
            index = gen.Next(0, num.Count);
            batsLocations[1] = (int)num[index];
            num.RemoveAt(index);
            index = gen.Next(0, num.Count);
            bottomlesspitLocations[0] = (int)num[index];
            num.RemoveAt(index);
            index = gen.Next(0, num.Count);
            bottomlesspitLocations[1] = (int)num[index];
            num.RemoveAt(index);
            cave = new Cave(cavenum);
            wumpus = new Wumpus();
            arrayOfRooms = cave.getRoomConnections();
            player = new Player();
        }
        public void moveToInitial()
        {
            //moves player back to starting location of the player
            playerLocation = initialPlayerLocation;
        }
        public int getInitialLoc()
        {
            return initialPlayerLocation;
        }
        public int updatePlayerLocation(int user_input)
        {
            //parameters tells which direction to move player, it's either 1, 2, 3, 4, 5, 6
            //1 moves player to top left and subsequent parameters move player clockwise
            int[] surroundingRooms = new int[6];
            //Creates an array to get surrounding rooms to the player location
            for (int i = 0; i < surroundingRooms.Length; i++)
            {
                surroundingRooms[i] = Math.Abs(arrayOfRooms[playerLocation - 1, i]);
                //transfers data from connections 2D Array to surroundingRooms
            }
            playerLocation = surroundingRooms[(user_input - 1)];
            //sets corresponding element in bool array to true 
            //to indicated user has visited room

            return playerLocation;
        }
        public void moveWumpusAtRandom()
        {
            Random gen = new Random();
            int move = gen.Next(10) + 1;
            if(move == 1)
            {
                moveWumpus();
            }
        }
        public void moveWumpusAway()
        {
            //moves the wumpus if arrow shot by user misses the wumpus
            //or if the wumpus is defeated in trivia
            int[] numOfRooms = { 2, 3, 4 };
            wumpus.setAsleep(false);
            Random gen = new Random();
            int numOfRoomsMoved = numOfRooms[gen.Next(numOfRooms.Length)];
            for (int i = 1; i <= numOfRoomsMoved; i++)
            {
                moveWumpus();
            }
        }
        public void moveWumpus()
        {
            int[] surroundingRooms = getCurrentConnections(wumpusLocation);
            Random gen = new Random();
            Array.Sort<int>(surroundingRooms);
            Array.Reverse(surroundingRooms);
            int countOfPositives = 0;
            for (int i = 0; i < surroundingRooms.Length; i++)
            {
                if (surroundingRooms[i] > 0)
                {
                    countOfPositives++;
                }
            }
            do
            {
                wumpusLocation = surroundingRooms[gen.Next(countOfPositives)];
            } while (wumpusLocation == playerLocation);
           
        }
        public void movePlayerRandom()
        {
            ArrayList roomNumbers = new ArrayList();
            for (int i = 1; i <= 30; i++)
            {
                roomNumbers.Add(i);
            }
            roomNumbers.Remove(wumpusLocation);
            roomNumbers.Remove(bottomlesspitLocations[0]);
            roomNumbers.Remove(bottomlesspitLocations[1]);
            roomNumbers.Remove(batsLocations[0]);
            roomNumbers.Remove(batsLocations[1]);
            roomNumbers.Remove(playerLocation);
            Random gen = new Random();
            int index = gen.Next(roomNumbers.Count);
            int newLocation = (int)roomNumbers[index];
            Debug.WriteLine("New player location: " +index);
            playerLocation = newLocation;
        }
        public void moveBatRandom()
        {
            ArrayList roomNumbers = new ArrayList();
            for (int i = 1; i <= 30; i++)
            {
                roomNumbers.Add(i);
            }
            roomNumbers.Remove(bottomlesspitLocations[0]);
            roomNumbers.Remove(bottomlesspitLocations[1]);
            roomNumbers.Remove(batsLocations[0]);
            roomNumbers.Remove(batsLocations[1]);
            roomNumbers.Remove(playerLocation);
            Random gen = new Random();
            int index = gen.Next(roomNumbers.Count);
            int newLocation = (int)roomNumbers[index];
            Debug.WriteLine("New bat index: " +index);
            if (batsLocations[0] == playerLocation)
            {
                batsLocations[0] = newLocation;
                return;
            }
            batsLocations[1] = newLocation;
        }
        public int encounterHazard()
        {
            //works
            //returns 0 if no hazards encountered
            //returns 1 if bats
            //returns 2 if bottomless pit
            //return 3 if wumpus
            if (playerLocation == bottomlesspitLocations[0] || playerLocation == bottomlesspitLocations[1])
            {
                return 2;
            }
            else if (playerLocation == wumpusLocation)
            {
                wumpus.setAsleep(false);
                return 3;
            }
            else if (playerLocation == batsLocations[0] || playerLocation == batsLocations[1])
            {
                return 1;
            }
            else
            {
                return 0;
            }

        }
        public ArrayList checkForHazards()
        {
            //returns an arraylist of warnings 
            //depending on the hazards close by
            bool[] hazards = { false, false, false, false, false };
            ArrayList warnings = new ArrayList();
            if (distanceBetweenRooms(playerLocation, wumpusLocation) == 1)
            {
                hazards[0] = true;
                warnings.Add("I smell a Wumpus");
            }
            if (distanceBetweenRooms(playerLocation, batsLocations[0]) == 1)
            {
                hazards[1] = true;
            }

            if (distanceBetweenRooms(playerLocation, batsLocations[1]) == 1)
            {
                hazards[2] = true;
            }
            if (distanceBetweenRooms(playerLocation, bottomlesspitLocations[0]) == 1)
            {
                hazards[3] = true;
            }
            if (distanceBetweenRooms(playerLocation, bottomlesspitLocations[1]) == 1)
            {
                hazards[4] = true;
            }
            if (hazards[1] && hazards[2])
            {
                warnings.Add("Two bats nearby");
            }
            else if (hazards[1] || hazards[2])
            {
                warnings.Add("Bats nearby");
            }
            if (hazards[3] && hazards[4])
            {
                warnings.Add("I feel two drafts nearby");
            }
            else if (hazards[3] || hazards[4])
            {
                warnings.Add("I feel a draft nearby");
            }
            else if (hazards[0] == false && hazards[1] == false && hazards[2] == false && hazards[3] == false && hazards[4] == false)
            {
                warnings.Add("No hazards nearby");
            }
            return warnings;
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
        public int[] getCurrentConnections(int roomNumber)
        {
            int[] connections = new int[6];
            for (int i = 0; i < connections.Length; i++)
            {
                connections[i] = arrayOfRooms[roomNumber - 1, i];
            }
            return connections;
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
            if (wumpusLocation == surroundingRooms[(user_input - 1) % 6])
            {
                wumpus = true;
            }
            return wumpus;
        }
        public int distanceBetweenRooms(int room1, int room2)
        {
            //If distance between rooms is 1, returns 1
            //If distance between rooms is 2, returns 2
            //If distance between rooms is greater, than 2 returns -1

            //Gets room connection array from cave
            int[] roomArray = new int[6];
            //Creates connection array for first room
            //Sets return variable to false so if hazard is not two rooms away, method
            //will return false
            for (int i = 0; i < roomArray.Length; i++)
            {
                roomArray[i] = Math.Abs(arrayOfRooms[room1 - 1, i]);
                //gets connections of room1 from 2D array returned by Cave Object
            }
            for (int i = 0; i < roomArray.Length; i++)
            {
                if (room2 == roomArray[i])
                {
                    return 1;
                }
            }
            //Above for loop checks      if room2 can be found in rooms that are one room away from room1
            int[] roomArray1 = new int[6];
            for (int i = 0; i < roomArray.Length; i++)
            {
                roomArray1[i] = Math.Abs(arrayOfRooms[roomArray[0] - 1, i]);
            }
            //Gets connections for first room in roomArray
            int[] roomArray2 = new int[6];
            for (int i = 0; i < roomArray.Length; i++)
            {
                roomArray2[i] = Math.Abs(arrayOfRooms[roomArray[1] - 1, i]);

            }
            //Gets connections for second room in roomArray
            int[] roomArray3 = new int[6];
            for (int i = 0; i < roomArray.Length; i++)
            {
                roomArray3[i] = Math.Abs(arrayOfRooms[roomArray[2] - 1, i]);
            }
            //Gets connections for third room in roomArray
            int[] roomArray4 = new int[6];
            for (int i = 0; i < roomArray.Length; i++)
            {
                roomArray4[i] = Math.Abs(arrayOfRooms[roomArray[3] - 1, i]);
            }
            //Gets connections for fourth room in roomArray
            int[] roomArray5 = new int[6];
            for (int i = 0; i < roomArray.Length; i++)
            {
                roomArray5[i] = Math.Abs(arrayOfRooms[roomArray[4] - 1, i]);
            }
            //gets connections for fifth room in roomArray
            int[] roomArray6 = new int[6];
            for (int i = 0; i < roomArray.Length; i++)
            {
                roomArray6[i] = Math.Abs(arrayOfRooms[roomArray[5] - 1, i]);
            }
            //gets connections for sixth room in roomArray
            int[][] roomsTwoAway = new int[][] { roomArray1, roomArray2, roomArray3, roomArray4, roomArray5, roomArray6 };
            //creates an array of arrays for rooms that are a distance 
            //of two rooms away from room1
            for (int i = 0; i < roomsTwoAway.Length; i++)
            {
                for (int j = 0; j < roomsTwoAway[i].Length; j++)
                {
                    if (roomsTwoAway[i][j] == room2)
                    {
                        return 2;
                    }
                }
            }
            return -1;
        }
    }
}