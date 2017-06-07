using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace WumpusTest
{
    class Cave
    {
        //2D array of the pathways between rooms
        private static int[,] pathways = new int[30, 6];

        //constructor - takes the cave number as parameter
        public Cave(int a)
        {
            //gets cave based on cave number
            string FileName = "Cave" + a + ".txt";
            string[] stPathways = System.IO.File.ReadAllLines(@"" + FileName);
            //checks if this is null and throws exception if found
            if (stPathways == null)
            {
                throw new IOException("Unable to read from file");
            }
            //sets the pathways for the current cave
            else
            {
                int[,] temporaryPathways = new int[30, 6];
                for (int i = 0; i < 30; i++)
                {
                    var entries = stPathways[i].Split(' ');
                    for (int j = 0; j < 6; j++)
                    {
                        temporaryPathways[i, j] = int.Parse(entries[j]);
                    }
                }
                pathways = temporaryPathways;
            }
        }
        
        //returns a 2D array of the pathways between rooms
        public int[,] getRoomConnections()
        {
            return pathways;
        }
    }
}

