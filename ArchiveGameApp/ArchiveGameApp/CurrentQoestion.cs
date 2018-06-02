using System;
using System.Collections.Generic;
using System.Text;

namespace ArchiveGameApp
{
    public class CurrentQoestion
    {
        public string questionID;
        public string questionText;
        public QuestionAnswer[] questionAnswers;
        public string questionDifficulty;
     
        public CurrentQoestion(string questionID, string questionText, QuestionAnswer[] questionAnswers, string questionDifficulty)
        {
            this.questionID = questionID;
            this.questionText = questionText;
            this.questionAnswers = questionAnswers;
            this.questionDifficulty = questionDifficulty;
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

    public class AswerRelation
    {
        string answerID;
        string playerID;

        public AswerRelation(string answerID, string playerID)
        {
            this.answerID = answerID;
            this.playerID = answerID;
        }
    }


}
