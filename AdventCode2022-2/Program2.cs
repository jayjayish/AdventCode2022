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
            string ln;
            int total = 0;

            while ((ln = file.ReadLine()) != null)
            {

                Console.WriteLine("Fight " + ln);
                var pairChar = ln.ToCharArray();
                int firstVal = pairChar[0] - 'A';
                int secondVal = pairChar[2] - 'X';


                if (secondVal == 0)
                {
                    total += 0;
                    total += (firstVal + 2) % 3 + 1;
                }
                else if (secondVal == 1)
                {
                    total += 3;

                    total += firstVal + 1;
                }
                else if (secondVal == 2)
                {
                    total += 6;

                    total += (firstVal + 1) % 3 + 1;
                }

            }

            file.Close();

            Console.WriteLine(total);
        }
    }
}