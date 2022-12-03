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
            int[] largest = { 0, 0, 0 };
            int current = 0;
            string ln = file.ReadLine();
            bool breakNext = false;

            while (true)
            {
                if (!String.IsNullOrEmpty(ln))
                {
                    var val = Int32.Parse(ln);
                    current += val;
                }
                else
                {
                    if (current >= largest[0])
                    {
                        int i = 0;
                        if (current > largest[2])
                        {
                            i = 2;
                        }
                        else if (current > largest[1])
                        {
                            i = 1;
                        }


                        for (int j = 0; j + 1 <= i; j += 1)
                        {
                            largest[j] = largest[j + 1];
                        }

                        largest[i] = current;
                    }

                    //Console.WriteLine(largest[0] + ", " + largest[1] + ", " + largest[2]);
                    current = 0;
                }
                if (breakNext)
                {
                    break;
                }

                if ((ln = file.ReadLine()) == null)
                {
                    breakNext = true;
                }
            }

            file.Close();

            //Console.WriteLine(largest[0] + ", " + largest[1] + ", " + largest[2]);
            Console.WriteLine(largest[0]  + largest[1]  + largest[2]);
        }
    }
}