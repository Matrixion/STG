using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STG
{
    internal class Test
    {
        static void StartTest(List<Question> test)
        {
            int count = 0;
            int questions = test.Count;
            foreach (Question q in test)
            {
                Console.WriteLine(q.QuestionText);
                Console.WriteLine();
                Console.WriteLine("1. " + q.Answers[0]);
                Console.WriteLine("2. " + q.Answers[1]);
                Console.WriteLine("3. " + q.Answers[2]);
                Console.WriteLine("4. " + q.Answers[3]);
                Console.WriteLine();
                Console.Write("Твой отговор: ");
                int answer = int.Parse(Console.ReadLine());

                if (answer == q.CorrectAnswer)
                {
                    Console.WriteLine("Това е правилния отговор!");
                    count++;
                }
                else
                {
                    Console.WriteLine($"Това е грешен отговор! Правилния беше {q.CorrectAnswer}: {q.Answers[q.CorrectAnswer]}");
                }
                Console.WriteLine();
            }

            Console.WriteLine($"Общ брой точки: {count}");
        }
    }
}
