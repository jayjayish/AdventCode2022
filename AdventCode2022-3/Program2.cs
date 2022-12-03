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
            int index = 0;
            List<List<int>> store = new List<List<int>>();
            int total = 0;
            string ln;

            while ((ln = file.ReadLine()) != null)
            {
                var list = ln.ToCharArray().Select((c) => ConvertToPriority(c)).ToList();
                store.Add(list);

                index += 1;

                if (index == 3)
                {
                    var intersect1 = store[0].Intersect(store[1]);
                    var intersect2 = intersect1.Intersect(store[2]);

                    total += intersect2.Sum();

                    store.Clear(); 
                    index = 0;
                }
            }

            file.Close();

            Console.WriteLine(total);
        }
    }

    private static int ConvertToPriority(char c)
    {
        if (Char.IsLower(c))
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