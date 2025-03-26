using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Numerics;

/*
* Program Name: Analysis of Share Exchange
* Author: Harry James Michael Vowles
* Date: 27/03/2025
*
* Description:
* This program is a console-based application that reads six different files,
* sorts the data in ascending/descending order, and searches the text files for a user-defined input.
* The program allows users to analyze stock trading activity by implementing different sort and search methods.
*
* Main Functionality:
* - Reads stock exchange volume data from six input files.
* - Sorts the data in both ascending and descending order.
* - Displays every 10th (for smaller datasets) or 50th (for larger datasets) value after sorting.
* - Searches for a user-defined value and returns its location(s).
* - If the value is not found, provides the nearest value(s) and their position(s).
*
* Input Parameters:
* - Arrays containing stock exchange volume data, read from six different input files.
* - Sorting direction (ascending/descending) selected by the user.
* - Search value provided by the user for locating positions or nearest values.
* - User input to choose the array for sorting or searching.
*
* Expected Output:
* - Sorted data with selected interval values displayed (every 10th or 50th value).
* - Search results showing the position(s) of the specified value, or the nearest value(s) and their position(s).
*
* Implemented Algorithms:
* - Sorting: Bubble Sort
* - Searching: Linear Search
*/

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
            //Create an instance of the SortandSearch class.
            SortandSearch sortAndSearch = new SortandSearch();


            //Creating arrays separated by file type and file numbers.
            int[] numbersArray1_256 = fileReader.ArrayFromFile("1", "256");
            int[] numbersArray2_256 = fileReader.ArrayFromFile("2", "256");
            int[] numbersArray3_256 = fileReader.ArrayFromFile("3", "256");

            int[] numbersArray1_2048 = fileReader.ArrayFromFile("1", "2048");
            int[] numbersArray2_2048 = fileReader.ArrayFromFile("2", "2048");
            int[] numbersArray3_2048 = fileReader.ArrayFromFile("3", "2048");


            //SWITCH 1 FOR SORTING IN ASCENDING/DESCENDING + DISPLAY EVERY 10TH/50TH ELEMENT

            //Continuously ask for input until valid
            bool continueLoop = true;
            while (continueLoop)
            {
                //Get the user input to select the array
                Console.WriteLine("\nWhich Array would you like to sort?");
                sortAndSearch.GetInput();

                bool validInput = true; //Track whether input was valid

                //Based on user input, call SortAndDisplay for the selected array
                switch (sortAndSearch.ToSortOrSearch)
                {
                    case "1_256":
                        sortAndSearch.SortAndDisplay(numbersArray1_256, "256");
                        break;
                    case "2_256":
                        sortAndSearch.SortAndDisplay(numbersArray2_256, "256");
                        break;
                    case "3_256":
                        sortAndSearch.SortAndDisplay(numbersArray3_256, "256");
                        break;
                    case "1_2048":
                        sortAndSearch.SortAndDisplay(numbersArray1_2048, "2048");
                        break;
                    case "2_2048":
                        sortAndSearch.SortAndDisplay(numbersArray2_2048, "2048");
                        break;
                    case "3_2048":
                        sortAndSearch.SortAndDisplay(numbersArray3_2048, "2048");
                        break;
                    default:
                        Console.WriteLine("Invalid input. Please enter a valid array name (1_256, 2_256, 3_256, 1_2048, 2_2048, 3_2048).");
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
                        Console.Clear();
                        validInput = false; //Mark input as invalid
                        break; //Keep looping until valid input
                }

                //Only ask to continue if the input was valid
                if (validInput)
                {
                    Console.WriteLine("\nWould you like to sort another array? (yes/no): ");
                    string response = Console.ReadLine()?.ToLower();

                    if (response != "yes")
                    {
                        continueLoop = false;
                    }
                }
            }
                    //SWITCH 2 FOR SEARCHING FOR USER INPUT 

                //Continuously ask for input until valid
                bool continueLoop1 = true;
                while (continueLoop1)
                {
                    //Ask user if they want to search for a specific value.
                    Console.WriteLine("\nWould you like to search for a specific value? (yes/no): ");
                    string searchResponse = Console.ReadLine()?.ToLower();
                    if (searchResponse == "yes")
                    {
                        sortAndSearch.GetInput();
                    }
                    else
                    {
                        continueLoop1 = false;
                        Console.WriteLine("Exiting program.");
                        Environment.Exit(0);
                    }

                    //Based on user input, 
                    switch (sortAndSearch.ToSortOrSearch)
                    {
                        case "1_256":
                            sortAndSearch.SearchValue(numbersArray1_256);
                            break;
                        case "2_256":
                            sortAndSearch.SearchValue(numbersArray2_256);
                            break;
                        case "3_256":
                            sortAndSearch.SearchValue(numbersArray3_256);
                            break;
                        case "1_2048":
                            sortAndSearch.SearchValue(numbersArray1_2048);
                            break;
                        case "2_2048":
                            sortAndSearch.SearchValue(numbersArray2_2048);
                            break;
                        case "3_2048":
                            sortAndSearch.SearchValue(numbersArray3_2048);
                            break;
                        default:
                            Console.WriteLine("Invalid input. Please enter a valid array name (1_256, 2_256, 3_256, 1_2048, 2_2048, 3_2048):");
                            Console.WriteLine("Press any key to continue...");
                            Console.ReadKey();
                            Console.Clear();
                            break; //Keep looping until valid input
                    }
                }
            
        }
    }
}
