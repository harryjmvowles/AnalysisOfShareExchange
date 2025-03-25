using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Numerics;

namespace AnalysisOfShareExchange
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //File Names to Access both 256 and 2048 numbers.
            string[] fileNames = { "Share_1_256.txt", "Share_2_256.txt", "Share_3_256.txt", "Share_1_2048.txt", "Share_2_2048.txt", "Share_3_2048.txt" };

            //Creating an instance of the FileReader class and Calls ArrayFromFile method to create an
            //array of numbers from the file.
            FileReader fileReader = new FileReader(fileNames);
            int[] numbersArray256 = fileReader.ArrayFromFile("256");
            int[] numbersArray2048 = fileReader.ArrayFromFile("2048");

            Console.WriteLine("Numbers from 256 files: " + string.Join(", ", numbersArray256));
            Console.WriteLine("Numbers from 2048 files: " + string.Join(", ", numbersArray2048));

        }
    }
}
