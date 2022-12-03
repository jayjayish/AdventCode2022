//Microsoft (R) Visual C# Compiler version 3.4.0-beta4-19562-05 (ff930dec)
//Copyright (C) Microsoft Corporation. All rights reserved.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;


public class Program
{
    public static void Main(string[] args)
    {
        string path = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
        string fullPath = Path.Combine(path, "..\\input.txt");
        using (StreamReader file = new StreamReader(fullPath))
        {
            int total = 0;
            string ln;

            while ((ln = file.ReadLine()) != null)
            {
                var list = ln.ToCharArray().Select((c) => ConvertToPriority(c)).ToList();
                var list1 = list.GetRange(0, list.Count / 2);
                var list2 =  list.GetRange(list.Count/2, list.Count/2);

                var intersect = list1.Intersect(list2);

                total += intersect.Sum();
            }

            file.Close();

            Console.WriteLine(total);

        }
    }

    private static int ConvertToPriority(char c)
    {
        if(Char.IsLower(c))
        {
            return c - 'a' + 1;
        }
        else if (Char.IsUpper(c))
        {
            return c - 'A' + 27;
        }
        return Int32.MinValue;
    }
}