namespace STG
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ReadWrite.TestExtractor();

            //дизайн
            //създаване на брой въпроси и тестове
            //играене на тестове (избиране на рандом тест)
            //избор за изтриване на файлове
            //собствено създаване на въпроси и тестове

            Console.Write("Колко теста искате да бъдат направени: ");
            int numberOfTests = int.Parse(Console.ReadLine());
            Console.Write("Колко въпроса искате да съдържа всеки тест: ");
            int questionCount = int.Parse(Console.ReadLine());
            ReadWrite.CreateTests(numberOfTests, questionCount);
        }
    }
}
