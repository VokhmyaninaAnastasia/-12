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
            // внутри функции создается две переменных
            int lower = 0; // счётчик строчных букв
            int upper = 0; // счётчик прописных букв
            int spaces = 0; // счетчик пробелов
            int other = 0; // счётчик других символов
            // подсчёт букв
            foreach (char c in text)
            {
                if (char.IsLower(c)) //проверяет, является ли символ строчной буквой
                {
                    lower++;
                }
                else if (char.IsUpper(c)) //проверяет, является ли символ прописной буквой
                {
                    upper++;
                }
                else if (c == ' ')
                {
                    spaces++;
                }
                else
                {
                    other++;
                }
            }
            //расчёт процентов
            double lowerPercent = (double)lower / text.Length * 100;
            double upperPercent = (double)upper / text.Length * 100;
            double spacesPercent = (double)spaces / text.Length * 100;
            double otherPercent = (double)other / text.Length * 100;

            Console.WriteLine($"Процент строчных букв:" + Math.Round(lowerPercent, 2) + "%");
            Console.WriteLine($"Процент прописных букв:" + Math.Round(upperPercent, 2) + "%");
            Console.WriteLine($"Процент пробелов:" + Math.Round(spacesPercent, 2) + "%");
            Console.WriteLine($"Процент другие символы:" + Math.Round(otherPercent, 2) + "%");
        }

        static void Main(string[] args)
        {
            Console.Clear();
            Console.Title = "Расчет процентов букв";

            string text = String.Empty; // переменная с пустым значением

            do
            {
                try
                {
                    Console.Write("Введите текст:");
                    text = Console.ReadLine();
                    // проверка введённого текста
                    if (String.IsNullOrWhiteSpace(text))
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
                // условие повторения цикла
            } while (String.IsNullOrWhiteSpace(text));
            Console.ReadKey();
        }
    }
}
