using ClassLibrary10Lab;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Text.RegularExpressions;
using static System.Net.Mime.MediaTypeNames;
using System.Diagnostics;
namespace Лабораторная_работа__11
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<Watch> queue = new Queue<Watch>();
            for (int i = 0; i < 5; i++)
            {
                Watch c = new Watch();
                c.RandomInit();
                queue.Enqueue(c);
            }
            for (int i = 0; i < 5; i++)
            {
                AnalogWatch c2 = new AnalogWatch();
                c2.RandomInit();
                queue.Enqueue(c2);
            }
            bool number1 = true;
            do
            {
                Console.WriteLine("Меню:" +
                    "\n1.Добавить объект" +
                    "\n2.Удалить первый объект" +
                    "\n3.Запрос количество пульсов" +
                    "\n4.Запрос количество часов" +
                    "\n5.Запрос печать всех уник часов" +
                    "\n6.Вывести все объекты" +
                    "\n7.Выполнить клонирование коллекции" +
                    "\n8.Сортировка по бренду по алфавиту" +
                    "\n9.Поиск объекта" +
                    "\n10.Завершить");
                switch (Console.ReadLine())
                {
                    case "1":
                        Console.WriteLine("Введите элемент для добавления:");
                        Watch watch1 = new Watch();
                        watch1.Init();
                        queue.Enqueue(new Watch(watch1.Brand, watch1.YearIssue, 1));
                        break;
                    case "2":
                        if (queue.Count == 0)
                        {
                            Console.WriteLine("Коллекция пуста");
                            break;
                        }
                        else
                        {
                            queue.Dequeue();                       //удаляет самый первый объект в очереди
                            break;
                        }
                    case "3":
                        int count = 0;
                        foreach (var item in queue)
                        {
                            if (item is Watch)
                                count++;
                        }
                        Console.WriteLine($"Количество = {count}");
                        Console.Write("Чтобы продолжить нажмите Enter");
                        Console.ReadLine();
                        break;
                    case "4":
                        int count2 = 0;
                        foreach (var item in queue)
                        {
                            if (item is Watch)
                            {
                                if (((Watch)item).Brand == "NoBrand")
                                {
                                    count2++;
                                }
                            }
                        }
                        Console.WriteLine($"Количество = {count2}");
                        Console.Write("Чтобы продолжить нажмите Enter");
                        Console.ReadLine();
                        break;
                    case "5":
                        foreach (var item in queue)
                        {
                            if (item is Watch)
                            {
                                ((AnalogWatch)item).Show();
                                Console.WriteLine("");
                            }
                        }
                        Console.WriteLine("");
                        Console.Write("Чтобы продолжить нажмите Enter");
                        Console.ReadLine();
                        break;
                    case "6":
                        foreach (var item in queue)
                        {
                            item.Show();
                            Console.WriteLine("");
                        }
                        Console.WriteLine("");
                        Console.Write("Чтобы продолжить нажмите Enter");
                        Console.ReadLine();
                        break;
                    case "7":
                        Queue clonQueue = new Queue(queue);                                   //копия
                        Console.WriteLine($"Количество ссылок в клоне: {clonQueue.Count}");
                        Console.WriteLine("");
                        Console.Write("Чтобы продолжить нажмите Enter");
                        Console.ReadLine();
                        break;
                    case "8":
                        Watch[] SortedArray = new Watch[queue.Count];
                        int index = 0;
                        foreach (var item in queue)
                        {
                            SortedArray[index] = item;
                            index++;
                        }
                        Array.Sort(SortedArray);
                        foreach (Watch item in SortedArray)
                        {
                            item.Show();
                            Console.WriteLine();
                        }
                        Console.WriteLine("");
                        Console.Write("Чтобы продолжить нажмите Enter");
                        Console.ReadLine();
                        break;
                    case "9":
                        Console.Write("Введите номер объекта: ");
                        int key_obj = int.Parse(Console.ReadLine());
                        Console.WriteLine("");
                        queue.ToArray()[key_obj - 1].Show();               //очередь превращает в массив
                        Console.WriteLine("");
                        Console.Write("Чтобы продолжить нажмите Enter");
                        Console.ReadLine();
                        break;
                    case "10":
                        number1 = false;
                        break;
                    default:
                        break;
                }
            } while (number1);


            Hashtable ht = new Hashtable();
            Console.WriteLine($"В словаре {ht.Count} элементов");
            for (int i = 0; i < 10; i++)
            {
                try
                {
                    AnalogWatch c = new AnalogWatch();
                    c.RandomInit();
                    Watch w = new Watch(c.Brand, c.YearIssue, 1);
                    ht.Add(w, c);
                }
                catch (Exception e) { i--; }
            }
            Console.WriteLine("DICTIONARY");
            bool number2 = true;             
            do
            {
                Console.WriteLine("Меню:" +
                    "\n1.Добавить объекты" +
                    "\n2.Удалить объекты" +
                    "\n3.Запросить кол" +
                    "\n4.Запросить количество" +
                    "\n5.Запросить печать всех watch" +
                    "\n6.Вывести все объекты коллекции на печать" +
                    "\n7.Выполнить клонирование коллекции" +
                    "\n8.Сортировка по бренду по алфавиту" +
                    "\n9.Поиск объекта" +
                    "\n10.Завершить");
                switch (Console.ReadLine())
                {
                    case "1":                                       //первое действие          
                        Console.Write("Укажите ключ объекта: ");
                        string key = Console.ReadLine();
                        Console.WriteLine("Введите элемент для добавления:");
                        Watch watch1 = new Watch();
                        watch1.Init();
                        ht.Add(key, new Watch(watch1.Brand, watch1.YearIssue, 1));
                        break;
                    case "2":                                           //второе действие
                        if (ht.Count == 0)                       //если в коллекции нет пар ключа и значения
                        {
                            Console.WriteLine("Коллекция пуста");
                            break;
                        }
                        else
                        {
                            Console.Write("Укажите ключ: ");
                            key = Console.ReadLine();
                            ht.Remove(key);                      //удаление пары по ключу
                            break;
                        }
                    case "3":                                           //третье действие
                        int count = 0;
                        foreach (var item in ht.Values)          //для всех значений в коллекции значений
                        {
                            if (item is AnalogWatch)                           //относится ли к analog
                                count++;
                        }
                        Console.WriteLine($"Количество = {count}");
                        Console.Write("Чтобы продолжить нажмите Enter");
                        Console.ReadLine();
                        break;
                    case "4":                                            //четвёртое действие
                        int count2 = 0;
                        foreach (var item in ht.Values)
                        {
                            if (item is Watch)
                            {
                                if (((Watch)item).Brand == "NoBrand")
                                {
                                    count2++;
                                }
                            }
                        }
                        Console.WriteLine($"Количество watch = {count2}");
                        Console.Write("Чтобы продолжить нажмите Enter");
                        Console.ReadLine();
                        break;
                    case "5":                                            //пятое дейсвтвие
                        foreach (var item in ht.Values)
                        {
                            if (item is Watch)
                            {
                                ((Watch)item).Show();
                                Console.WriteLine("");
                            }
                        }
                        Console.WriteLine("");
                        Console.Write("Чтобы продолжить нажмите Enter");
                        Console.ReadLine();
                        break;
                    case "6":                                            //шестое действие
                        foreach (var item in ht.Values)
                        {
                            ((Watch)item).Show();
                            Console.WriteLine("");
                        }
                        Console.WriteLine("");
                        Console.Write("Чтобы продолжить нажмите Enter");
                        Console.ReadLine();
                        break;
                    case "7":                                           //седьмое действие
                        Hashtable clon = (Hashtable)ht.Clone();  //клонирование, присваивает ссылку
                        Console.WriteLine($"Количество ссылок в клоне: {clon.Count}");
                        Console.WriteLine("");
                        Console.Write("Чтобы продолжить нажмите Enter");
                        Console.ReadLine();
                        break;
                    case "8":                                           //восьмое действие
                        Watch[] SortedArray = new Watch[ht.Count];
                        int index = 0;
                        foreach (var item in ht.Values)
                        {
                            SortedArray[index] = (Watch)item;
                            index++;
                        }
                        Array.Sort(SortedArray);
                        foreach (Watch item in SortedArray)
                        {
                            item.Show();
                            Console.WriteLine();
                        }
                        Console.WriteLine("");
                        Console.Write("Чтобы продолжить нажмите Enter");
                        Console.ReadLine();
                        break;
                    case "9":                                           //девятое действие
                        Console.Write("Введите ключ объекта: ");
                        string key_obj = Console.ReadLine();
                        Console.WriteLine("");
                        ((Watch)ht[key_obj]).Show();     //поиск по ключу и вывод
                        Console.WriteLine("");
                        Console.Write("Чтобы продолжить нажмите Enter");
                        Console.ReadLine();
                        break;
                    case "10":                                          //десятое действие
                        number2 = false;
                        break;
                    default:                                            //если выбрано не 1-10
                        break;
                }
            } while (number2);

            TestCollections a = new TestCollections();
        }

    }
}
