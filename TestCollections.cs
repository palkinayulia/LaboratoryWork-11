using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using ClassLibrary10Lab;

namespace Лабораторная_работа__11
{
    internal class TestCollections
    {
        Stack<Watch> st1;               //Стэк, последним пришёл, первым вышел, доступен только первый
        Stack<string> st2;
        Dictionary<Watch, AnalogWatch> dic1;   //Словарь - ассоциативный массив, универсальный тип в отличие от hashtable
        Dictionary<string, AnalogWatch> dic2;
        Stopwatch sw = new Stopwatch();     //считает сколько времени выполняется
        Watch first;
        AnalogWatch firstV;
        Watch middle;
        AnalogWatch middleV;
        Watch end;
        AnalogWatch endV;
        Watch outof = new Watch();
        AnalogWatch outofV = new AnalogWatch();

        public TestCollections()
        {
            st1 = new Stack<Watch>(1000);   //в () размер
            st2 = new Stack<string>(1000);
            dic1 = new Dictionary<Watch, AnalogWatch>(1000);//создание коллекций
            dic2 = new Dictionary<string, AnalogWatch>(1000);
            for (int i = 0; i < 1000; i++)
            {
                AnalogWatch t = new AnalogWatch();
                t.RandomInit();
                st1.Push(t.GetBase);            //вставить в стэк
                st2.Push(t.GetBase.ToString());
                try
                {
                    dic1.Add(t.GetBase, t);
                    dic2.Add(t.GetBase.ToString(), t);
                }
                catch { }
                if (i == 0)
                {
                    first = t.GetBase;
                    firstV = t.GetTest;
                }
                if (i == 500)
                {
                    middle = t.GetBase;
                    middleV = t.GetTest;
                }
                if (i == 999)
                {
                    end = t.GetBase;
                    endV = t.GetTest;
                }
            }
            Menu(); //функция меню
        }
        private void Menu()
        {
            bool stop = true;
            do
            {
                Console.WriteLine("Меню" +
                    "\n1.Добавить элемент в коллекцию" +
                    "\n2.Удалить элемент из коллекции" +
                    "\n3.Посмотреть все ключи" +
                    "\n4.Посмотреть затраченное время на поиск" +
                    "\n5.Завершить");
                switch (Console.ReadLine())
                {
                    case "1":
                        Console.WriteLine("Введите эелмент:");
                        AnalogWatch w = new AnalogWatch();
                        w.Init();
                        Watch bb = w.GetBase;
                        string aa = bb.ToString();
                        st1.Push(bb);
                        st2.Push(aa);
                        try
                        {
                            dic1.Add(bb, w);       //добавить в словарь
                            dic2.Add(aa, w);
                        }
                        catch
                        {
                            Console.WriteLine("Такой элемент уже находится в коллекции!");
                        }
                        break;
                    case "2":
                        Console.WriteLine("Введите эелмент:");
                        w = new AnalogWatch();
                        w.Init();
                        int index = 0;
                        var b = dic1.Values.ToArray();    //присваем коллекцию значений в массив
                        foreach (var item in b)
                        {
                            if ((w.Brand == b[index].Brand) && (w.YearIssue == b[index].YearIssue))
                            {
                                b[index] = null;
                            }
                            index++;
                        }
                        st1.Clear();        //очищение стэков и словарей
                        st2.Clear();
                        dic1.Clear();
                        dic2.Clear();
                        foreach (var item in b) //заполяем коллекции снова
                        {
                            if (item != null)
                            {
                                Watch new_bb = item.GetBase;
                                string new_aa = new_bb.ToString();
                                st1.Push(new_bb);
                                st2.Push(new_aa);
                                try
                                {
                                    dic1.Add(new_bb, item);
                                    dic2.Add(new_aa, item);
                                }
                                catch
                                {

                                }
                            }
                        }
                        break;
                    case "3":
                        foreach (var item in st2)
                            Console.WriteLine(item);
                        break;
                    case "4":
                        Console.Clear();
                        Console.WriteLine("Поиск первого элемента");
                        sw.Start();     //начало таймера
                        if (st1.Contains(first))    //определяет содержится ли объект в стэке
                        {
                            sw.Stop();  //остановка таймера
                            Console.WriteLine($"Stack<Watch> : {sw.Elapsed}");  //вывод таймера
                        }
                        sw.Reset();     //обнуление таймера
                        sw.Start();
                        if (st2.Contains(first.ToString())) //определяет содержится ли строка из объекта в стэке
                        {
                            sw.Stop();
                            Console.WriteLine($"Stack<string> : {sw.Elapsed}");
                        }
                        sw.Reset();
                        sw.Start();
                        if (dic1.ContainsKey(first))    //опеределяет содержится ли объект в словаре по ключу
                        {
                            sw.Stop();
                            Console.WriteLine($"Dictionary<Watch, AnalogWatch> | ContainsKey : {sw.Elapsed}");
                        }
                        sw.Reset();
                        sw.Start();
                        if (dic1.ContainsValue(firstV))     //определяет содержится ли объект в словаре по значению
                        {
                            sw.Stop();
                            Console.WriteLine($"Dictionary<Watch, AnalogWatch> | ContainsValue : {sw.Elapsed}");
                        }
                        sw.Reset();
                        sw.Start();
                        if (dic2.ContainsKey(first.ToString()))     //определяет содержится ли строка в словаре по ключу
                        {
                            sw.Stop();
                            Console.WriteLine($"Dictionary<string, AnalogWatch> : {sw.Elapsed}");
                        }
                        sw.Reset();
                        Console.WriteLine("");
                        Console.WriteLine("Поиск средного элемента");
                        sw.Start();
                        if (st1.Contains(middle))
                        {
                            sw.Stop();
                            Console.WriteLine($"Stack<Watch> : {sw.Elapsed}");
                        }
                        sw.Reset();
                        sw.Start();
                        if (st2.Contains(middle.ToString()))
                        {
                            sw.Stop();
                            Console.WriteLine($"Stack<string> : {sw.Elapsed}");
                        }
                        sw.Reset();
                        sw.Start();
                        if (dic1.ContainsKey(middle))
                        {
                            sw.Stop();
                            Console.WriteLine($"Dictionary<Watch, AnalogWatch> | ContainsKey : {sw.Elapsed}");
                        }
                        sw.Reset();
                        sw.Start();
                        if (dic1.ContainsValue(middleV))
                        {
                            sw.Stop();
                            Console.WriteLine($"Dictionary<Watch, AnalogWatch> | ContainsValue : {sw.Elapsed}");
                        }
                        sw.Reset();
                        sw.Start();
                        if (dic2.ContainsKey(middle.ToString()))
                        {
                            sw.Stop();
                            Console.WriteLine($"Dictionary<string, AnalogWatch> : {sw.Elapsed}");
                        }
                        sw.Reset();
                        Console.WriteLine("");
                        Console.WriteLine("Поиск последнего элемента");
                        sw.Start();
                        if (st1.Contains(end))
                        {
                            sw.Stop();
                            Console.WriteLine($"Stack<Watch> : {sw.Elapsed}");
                        }
                        sw.Reset();
                        sw.Start();
                        if (st2.Contains(end.ToString()))
                        {
                            sw.Stop();
                            Console.WriteLine($"Stack<string> : {sw.Elapsed}");
                        }
                        sw.Reset();
                        sw.Start();
                        if (dic1.ContainsKey(end))
                        {
                            sw.Stop();
                            Console.WriteLine($"Dictionary<Watch, AnalogWatch> | ContainsKey : {sw.Elapsed}");
                        }
                        sw.Reset();
                        sw.Start();
                        if (dic1.ContainsValue(endV))
                        {
                            sw.Stop();
                            Console.WriteLine($"Dictionary<Watch, AnalogWatch> | ContainsValue : {sw.Elapsed}");
                        }
                        sw.Reset();
                        sw.Start();
                        if (dic2.ContainsKey(end.ToString()))
                        {
                            sw.Stop();
                            Console.WriteLine($"Dictionary<string, Watch> : {sw.Elapsed}");
                        }
                        sw.Reset();
                        Console.WriteLine("");
                        Console.WriteLine("Поиск элемента не из коллекции");
                        sw.Start();
                        if (st1.Contains(outof))
                        {
                            sw.Stop();
                            Console.WriteLine($"Stack<Watch> : {sw.Elapsed}");
                        }
                        else
                            Console.WriteLine($"Не найден!{sw.Elapsed}");
                        sw.Reset();
                        sw.Start();
                        if (st2.Contains(outof.ToString()))
                        {
                            sw.Stop();
                            Console.WriteLine($"Stack<string> : {sw.Elapsed}");
                        }
                        else
                            Console.WriteLine($"Не найден!{sw.Elapsed}");
                        sw.Reset();
                        sw.Start();
                        if (dic1.ContainsKey(outof))
                        {
                            sw.Stop();
                            Console.WriteLine($"Dictionary<Watch, AnalogWatch> : {sw.Elapsed}");
                        }
                        else
                            Console.WriteLine($"Не найден!{sw.Elapsed}");
                        sw.Reset();
                        sw.Start();
                        if (dic1.ContainsValue(outofV))
                        {
                            sw.Stop();
                            Console.WriteLine($"Dictionary<Watch, AnalogWatch> | ContainsValue : {sw.Elapsed}");
                        }
                        else
                            Console.WriteLine($"Не найден!{sw.Elapsed}");
                        sw.Reset();
                        sw.Start();
                        if (dic2.ContainsKey(outof.ToString()))
                        {
                            sw.Stop();
                            Console.WriteLine($"Dictionary<string, AnalogWatch> : {sw.Elapsed}");
                        }
                        else
                            Console.WriteLine($"Не найден!{sw.Elapsed}");
                        sw.Reset();
                        Console.WriteLine("");
                        break;
                    case "5":
                        stop = false;   //прекращение работы программы 
                        break;
                }
            } while (stop);
        }
    }
}
