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
        public static string ReadTextFile(string fileName)
        {
            string currentLineOfTextFile = "";
            string FullTextFileAsString = "";
            string currentAssemblyLocation = CurrentAssemblyLocation();
            try
            {
                StreamReader openTextFileContainer = new StreamReader($"{currentAssemblyLocation}\\{fileName}");

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
    }
}
