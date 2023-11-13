using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace module3pr
{
    class Program
    {
        static void Main()
        {
            // Задача 1
            double[] A = new double[5];
            double[,] B = new double[3, 4];

            Console.WriteLine("Введите 5 чисел для массива A: ");
            for (int i = 0; i < 5; i++)
            {
                A[i] = Convert.ToDouble(Console.ReadLine());
            }

            Random random = new Random();
            Console.WriteLine("Массив B:");
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    B[i, j] = random.NextDouble();
                    Console.Write(B[i, j] + "\t");
                }
                Console.WriteLine();
            }

            double maxCommon = Math.Max(A.Max(), B.Cast<double>().Max());
            double minCommon = Math.Min(A.Min(), B.Cast<double>().Min());
            double totalSum = A.Sum() + B.Cast<double>().Sum();
            double totalProduct = A.Aggregate(1.0, (x, y) => x * y) * B.Cast<double>().Aggregate(1.0, (x, y) => x * y);
            double evenSum = A.Where(x => x % 2 == 0).Sum();

            double oddColSum = 0;
            for (int j = 0; j < 4; j++)
            {
                double colSum = 0;
                for (int i = 0; i < 3; i++)
                {
                    colSum += B[i, j];
                }
                if (j % 2 == 1)
                {
                    oddColSum += colSum;
                }
            }

            Console.WriteLine("Общий максимальный элемент: " + maxCommon);
            Console.WriteLine("Общий минимальный элемент: " + minCommon);
            Console.WriteLine("Общая сумма всех элементов: " + totalSum);
            Console.WriteLine("Общее произведение всех элементов: " + totalProduct);
            Console.WriteLine("Сумма четных элементов в массиве A: " + evenSum);
            Console.WriteLine("Сумма нечетных столбцов в массиве B: " + oddColSum);

            // Задача 2
            int[] M = { 1, 2, 3, 4, 5 };
            int[] N = { 3, 4, 5, 6, 7 };
            IEnumerable<int> commonElements = M.Intersect(N).Distinct();
            Console.WriteLine("Общие элементы без повторений: " + string.Join(", ", commonElements));

            // Задача 3
            Console.Write("Введите строку: ");
            string inputString = Console.ReadLine();
            bool isPalindrome = IsPalindrome(inputString);
            Console.WriteLine("Является ли строка палиндромом: " + isPalindrome);

            // Задача 4
            Console.Write("Введите предложение: ");
            string sentence = Console.ReadLine();
            string[] words = sentence.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            int wordCount = words.Length;
            Console.WriteLine("Количество слов в предложении: " + wordCount);

            // Задача 5
            int[,] matrix = new int[5, 5];
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    matrix[i, j] = random.Next(-100, 101);
                }
            }

            int minElement = matrix.Cast<int>().Min();
            int maxElement = matrix.Cast<int>().Max();
            int sumBetweenMinMax = 0;
            bool foundMin = false;
            bool foundMax = false;

            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (matrix[i, j] == minElement)
                    {
                        foundMin = true;
                    }
                    else if (matrix[i, j] == maxElement)
                    {
                        foundMax = true;
                    }

                    if (foundMin && !foundMax)
                    {
                        sumBetweenMinMax += matrix[i, j];
                    }

                    if (foundMax)
                    {
                        break;
                    }
                }
                if (foundMax)
                {
                    break;
                }
            }

            Console.WriteLine("Сумма элементов между минимальным и максимальным элементами: " + sumBetweenMinMax);

            // Задача 6
            Console.Write("Введите текст: ");
            string text = Console.ReadLine();
            char maxRepeatingChar = text.GroupBy(c => c).OrderByDescending(gr => gr.Count()).First().Key;
            int maxRepeatingCount = text.Count(c => c == maxRepeatingChar);
            Console.WriteLine("Наибольшее количество идущих подряд одинаковых символов: " + maxRepeatingCount);

            // Задача 8
            Console.Write("Введите строку длиной 20 символов: ");
            string inputString3 = Console.ReadLine();
            int digitCount = inputString3.Count(char.IsDigit);
            Console.WriteLine("Количество цифр в строке: " + digitCount);

            // Задача 9
            string name = "ваше имя"; // Замените на своё имя
            Console.Write("Введите текст: ");
            string inputText = Console.ReadLine();
            bool canFormName = name.All(inputText.Contains);
            Console.WriteLine(canFormName ? "Можно составить ваше имя." : "Нельзя составить ваше имя.");

            // Задача 10
            Console.Write("Введите строку: ");
            string inputString4 = Console.ReadLine();
            string[] words2 = inputString4.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            int wordsWithSameStartAndEndCount = words2.Count(word => word.Length > 0 && word[0] == word[word.Length - 1]);
            Console.WriteLine("Количество слов, у которых первый и последний символы совпадают: " + wordsWithSameStartAndEndCount);

            // Задача 11
            Console.Write("Введите маленькую букву: ");
            char lowercaseChar = Convert.ToChar(Console.ReadLine());
            char uppercaseChar = Char.ToUpper(lowercaseChar);
            Console.WriteLine("Соответствующая большая буква: " + uppercaseChar);
        }

        static bool IsPalindrome(string s)
        {
            s = s.ToLower();
            s = new string(s.Where(char.IsLetter).ToArray());
            return s.SequenceEqual(s.Reverse());
        }
    }
}
