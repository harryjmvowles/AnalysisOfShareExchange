using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnalysisOfShareExchange
{
    class SortandSearch
    {
        public string ToSortOrSearch;
        bool continueSorting = true;

        //Method to get user input for the array to search and sort.
        public void GetInput()
        {
            Console.WriteLine("\nPlease Input which array! (1_256, 2_256, 3_256, 1_2048, 2_2048, 3_2048): ");
            ToSortOrSearch = Console.ReadLine();
        }

        //Method to pick which sorting method to use.
        public void SortAndDisplay(int[] selectedArray, string arrayName)
        {
            //Ask the user to select the sorting algorithm
            Console.WriteLine("\nSelect Sorting Algorithm:");
            Console.WriteLine("1. Bubble Sort");
            Console.WriteLine("2. Selection Sort");
            Console.WriteLine("3. Insertion Sort");

            string userChoice = Console.ReadLine();
            int[] sortedArray;

            switch (userChoice)
            {
                case "1":
                    //Bubble Sort (ascending)
                    sortedArray = (int[])selectedArray.Clone();
                    BubbleSort(sortedArray, ascending: true);
                    Console.WriteLine("\nBubble Sort - Ascending Order:");
                    DisplayElements(sortedArray, arrayName);

                    //Bubble Sort (descending)
                    sortedArray = (int[])selectedArray.Clone();
                    BubbleSort(sortedArray, ascending: false);
                    Console.WriteLine("\nBubble Sort - Descending Order:");
                    DisplayElements(sortedArray, arrayName);
                    break;

                case "2":
                    //Selection Sort (ascending)
                    sortedArray = (int[])selectedArray.Clone();
                    SelectionSort(sortedArray, ascending: true);
                    Console.WriteLine("\nSelection Sort - Ascending Order:");
                    DisplayElements(sortedArray, arrayName);

                    //Selection Sort (descending)
                    sortedArray = (int[])selectedArray.Clone();
                    SelectionSort(sortedArray, ascending: false);
                    Console.WriteLine("\nSelection Sort - Descending Order:");
                    DisplayElements(sortedArray, arrayName);
                    break;

                case "3":
                    //Insertion Sort (ascending)
                    sortedArray = (int[])selectedArray.Clone();
                    InsertionSort(sortedArray, ascending: true);
                    Console.WriteLine("\nInsertion Sort - Ascending Order:");
                    DisplayElements(sortedArray, arrayName);

                    //Insertion Sort (descending)
                    sortedArray = (int[])selectedArray.Clone();
                    InsertionSort(sortedArray, ascending: false);
                    Console.WriteLine("\nInsertion Sort - Descending Order:");
                    DisplayElements(sortedArray, arrayName);
                    break;

                default:
                    Console.WriteLine("Invalid input. Please select 1, 2, or 3 for the sorting method.");
                    break;
            }
        }

        //Selection Sort Algorithm
        private void SelectionSort(int[] array, bool ascending)
        {
            int n = array.Length;
            for (int i = 0; i < n - 1; i++)
            {
                int selectedIndex = i;
                for (int j = i + 1; j < n; j++)
                {
                    if (ascending)
                    {
                        if (array[j] < array[selectedIndex]) //Ascending order
                        {
                            selectedIndex = j;
                        }
                    }
                    else
                    {
                        if (array[j] > array[selectedIndex]) //Descending order
                        {
                            selectedIndex = j;
                        }
                    }
                }

                // Swap the elements
                int temp = array[selectedIndex];
                array[selectedIndex] = array[i];
                array[i] = temp;
            }
        }

        //Bubble sort algorithm.
        private void BubbleSort(int[] array, bool ascending)
        {
            //Variable to store the length of the array and boolean to check if the array is swapped.
            int n = array.Length;
            bool swapped;

            //Sorting Process.
            for (int i = 0; i < n; i++)
            {
                swapped = false;
                for (int j = 0; j < n - 1; j++)
                {
                    //If the array is in ascending order.
                    if (ascending)
                    {
                        if (array[j] > array[j + 1])
                        {
                            //Swap the elements.
                            int temp = array[j];
                            array[j] = array[j + 1];
                            array[j + 1] = temp;
                            swapped = true;
                        }
                    }
                    //If the array is in descending order.
                    else
                    {
                        if (array[j] < array[j + 1])
                        {
                            //Swap the elements.
                            int temp = array[j];
                            array[j] = array[j + 1];
                            array[j + 1] = temp;
                            swapped = true;
                        }
                    }
                }
                //If no elements were swapped, the array is already sorted.
                if (!swapped)
                    break;
            }
        }

        //Insertion Sort Algorithm
        private void InsertionSort(int[] array, bool ascending)
        {
            int n = array.Length;
            for (int i = 1; i < n; i++)
            {
                int key = array[i];
                int j = i - 1;

                //For Ascending Order
                if (ascending)
                {
                    while (j >= 0 && array[j] > key)
                    {
                        array[j + 1] = array[j];
                        j--;
                    }
                }
                //For Descending Order
                else
                {
                    while (j >= 0 && array[j] < key)
                    {
                        array[j + 1] = array[j];
                        j--;
                    }
                }
                array[j + 1] = key;
            }
        }

        //Method to display elements based on array size.
        private void DisplayElements(int[] array, string arrayName)
        {
            if (arrayName.Contains("2048"))
            {
                Console.WriteLine("Displaying every 50th value (1-based Index):");
                DisplayEveryNthValue(array, 50);
            }
            else if (arrayName.Contains("256"))
            {
                Console.WriteLine("Displaying every 10th value (1-based Index):");
                DisplayEveryNthValue(array, 10);
            }
        }

        //General method to display every Nth value.
        private void DisplayEveryNthValue(int[] array, int step)
        {
            for (int i = step - 1; i < array.Length; i += step)
            {
                Console.WriteLine($"Index {i + 1}: {array[i]}");
            }
        }

       
        //Search for a value in the selected array (Linear Search).
        public void SearchValue(int[] selectedArray)
        {
            Console.Write("\nEnter a value to search for: ");
            if (int.TryParse(Console.ReadLine(), out int searchValue))
            {
                List<int> indices = new List<int>(); //List to store indices where value appears

                //Linear search through the array
                for (int i = 0; i < selectedArray.Length; i++)
                {
                    if (selectedArray[i] == searchValue)
                    {
                        //Store 1-based index
                        indices.Add(i + 1);
                    }
                }

                //If the value exists, print all locations
                if (indices.Count > 0)
                {
                    Console.WriteLine($"\nValue {searchValue} found at the following index/indices (1-based): {string.Join(", ", indices)}");
                }
                else
                {
                    Console.WriteLine($"\nError: Value {searchValue} not found in the array.");
                    //If not found, find the nearest value(s)
                    FindNearestValue(selectedArray, searchValue);
                }
            }
            else
            {
                Console.WriteLine("\nInvalid input. Please enter a valid integer.");
            }
        }

        //Method to find and display the nearest value(s) to the search value
        private void FindNearestValue(int[] array, int searchValue)
        {
            int closestDifference = int.MaxValue; //To store the smallest difference
            List<int> closestIndices = new List<int>(); //To store the indices of the nearest values
            int nearestValue = 0; //To store the value of the nearest match

            //Loop through the array to find the nearest value
            for (int i = 0; i < array.Length; i++)
            {
                int difference = Math.Abs(array[i] - searchValue);

                //If the current difference is smaller than the previously found difference
                if (difference < closestDifference)
                {
                    closestDifference = difference;
                    nearestValue = array[i];
                    closestIndices.Clear(); //Clear the list if a closer value is found
                    closestIndices.Add(i + 1);// Store the 1-based index
                }
                //If the current difference is the same as the smallest found, add to the list
                else if (difference == closestDifference)
                {
                    closestIndices.Add(i + 1);//Store the 1-based index
                }
            }

            //Display the nearest value(s) and their locations
            Console.WriteLine($"\nThe nearest value(s) to {searchValue} is/are {nearestValue} at index/indices: {string.Join(", ", closestIndices)}");
        }
    }
}
