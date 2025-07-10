using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STG
{
    internal class Test
    {
        public static void StartTest(List<Question> test)
        {
            double count = 0;
            int questions = test.Count;
            Console.Write("Какво е твоето име: ");
            string name = Console.ReadLine();
            Console.WriteLine();
            for (int i = 0; i < questions; i++)
            {
                Console.WriteLine($"Въпрос {i + 1}/{test.Count}: {test[i].QuestionText}");
                Console.WriteLine();
                Console.WriteLine("1. " + test[i].Answers[0]);
                Console.WriteLine("2. " + test[i].Answers[1]);
                Console.WriteLine("3. " + test[i].Answers[2]);
                Console.WriteLine("4. " + test[i].Answers[3]);
                Console.WriteLine();
                Console.Write("Твойят отговор: ");
                int answer = int.Parse(Console.ReadLine());
                Console.WriteLine();

                if (answer == test[i].CorrectAnswer)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Това е правилният отговор!");
                    Console.ForegroundColor = ConsoleColor.White;
                    count++;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Това е грешен отговор! Правилният беше {test[i].CorrectAnswer}: {test[i].Answers[test[i].CorrectAnswer-1]}");
                    Console.ForegroundColor = ConsoleColor.White;
                }

                Program.CreateLine();
            }
            Console.WriteLine($"{name} имаш {count}/{test.Count} точки");
            Console.WriteLine("Оценка: "+(((count * 4) / test.Count )+ 2));
        }
    }
}
