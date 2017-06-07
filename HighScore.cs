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
            scores = new int[10];
            names = new string[10];
        }

        public string[] getNames()
        {
            return names;
        }


        public int[] getScores()
        {
            return scores;
        }


        public void addNewHighScore(string name, int score)
        {
            string fileName = "HighScoreDoc.txt";
            if(new FileInfo(fileName).Length != 0)
            {
                System.IO.StreamReader fileReader = new System.IO.StreamReader(@"HighScoreDoc.txt");
                Dictionary<string, int> nameScores= new Dictionary<string, int>();
                string line;
                int count = 0;
                while ((line = fileReader.ReadLine()) != null && count < 10)
                {
                    names[count] = splitLine[0];
                    scores[count] = Int32.Parse(splitLine[1]);   
                    count++;
                }

            }
            //string line;
            //int count = 0;
            //System.IO.StreamReader file = new System.IO.StreamReader(@"HighScoreDoc.txt");
            //while ((line = file.ReadLine()) != null && count < 10)
            //{
            //    string[] splitLine = { " ab ", " cd " };
            //    splitLine = line.Split(';');
            //    names[count] = splitLine[0];
            //    scores[count] = Int32.Parse(splitLine[1]);
            //    Console.WriteLine(line);
            //    count++;
            //}
            //file.Close();
            //count = 0;
            //for (int i = 0; i < 10; i++)
            //{
            //    if (score < scores[i])
            //    {
            //        count++;
            //    }
            //    else
            //    {
            //        break;
            //    }
            //}
            //Console.WriteLine(count);
            //if (count == 9)
            //{
            //}
            //else
            //{
            //    for (int i = 9; i > count; i--)
            //    {
            //        scores[i] = scores[i - 1];
            //        names[i] = names[i - 1];
            //    }
            //    scores[count] = score;
            //    names[count] = name;
            //}
            //using (StreamWriter outputFile = new StreamWriter(@"HighScoreDoc.txt", true))
            //{
            //    for(int i = 0; i < 10; i++)
            //    {
            //        outputFile.WriteLine(names[i] + ";" + scores[i] + "\n");
            //    }
            //    outputFile.Close();
            //}
            ////    for (int i = 0; i < scores.Length; i++)
            ////{
            ////    scoreWriter.WriteLine(names[i] + " " + scores[i] + "\n");
            ////}

        }
    }
}