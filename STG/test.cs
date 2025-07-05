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




        static void Main()
        {
            string filePath = "test.txt";
            List<test> tests = new List<test>();
            foreach (string line in File.ReadLines(filePath))
            {
                string[] parts = line.Split('^');
                if (parts.Length != 7)
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
        }
    }
}
