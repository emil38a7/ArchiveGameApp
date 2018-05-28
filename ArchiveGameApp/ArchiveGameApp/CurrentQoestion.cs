using System;
using System.Collections.Generic;
using System.Text;

namespace ArchiveGameApp
{
    public class CurrentQoestion
    {
        private string questionID;
        private string questionText;
        private QuestionAnswer[] questionAnswer;
        private string questionDifficulty;

        public string QuestionID { get => questionID; set => questionID = value; }
        public string QuestionText { get => questionText; set => questionText = value; }
        public QuestionAnswer[] QuestionAnswer { get => questionAnswer; set => questionAnswer = value; }
        public string QuestionDifficulty { get => questionDifficulty; set => questionDifficulty = value; }

        public CurrentQoestion(string questionID, string questionText, QuestionAnswer[] questionAnswer, string questionDifficulty)
        {
            this.QuestionID = questionID;
            this.QuestionText = questionText;
            this.QuestionAnswer = questionAnswer;
            this.QuestionDifficulty = questionDifficulty;
        }
    }

    public class QuestionAnswer
    {
        public string answerID;
        public string answerText;
        public string questionID;
        public string correctAnswer;

        public QuestionAnswer(string answerID, string answerText, string questionID, string correctAnswer)
        {
            this.answerID = answerID;
            this.answerText = answerText;
            this.questionID = questionID;
            this.correctAnswer = correctAnswer;
        }
    }
}
