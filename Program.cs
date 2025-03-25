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

            //Create an instance of the FileReader class.
            FileReader fileReader = new FileReader(fileNames);

            //Creating arrays separated by file type and file numbers.
            int[] numbersArray1_256 = fileReader.ArrayFromFile("1", "256");
            int[] numbersArray2_256 = fileReader.ArrayFromFile("2", "256");
            int[] numbersArray3_256 = fileReader.ArrayFromFile("3", "256");

            int[] numbersArray1_2048 = fileReader.ArrayFromFile("1", "2048");
            int[] numbersArray2_2048 = fileReader.ArrayFromFile("2", "2048");
            int[] numbersArray3_2048 = fileReader.ArrayFromFile("3", "2048");

            //Create an instance of the SortandSearch class.
            SortandSearch sortAndSearch = new SortandSearch();

            //Continuously ask for input until valid
            bool continueLoop = true;
            while (continueLoop)
            {
                //Get the user input to select the array
                sortAndSearch.GetInput();

                //Based on user input, call SortAndDisplay for the selected array
                switch (sortAndSearch.ToSort)
                {
                    case "1_256":
                        sortAndSearch.SortAndDisplay(numbersArray1_256);
                        break;
                    case "2_256":
                        sortAndSearch.SortAndDisplay(numbersArray2_256);
                        break;
                    case "3_256":
                        sortAndSearch.SortAndDisplay(numbersArray3_256);
                        break;
                    case "1_2048":
                        sortAndSearch.SortAndDisplay(numbersArray1_2048);
                        break;
                    case "2_2048":
                        sortAndSearch.SortAndDisplay(numbersArray2_2048);
                        break;
                    case "3_2048":
                        sortAndSearch.SortAndDisplay(numbersArray3_2048);
                        break;
                    default:
                        Console.WriteLine("Invalid input. Please enter a valid array name (1_256, 2_256, 3_256, 1_2048, 2_2048, 3_2048):");
                        break; //Keep looping until valid input
                }
                //Ask if they want to continue sorting another array
                Console.WriteLine("\nWould you like to sort another array? (yes/no): ");
                string response = Console.ReadLine()?.ToLower();

                if (response != "yes")
                {
                    continueLoop = false;
                    Console.WriteLine("Exiting the program.");
                }
            }
        }
    }
}
