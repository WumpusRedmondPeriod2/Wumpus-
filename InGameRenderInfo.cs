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
        //cause for game end
        public int cause;

        //0 - no hazard, 1 - bats, 2 - pit, 3 - wumpus
        public int isHazard;
        //arraylist of nearby hazards
        //indices: 0 - no hazard, 1 - bats, 2 - pit, 3 - wumpus
        //false - no hazard, true - one of hazard, null - two of the hazard
        public ArrayList warnings;

        //the messages that should be displayed
        //0 - none, 1 - bats, 2 - pit, 3 - wumpus
        //resolution: 4- pit true, 5 - pit false, 6 - wumpus true, 7 - wumpus false
        // 8- hit arrow, 9 - missed arrow
        public ArrayList popUp;

        //locations of the hazards
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

        //all the possible cave pathways
        public int[,] CaveConnections;
        //the current possible pathways
        public int[] currentPaths;

        //whether or not a question should be asked
        public bool askQuestion;
        //question and answers
        public int numOfQuestions;
        public String[] question;
        public String[][] answers;

        //the current displayed secret
        public String secret;
        //the current displayed fact
        public String fact;

        //constructor
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
            CaveConnections = new int[0, 0];
            numOfQuestions = 0;
            question = new String[0];
            answers = new String[0][];
            popUp = new ArrayList(0);
            secret = "";
            fact = "";
        }
    }
}
