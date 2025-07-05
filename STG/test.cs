using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STG
{
    public class test
    {
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
            List<test> tests = new List<test>();
            foreach (string line in File.ReadLines(filePath))
            {
                string[] parts = line.Split('^');
                if (parts.Length == 7)
                {
                     test i = new test
                    {
                        ID = int.Parse(parts[0]),
                        QuestionText = parts[1],
                        Answer1 = parts[2],
                        Answer2 = parts[3],
                        Answer3 = parts[4],
                        Answer4 = parts[5],
                        CorrectAnswer = parts[6]
                    };
                    tests.Add(i);
                }
            }

            Console.Write("Колко теста искате да бъдат направени: " );
            int numberOfQuestions = int.Parse(Console.ReadLine());

            Random random = new Random();

            for (int i = 0; i < numberOfQuestions; i++)
            {
                int randomIndex = random.Next(tests.Count);

                test selectedTest = tests[randomIndex];
                using (StreamWriter write = new StreamWriter($"../../../test_{i + 1}.txt"))
                {
                    write.WriteLine($"Тест {i + 1}");
                    write.WriteLine($"Въпрос: {selectedTest.QuestionText}");
                    write.WriteLine($"1. {selectedTest.Answer1}");
                    write.WriteLine($"2. {selectedTest.Answer2}");
                    write.WriteLine($"3. {selectedTest.Answer3}");
                    write.WriteLine($"4. {selectedTest.Answer4}");
                    write.WriteLine($"Правилен отговор: {selectedTest.CorrectAnswer}");
                    write.WriteLine();
                }
            }
        }
    }
}
