using System;
using InputHelper;

namespace Task6
{
    class Program
    {
        static double? GetNumber(double first, double second, double third, int N, ref double?[] arr)
        {
            if (N == 1)
                return first;
            if (N == 2)
                return second;
            if (N == 3)
                return third;
            double? number;
            if (arr[N - 1] == null)
            {
                number = (GetNumber(first, second, third, N - 1, ref arr) + 1) / (GetNumber(first, second, third, N - 2, ref arr) + 2) * GetNumber(first, second, third, N - 3, ref arr);
                arr[N - 1] = number;
            }
            else
                return arr[N - 1];
            return number;
        }

        //0 - монотонно неубывающая (x(n) <= x(n+1))
        //1 - строго возрастающая   (x(n) < x(n+1))
        static int SequenceType(double?[] sequence)
        {
            bool isEqual = false;
            for (int i = 1; i < sequence.Length; i++)
            {
                if (sequence[i - 1] == sequence[i])
                {
                    isEqual = true;
                    break;
                }
            }

            if (isEqual)
                return 0;
            return 1;
        }

        static void Main()
        {
            double first = Input.ReadDouble("Введите число a1: ");
            double second = Input.ReadDouble("Введите число a2: ");
            double third = Input.ReadDouble("Введите число a3: ");
            int N = Input.ReadInt("Введите количество элементов последовательности, которые хотите посмотреть: ");

            double?[] arr = new double?[N];
            arr[0] = first;
            arr[1] = second;
            arr[2] = third;
            GetNumber(first, second, third, N, ref arr);
            foreach (double i in arr)
                Console.Write("{0:F4} ", i);

            Console.WriteLine("\nПоследовательность {0}", SequenceType(arr) == 0 ? "монотонно неубывающая." : "строго возрастающая.");
        }
    }
}
