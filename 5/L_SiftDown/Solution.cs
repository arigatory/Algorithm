using System.Collections.Generic;

namespace L_SiftDown
{
    public class Solution
    {
        public static int SiftDown(List<int> array, int idx)
        {
            int left = 2 * idx;
            int right = 2 * idx + 1;

            if (array.Count <= left)
            {
                return idx;
            }


            int indexLargest;

            // both 
            if (right < array.Count && array[left] < array[right])
            {
                indexLargest = right;
            }
            else
            {
                indexLargest = left;
            }

            if (array[idx] < array[indexLargest])
            {
                var temp = array[idx];
                array[idx] = array[indexLargest];
                array[indexLargest] = temp;
                return SiftDown(array, indexLargest);
            }
            return idx;
        }

        public static void Test()
        {
            var sample = new List<int> { -1, 12, 1, 8, 3, 4, 7 };
            System.Console.WriteLine(SiftDown(sample, 2) == 5);
        }
    }
}
