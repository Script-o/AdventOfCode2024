using System;

namespace AdventOfCode2024
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //string textFileData = AccessingTextFiles.ReadTextFile("Day1Data.txt");
            //AccessingTextFiles.ExtractNumbersFromStringIntoTwoGroups(textFileData);
            
            string textFileData2 = AccessingTextFiles.ReadTextFile("Day2Data.txt");
            RegularExpressionSorting.ExtractNumbersFromStringMatchingFiveAsendingOrDecnding(textFileData2);
        }
    }
}