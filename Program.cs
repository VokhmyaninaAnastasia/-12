//*****************************************************************************
//*Практическая работа №12                                                    *
//* Выполнила: Вохмянина А.Р., группа 2-ИСП                                   *
//* Задание: Организация и использование функций.                             *
//*****************************************************************************
using System;

namespace ConsoleApp1
{
    internal class Program
    {
        static void CalculatePercent(string text)
        {
            int lower = 0;
            int upper = 0;

            foreach (char c in text)
            {
                if (char.IsLower(c))
                {
                    lower++;
                }
                else if (char.IsUpper(c))
                {
                    upper++;
                }
            }

            double lowerPercent = (double)lower / text.Length * 100;
            double upperPercent = (double)upper / text.Length * 100;

            Console.WriteLine($"Процент строчных букв:" + Math.Round(lowerPercent, 2) + "%");
            Console.WriteLine($"Процент прописных букв:" + Math.Round(upperPercent, 2) + "%");
        }

        static void Main(string[] args)
        {
            Console.Title = "Расчет процентов букв";

            string text = "";

            do
            {
                try
                {
                    Console.Write("Введите текст:");
                    text = Console.ReadLine();

                    if (string.IsNullOrWhiteSpace(text))
                    {
                        throw new ArgumentException("Текст не должен быть пустым или состоять только из пробелов.");
                    }

                    CalculatePercent(text);
                }
                catch (ArgumentException aex)
                {
                    Console.WriteLine("Ошибка: " + aex.Message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Непредвиденная ошибка: " + ex.Message);
                }

            } while (string.IsNullOrWhiteSpace(text));
            Console.ReadKey();
        }
    }
}