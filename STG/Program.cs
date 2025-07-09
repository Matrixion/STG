namespace STG
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ReadWrite.TestExtractor();

            //дизайн
            //избиране на рандом тест
            //избор за изтриване на файлове

            while (true)
            {
                Console.WriteLine("1. Създаване на тестове");
                Console.WriteLine("2. Играене на тест");
                Console.WriteLine("3. Излизане от програмата");
                Console.WriteLine();
                Console.Write("Какво действие искате да извършвате: ");
                int option = int.Parse(Console.ReadLine());
                CreateLine();

                if (option == 1)
                {
                    Console.WriteLine("1. Всички с една и съща дължина");
                    Console.WriteLine("2. Всички с различни дължини");
                    Console.WriteLine();
                    Console.Write("Какво действие искате да извършвате: ");
                    option = int.Parse(Console.ReadLine());
                    CreateLine();

                    if (option == 1)
                    {
                        Console.Write("Колко теста искате да бъдат направени: ");
                        int numberOfTests = int.Parse(Console.ReadLine());
                        Console.Write("Колко въпроса искате да съдържа всеки тест: ");
                        int questionCount = int.Parse(Console.ReadLine());
                        ReadWrite.CreateTestsSameLength(numberOfTests, questionCount);
                    }

                    else if (option == 2)
                    {
                        Console.Write("Колко теста искате да бъдат направени: ");
                        int numberOfTests = int.Parse(Console.ReadLine());
                        ReadWrite.CreateDifferentTests(numberOfTests);
                    }
                    CreateLine();
                }

                else if (option == 2)
                {
                    Console.Write("Какъв тест искате да играете (0 за всички въпроси): ");
                    int test = int.Parse(Console.ReadLine());
                    CreateLine();

                    if (test == 0)
                    {
                        Test.StartTest(Question.Test);
                    }

                    else
                    {
                        Test.StartTest(ReadWrite.ExtractTest(test));
                    }

                    CreateLine();
                }

                else if (option == 3) break;
            }
        }

        public static void CreateLine()
        {
            Console.WriteLine();
            Console.WriteLine("-------------------------------------------------------------------------");
            Console.WriteLine();
        }
    }
}
