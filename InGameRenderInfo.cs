using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace WumpusTest
{
    public class InGameRenderInfo
    {
        //is game over
        public bool IsGameOver;
        public int cause;
        //0 - no hazard, 1 - bats, 2 - pit, 3 - wumpus
        public int isHazard;
        //indices: 0 - no hazard, 1 - bats, 2 - pit, 3 - wumpus
        //false - no hazard, true - one of hazard, null - two of
        public ArrayList warnings;

        //0 - none, 1 - bats, 2 - pit, 3 - wumpus
        //resolution: 4- pit true, 5 - pit false, 6 - wumpus true, 7 - wumpus false
        // 8- hit arrow, 9 - missed arrow
        public ArrayList popUp;

        public int wumpusLocation;
        public int batlocation1;
        public int batlocation2;
        public int pitlocation1;
        public int pitlocation2;

        public int numberOfTurns;
        public int roomNum;
        //displayed num of arrows
        public int ArrowCount;
        //displayed goldcount
        public int GoldCount;
        //displayed score
        public int score;

        public int[,] CaveConnections;
        public int[] currentPaths;
        
        //whether or not a question should be asked
        public bool askQuestion;
        //question and answers - input goes to control
        public int numOfQuestions;
        public String[] question;
        public String[][] answers;
        public Boolean  correct;
        public String secret;
        public String fact;
        public InGameRenderInfo()
        {
            IsGameOver = false;
            cause = -1;
            isHazard = 0;
            wumpusLocation = 0;
            warnings = new ArrayList(0);
            roomNum = -1;
            numberOfTurns = 0;
            ArrowCount = 0;
            GoldCount = 0;
            askQuestion = false;
            CaveConnections = new int[0,0];
            numOfQuestions = 0;
            question = new String[0];
            answers = new String[0][];
            popUp = new ArrayList(0);
            secret = "";
            fact = "";
        }
    }
}