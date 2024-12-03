using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AdventOfCode2024
{
    public class RegularExpressionSorting
    {
        public static void ExtractNumbersFromStringIntoTwoGroups(string rawTextFileData)
        {
            string pattern = @"\d+";
            string sentence = rawTextFileData;
            int totalDifference = 0;
            //Console.WriteLine(sentence);

            try
            {
                List<NumberCode> NumberGroup1 = new List<NumberCode>();
                List<NumberCode> NumberGroup2 = new List<NumberCode>();

                bool groupToggle = true;
                foreach (Match match in Regex.Matches(sentence, pattern,
                                                      RegexOptions.None,
                                                      TimeSpan.FromSeconds(1)))
                    if (groupToggle)
                    {
                        int numberAsInt = UserInputCheck.IntegerCheck(match.Value);
                        //Console.WriteLine("Add Group 1 - " + match.Value);
                        NumberGroup1.Add(new NumberCode() { ObjectNumber = numberAsInt });
                        groupToggle = false;
                    }
                    else
                    {
                        int numberAsInt = UserInputCheck.IntegerCheck(match.Value);
                        //Console.WriteLine("Add Group 2 - " + match.Value);
                        NumberGroup2.Add(new NumberCode() { ObjectNumber = numberAsInt });
                        groupToggle = true;
                    }
                NumberGroup1.Sort();
                NumberGroup2.Sort();
                //totalDifference = ColumnComparison.FindDifferenceDistanceBetweenLists(NumberGroup1, NumberGroup2);
                totalDifference = ColumnComparison.FindMatchesBetweenLists(NumberGroup1, NumberGroup2);
            }
            catch (RegexMatchTimeoutException)
            {
                // Do Nothing: Assume that timeout represents no match.
            }
            Console.WriteLine(totalDifference);
        }
        public static void ExtractNumbersFromStringMatchingFiveAsendingOrDecnding(string rawTextFileData)
        {
            string pattern = @"(\d+|\n)";
            string sentence = rawTextFileData;
            int numberOfSuccessfulOptions = 0;
            //Console.WriteLine(sentence);

            try
            {
                List<NumberCode> NumberGroup = new List<NumberCode>();

                int groupToggle = 0;
                int maxIterations = 5;
                int numberAsInt = 0;
                foreach (Match match in Regex.Matches(sentence, pattern,
                                                      RegexOptions.None,
                                                      TimeSpan.FromSeconds(1)))
                {
                    groupToggle++;
                    if (match.Value != "\n")
                    {
                        numberAsInt = UserInputCheck.IntegerCheck(match.Value);
                        NumberGroup.Add(new NumberCode() { ObjectNumber = numberAsInt });
                        //Console.WriteLine(numberAsInt);
                    }


                    if (match.Value == "\n")
                    {
                        ColumnComparison columnComparison = new ColumnComparison();
                        numberOfSuccessfulOptions += columnComparison.GoThroughListToCheckConditions(NumberGroup);
                        NumberGroup.Clear();
                    }
                }
                Console.WriteLine("Number of Safe Options: " + numberOfSuccessfulOptions);
            }
            catch (RegexMatchTimeoutException)
            {
                // Do Nothing: Assume that timeout represents no match.
            }
        }
    }
}
