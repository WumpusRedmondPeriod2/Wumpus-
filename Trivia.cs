using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WumpusTest

{
    class Trivia
    {
        private string question;
        private static Boolean[] elimQuestions = new Boolean[20];
        private string[] questionArr;
        private string[] stringArray;

        public Trivia()
        {
            //Reads files and assorts lines into array
            questionArr = System.IO.File.ReadAllLines(@"TriviaQuestions.txt");
            //Sets first question as current question
            question = questionArr[0];
            stringArray = question.Split(';');
            for(int i = 0; i < elimQuestions.Length; i++)
            {
                elimQuestions[i] = false;
            }
            elimQuestions[0] = true;
        }
        public string getQuestion()
        {
            //Sends question as a String to Game Control
            return stringArray[0]; 
        }

        public string getAnswer()
        {
            //returns the answer as a string to Game Control
            return stringArray[5];
        }

        public string[] getPossibleAnswers() 
        {
            //returns answer choices as a string array
            string[] returnArray = new string[5];

            for (int i = 0; i < 5; i++)
            {
                returnArray[i] = stringArray[i+1];
            }
            return returnArray; 
        }

        public void newQuestion()
        {
            Random r = new Random();
            //randomizes question 
            int q = r.Next(20);

            while (elimQuestions[q] != false)
            {
                q = r.Next(20);
            }
            //ensures answered questions are not repeated
            elimQuestions[q] = true;
            //sets new question and answers as current question and answer
            question = questionArr[q];
            stringArray = question.Split(';');
        }

        public Boolean isAnswerCorrect(String answer)
        {
            //Determines if answer is correct for game control
            if (stringArray[5] == answer)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
