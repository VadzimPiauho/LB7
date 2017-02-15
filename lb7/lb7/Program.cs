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
            try
            {
                while (go_on)
                {
                    Console.Clear();
                    Console.WriteLine("*************Меню**************");
                    Console.WriteLine("*******************************");
                    Console.WriteLine("1 - Cоздать новый файл с именем «Day17.txt»");
                    Console.WriteLine("2 - Открыть и прочесть файл с именем «Day17.txt». ");
                    Console.WriteLine("3 - Удалить файл с именем «Day17.txt»");
                    Console.WriteLine("4 - Поиск по фамилии и номеру");
                    Console.WriteLine("5 - Поиск по фамилии");
                    Console.WriteLine("6 - Перейти к записи №");
                    Console.WriteLine("7 - Отобразить список");
                    Console.WriteLine("0 - Выход из программы");
                    Console.WriteLine("*******************************");

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
                                if ((s = sr.ReadLine()) == null)
                                {
                                    Console.WriteLine("Файл пуст");
                                }
                            }
                            Thread.Sleep(1000);
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
                            
                            break;
                        case '5':
                            
                            break;
                        case '6':
                            
                            Thread.Sleep(3000);
                            break;
                        case '7':
                           
                            _getch();
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
