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

        var lenNum1 = ReadInt();
        var Num1 = ReadList();
        var n2 = ReadInt();
        var Num2 = new List<int>();

        int tempNum = n2;
        while (tempNum != 0)
        {
            Num2.Insert(0,tempNum%10);
            tempNum/=10;
        }

        var lenNum2 = Num2.Count;

        if (lenNum1 < lenNum2)
        {
            var temp = Num2;
            Num2 = Num1;
            Num1 = temp;
            lenNum1 = Num1.Count;
            lenNum2 = Num2.Count;
        }
        //num1 >= num2

        int i = 1;

        var result = new List<int>();

        int carry = 0;

        while (i <= lenNum2)
        {
            int r = Num1[lenNum1 - i] + Num2[lenNum2 - i] + carry;
            carry = 0;
            if (r > 9)
            {
                carry = 1;
                r -= 10;
            }
            result.Insert(0, r);
            i++;

        }

        while (i <= lenNum1)
        {
            int r = Num1[lenNum1 - i] + carry;
            carry = 0;
            if (r > 9)
            {
                carry = 1;
                r -= 10;
            }
            result.Insert(0, r);
            i++;
        }
        if (carry > 0)
            result.Insert(0, carry);



        writer.WriteLine(string.Join(" ", result));


        reader.Close();
        writer.Close();
    }

    private static int ReadInt()
    {
        return int.Parse(reader.ReadLine());
    }

    private static List<int> ReadList()
    {
        return reader.ReadLine()
            .Split(new[] { ' ', '\t', }, StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToList();
    }
}