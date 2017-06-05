using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace WumpusTest
{
    class HighScore
    {
        int[] scores;
        string[] names;

        public HighScore()
        {
            scores = new int[5];
            names = new string[5];
        }


        public void addNewHighScore(string name, int score)
        {
            string line;
            int count = 0;
            System.IO.StreamReader file = new System.IO.StreamReader(@"HighScoreDoc.txt");
            while ((line = file.ReadLine()) != null && count < 5)
            {
                string[] splitLine = null;
                splitLine = line.Split(new char[] { ' ' });
                names[count] = splitLine[0];
                scores[count] = Int32.Parse(splitLine[1]);
                Console.WriteLine(line);
                count++;
            }

            count = 0;
            for (int i = 0; i < 5; i++)
            {
                if (score < scores[i])
                {
                    count++;
                }
                else
                {
                    break;
                }
            }
            Console.WriteLine(count);
            if (count == 4)
            {
            }
            else
            {
                for (int i = 4; i > count; i--)
                {
                    scores[i] = scores[i - 1];
                    names[i] = names[i - 1];
                }
                scores[count] = score;
                names[count] = name;
            }
            for (int i = 0; i < 5; i++)
            {
                System.IO.StreamWriter write = new System.IO.StreamWriter(@"HighScoreDoc.txt");
                write.Write(names[i] + " " + scores[i] + "\n");
            }
        }
        public void showHighScores()
        {
            System.Diagnostics.Process.Start("HighScoreDoc.txt");
        }

    }
}