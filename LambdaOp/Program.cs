using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LambdaOp
{
    class Program
    {
        public delegate bool delegateName(int number);

        static void Main(string[] args)
        {
            int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            //delegateName evenpredicate = IsEven;
            delegateName evenpredicate= number => number % 2 == 0;
            Console.WriteLine($"Call isEven using a delegate variable: {evenpredicate(25)}");

            List<int> evenNumbers = FilterArray(numbers, evenpredicate);
            DisplayList("Used a predicate to filter numbers", evenNumbers);

            List<int> oddNumbers = FilterArray(numbers, number => { return number % 2 != 0; });
            DisplayList("Used a predicate to filter numbers", oddNumbers);

            List<int> overFive = FilterArray(numbers, number => { return number > 5; });
            DisplayList("Used a predicate to filter numbers", overFive);

            var values = new List<int> { 3, 5, 3, 1, 2, 3, 4, 7, 88 };
            values.Display();

            Console.WriteLine($"Min: {values.Min()}");
            Console.WriteLine($"Max: {values.Max()}");
            Console.WriteLine($"Average: {values.Average()}");
            Console.WriteLine($"Sum: {values.Sum()}");

            Console.WriteLine($"Sum implemented with aggregates: {values.Aggregate(0, (x, y) => x + y)}");
            Console.WriteLine($"Unknown1: {values.Aggregate(0, (x, y) => x + y*y)}");
            Console.WriteLine($"Unknown2: {values.Aggregate(1, (x, y) => x * y ) }");
            //Filters then orders
            values.Where(value => value%2==0).OrderBy(value=>value).Display();
        }

        private static void DisplayList(string message, List<int> intArray)
        {
            Console.WriteLine(message);
            foreach(var item in intArray)
            {
                Console.WriteLine($"{item} ");
            }
            Console.WriteLine();
        }

        //Takes the delegate that allows us do the shortened comparison call
        private static List<int> FilterArray(int[] intArray, delegateName predicate)
        {
            var result = new List<int>();
            foreach(var item in intArray)
            {
                if (predicate(item))
                {
                    result.Add(item);
                }
            }
            return result;
        }

        //Delegate that performs a short op
        //private static bool IsEven(int number) => number % 2 == 0;
        //private static bool IsOdd(int number) => number % 2 != 0;

        ///private static bool IsOverFive(int number) => number > 0;
    }

    static class Extension
    {
        //Generic display, should display as long as the data implements the specific interface
        //Displays through the entire dataset
        public static void Display<T>(this IEnumerable<T> data)
        {
            Console.WriteLine(string.Join(" ", data));
        }
    }
}
