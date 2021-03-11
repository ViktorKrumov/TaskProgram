using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using System.Threading;

namespace Code
{
    class Program
    {

        static void Main()
        {

            while (true)
            {
                Console.WriteLine("1 do: Sum, the smallest, the biggest and average of numbers");
                Console.WriteLine("2 do: Average of 10 random arrays");
                Console.WriteLine("3 do: Sorting numbers");
                Console.WriteLine("4 do: The second smallest and second biggest number");
                Console.WriteLine("5 do: Prints each degree of the pair");
                Console.WriteLine("6 do: Comperes the different ways of sorting");
                Console.WriteLine("7 do: EGN validator");

                Console.WriteLine("8 do: Exit");
                Console.WriteLine("Choose and option: ");

                int option;
                int.TryParse(Console.ReadLine(), out option);

                switch (option)
                {
                    case 1:
                        Console.WriteLine("Do 1");
                        Console.WriteLine(For1());

                        break;

                    case 2:
                        Console.WriteLine("Do 2");
                        For2();
                        break;

                    case 3:
                        Console.WriteLine("Do 3");
                        For3();
                        break;

                    case 4:
                        Console.WriteLine("Do 4");
                        For4();
                        break;

                    case 5:
                        Console.WriteLine("Do 5");

                        For5();
                        break;

                    case 6:
                        Console.WriteLine("Do 6");
                        For6();
                        break;

                    case 7:
                        Console.WriteLine("Do 7");
                        break;

                    case 8:
                        Console.WriteLine("Exit");
                        return;

                    default:
                        Console.WriteLine("Invalid input. Try again");
                        break;

                }
                Console.WriteLine("Press any key to continue...");
                Console.ReadLine();

            }

        }
        static string For1()
        {

            double sum = 0;
            int max = int.MinValue;
            int min = int.MaxValue;
            double avg = 0;
            int times = int.Parse(Console.ReadLine());
            int[] numbers = new int[times];

            for (int i = 0; i < numbers.Length; i++)
            {
                int num = int.Parse(Console.ReadLine());
                sum += num;
                if (num > max)
                {
                    max = num;
                }
                if (num < min)
                {
                    min = num;
                }
            }

            avg = (double)(sum / times);

            string all = $"The sum is {sum} - The biggest number is {max} - The smallest number is {min} - The avarage is { avg }";
        return all;

        }
        static void For2()

        {
            int helper = 0;

            int n = int.Parse(Console.ReadLine());
            int m = int.Parse(Console.ReadLine());

            if (n > m)
            {
                helper = n;// helper stava 3
                n = m;// n stava 4
                m = helper;// m stava 3
            }

            for (int i = 0; i < 10; i++)
            {

                int[] array = new int[100];

                Random randNum = new Random();
                for (int v = 0; v < array.Length; v++)
                {
                    array[v] = randNum.Next(n, m);

                }

                double avg = array.Average();
                Console.WriteLine(avg);

            }

        }
        static void For3()
        {

            List<int> collector = new List<int>();
            int numbers;

            while (true)
            {
                numbers = int.Parse(Console.ReadLine());
                if (numbers == -1)
                {
                    break;
                }
                else
                {
                    collector.Add(numbers);
                }

            }
            collector.Sort();

            Console.WriteLine(string.Join(" ", collector));

        }
        static void For4()
        {

            int Min = 0;
            int Max = 0;
            int index = 0;

            int[] input = Console.ReadLine()
            .Split(",")
            .Select(int.Parse)
            .ToArray();

            Array.Sort(input);
            Min = input[1];

            index = input.Length;

            Max = input[index - 2];

            Console.WriteLine($"After Min:{Min}");

            Console.WriteLine($"Before Max:{Max}");
            Console.WriteLine();

        }
        static void For5()
        {
            List<int> input = Console.ReadLine()
            .Split(",")
            .Select(int.Parse)
            .ToList();

            List<int> final = new List<int>();

            for (int i = 0; i < input.Count; i++)
            {
                if (input[i] % 2 == 0)
                {

                    final.Add(input[i]);

                }

            }

            final.Sort();

            for (int n = 0; n < final.Count - 1; n++)
            {
                if (final[n] == final[n + 1])
                {
                    final.RemoveAt(n);
                }
            }

            Console.WriteLine(string.Join(", ", final));

        }
        static void For6()
        {
            int[] array1 = new int[100];

            int[] array2 = new int[100];
            int[] array3 = new int[100];
            int[] array4 = new int[100];

            Stopwatch timer = new Stopwatch();

            for (int i = 0; i < array1.Length; i++)
            {
                Random randNum = new Random();
                array1[i] = randNum.Next(-100, 100);

                array2[i] = randNum.Next(-100, 100);
                array3[i] = randNum.Next(-100, 100);
                array4[i] = randNum.Next(-100, 100);
            }

            timer.Start();
            ArrSort(array1);
            timer.Stop();
            Console.WriteLine("Array.Sort -time elapsed: {0}", timer.Elapsed);
            timer.Reset();

            timer.Start();
            BubbleSort(array2);
            timer.Stop();
            Console.WriteLine("BubbleSort -time elapsed: {0}", timer.Elapsed);
            timer.Reset();

            timer.Start();

            InsertionSort(array3);
            timer.Stop();
            Console.WriteLine("InsurtionSort -time elapsed: {0}", timer.Elapsed);
            timer.Reset();

            timer.Start();
            SelectionSort(array4);
            timer.Stop();
            Console.WriteLine("SelectionSort -time elapsed: {0}", timer.Elapsed);
            timer.Reset();

        }
        static void ArrSort(int[] array1)
        {

            Array.Sort(array1);

        }
        static void BubbleSort(int[] array2)
        {
            int helper;

            for (int j = 0; j <= array2.Length - 2; j++)
            {
                for (int i = 0; i <= array2.Length - 2; i++)
                {
                    if (array2[i] > array2[i + 1])
                    {
                        helper = array2[i + 1];

                        array2[i + 1] = array2[i];
                        array2[i] = helper;
                    }
                }
            }
        }
        static void InsertionSort(int[] array3)
        {
            for (int i = 0; i < array3.Length - 1; i++)

            {
                for (int j = i + 1; j > 0; j--)
                {
                    if (array3[j - 1] > array3[j])
                    {
                        int helper = array3[j - 1];
                        array3[j - 1] = array3[j];
                        array3[j] = helper;
                    }
                }
            }
        }
        static void SelectionSort(int[] array4)
        {
            int n = array4.Length;
            for (int i = 0; i < n - 1; i++)
            {
                int min = i;
                for (int j = i + 1; j < n; j++)

                {
                    if (array4[j] < array4[min])
                    {
                        min = j;
                    }
                }
                int helper = array4[min];
                array4[min] = array4[i];
                array4[i] = helper;
            }

        }

    }
}
