using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2024
{
    public class ColumnComparison
    {
        public static int FindDifferenceDistanceBetweenLists(List<NumberCode> NumberGroup1, List<NumberCode> NumberGroup2)
        {
            int loopCounter = 0;
            int totalDifference = 0;
            foreach (NumberCode currentNumber in NumberGroup1)
            {
                int numberGroup1AsInt = NumberGroup1[loopCounter].ObjectNumber;
                int numberGroup2AsInt = NumberGroup2[loopCounter].ObjectNumber;
                if (numberGroup1AsInt > numberGroup2AsInt)
                {
                    totalDifference += numberGroup1AsInt - numberGroup2AsInt;
                }
                else
                {
                    totalDifference += numberGroup2AsInt - numberGroup1AsInt;
                }

                //Console.WriteLine("Group 1 - " + numberGroup1AsInt);
                //Console.WriteLine("Group 2 - " + numberGroup2AsInt);
                loopCounter++;
            }

            return totalDifference;
        }

        public static int FindMatchesBetweenLists(List<NumberCode> NumberGroup1, List<NumberCode> NumberGroup2)
        {
            int loopCounter = 0;
            int similarityScore = 0;
            foreach (NumberCode currentNumber in NumberGroup1)
            {
                int matchedAmount = 0;
                foreach (NumberCode currentNumberSecondList in NumberGroup2)
                {
                    if ( currentNumber.ObjectNumber == currentNumberSecondList.ObjectNumber)
                    {
                        matchedAmount++;
                    }
                }
                if (matchedAmount != 0) {
                    similarityScore += currentNumber.ObjectNumber * matchedAmount;
                }
                loopCounter++;
            }

            return similarityScore;
        }
    }
}
