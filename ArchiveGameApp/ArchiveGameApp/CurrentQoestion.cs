using Newtonsoft.Json;
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
        public string questionIndex;
     
        public CurrentQoestion(string questionID, string questionText, QuestionAnswer[] questionAnswers, string questionDifficulty, string questionIndex)
        {
            this.questionID = questionID;
            this.questionText = questionText;
            this.questionAnswers = questionAnswers;
            this.questionDifficulty = questionDifficulty;
            this.questionIndex = questionIndex;
        }
    }

    public class QuestionAnswer
    {
        public string _id;
        public string answerID;
        public string answerText;
        public string questionID;
        public string correctAnswer;

        /*
        public QuestionAnswer(string answerID, string answerText, string questionID, string correctAnswer)
        {
            this.answerID = answerID;
            this.answerText = answerText;
            this.questionID = questionID;
            this.correctAnswer = correctAnswer;
        }
        */
        public QuestionAnswer(string _id, string answerID, string answerText, string questionID, string correctAnswer)
        {
            this._id = _id;
            this.answerID = answerID;
            this.answerText = answerText;
            this.questionID = questionID;
            this.correctAnswer = correctAnswer;
        }
    }

    public class AnswerRelation
    {
        public string answerID;
        public string playerID;

        public AnswerRelation(string answerID, string playerID)
        {
            this.answerID = answerID;
            this.playerID = playerID;
        }
    }
}
