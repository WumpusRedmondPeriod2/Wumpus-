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

        private static int[,] pathways = new int[30, 6];

        public Cave(int a)
        {
            string FileName = "Cave" + a + ".txt";
            string[] stPathways = System.IO.File.ReadAllLines(@"" +FileName);
            //reads from any file
            if (stPathways == null)
            {
                throw new IOException("Unable to read from file");
                //checks if this is null and throws exception if found
            }
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

        public int[,] getRoomConnections()
        {
            return pathways;
        }
    }
}

