using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualBasic;

namespace K_MergeSort
{
    public class Solution
    {
        public static void MergeSort(List<int> array, int left, int right)
        {
            if (right - left == 1)
            {
                return;
            }
            var mid = left + (right - left) / 2;
            MergeSort(array,left,mid);
            MergeSort(array,mid,right);
            Merge(array, left, mid, right);
        }

        public static List<int> Merge(List<int> array, int left, int mid, int right)
        {
            List<int> result = new List<int>();
            var i = left;
            var j = mid;
            while (i < mid && j < right)
            {
                if (array[i]<array[j])
                {
                    result.Add(array[i]);
                    i++;
                }
                else
                {
                    result.Add(array[j]);
                    j++;
                }
            }

            while (i < mid)
            {
                result.Add(array[i]);
                i++;
            }

            while (j < right)
            {
                result.Add(array[j]);
                j++;
            }

            int ind = 0;
            for (int k = left; k < right; k++)
            {
                array[k] = result[ind];
                ind++;
            }
            return result;
        }

        public static void Main(string[] args)
        {
            var a = new List<int> { 1, 4, 9, 2, 10, 11 };
            var b = Merge(a, 0, 3, 6);
            var expectedMergeResult = new List<int> {1, 2, 4, 9, 10, 11};
            System.Console.WriteLine(b.SequenceEqual(expectedMergeResult));
            var c = new List<int> {1, 4, 2, 10, 1, 2};
            MergeSort(c, 0, 6);
            var expectedMergeSortResult = new List<int> {1, 1, 2, 2, 4, 10};
            System.Console.WriteLine(c.SequenceEqual(expectedMergeSortResult));
        }
    }
}
