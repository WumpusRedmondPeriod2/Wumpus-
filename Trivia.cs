using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WumpusTest
{
    class Trivia
    {
        private String question;
        private static Boolean[] elimQuestions = new Boolean[20];
        private String[] questionArr;
        private String[] stringArray;

        public Trivia()
        {
            //Reads files and assorts lines into array
            questionArr = System.IO.File.ReadAllLines(@"TriviaQuestions.txt");
            //Sets first question as current question
            question = questionArr[0];
            //splits each line into questions and answers
            stringArray = question.Split(';');
            //resets questions so all questions can be shown
            for (int i = 0; i < elimQuestions.Length; i++)
            {
                elimQuestions[i] = false;
            }
            //eliminates the first question
            elimQuestions[0] = true;
        }

        //returns the current question as a String
        public String getQuestion()
        {
            return stringArray[0];
        }

        //returns answer choices as a string array
        public String[] getPossibleAnswers()
        {
            String[] returnArray = new string[5];

            for (int i = 0; i < 5; i++)
            {
                returnArray[i] = stringArray[i + 1];
            }
            return returnArray;
        }

        //loads the next question
        public void newQuestion()
        {
            //randomizes question 
            Random r = new Random();
            int q = r.Next(20);

            //ensures answered questions are not repeated
            while (elimQuestions[q] != false)
            {
                q = r.Next(20);
            }
            elimQuestions[q] = true;
            //sets new question and answers as current question and answer
            question = questionArr[q];
            stringArray = question.Split(';');
        }
    }
}

