namespace STG
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ReadWrite.TestExtractor();
            // извлича тестовете от файла и ги записва в списъка Question.Test

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\r\n  _______        _      _____                           _             " +
                "\r\n |__   __|      | |    / ____|                         | |            " +
                "\r\n    | | ___  ___| |_  | |  __  ___ _ __   ___ _ __ __ _| |_ ___  _ __ " +
                "\r\n    | |/ _ \\/ __| __| | | |_ |/ _ \\ '_ \\ / _ \\ '__/ _` | __/ _ \\| '__|" +
                "\r\n    | |  __/\\__ \\ |_  | |__| |  __/ | | |  __/ | | (_| | || (_) | |   " +
                "\r\n    |_|\\___||___/\\__|  \\_____|\\___|_| |_|\\___|_|  \\__,_|\\__\\___/|_|   " +
                "\r\n                                                                      " +
                "\r\n                                                                      \r\n");
            Console.ForegroundColor= ConsoleColor.White;

            while (true)
            //докато не излезе от програмата ще се върти цикълът
            {
                Console.WriteLine("1. Създаване на тестове");
                Console.WriteLine("2. Играене на тест");
                Console.WriteLine("3. Излизане от програмата");
                Console.WriteLine();
                Console.Write("Изберете едно действие от изброените отгоре: ");

                int option = int.Parse(Console.ReadLine());
                CreateLine();

                if (option == 1)
                // ако избере 1 ще се създават тестове
                {
                    Console.WriteLine("1. Всички с една и съща дължина");
                    Console.WriteLine("2. Всички с различни дължини");
                    Console.WriteLine();
                    Console.Write("Изберете едно действие от изброените отгоре: ");
                    option = int.Parse(Console.ReadLine());
                    CreateLine();

                    if (option == 1)
                    // ако избере 1 ще се създават тестове с една и съща дължина
                    {
                        Console.Write("Колко теста искате да бъдат направени: ");
                        int numberOfTests = int.Parse(Console.ReadLine());
                        Console.Write("Колко въпроса искате да съдържа всеки тест: ");
                        int questionCount = int.Parse(Console.ReadLine());
                        ReadWrite.CreateTestsSameLength(numberOfTests, questionCount);
                    }

                    else if (option == 2)
                    // ако избере 2 ще се създават тестове с различна дължина
                    {
                        Console.Write("Колко теста искате да бъдат направени: ");
                        int numberOfTests = int.Parse(Console.ReadLine());
                        ReadWrite.CreateDifferentTests(numberOfTests);
                    }
                    CreateLine();
                }

                else if (option == 2)
                // ако избере 2 ще се играят тестове
                {
                    Console.Write("Какъв тест искате да играете (0 за всички въпроси): ");
                    int test = int.Parse(Console.ReadLine());
                    CreateLine();

                    if (test == 0)
                    // ако избере 0 ще се играят всички въпроси
                    {
                        Test.StartTest(Question.Test);
                    }

                    else
                    // ако избере друг номер, ще се играе само този тест
                    {
                        Test.StartTest(ReadWrite.ExtractTest(test));
                    }

                    CreateLine();
                }

                else if (option == 3) break;// ако избере 3 ще излезе от програмата
            }
        }

        public static void CreateLine()
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("-------------------------------------------------------------------------");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
        }
    }
}
