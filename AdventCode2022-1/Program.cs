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
            int largest = 0;
            int current = 0;
            string ln;

            while ((ln = file.ReadLine()) != null)
            {
                if (!String.IsNullOrEmpty(ln))
                {
                    var val = Int32.Parse(ln);
                    current += val;
                }
                else
                {
                    if (current > largest)
                    {
                        largest = current;
                    }
                    current = 0;
                }
            }

            file.Close();

            Console.WriteLine(largest);
        }
    }
}