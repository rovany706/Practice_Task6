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
        //-1 - никакая
        static int SequenceType(double?[] sequence)
        {
            bool isEqual = false, isWeird = false;
            for (int i = 1; i < sequence.Length; i++)
            {
                if (sequence[i - 1] > sequence[i])
                {
                    isWeird = true;
                    break;
                }

                if (sequence[i - 1] == sequence[i])
                    isEqual = true;
            }

            if (isWeird)
                return -1;
            if (isEqual)
                return 0;
            return 1;
        }

        static void Main()
        {
            double first = Input.ReadDouble("Введите число a1: ");
            double second = Input.ReadDouble("Введите число a2: ");
            while (second == -2)
            {
                Console.WriteLine("Ошибка! a2 не может равняться -2, потому что это приведет к делению на 0.\n" +
                                  "Повторите ввод.");
                second = Input.ReadDouble("Введите число a2: ");
            }
            double third = Input.ReadDouble("Введите число a3: ");
            int N = Input.ReadInt("Введите количество элементов последовательности, которые хотите посмотреть: ");

            double?[] arr = new double?[N];
            arr[0] = first;
            arr[1] = second;
            arr[2] = third;
            GetNumber(first, second, third, N, ref arr);
            foreach (double i in arr)
                Console.Write("{0:F4} ", i);

            Console.Write("\nПоследовательность ");
            int sequenceType = SequenceType(arr);
            if(sequenceType == 0)
                Console.WriteLine("монотонно неубывающая.");
            else if (sequenceType == 1)
                Console.WriteLine("строго возрастающая");
            else
                Console.WriteLine("не имеет определенного типа.");
        }
    }
}
