using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnalysisOfShareExchange
{
    class SortandSearch
    {
        public string ToSort;

        //Method to get user input for the array to search and sort.
        public void GetInput()
        {
            Console.WriteLine("\nWhich Array would you like to search and sort? (1_256, 2_256, 3_256, 1_2048, 2_2048, 3_2048): ");
            ToSort = Console.ReadLine();
        }

        //Method to sort and display every 10th element of the array.
        public void SortAndDisplay(int[] selectedArray)
        {
            //Sort in ascending order.
            BubbleSort(selectedArray, ascending: true);
            Console.WriteLine("\nSorting in Ascending Order and displaying every 10th value: ");
            DisplayEvery10thValue(selectedArray);

            //Sort in descending order.
            BubbleSort(selectedArray, ascending: false);
            Console.WriteLine("\nSorting in Descending Order and displaying every 10th value: ");
            DisplayEvery10thValue(selectedArray);
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
        //Method to display every 10th value of the array.
        private void DisplayEvery10thValue(int[] array)
        {
            for (int i = 9; i < array.Length; i += 10)
            {
                Console.WriteLine($"Index {i}: {array[i]}");
            }
        }
    }
}
