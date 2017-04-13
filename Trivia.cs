using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    class Trivia
    {
        private string question;
        private Boolean[] elimQuestions;
        private string[] questionArr;
        private string[] stringArray;
        private int NumQuestions = 0;
        private Random r;

        public Trivia()
        {
            elimQuestions = new Boolean[20];
            r = new Random();
            //Reads files and assorts lines into array
            questionArr = System.IO.File.ReadAllLines(@"E:\WumpusTest\TriviaQuestions.txt"); //change according to file location
            //Sets first question as current question
            question = questionArr[0];
            stringArray = question.Split(';');
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
            string[] returnArray = new string[4];
            for (int i = 1; i < 5; i++)
            {
                returnArray[i - 1] = stringArray[i];
            }
            return returnArray; 
        }

        public void newQuestion()
        {
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
            NumQuestions++;
            //resets questions if all are answered - meant to prevent crashing
            if (NumQuestions == 20)
            {
                for (int i = 0; i < elimQuestions.Length; i++)
                {
                    elimQuestions[i] = false;
                }
                NumQuestions = 0;
            }
        }

        public Boolean isAnswerCorrect(String answer)
        {
            //Determines if answer is correct for game control
            if (stringArray[5] == answer)
            {
                newQuestion();
                return true;
            }
            else
            {
                newQuestion();
                return false;
            }
        }
    }
}
