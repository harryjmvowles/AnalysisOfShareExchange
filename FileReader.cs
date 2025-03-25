using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnalysisOfShareExchange
{
    class FileReader
    {
        private string[] fileNames;

        //constructor to initialise the fileNames.
        public FileReader(string[] fileNames)
        {
            this.fileNames = fileNames;
        }

        //Method to read and filter numbers from files based on type(256 or 2048).
        public int[] ArrayFromFile(string fileTypes)
        {
            //Inistialise a list to store the numbers.
            List<int> numbersList = new List<int>();
            
            foreach (string file in fileNames)
            {
                //Checks if the file exists and if it contains the correct type (256 or 2048).
                if (file.Contains(fileTypes) && File.Exists(file))
                {
                    string[] lines = File.ReadAllLines(file);
                    foreach (string line in lines)
                    {
                        if (int.TryParse(line, out int number))
                        {
                            numbersList.Add(number); //Add the number to the list.
                        }
                    }
                }
                else if (!file.Contains(fileTypes))
                {
                    continue; //Skip files that don't match the type
                }
                else
                {
                    Console.WriteLine($"File not found: {file}");
                }
            }
            return numbersList.ToArray();
        }

    }
}
