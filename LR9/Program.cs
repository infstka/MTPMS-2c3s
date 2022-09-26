using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;


namespace oop_lab9
{

    public delegate void Message(string m);
    public delegate void Action<T>(T obj);
    public delegate int Sum(int x, int y);
    public class Programer 
    {
        public event Message remove;
        public event Message mutate;
        List<string> list = new List<string>();
       
       
        public void add(string item)
        {
            list.Add(item); 
        }

        public void delete(string item)
        {
            list.Remove(item);
            remove?.Invoke($" --- element {item} was deleted --- ");
            foreach (var i in list)
                Console.WriteLine(i);
            Console.WriteLine();
        
            return;
        }
        public void view()
        {
            foreach (var i in list)
                Console.WriteLine(i);
            Console.WriteLine();
        }
        public void changeUp(string e)
        {
            mutate?.Invoke(" --- list mutated --- ");
           
            int indx = list.IndexOf(e);
            if (indx < list.Count)
            {
                list.Remove(e);
                e = e.ToUpper();
                list.Insert(indx, e);
            }
           
        }
        public void Up(string str)
        {
            for (int i = 0; i < str.Length; i++)
            {
                if (i % 2 == 0)
                {
                    Console.Write(char.ToUpper(str[i]));
                }
                if (i % 2 == 1) 
                {
                    Console.Write(char.ToLower(str[i]));
                }
            }
            Console.WriteLine();

        }

        public void deleteComma(string str)
        {
            
            Console.WriteLine(str.Replace(',', ' '));
            return;
        }
        public void deleteFree(string str)
        {
            
            Console.WriteLine(str.Replace(" ", ""));
            return;
        }
        public void deleteQ(string str)
        {
            
            Console.WriteLine(str.Replace('?', ' '));
            return;
        }
        public void changeA(string str, char n)
        {
            
            Console.WriteLine(str.Replace(n, 'X'));
            return;
        }

    }
    
    class Program
    {
      
        static void Main(string[] args)
        {

            Sum plus = (x, y) => x + y;
            Console.WriteLine(plus(100, 240));

            Programer program1 = new Programer();
            program1.remove += DisplayMessage;
            program1.mutate += DisplayMessage;
            
            // program1.mutate += f;
            program1.add("c++");
            program1.add("java");
            program1.add("kotlin");
            program1.add("js");
            program1.add("c");
            program1.add("swift");
            program1.view();

            program1.delete("js");

            program1.changeUp("java");
            program1.view();


            string str = "hello!! how r u? hope everything good! if not text me.";
            
            Action<string> task;
            task = program1.deleteFree;
            task(str);
            task = program1.deleteQ;
            task(str);
            task = program1.deleteComma;
            task(str);
            task = program1.Up;
            task(str);

            Action<string, char> task2;
            task2 = program1.changeA;
            task2(str, 'h');

            Console.ReadKey();
        }
        private static void DisplayMessage(string message)
        {
            Console.WriteLine(message);

        }
        private static void f(string message)
        {
            Console.WriteLine("----------------");
        }
    }
}
