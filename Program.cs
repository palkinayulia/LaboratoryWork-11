using ClassLibrary10Lab;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Text.RegularExpressions;
using static System.Net.Mime.MediaTypeNames;
using System.Diagnostics;
using System.Runtime.InteropServices;
using static System.Runtime.InteropServices.JavaScript.JSType;
namespace Лабораторная_работа__11
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //1 задание
            Queue<Watch> queue = new Queue<Watch>(); //создание очереди
            for (int i = 0; i < 5; i++) //заполнение очереди разными элементами
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
            for (int i = 0; i < 5; i++)
            {
                DigitalWatch c2 = new DigitalWatch();
                c2.RandomInit();
                queue.Enqueue(c2);
            }
            for (int i = 0; i < 5; i++)
            {
                SmartWatch c2 = new SmartWatch();
                c2.RandomInit();
                queue.Enqueue(c2);
            }
            bool number1 = true; //меню
            do
            {
                Console.WriteLine("Меню:" +
                    "\n1.Добавить объект" +
                    "\n2.Удалить первый объект" +
                    "\n3.Запрос количество часов с пульсометром" +
                    "\n4.Запрос о новом бренде часов" +
                    "\n5.Запрос об уникальном стиле аналог часов" +
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
                        queue.Enqueue(new Watch(watch1.Brand, watch1.YearIssue, 1)); //метод для добавления элемента
                        Console.WriteLine("Элемент добавлен");
                        break;
                    case "2":
                        if (queue.Count == 0)
                        {
                            Console.WriteLine("Коллекция пуста"); //проверка на пустоту
                            break;
                        }
                        else
                        {
                            queue.Dequeue(); //удаляет самый первый объект в очереди
                            Console.WriteLine("Элемент удален");
                            break;
                        }
                    case "3":
                        int count = 0;
                        foreach (var item in queue)
                        {
                            if (item is SmartWatch c)
                                if (c.Pulsometer == true)
                                    count++;
                        }
                        Console.WriteLine($"Количество умных часов с датчиком измерения пульса: {count}");
                        break;
                    case "4":
                        int maxYear = 0;
                        string newBrand = "";
                        foreach (Watch clock in queue) //самый новый бренд часов по году выпуска
                        {
                            if (clock.YearIssue > maxYear)
                            {
                                newBrand = clock.Brand;
                                maxYear = clock.YearIssue;
                            }
                        }
                        Console.WriteLine($"Самый новый бренд часов: {newBrand}");
                        break;
                    case "5":
                        int countClassic = 0;
                        int countSport = 0;
                        int countFashion = 0;
                        int countPremium = 0;
                        foreach (var item in queue)//уникальные стили аналоговых часов
                        {
                            if (item is AnalogWatch clock)
                                if (clock.Style == "classic") countClassic++;
                                else if (clock.Style == "sport") countSport++;
                                else if (clock.Style == "fashion") countFashion++;
                                else if (clock.Style == "premium") countPremium++;
                        }
                        Console.WriteLine("Уникальные стили аналоговых часов: ");
                        if (countClassic == 1) { Console.WriteLine("classic"); }
                        if (countSport == 1) { Console.WriteLine("sport"); }
                        if (countPremium == 1) { Console.WriteLine("premium"); }
                        if (countFashion == 1) { Console.WriteLine("fashion"); }
                        else Console.WriteLine("уникальных стилей нет");
                        break;
                    case "6":
                        foreach (var item in queue)
                        {
                            Console.WriteLine(item.ToString()); //вывод элементов
                        }
                        Console.WriteLine("");
                        break;
                    case "7":
                        Queue clonQueue = new Queue(queue);   //копия
                        Console.WriteLine($"Количество ссылок в клоне: {clonQueue.Count}");
                        Console.WriteLine("");
                        break;
                    case "8":
                        Watch[] SortedArray = new Watch[queue.Count]; //сортировка
                        int index = 0;
                        foreach (var item in queue)
                        {
                            SortedArray[index] = item;
                            index++;
                        }
                        Array.Sort(SortedArray);
                        foreach (Watch item in SortedArray)
                        {
                            Console.WriteLine(item);
                        }
                        Console.WriteLine("");
                        break;
                    case "9":
                        Console.Write("Введите номер объекта: "); //поиск эелмента по его номеру в очереди
                        int key_obj = int.Parse(Console.ReadLine());
                        Console.WriteLine("");
                        queue.ToArray()[key_obj - 1].Show();//очередь превращает в массив
                        Console.WriteLine("");
                        break;
                    case "10":
                        number1 = false;
                        break;
                    default:
                        break;
                }
            } while (number1);

            //2 задание
            Hashtable ht = new Hashtable(); //создание хеш-таблицы
            for (int i = 0; i < 5; i++)
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
            for (int i = 0; i < 5; i++)
            {
                try
                {
                    DigitalWatch c = new DigitalWatch();
                    c.RandomInit();
                    Watch w = new Watch(c.Brand, c.YearIssue, 1);
                    ht.Add(w, c);
                }
                catch (Exception e) { i--; }
            }
            for (int i = 0; i < 5; i++)
            {
                
                try
                {
                    SmartWatch c = new SmartWatch();
                    c.RandomInit();
                    Watch w = new Watch(c.Brand, c.YearIssue, 1);
                    ht.Add(w, c);
                }
                catch (Exception e) { i--; }
            }
            Console.WriteLine("DICTIONARY");
            bool number2 = true; //меню        
            do
            {
                Console.WriteLine("Меню:" +
                    "\n1.Добавить объекты" +
                    "\n2.Удалить объекты" +
                    "\n3.Запрос количество часов с пульсометром" +
                    "\n4.Запрос о новом бренде часов" +
                    "\n5.Запрос об уникальном стиле аналог часов" +
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
                            if (item is SmartWatch c)
                                if (c.Pulsometer == true)
                                    count++;
                        }
                        Console.WriteLine($"Количество умных часов с датчиком измерения пульса: {count}");
                        break;
                    case "4":                                            //четвёртое действие
                        int maxYear = 0;
                        string newBrand = "";
                        foreach (Watch clock in ht.Values)
                        {
                            if (clock.YearIssue > maxYear)
                            {
                                newBrand = clock.Brand;
                                maxYear = clock.YearIssue;
                            }
                        }
                        Console.WriteLine($"Самый новый бренд часов: {newBrand}");
                        break;
                    case "5":                                            //пятое дейсвтвие
                        int countClassic = 0;
                        int countSport = 0;
                        int countFashion = 0;
                        int countPremium = 0;
                        foreach (var item in ht.Values)//уникальные стили аналоговых часов
                        {
                            if (item is AnalogWatch clock)
                                if (clock.Style == "classic") countClassic++;
                                else if (clock.Style == "sport") countSport++;
                                else if (clock.Style == "fashion") countFashion++;
                                else if (clock.Style == "premium") countPremium++;
                        }
                        Console.WriteLine("Уникальные стили аналоговых часов: ");
                        if (countClassic == 1) { Console.WriteLine("classic"); }
                        if (countSport == 1) { Console.WriteLine("sport"); }
                        if (countPremium == 1) { Console.WriteLine("premium"); }
                        if (countFashion == 1) { Console.WriteLine("fashion"); }
                        else Console.WriteLine("уникальных стилей нет");
                        break;
                    case "6":                                            //шестое действие
                        foreach (var item in ht.Values)
                        {
                            Console.WriteLine(item);
                        }
                        Console.WriteLine("");
                        break;
                    case "7":                                           //седьмое действие
                        Hashtable clon = (Hashtable)ht.Clone();  //клонирование, присваивает ссылку
                        Console.WriteLine($"Количество ссылок в клоне: {clon.Count}");
                        Console.WriteLine("");
                        break;
                    case "8":                                           //восьмое действие
                        Watch[] SortedArray = new Watch[ht.Count]; //создаем массив для сортировки
                        int index = 0;
                        foreach (var item in ht.Values)
                        {
                            SortedArray[index] = (Watch)item;
                            index++;
                        }
                        Array.Sort(SortedArray);
                        foreach (Watch item in SortedArray)
                        {
                            Console.WriteLine(item);
                        }
                        Console.WriteLine("");
                        break;
                    case "9":                                           //девятое действие
                        Console.Write("Введите ключ объекта: ");
                        string key_obj = Console.ReadLine();
                        Console.WriteLine("");
                        Console.WriteLine((Watch)ht[key_obj]);     //поиск по ключу и вывод
                        Console.WriteLine("");
                        break;
                    case "10":                                          //десятое действие
                        number2 = false;
                        break;
                    default:                                            //если выбрано не 1-10
                        break;
                }
            } while (number2);

            //3 задание
            TestCollections a = new TestCollections(); //запуск 3 задания
        }

    }
}
