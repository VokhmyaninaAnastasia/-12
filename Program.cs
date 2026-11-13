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
                if (Char.IsLower(c)) //проверяет, является ли символ строчной буквой
                {
                    lower++;
                }
                else if (Char.IsUpper(c)) //проверяет, является ли символ прописной буквой
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
        // функция обработки исключений
        static void HandleError(Exception ex)
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("Ошибка: " + ex.Message);
            Console.ForegroundColor = ConsoleColor.White;
        }
        static void Main(string[] args)
        {
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;

            string text = String.Empty; // переменная с пустым значением
            bool repeat = true;

            do
            {
                try
                {
                    Console.Clear ();
                    Console.WriteLine("Здравствуй!");
                    Console.Title = "Расчет процентов букв";
                    Console.Write("Введите текст: ");
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
                    HandleError(aex);
                }
                catch (Exception ex)
                {
                    HandleError(ex);
                }
                Console.Write("\nВведите любой символ для продолжения (Enter - выход)");
                string answer = Console.ReadLine();
                repeat = !string.IsNullOrEmpty(answer);
            } while (repeat);
            Console.ReadKey();
        }
    }
}
