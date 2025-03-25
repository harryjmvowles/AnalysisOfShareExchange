using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AnalysisOfShareExchange
{
    class FileReader
    {
        private string[] fileNames;

        //Constructor to initialize the fileNames.
        public FileReader(string[] fileNames)
        {
            this.fileNames = fileNames;
        }

        //Method to read and filter numbers from files based on file number and type (256 or 2048).
        public int[] ArrayFromFile(string fileNum, string fileType)
        {
            List<int> numbersList = new List<int>();

            //Expression pattern to match Share_X_256.txt (where X is the file number)
            string pattern = $@"^Share_{fileNum}_{fileType}\.txt$";

            Console.WriteLine("\nCreating an Array: ");
            foreach (string file in fileNames)
            {
                //Use regular expression to match the exact file format.
                if (Regex.IsMatch(file, pattern) && File.Exists(file))
                {
                    string[] lines = File.ReadAllLines(file);
                    foreach (string line in lines)
                    {
                        if (int.TryParse(line, out int number))
                        {
                            numbersList.Add(number);
                        }
                    }
                }
                else
                {
                    //If the file doesn't match the expected name, skip it
                    Console.WriteLine($"Skipping file: {file}. It doesn't match {fileNum}_{fileType}.txt.");
                }
            }

            return numbersList.ToArray();
        }
    }
}

