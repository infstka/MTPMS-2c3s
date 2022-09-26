using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace oop_lab15
{
    
    class Program
    {
        static int x = 0;
        static object locker = new object();
        static void Main(string[] args)
        {

            foreach (Process process in Process.GetProcesses())
            {
                Console.WriteLine($"id: {process.Id}");
                Console.WriteLine($"name: {process.ProcessName}");
                Console.WriteLine($"priority: {process.BasePriority}");
                Console.WriteLine("-------------------------------------");

            }


            AppDomain domain = AppDomain.CurrentDomain;
            Console.WriteLine($"name: {domain.FriendlyName}");
            Console.WriteLine($"info: {domain.SetupInformation}\n");
            Assembly[] assemblies = domain.GetAssemblies();
            foreach (Assembly asm in assemblies)
                Console.WriteLine(asm.GetName().Name);

           
            AppDomain newD = AppDomain.CreateDomain("newDomain");
            loadAssembly(newD);
            AppDomain.Unload(newD);

           

            Console.Write("enter number: ");
            int n = int.Parse(Console.ReadLine());
            Thread thread = new Thread(new ParameterizedThreadStart(Count));
            thread.Start(n);
            Console.WriteLine($"state: {thread.ThreadState}");
            Console.WriteLine($"name: {thread.Name}");
            Console.WriteLine($"priority: {thread.Priority}");
            Console.WriteLine($"id: {thread.ManagedThreadId}");


            Thread t1 = new Thread(new ParameterizedThreadStart(countFirst));
            Thread t2 = new Thread(new ParameterizedThreadStart(countSecond));
            t2.Priority = ThreadPriority.Highest;
            t2.Start(n);
            t1.Start(n);


            Thread t3 = new Thread(new ParameterizedThreadStart(countFirstSync));
            Thread t4 = new Thread(new ParameterizedThreadStart(countSecondSync));
            t3.Start(n);
            t4.Start(n);

            Thread t5 = new Thread(new ParameterizedThreadStart(countFirstOneByOne));
            Thread t6 = new Thread(new ParameterizedThreadStart(countSecondOneByOne));
            t5.Start(n);
            t6.Start(n);



            TimerCallback tm = new TimerCallback(hello);
            Timer timer = new Timer(tm, null, 0, 2000);

            Console.ReadKey();
        }
        static void loadAssembly(AppDomain defaultD)
        {
            string path = @"D:\Саша Комкова\oop\oop_lab15\factorial\factorial\bin\Debug\factorial.exe";
            Assembly assembly = Assembly.LoadFile(path);
            Console.WriteLine($"loaded assemly: {assembly.GetName().Name}\n");
        }
        public static void hello(object n) 
        {
            
                Console.WriteLine(" - hello - ");
            
        }
        public static void Count(object n)
        {
            StreamWriter sw = new StreamWriter(@"D:\Саша Комкова\oop\oop_lab15\file.txt", true);
            int counter = (int)n;
            for (int i = 1; i <= counter; i++)
            {
                Console.WriteLine(i);
                sw.WriteLine(i);
                Thread.Sleep(400);
            }
            sw.Close();
        }
        public static void countFirst(object n)
        {
            StreamWriter sw = new StreamWriter(@"D:\Саша Комкова\oop\oop_lab15\file.txt", true);
            int counter = (int)n;
            for (int i = 1; i <= counter; i++)
            {
                if (i % 2 == 0)
                {
                    Console.WriteLine(i);
                    sw.WriteLine(i);
                }
                Thread.Sleep(200);
            }
           
            sw.Close();
        }
        public static void countSecond(object n)
        {
            StreamWriter sw = new StreamWriter(@"D:\Саша Комкова\oop\oop_lab15\file.txt", true);
            int counter = (int)n;
            for (int i = 1; i <= counter; i++)
            {
                if (i % 2 == 1)
                {
                    Console.WriteLine(i);
                    sw.WriteLine(i);
                }
                Thread.Sleep(300);
            }
            sw.Close();
        }
        public static void countFirstSync(object n)
        {
            lock (locker)
            {
                StreamWriter sw = new StreamWriter(@"D:\Саша Комкова\oop\oop_lab15\file.txt", true);
                int counter = (int)n;
                for (int i = 1; i <= counter; i++)
                {
                    if (i % 2 == 0)
                    {
                        Console.WriteLine(i);
                        sw.WriteLine(i);
                    }
                    Thread.Sleep(200);
                }

                sw.Close();
            }
        }
        public static void countSecondSync(object n)
        {
            
            lock (locker)
            {
                StreamWriter sw = new StreamWriter(@"D:\Саша Комкова\oop\oop_lab15\file.txt", true);
                int counter = (int)n;
                for (int i = 1; i <= counter; i++)
                {
                    if (i % 2 == 1)
                    {
                        Console.WriteLine(i);
                        sw.WriteLine(i);
                    }
                    Thread.Sleep(300);
                }
                sw.Close();
            }
        }

        public static void countFirstOneByOne(object n)
        {
            int counter = (int)n;
            for (int i = 1; i <= counter; i++)
            {
                if (i % 2 == 0)
                {
                    Console.WriteLine(i);
                    Thread.Sleep(300);
                }
            }
            
        }
        public static void countSecondOneByOne(object n)
        {
             
            int counter = (int)n;
            for (int i = 1; i <= counter; i++)
            {
                if (i % 2 == 1)
                {
                    Console.WriteLine(i);
                    Thread.Sleep(300);
                }
            }
            
            
        }
    }
}
//Console.WriteLine($"start time: {process.StartTime}");
//Console.WriteLine($"processor time: {process.TotalProcessorTime}");