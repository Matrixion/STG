using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STG
{
    public class Question
    {
        //make list
        //split methods
        public static List<Question> Test { get; set; } = new List<Question>();
        public int ID { get; set; }
        public string QuestionText { get; set; }
        public string[] Answers { get; set; }
        public int CorrectAnswer { get; set; }

        public Question(int id, string questionText, string[] answers, int correctAnswer)
        {
            ID = id;
            QuestionText = questionText;
            Answers = answers;
            CorrectAnswer = correctAnswer;
        }

        public string ToCsvString(int id)
        {
            string CsvInfo = $"{id}^{QuestionText}^{Answers[0]}^{Answers[1]}^{Answers[2]}^{Answers[3]}^{CorrectAnswer}";
            return CsvInfo;
        }
    }
}
