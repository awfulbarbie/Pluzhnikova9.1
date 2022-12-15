using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace lab9._1_console_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num = 0;
            Console.WriteLine("Введите длину слова");
            try
            {
                num = Convert.ToInt32(Console.ReadLine());
                if (num <= 0)
                {
                    Console.WriteLine("Ошибка! Длина слова не может иметь отрицательное или нулевое значение!");
                    Environment.Exit(0);
                }
            }
            catch
            {
                Console.WriteLine("Ошибка! Неверный ввод данных!");
                Environment.Exit(0);
            }
            string path = @"D:\Учебная практика\Задание 9\lab9.1(console)\lab9.1(console)\TextFile1.dat";
            var read = new StreamReader(path).ReadToEnd().Split(new char[] { '!', '?', ';', '.', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            // Считывание файла и разделение его на массив строк с помощью разделителей
            bool flag = false;
            foreach (var line in read) //проход по всем строкам
            {
                foreach (var word in line.Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)) //проход по всем словам
                {
                    if (word.Length == num)
                    {
                        Console.WriteLine(word);
                        flag = true;
                    }

                }
            }
            if (!flag)
            {
                Console.WriteLine("Таких слов в тексте нет");
            }

        }
    }
}