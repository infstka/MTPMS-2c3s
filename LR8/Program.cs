using oop_lab8;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace oop_lab4
{
    
    // Объявляем обобщенный интерфейс
    public interface IBase<T>
        where T : new()
    {
        void add(T item);
        void delete(T item);
        void view();
    }
    public class MyList<T> : IEnumerable<T>, IBase<T> where T : new()
    {
        List<T> list = new List<T>();
        static int count = 0;
        public void add(T item) 
        {
            list.Add(item);
            count++;
        }

        public void delete(T item)
        {
            list.Remove(item);
            count--;
        }
        public void deleteFirst()
        {
            list.RemoveAt(0);
            count--;
        }

        public void view()
        {
            foreach (var i in list)
                Console.WriteLine(i);
        }
        public override string ToString()
        {
            return $"{list}\n";
        }
        public IEnumerator<T> GetEnumerator()
        {
            return ((IEnumerable<T>)list).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)list).GetEnumerator();
        }

        public static bool operator true(MyList<T> a)
        {
            if (count != 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool operator false(MyList<T> a)
        {
            if (count == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static MyList<T> operator +(MyList<T> a, MyList<T> b)
        {
            MyList<T> result = new MyList<T>();
            foreach (T item in a) result.add(item);
            foreach (T item in b) result.add(item);
            return result;
        }

        public static MyList<T> operator --(MyList<T> a)
        {
            a.deleteFirst();
            return a;
        }


        public static bool operator ==(MyList<T> a, MyList<T> b)
        {
            return a.Equals(b);

        }
        public static bool operator !=(MyList<T> a, MyList<T> b)
        {
            return !a.Equals(b);
        }

    }
    class Program
    {
        static void Main(string[] args)
        {

            MyList<int> ilist = new MyList<int>();
            ilist.add(11);
            ilist.add(22);
            ilist.add(77);
            ilist.view();
            MyList<int> ilist2 = new MyList<int>();
            ilist2.add(119);
            ilist2.add(245);


            try
            {
                MyList<float> flist = new MyList<float>();
                flist.add(1);
               
            }
            catch (Exception ex)
            {
                 
                Console.WriteLine("Ошибка: " + ex.Message);
                Console.WriteLine("Метод: " + ex.TargetSite);
                Console.WriteLine("Источник: " + ex.Source);
                Console.WriteLine("Стек: " + ex.StackTrace);
                Console.WriteLine("Исключение: " + ex.InnerException);
            }
            finally
            {
                Console.WriteLine("Попытка деления на ноль не удалась.");
            }
            Console.Read();

            MyList<double> dlist = new MyList<double>();
            dlist.add(12.45);
            dlist.add(7.7);
            dlist.add(0.7);
            dlist.add(767.89);
            dlist.view();
            dlist.delete(7.7);
            dlist.view();

            Flowers flower1 = new Flowers("rose");
            Flowers flower2 = new Flowers("violets");
            Flowers flower3 = new Flowers("daisy");

            MyList<Goods> result = new MyList<Goods>();
            result.add(flower1);
            result.add(flower2);
            result.add(flower3);
            result.view();


            string writePath = @"D:\Саша Комкова\oop\oop_lab8\file.txt";

            try
            {

                using (StreamWriter sw = new StreamWriter(writePath, false, System.Text.Encoding.Default))
                {

                    foreach (var item in ilist)
                    {
                        sw.WriteLine(item);
                    }
                }
                Console.WriteLine("WROTE TO FILE\n");
                using (StreamReader sr = new StreamReader(writePath))
                {
                    Console.WriteLine("READ FROM FILE:");
                    Console.WriteLine(sr.ReadToEnd());
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }


            Console.ReadKey();
        }


    }




}


