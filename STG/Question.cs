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
        public string Answer1 { get; set; }
        public string Answer2 { get; set; }
        public string Answer3 { get; set; }
        public string Answer4 { get; set; }
        public string CorrectAnswer { get; set; }

        public static void TestExtractor()
        {
            string filePath = "../../../tiktok_meme_test_40.txt";
            foreach (string line in File.ReadLines(filePath))
            {
                string[] parts = line.Split('^');
                if (parts.Length == 7)
                {
                     Question i = new Question
                    {
                        ID = int.Parse(parts[0]),
                        QuestionText = parts[1],
                        Answer1 = parts[2],
                        Answer2 = parts[3],
                        Answer3 = parts[4],
                        Answer4 = parts[5],
                        CorrectAnswer = parts[6]
                    };
                    Test.Add(i);
                }
            }
        }

        public string ToCsvString(int id)
        {
            string CsvInfo = $"{id}^{QuestionText}^{Answer1}^{Answer2}^{Answer3}^{Answer4}^{CorrectAnswer}";
            return CsvInfo;
        }

        public static void CreateTests(int numberOfTests, int questionCount)
        {
            Random random = new Random();

            for (int i = 1; i <= numberOfTests; i++)
            {
                List<int> usedNumbers = new List<int>();
                string newfilepath = $"../../../test_{i}.txt";
                List<string> lines = new List<string>();

                for (int j = 1; j <= questionCount; j++)
                {
                    int randomIndex = random.Next(Test.Count);

                    if (usedNumbers.Contains(randomIndex)) j--;
                    else
                    {
                        Question selectedTest = Test[randomIndex];
                        string line = selectedTest.ToCsvString(j);
                        lines.Add(line);
                        usedNumbers.Add(randomIndex);
                    }
                }

                File.WriteAllLines(newfilepath, lines);
            }
        }
    }
}
