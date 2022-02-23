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

        var text = reader.ReadLine();

        int i = 0;
        int j = text.Length-1;
        
        bool isPalindrome = true;

        while (i < j)
        {
            while (!char.IsLetterOrDigit(text[i]))
            {
                i++;
            }
            while (!char.IsLetterOrDigit(text[j]))
            {
                j--;
            }

            if (char.ToUpperInvariant(text[i]) == char.ToUpperInvariant(text[j]))
            {
                i++;
                j--;
            }
            else
            {
                isPalindrome = false;
                break;
            }

        }

        writer.WriteLine(isPalindrome);
        reader.Close();
        writer.Close();
    }

}