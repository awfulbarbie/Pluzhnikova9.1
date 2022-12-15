using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using static System.Net.WebRequestMethods;
using System.Text.RegularExpressions;

namespace lab9._2_console_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = 0;
            Console.WriteLine("Введите длину строки");
            try
            {
                n = Convert.ToInt32(Console.ReadLine());

                if (n <= 0)
                {
                    Console.WriteLine("Ошибка! Длина строки не может иметь отрицательное или нулевое значение");
                    Environment.Exit(0);
                }
            }
            catch
            {
                Console.WriteLine("Ошибка! Неверный ввод данных");
                Environment.Exit(0);
            }

            string path1 = @"D:\Учебная практика\Задание 9\1.txt";
            string path2 = @"D:\Учебная практика\Задание 9\2.txt";
            StreamReader reader = new StreamReader(path1);
            string[] text = null;
            string text2 = " ";
            try
            {
                text = new StreamReader(path1).ReadToEnd().Split(new char[] {'\n' }, StringSplitOptions.RemoveEmptyEntries);
            }
            catch
            {
                Console.WriteLine("Не удалось считать файл");
            }
            bool flag = false;
            foreach (var lines in text)
            {
                if (lines.Length > n)
                {
                    text2 += lines;
                    flag = true;
                }
            }
            reader.Close();

            using(FileStream file = new FileStream(path2, FileMode.Open))
            {
                using(StreamWriter writer = new StreamWriter(file))
                {
                    if (flag)
                    {
                        writer.WriteLine(text2);
                    }
                    else
                    {
                        writer.WriteLine("Отсутствуют строки заданной длины");
                    }
                    
                }
            }

        }
    }
}

