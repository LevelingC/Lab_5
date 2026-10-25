using System;

namespace Lab5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Облік витрат

            Console.WriteLine("=== Облік витрат ===");
            Console.WriteLine("Уводьте витрати за день. Для завершення введіть -1.");

            double totalCost= 0; // накопичувач загальних витрат
            int dayCount = 0; // лічильник усіх днів
            int AverageCount = 0; // лічильник днів вище  середнього
            double max = double.MinValue; // найбільша витрата
            double Total = 0; // сума витрат за попередні дні
            // цикл введення витрат
            while (true)
            {

                Console.Write($"Витрати за день {dayCount + 1}: ");
                // Перевірка правильності введення числа

                if (!double.TryParse(Console.ReadLine(), out double costs))
                {
                    Console.WriteLine("Помилка! Введіть число.");
                    continue;
                }

                if (costs == -1) { break; } // виходимо з циклу

                if (costs < 0)
                {
                    Console.WriteLine("Витрати не можуть бути від'ємними, значення пропущено.");
                    continue; 
                }

                if (dayCount > 0)
                {
                    double previousAverage = Total / dayCount;

                    if (costs > previousAverage)
                    {
                        AverageCount++;
                    }
                }

                dayCount++;
                totalCost += costs;

                if (costs > max) { max = costs; }

                Total += costs;
            }

            Console.WriteLine();

            if (dayCount == 0)
            {
                Console.WriteLine("Жодного дня не введено, звіт порожній.");
            }
            else
            {
                double averageExpenses = totalCost / dayCount;

                Console.WriteLine($"Кількість днів: {dayCount}");
                Console.WriteLine($"Загальні витрати: {totalCost:F2}");
                Console.WriteLine($"Середні витрати за день: {averageExpenses:F2}");
                Console.WriteLine($"Найбільша витрата: {max:F2}");
                Console.WriteLine($"Дні із витратами вище середніхі: {AverageCount}");
            }

            // Рівень Б побудова квадрата

            Console.WriteLine();
            Console.WriteLine("=== Побудова квадрата ===");

            int n;

            do
            {
                Console.Write("Введіть розмір квадрата від 3 до 20: ");

                if (!int.TryParse(Console.ReadLine(), out n))
                {
                    n = 0;
                    Console.WriteLine("Помилка! Введіть ціле число.");
                }
                else if (n < 3 || n > 20)
                {
                    Console.WriteLine("Розмір має бути від 3 до 20.");
                }
            }
            while (n < 3 || n > 20);

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (i == j || i + j == n - 1)
                    {
                        Console.Write("#");
                    }
                    else if (i == 0 || i == n - 1 || j == 0 || j == n - 1)
                    {
                        Console.Write("*");
                    }
                    else
                    {
                        Console.Write(" ");
                    }
                }

                Console.WriteLine();
            }
        }
    }
}
