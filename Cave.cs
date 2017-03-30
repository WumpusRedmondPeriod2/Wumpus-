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

        private static int[,] x1 = new int[30, 6];

        public Cave(int a)
        {
            if (a == 1)
            {
                String FileName = "Cave" + a + ".txt";
                System.IO.StreamReader file = new System.IO.StreamReader(@"\Projects\WumpusTestV2\WumpusTestV2\" + FileName);
                while (file.ReadLine() != null)
                {
                    int[,] x = new int[30, 6];
                    for (int i = 0; i < 30; i++)
                    {
                        String[] st = file.ReadLine().Split(' ');
                        for (int j = 0; j < 6; j++)
                        {
                            x[i, j] = int.Parse(st[i]);
                        }
                    }
                    x1 = x;
                }
            }
        }
        public int[,] getRoomConnections()
        {
            return x1;
        }
    }
}

