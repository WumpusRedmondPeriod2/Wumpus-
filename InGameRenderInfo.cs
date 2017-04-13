using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WumpusTest
{
    public class InGameRenderInfo
    {
        //is game over
        public bool IsGameOver;

        public int numberOfTurns;

        //displayed num of arrows
        public int ArrowCount;

        //displayed goldcount
        public int GoldCount;

        //TODO reformat this array
        public int[,] CaveConnections;

        //whether or not a question should be asked
        public Boolean askQuestion;
        //question and answers - input goes to control
        public int numOfQuestions;
        public String[] question;
        public String[][] answers;
    }
}