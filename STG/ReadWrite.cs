using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace STG
{
    internal class ReadWrite
    {
        static string _filepath = "../../../tiktok_meme_test_40.txt";

        public static void TestExtractor()
        // извлича въпросите от файла и ги записва в списъка Question.Test
        {
            foreach (string line in File.ReadLines(_filepath))
            {
                string[] parts = line.Split('^');
                if (parts.Length == 7)
                {
                    int id = int.Parse(parts[0]);
                    string questionText = parts[1];
                    string[] answers = new string[] { parts[2], parts[3], parts[4], parts[5], };
                    int correctAnswer = int.Parse(parts[6]);
                    Question q = new Question(id, questionText, answers, correctAnswer);
                    Question.Test.Add(q);
                }
            }
        }

        public static List<Question> ExtractTest(int test)
        // извлича теста с номер test от файла test_readable_{test}.txt и го връща като списък от въпроси
        {
            string filePath = $"../../../test_readable_{test}.txt";
            List<Question> questions = new List<Question>();
            foreach (string line in File.ReadLines(filePath))
            {
                string[] parts = line.Split('^');
                if (parts.Length == 7)
                {
                    int id = int.Parse(parts[0]);
                    string questionText = parts[1];
                    string[] answers = new string[] { parts[2], parts[3], parts[4], parts[5], };
                    int correctAnswer = int.Parse(parts[6]);
                    Question q = new Question(id, questionText, answers, correctAnswer);
                    questions.Add(q);
                }
            }
            return questions;
        }

        public static void CreateDifferentTests(int numberOfTests)
        // създава различни тестове с различен брой въпроси, като всеки тест съдържа случайно избрани
        // въпроси от списъка Question.Test
        {
            Random random = new Random();

            for (int i = 1; i <= numberOfTests; i++)
            {
                if (FindExistingTest(i))
                {
                    List<int> usedNumbers = new List<int>();

                    string newfilepath_readable = $"../../../test_readable_{i}.txt";
                    string newfilepath = $"../../../test_{i}.txt";

                    List<string> lines = new List<string>();
                    List<string> csvLines = new List<string>();

                    csvLines.Add($"ТЕСТ {i}");
                    csvLines.Add($" ");
                    csvLines.Add($"ИМЕ:                                       Клас:");
                    csvLines.Add($" ");


                    Console.WriteLine($"Колко въпроса искате да съдържа тест {i}: ");
                    int questionCount = int.Parse(Console.ReadLine());

                    for (int j = 1; j <= questionCount; j++)
                    {
                        int randomIndex = random.Next(Question.Test.Count);

                        if (usedNumbers.Contains(randomIndex)) j--;
                        else
                        {
                            Question selectedQuestion = Question.Test[randomIndex];
                            selectedQuestion.MixAnswers();
                            
                            string line1 = selectedQuestion.ToCsvStringReadable(j);
                            lines.Add(line1);
                           

                            string[] line2 = selectedQuestion.ToCsvString(j);
                            foreach (string s in line2)
                            {
                                csvLines.Add(s);
                            }
                            usedNumbers.Add(randomIndex);
                            // добавя въпроса в списъка с въпроси за теста
                        }
                    }

                    File.WriteAllLines(newfilepath_readable, lines);//файлът с четими въпроси за програмата
                    File.WriteAllLines(newfilepath, csvLines);// txt файл с въпроси на тестове
                }
            }
        }

        public static void CreateTestsSameLength(int numberOfTests, int questionCount)
        // създава тестове с една и съща дължина, като всеки тест съдържа случайно избрани въпроси от списъка Question.Test
        {
            Random random = new Random();

            for (int i = 1; i <= numberOfTests; i++)
            {
                if (FindExistingTest(i))
                {
                    List<int> usedNumbers = new List<int>();
                    List<string> lines = new List<string>();
                    List<string> csvLines = new List<string>();

                    csvLines.Add($"ТЕСТ {i}");
                    csvLines.Add($" ");
                    csvLines.Add($"ИМЕ:                                       Клас:");
                    csvLines.Add($" ");

                    string newfilepath_readable = $"../../../test_readable_{i}.txt"; //файлът с четими въпроси за програмата
                    string newfilepath = $"../../../test_{i}.txt";// txt файл с въпроси на тестове


                    for (int j = 1; j <= questionCount; j++)
                    {
                        int randomIndex = random.Next(Question.Test.Count);

                        if (usedNumbers.Contains(randomIndex)) j--;
                        else
                        {
                            Question selectedQuestion = Question.Test[randomIndex];
                            selectedQuestion.MixAnswers();

                            string line = selectedQuestion.ToCsvStringReadable(j);
                            lines.Add(line);

                            usedNumbers.Add(randomIndex);

                            string[] line2 = selectedQuestion.ToCsvString(j);
                            foreach (string s in line2)
                            {
                                csvLines.Add(s);
                            }
                            usedNumbers.Add(randomIndex);
                            // добавя въпроса в списъка с въпроси за теста
                        }
                    }

                    File.WriteAllLines(newfilepath_readable, lines);//файлът с четими въпроси за програмата
                    File.WriteAllLines(newfilepath, csvLines);// txt файл с въпроси на тестове
                }
            }
        }

        public static bool FindExistingTest(int test)
        // проверява дали файлът test_{test}.txt вече съществува и ако да, пита потребителя дали иска да го презапише
        {
            if (File.Exists($"../../../test_{test}.txt"))
            {
                Console.WriteLine();
                Console.WriteLine($"test_{test}.txt вече съществува. Искате ли да презапишете файла?");
                Console.WriteLine();
                Console.WriteLine("1. ДА");
                Console.WriteLine("2. НЕ");
                Console.WriteLine();
                Console.Write("Отговор: ");
                int answer = int.Parse(Console.ReadLine());

                if (answer == 1) return true;
                else if (answer == 2) return false;
                else FindExistingTest(test);
            }

            return false;
        }
    }
}
