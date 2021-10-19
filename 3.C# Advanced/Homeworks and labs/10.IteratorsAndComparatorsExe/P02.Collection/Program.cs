﻿using System;
using System.Linq;

namespace P01.ListyIterator
{
    public class Program
    {
        static void Main(string[] args)
        {
            string comand = Console.ReadLine();
            string[] create = comand.Split().Skip(1).ToArray();
            ListyIterator<string> list = new ListyIterator<string>(create);

            while ((comand = Console.ReadLine()) != "END")
            {
                if (comand == "Move")
                {
                    Console.WriteLine(list.Move());
                }
                else if (comand == "HasNext")
                {
                    Console.WriteLine(list.HasNext());
                }
                else if (comand == "PrintAll")
                {
                    try
                    {
                        list.PrintAll();
                    }
                    catch (InvalidOperationException ex)
                    {

                        Console.WriteLine(ex.Message);
                    }
                }
                else if (comand == "Print")
                {
                    try
                    {
                        list.Print();
                    }
                    catch (InvalidOperationException ex)
                    {

                        Console.WriteLine(ex.Message);
                    }
                }
                else
                {
                    Console.WriteLine("Invalid Operation!");
                }
            }
        }
    }
}