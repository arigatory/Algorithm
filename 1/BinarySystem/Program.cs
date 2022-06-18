using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public class Solution
{
    private static TextReader reader;
    private static TextWriter writer;

    public static void Main(string[] args)
    {
        reader = new StreamReader(Console.OpenStandardInput());
        writer = new StreamWriter(Console.OpenStandardOutput());

        var num1 = ReadBinary();
        var num2 = ReadBinary();

        var lenNum1 = num1.Count;
        var lenNum2 = num2.Count;

        if (lenNum1 < lenNum2)
        {
            var temp = num2;
            num2 = num1;
            num1 = temp;
            lenNum1 = num1.Count;
            lenNum2 = num2.Count;
        }
        //num1 >= num2

        int i = 1;

        var result = new List<int>();

        int carry = 0;

        while (i <= lenNum2)
        {
            int r = num1[lenNum1 - i] + num2[lenNum2 - i] + carry;
            carry = 0;
            if (r > 1)
            {
                carry = 1;
                r -= 2;
            }
            result.Insert(0, r);
            i++;

        }

        while (i <= lenNum1)
        {
            int r = num1[lenNum1 - i] + carry;
            carry = 0;
            if (r > 1)
            {
                carry = 1;
                r -= 2;
            }
            result.Insert(0, r);
            i++;
        }
        if (carry > 0)
            result.Insert(0, carry);

        writer.WriteLine(string.Join("", result));

        reader.Close();
        writer.Close();
    }

    private static int ReadInt()
    {
        return int.Parse(reader.ReadLine());
    }

    private static List<int> ReadBinary()
    {
        return reader.ReadLine().Trim().ToCharArray().Select(c=> c == '0'? 0 : 1).ToList();
    }
}