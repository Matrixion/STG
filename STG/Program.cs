namespace STG
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Question.TestExtractor();

            Console.Write("Колко теста искате да бъдат направени: ");
            int numberOfTests = int.Parse(Console.ReadLine());
            Console.Write("Колко въпроса искате да съдържа всеки тест: ");
            int questionCount = int.Parse(Console.ReadLine());
            Question.CreateTests(numberOfTests, questionCount);
        }
    }
}
