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
        /*
        public string QuestionID { get => questionID; set => questionID = value; }
        public string QuestionText { get => questionText; set => questionText = value; }
        public QuestionAnswer[] QuestionAnswer { get => questionAnswer; set => questionAnswer = value; }
        public string QuestionDifficulty { get => questionDifficulty; set => questionDifficulty = value; }
        */
        public CurrentQoestion(string questionID, string questionText, QuestionAnswer[] questionAnswers, string questionDifficulty)
        {
            this.questionID = questionID;
            this.questionText = questionText;
            this.questionAnswers = questionAnswers;
            this.questionDifficulty = questionDifficulty;
        }
    }

    /*
      QuestionSchema = new Schema({
    questionID: String,
    questionText: String,
    questionAnswers: [{
        answerID: String,
        answerText: String,
        questionID: String,
        correctAnswer: String}],
    questionDifficulty: String     */

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
