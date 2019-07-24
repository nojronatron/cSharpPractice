using System;
using System.Diagnostics;

namespace ComparingSortAlgorithms
{
    class Program
    {
        static Random rand = new Random(DateTime.Now.Millisecond);
        static int arraySize = 70_000;

        static void Main(string[] args)
        {

            int[] array = new int[arraySize];
            Initialize(array);
            int[] marray = new int[array.Length];
            int[] qarray = new int[array.Length];
            int[] iarray = new int[array.Length];
            //copy
            array.CopyTo(marray, 0);
            array.CopyTo(qarray, 0);
            array.CopyTo(iarray, 0);

            //use stopwatch to time the bubblesort as well as the Mergesort
            Stopwatch sw = new Stopwatch();
            sw.Start();
            BubbleSortArray(array);
            sw.Stop();
            string bubblesorttime = sw.Elapsed.ToString();

            sw = new Stopwatch();
            sw.Start();
            MergeSort(marray, 0, array.Length - 1);
            sw.Stop();
            string mergesorttime = sw.Elapsed.ToString();

            sw = new Stopwatch();
            sw.Start();
            QuickSort(qarray, 0, array.Length - 1);
            sw.Stop();
            string quicksorttime = sw.Elapsed.ToString();

            sw = new Stopwatch();
            sw.Start();
            InsertionSort(iarray);
            sw.Stop();
            string insertionsorttime = sw.Elapsed.ToString();

            Console.WriteLine("\n\nNumber of values sorted is: {0}", array.Length);
            Console.WriteLine("\n\nBubble sort time: {0}", bubblesorttime);
            Console.WriteLine("\n\nMerge sort time: {0}", mergesorttime);
            Console.WriteLine("\n\nQuick sort time: {0}", quicksorttime);
            Console.WriteLine("\n\nInsertion sort time: {0}", insertionsorttime);

            Console.WriteLine("\n\nPress <Enter> To Exit. . .");
            Console.ReadKey();
        }

        static void Initialize(int[] a)
        {
            for (int i = 0; i < a.Length; i++)
                a[i] = rand.Next(1000000, 9000000);
        }

        private static void MergeSort(int[] a, int first, int last)
        {
            if (first < last)
            {
                int mid = (first + last) / 2;
                MergeSort(a, first, mid);
                MergeSort(a, mid + 1, last);
                Merge(a, first, mid, last);
            }
        }

        private static void Merge(int[] a, int first, int mid, int last)
        {
            //assuming that the first half is sorted and the second half is sorted also
            //but independently
            int i = first;
            int j = mid + 1;
            int k = 0;
            int[] temp = new int[last - first + 1];
            while (i <= mid && j <= last)
            {
                if (a[i] < a[j])
                {
                    temp[k] = a[i];
                    i++;
                    k++;
                }
                else
                {
                    temp[k] = a[j];
                    j++;
                    k++;
                }
            }
            while (i <= mid)
            {
                temp[k] = a[i];
                i++;
                k++;
            }
            while (j <= last)
            {
                temp[k] = a[j];
                j++;
                k++;
            }

            //copy temp to array
            i = first;
            for (int s = 0; s < temp.Length; s++, i++)
            {
                a[i] = temp[s];
            }
        }

        static void BubbleSortArray(int[] array)
        {
            for (int x = 0; x < array.Length; x++)
            {
                for (int y = 0; y < array.Length - 1; y++)
                {
                    if (array[y] > array[y + 1])
                    {
                        //swap them
                        int temp = array[y + 1];
                        array[y + 1] = array[y];
                        array[y] = temp;
                    }
                }
            }
        }
        ///===========================QuickSort Algorithem
        ///
        //method to partition an array according to a chosen pivot, where elements less than or equal to pivot are moved
        //to the left of the pivot and elements greater than the pivot are moved to the right of the pivot.
        //since the pivot is in the right sorted spot, it is not included in either of the partitions

        //array is the array to partition, First is the first index of the array to partition and Last is the last index 
        //of the array to partition
        static int partition(int[] array, int First, int Last)
        {
            int Up = First;//set up an index to move left to right
            int Down = Last;//set up an index to move right to left

            //if (First < Last)
            //{
            int pivot = array[First]; //pick the first element as the pivot
            while (Up < Down)
            {
                //move the Up index (pointer) to the next element that is greater than the pivot
                while (array[Up] <= pivot && Up < Last)
                    Up++;

                //move the Down index to the next element that is less than the pivot
                while (array[Down] > pivot && Down > First)
                    Down--;

                if (Up < Down)
                    swap(array, Up, Down);
            }
            //at this point Up and Down have crossed each other
            //swap the pivot element (at index First) with the element at index Down
            swap(array, First, Down);
            //Now the Down index points to the pivot element. 
            //Note that all the elements to the left of pivot are less than or equal to pivot
            //and all the elements to the right of pivot are greater than pivot

            //return the new pivot index
            return Down;

            //}
            //return First;
        }
        static void swap(int[] array, int i, int j)
        {
            int temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }
        static void QuickSort(int[] array, int first, int last)
        {
            if (first < last)
            {
                //partition the array/ divides the array into two part
                //according to a pivot. 
                //left part would contain values less or equal to the pivot
                //right part would contain values larger than the pivot
                int pivIndex = partition(array, first, last);
                //apply the quicksort on the left part
                QuickSort(array, first, pivIndex - 1);
                //apply the quicksort on the right part
                QuickSort(array, pivIndex + 1, last);
            }
        }

        //=========================InsertionSort======================
        static void InsertionSort(int[] array)
        {
            for (int j = 1; j < array.Length; j++)
            {
                int i = j - 1;
                while (i > -1 && array[i] > array[i + 1])
                {
                    swap(array, i, i + 1);
                    i--;
                }
            }
        }
    }
}
