using System.Collections.Generic;

//namespace M_SiftUp
//{


    public class Solution
    {
        public static int SiftUp(List<int> array, int idx)
        {
            if (idx == 1)
            {
                return idx;
            }

            int parIdx = idx/2;
            if (array[parIdx]<array[idx])
            {
                var temp = array[parIdx];
                array[parIdx] = array[idx];
                array[idx] = temp;
                return SiftUp(array, parIdx);
            }
            else
            {
                return idx;
            }
        }

        public static void Test()
        {
            var sample = new List<int> { -1, 12, 6, 8, 3, 15, 7 };
            System.Console.WriteLine(SiftUp(sample, 5) == 1);
        }

    }
//}