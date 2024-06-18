using System;
using System.Collections.Generic;
using System.IO;

namespace Renju
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Enter file path, please:");
            string filePath = Console.ReadLine();
            List<string> lines = new();
            try
            {
                lines.AddRange(File.ReadAllLines(filePath));
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                return;
            }

            int testCasesNum;
            try
            {
                testCasesNum = Convert.ToInt32(lines[0]);
                if (testCasesNum < 1 || testCasesNum > 11)
                {
                    throw new Exception();
                }
            }
            catch (Exception)
            {
                Console.WriteLine($"An error occurred: Incrrect number of test cases");
                return;
            }

            List<TestCase> testCaseList = new();
            try
            {
                for (int i = 0; i < testCasesNum; i++)
                {
                    testCaseList.Add(new TestCase(lines.GetRange(i * TestCase.BoardSize + 1, TestCase.BoardSize)));
                }
            }
            catch (Exception)
            {
                Console.WriteLine($"An error occurred: Incorrect number of lines in {testCasesNum} test cases");
                return;
            }

            for (int i = 0; i < testCasesNum; i++)
            {
                Console.WriteLine($"Test case {i + 1}");
                if (!testCaseList[i].CheckTest())
                {
                    Console.WriteLine($"Incorrect test case");
                    continue;
                }
                testCaseList[i].Process();
                Console.WriteLine(testCaseList[i].ReturnResult());
                Console.WriteLine();
            }

        }
    }
}
