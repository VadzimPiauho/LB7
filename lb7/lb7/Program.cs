using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace lb7
{
    class Program
    {
        [DllImport("msvcrt")]
        static extern int _getch();
        static void Main(string[] args)
        {
            string nameFile = "Day17.txt";
            bool go_on = true;
            const int stolb = 3, str = 2;
            double[,] array1 = new double[stolb, str] { { 1.2, 2.9 }, { 3.1, 4.4 }, { 5.7, 6.6 } };
            int[,] array2 = new int[stolb, str] { { 1, 2 }, { 3, 4 }, { 5, 6 }};
            string FIO = "Иванов Иван Иванович";
            DateTime date1 = new DateTime(1991, 3, 1, 7, 0, 0);
            DateTime date2 = DateTime.Now;
            //Console.WriteLine(date1.ToString());
            // For en-US culture, displays 3/1/2008 7:00:00 AM

            //DateTime date1 = new DateTime(2008, 3, 1, 7, 0, 0);
            //Console.WriteLine(date1.ToString(System.Globalization.CultureInfo.CreateSpecificCulture("fr-FR")));
            //// Displays 01/03/2008 07:00:00

            try
            {
                while (go_on)
                {
                    Console.Clear();
                    Console.WriteLine("****************************************************МЕНЮ*****************************************************");
                    Console.WriteLine("*************************************************************************************************************");
                    Console.WriteLine("1 - Cоздать новый файл с именем «Day17.txt»");
                    Console.WriteLine("2 - Открыть и прочесть файл с именем «Day17.txt». ");
                    Console.WriteLine("3 - Удалить файл с именем «Day17.txt»");
                    Console.WriteLine("4 - Записать форматированную информацию в файл «Day17.txt»");
                    Console.WriteLine("0 - Выход из программы");
                    Console.WriteLine("*************************************************************************************************************");

                    switch (_getch())
                    {
                        case '1':
                            if (File.Exists(nameFile))
                            {
                                Console.WriteLine("Файл уже существует");
                            }
                            else
                            {
                                File.Create(nameFile);
                                Console.WriteLine("Файл успешно создан");
                            }
                            Thread.Sleep(1000);
                            break;
                        case '2':
                            if (!File.Exists(nameFile))
                            {
                                Console.WriteLine("Файла не существует");
                                Thread.Sleep(1000);
                                break;
                            }
                            using (StreamReader sr = File.OpenText(nameFile))
                            {
                                string s = "";
                                while ((s = sr.ReadLine()) != null)
                                {
                                    Console.WriteLine(s);
                                }
                               
                            }
                            Console.WriteLine("Для продолжения нажмите любую клавишу...");
                            _getch();
                            break;
                        case '3':
                            if (!File.Exists(nameFile))
                            {
                                Console.WriteLine("Файла не существует");
                                Thread.Sleep(1000);
                                break;
                            }
                            else
                            {
                                File.Delete(nameFile);
                                Console.WriteLine("Файл успешно удален");
                            }
                            Thread.Sleep(1000);
                            break;
                        case '4':
                            if (!File.Exists(nameFile))
                            {
                                Console.WriteLine("Файла не существует");
                                Thread.Sleep(1000);
                                break;
                            }
                            // Create a file to write to.
                            using (StreamWriter sw = File.CreateText(nameFile))
                            {
                                sw.WriteLine($"{FIO} \t дата рождения - {date1.ToString()}");
                                sw.WriteLine($"количество строк - {str}\t количество столбцов {stolb} массива дробных чисел");
                                for (int i = 0; i < stolb; i++)
                                {
                                    for (int j = 0; j < str; j++)
                                    {
                                        sw.Write($"{array1[i, j]} ");
                                    }
                                    sw.WriteLine();
                                }
                                sw.WriteLine($"количество строк - {str}\t количество столбцов {stolb} массива целых чисел");
                                for (int i = 0; i < stolb; i++)
                                {
                                    for (int j = 0; j < str; j++)
                                    {
                                        sw.Write($"{array2[i, j]} ");
                                    }
                                    sw.WriteLine();
                                }
                                sw.WriteLine($"текущая дата {date2.ToString()}");
                                Console.WriteLine("Информация записана");
                                Thread.Sleep(1000);
                            }
                            break;
                        case '0':
                            go_on = false;
                            break;
                        default:
                            Console.WriteLine("Неверный выбор");
                            Thread.Sleep(1000);
                            break;
                    }
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Неверный ввод Завершение программы");
                Environment.Exit(0);
            }
            
        }
    }
}
