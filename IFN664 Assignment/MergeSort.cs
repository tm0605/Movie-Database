using System;
using System.Collections.Generic;
using System.Text;

namespace IFN664_Assignment
{
    internal class MovieMergeSort
    {
        public static void Sort(Movie[] array)
        {
            if (array.Length <= 1)
                return;

            int middle = array.Length / 2;
            Movie[] left = new Movie[middle];
            Movie[] right = new Movie[array.Length - middle];

            Array.Copy(array, 0, left, 0, middle);
            Array.Copy(array, middle, right, 0, array.Length - middle);

            Sort(left);
            Sort(right);
            Merge(array, left, right);
        }

        private static void Merge(Movie[] array, Movie[] left, Movie[] right)
        {
            int i = 0, j = 0, k = 0;

            while (i < left.Length && j < right.Length)
            {
                if (string.Compare(left[i].GetTitle(), right[j].GetTitle()) <= 0)
                {
                    array[k] = left[i];
                    i++;
                }
                else
                {
                    array[k] = right[j];
                    j++;
                }
                k++;
            }
            while (i < left.Length)
            {
                array[k] = left[i];
                i++;
                k++;
            }
            while (j < right.Length)
            {
                array[k] = right[j];
                j++;
                k++;
            }
        }
    }
}
