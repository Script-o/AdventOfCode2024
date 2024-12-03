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

        public int GoThroughListToCheckConditions(List<NumberCode> NumberGroup)
        {
            int loopCounter = 0;
            int itemNumberToBeSkipped = 0;
            bool decending = false;
            bool ascending = false;
            bool safeConditions = true;
            foreach (NumberCode currentNumber in NumberGroup)
            {
                if (loopCounter + 1 < NumberGroup.Count)
                {
                    if (currentNumber.ObjectNumber > NumberGroup[loopCounter + 1].ObjectNumber)
                    {
                        decending = true;
                    }
                    if (currentNumber.ObjectNumber < NumberGroup[loopCounter + 1].ObjectNumber)
                    {
                        ascending = true;
                    }
                    if (decending == ascending)
                    {
                        safeConditions = false;
                        if (itemNumberToBeSkipped == 0) {itemNumberToBeSkipped = loopCounter; }
                    }
                    if (currentNumber.ObjectNumber >= NumberGroup[loopCounter + 1].ObjectNumber + 4)
                    {
                        safeConditions = false;
                        if (itemNumberToBeSkipped == 0) { itemNumberToBeSkipped = loopCounter; }
                    }
                    if (currentNumber.ObjectNumber <= NumberGroup[loopCounter + 1].ObjectNumber - 4)
                    {
                        safeConditions = false;
                        if (itemNumberToBeSkipped == 0) { itemNumberToBeSkipped = loopCounter; }
                    }
                    if (currentNumber.ObjectNumber == NumberGroup[loopCounter + 1].ObjectNumber)
                    {
                        safeConditions = false;
                        if (itemNumberToBeSkipped == 0) { itemNumberToBeSkipped = loopCounter; }
                    }
                }
                loopCounter++;
            }

            if (safeConditions == false)
            {
                loopCounter = 0;
                decending = false;
                ascending = false;
                int skipAmount = 0;
                safeConditions = true;
                foreach (NumberCode currentNumber in NumberGroup)
                {
                    if (itemNumberToBeSkipped == loopCounter)
                    {
                        Console.WriteLine("Skipping: " + currentNumber.ObjectNumber);
                        skipAmount++;
                    }
                    if (loopCounter + skipAmount + 1 < NumberGroup.Count)
                    {
                        if (currentNumber.ObjectNumber > NumberGroup[loopCounter + skipAmount + 1].ObjectNumber)
                        {
                            decending = true;
                        }
                        if (currentNumber.ObjectNumber < NumberGroup[loopCounter + skipAmount + 1].ObjectNumber)
                        {
                            ascending = true;
                        }
                        if (decending == ascending)
                        {
                            safeConditions = false;
                        }
                        if (currentNumber.ObjectNumber >= NumberGroup[loopCounter + skipAmount + 1].ObjectNumber + 4)
                        {
                            safeConditions = false;
                        }
                        if (currentNumber.ObjectNumber <= NumberGroup[loopCounter + skipAmount + 1].ObjectNumber - 4)
                        {
                            safeConditions = false;
                        }
                        if (currentNumber.ObjectNumber == NumberGroup[loopCounter + skipAmount + 1].ObjectNumber)
                        {
                            safeConditions = false;
                        }
                    }
                    loopCounter++;
                }
            }


            if (safeConditions)
            {
                Console.WriteLine($"Safe: {NumberGroup[0].ObjectNumber} {NumberGroup[1].ObjectNumber} {NumberGroup[2].ObjectNumber} {NumberGroup[3].ObjectNumber} {NumberGroup[4].ObjectNumber}");
                return 1;
            }
            return 0;
        }
    }
}
