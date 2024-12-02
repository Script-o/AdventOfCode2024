using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Reflection;
using System.Diagnostics;
using System.Text.RegularExpressions;


namespace AdventOfCode2024
{
    public class AccessingTextFiles
    {
        public static string ReadTextFile()
        {
            string currentLineOfTextFile = "";
            string FullTextFileAsString = "";
            string currentAssemblyLocation = CurrentAssemblyLocation();
            try
            {
                StreamReader openTextFileContainer = new StreamReader($"{currentAssemblyLocation}\\Day1Data.txt");

                currentLineOfTextFile = openTextFileContainer.ReadLine();
                while (currentLineOfTextFile != null)
                {
                    FullTextFileAsString += currentLineOfTextFile + "\n";
                    currentLineOfTextFile = openTextFileContainer.ReadLine();
                }
                openTextFileContainer.Close();
                //Console.WriteLine(FullTextFileAsString);
                return FullTextFileAsString;
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
                return null;
            }
            finally
            {
                Console.WriteLine("Executing finally block.");
            }
        }

        private static string CurrentAssemblyLocation()
        {
            String currentAssemblyLocation = AppDomain.CurrentDomain.BaseDirectory;
            int indexOfBinFolderLocation = currentAssemblyLocation.IndexOf("\\bin");
            currentAssemblyLocation = currentAssemblyLocation.Remove(indexOfBinFolderLocation);
            return currentAssemblyLocation;
        }

        public static void ExtractNumbersFromString()
        {
            string pattern = @"\d+";
            string sentence = ReadTextFile();
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

        
    }
}
