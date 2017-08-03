using System;
using System.Collections.Generic;
using System.Text;
using SalesTax;
using System.Text.RegularExpressions;

namespace SalesPrompter
{
    class Program
    {

        static void Main(string[] args)
        {
            Sale sale;
            string input;

            sale = new Sale();
            Console.WriteLine("Enter sales in the format <qty> <description> at <unit price>\nFor example: 2 books at 13.25\nEntering a blank line completes the sale\n");
            input = GetInput();

            //Change 6
            if (string.IsNullOrEmpty(input))
                Console.WriteLine("A blank receipt (showing 0.00 amounts)");
            Console.ReadLine();

            while (!string.IsNullOrEmpty(input))
            {
                //Change 5
                bool isNumberExist = Regex.IsMatch(input, @"\d");
                if (isNumberExist)
                {
                    if (!sale.Add(input))
                        Console.WriteLine("Sales should be in the format of <qty> <description> at <unit price>\nFor example: 2 books at 13.25");
                    input = GetInput();
                }
                else
                {
                    //Change 5
                    Console.WriteLine("Nicely handled error");
                    Console.WriteLine("--- Press Enter to Finish ---");
                    Console.ReadLine();
                }
            }
           
            Console.WriteLine(sale.ToString());
            Console.WriteLine("--- Press Enter to Finish ---");
            Console.ReadLine();
        }

        static string GetInput()
        {
            string result;
            Console.Write("Sale : ");
            try
            {
                result = Console.ReadLine();
            }
            catch (System.IO.IOException)
            {
                result = string.Empty;
            }
            if (!string.IsNullOrEmpty(result))
                result = result.Trim();
            return result;
        }
    }
}
