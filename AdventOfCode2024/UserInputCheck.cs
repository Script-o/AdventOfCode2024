using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2024
{
    public class UserInputCheck
    {
        public static int IntegerCheck(string input)
        {
            bool inputCheck = false;
            int intInput = 0;
            while (inputCheck == false)
            {
                if (int.TryParse(input, out intInput))
                {
                    inputCheck = true;
                }
                else
                {
                    Console.WriteLine("\nSorry, that doesn't appear to be a valid number. \nYou must enter a whole number, an example would be '12'.");
                    input = Console.ReadLine() ?? "";
                }
            }
            return intInput;
        }

        public static decimal DecimalCheck(string input)
        {
            bool inputCheck = false;
            decimal decInput = 0;
            while (inputCheck == false)
            {
                if (decimal.TryParse(input, out decInput))
                {
                    inputCheck = true;
                }
                else
                {
                    Console.WriteLine("\nSorry, that doesn't appear to be a valid decimal. \nYou must enter a decimal number, an example would be '1.5'.");
                    input = Console.ReadLine() ?? "";
                }
            }
            return decInput;
        }

        public static bool BoolCheck(string input)
        {
            bool inputCheck = false;
            bool boolInput = false;
            while (inputCheck == false)
            {
                if (bool.TryParse(input, out boolInput))
                {
                    inputCheck = true;
                }
                else
                {
                    Console.WriteLine("\nSorry, that doesn't appear to be a valid true/false statement. \nYou must enter either 'true' or 'false'.");
                    input = Console.ReadLine() ?? "";
                }
            }
            return boolInput;
        }
    }
}
