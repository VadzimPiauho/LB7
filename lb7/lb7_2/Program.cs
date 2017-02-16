using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace lb7_2
{
    class Program
    {
        [DllImport("msvcrt")]
        static extern int _getch();
        static void Main(string[] args)
        {
            string nameFile = "Day17.txt";
            bool go_on = true;
            string text = "using System\n" +
                          "using System.Collections.Generic\n" +
                          "using System.Linq\n" +
                          "using System.Text\n" +
                          "namespace ConsoleApplication1\n" +
                          "{\n" +
                          "\tclass UserInfo\n" +
                          "\t{\n" +
                          "\t\t// Поля класса\n" +
                          "\t\tpublic string Name, Family, Adress;\n" +
                          "\t\tpublic byte Age;\n" +
                          "\t\t// Метод, выводящий в консоль контактную информацию\n" +
                          "\t\tpublic void writeInConsoleInfo(string name, string family, string adress, byte age)\n" +
                          "\t\t{\n" +
                          "\t\tConsole.Write(Имя: { 0}Фамилия: { 1}Местонахождение: { 2}Возраст: { 3}, name, family, adress, age);\n" +
                          "\t\t}\n" +
                          "\t}\n" +
                          "\tclass Program\n" +
                          "\t{\n" +
                          "\t\tstatic void Main(string[] args)\n" +
                          "\t\t{\n" +
                          "\t\t\t// Создаем объект типа UserInfo\n" +
                          "\t\t\tUserInfo myInfo = new UserInfo();\n" +
                          "\t\t\tmyInfo.Name = Alexandr;\n" +
                          "\t\t\tmyInfo.Family = Erohin;\n" +
                          "\t\t\tmyInfo.Adress = ViceCity;\n" +
                          "\t\t\tmyInfo.Age = 26;\n" +
                          "\t\t\t// Создадим новый экземпляр класса UserInfo\n" +
                          "\t\t\tUserInfo myGirlFriendInfo = new UserInfo();\n" +
                          "\t\t\tmyGirlFriendInfo.Name = Elena;\n" +
                          "\t\t\tmyGirlFriendInfo.Family = Korneeva;\n" +
                          "\t\t\tmyGirlFriendInfo.Adress = ViceCity;\n" +
                          "\t\t\tmyGirlFriendInfo.Age = 22;\n" +
                          "\t\t\t// Выведем информацию в консоль\n" +
                          "\t\t\tmyInfo.writeInConsoleInfo(myInfo.Name, myInfo.Family, myInfo.Adress, myInfo.Age);\n" +
                          "\t\t\tmyGirlFriendInfo.writeInConsoleInfo(myGirlFriendInfo.Name, myGirlFriendInfo.Family, myGirlFriendInfo.Adress, myGirlFriendInfo.Age);\n" +
                          "\t\t\tConsole.ReadLine();" +
                          "\t\t}\n" +
                          "\t}\n" +
                          "}\n";
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
                    Console.WriteLine("1 - Открыть и прочесть файл");
                    Console.WriteLine("2 - Форматировать информацию в файле согласно заданию");
                    Console.WriteLine("3 - Удалить файл");
                    Console.WriteLine("4 - Записать не отформатированную информацию в файл ");
                    Console.WriteLine("0 - Выход из программы");
                    Console.WriteLine("*************************************************************************************************************");

                    switch (_getch())
                    { 
                        case '1':
                            if (!File.Exists(nameFile))
                            {
                                Console.WriteLine("Файла не существует");
                                FileStream fs1 = File.Create(nameFile);
                                fs1.Close();
                                Console.WriteLine("Файл успешно создан\n"+
                                                  "Файл пуст");
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
                                sw.WriteLine(text);                                
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
