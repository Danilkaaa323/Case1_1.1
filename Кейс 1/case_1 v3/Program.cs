using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace case_1_v3
{
    internal class Program
    {
        public static void CountingUsedResources(Steel steel, double[] usedResources) //считает использованные ресурсы
        {
            usedResources[0] += steel.Ore * steel.Volume;
            usedResources[1] += steel.Nickel * steel.Volume;
            usedResources[2] += steel.Chrom * steel.Volume;
            usedResources[3] += steel.Manganese * steel.Volume;
            usedResources[4] += steel.TimeFurnaces * steel.Volume;
            usedResources[5] += steel.TimeConverter * steel.Volume;
            usedResources[6] += steel.Mill * steel.Volume;
            usedResources[7] += steel.Price * steel.Volume;
        }
        static void Main(string[] args)
        {
            string filepath = "Входные данные.txt";
            string[] lines = File.ReadAllLines(filepath);

            List<double> extractedNumbers = new List<double>();
            foreach (string line in lines) //достает из файла числа
            {
                Match match = Regex.Match(line, @"(-?\d+(\.\d+)?)"); 
                string numberString = match.Value;
                if (double.TryParse(numberString, NumberStyles.Any, CultureInfo.InvariantCulture, out double number))
                {
                    extractedNumbers.Add(number);
                }
            }

            int count = 0;
            for (int i = 0; i < extractedNumbers.Count; i++) //проверка на отрицательные числа
            {
                if (extractedNumbers[i] < 0)
                {
                    count++;
                }
            }

            if (count == 0)
            {
                List<double> maxResourсes = new List<double>(); //запись доступных ресурсов
                for (int i = 0; i <= 6; i++)
                {
                    maxResourсes.Add(extractedNumbers[i]);
                }
                extractedNumbers.RemoveRange(0, 7);

                Steel steelA = new Steel(extractedNumbers);
                Steel steelB = new Steel(extractedNumbers);
                Steel steelC = new Steel(extractedNumbers);

                double[] usedResources = new double[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 };

                CountingUsedResources(steelA, usedResources);
                CountingUsedResources(steelB, usedResources);
                CountingUsedResources(steelC, usedResources);

                string[] resourceNames = { "Руда", "Никель", "Хром", "Марганец", "Время работы доменных печей", "Время работы конвертеров", "Время работы прокатного стана", "Общая прибыль" };
                string[] resourceUnit = { "тонн", "кг", "кг", "кг", "часов", "часов", "часов" };

                Console.WriteLine("Оптимальный производственный план:\n"); //вывод данных
                Console.WriteLine($"Марка стали A: {steelA.Volume}");
                Console.WriteLine($"Марка стали B: {steelB.Volume}");
                Console.WriteLine($"Марка стали C: {steelC.Volume}\n");
                Console.WriteLine("Использованные ресурсы:");
                for (int i = 0; i <= 6; i++)
                {
                    Console.WriteLine($"{resourceNames[i]}: {usedResources[i]} {resourceUnit[i]}");
                }
                Console.WriteLine($"\nОбщая прибыль: {usedResources[7]}");

                for (int i = 0; i < maxResourсes.Count; i++) //проверка на превышение доступных ресурсов
                {
                    if (usedResources[i] > maxResourсes[i])
                    {
                        Console.WriteLine($"\nПредупреждение: Превышен лимит. {resourceNames[i]}: {usedResources[i]}, Доступно: {maxResourсes[i]}");
                    }
                }
            }
            else
            {
                Console.WriteLine("Ресурсы не могут быть отрицательными.");
            }
        }
    }
}
