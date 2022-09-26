using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace oop_lab16
{
    class Program
    {
        static void Main(string[] args)
        {


            Task task = new Task(SieveEratosthenes);
            task.Start();
            Console.WriteLine($"state in time: {task.Status}");
            task.Wait();
            Console.WriteLine("finish method Main");
            Console.WriteLine($"id: {task.Id}");
            Console.WriteLine($"state after finish: {task.Status}");


            Stopwatch watch = new Stopwatch();
            watch.Start();
            task.Start();
            watch.Stop();

            CancellationTokenSource cancelTokenSource = new CancellationTokenSource();
            CancellationToken token = cancelTokenSource.Token;


            Task task1 = new Task(() =>
            {
                Console.WriteLine("enter n");
                int n = int.Parse(Console.ReadLine());
                var list = new List<int>();
                for (var i = 2; i < n; i++)
                {
                    list.Add(i);
                }

                if (token.IsCancellationRequested)
                {
                    Console.WriteLine("stopped");
                    return;
                }

                for (var i = 0; i < list.Count; i++)
                {
                    for (var j = 2; j < n; j++)
                    {
                            
                            list.Remove(list[i] * j);
                    }
                }


                foreach (var i in list)
                {
                    Console.WriteLine(i);
                }

            });
            task1.Start();
            Console.WriteLine("enter X to stop");
            string symbol = Console.ReadLine();
            if (symbol == "X")
                cancelTokenSource.Cancel();


            SieveEratosthenesAsync();

            Stopwatch watch2 = new Stopwatch();
            watch2.Start();
            Parallel.For(0, 3, Random);
            watch2.Stop();
            TimeSpan span2 = watch2.Elapsed;
            Console.WriteLine($"time Parallel.For: {span2}");


            Stopwatch watch3 = new Stopwatch();
            watch3.Start();
            List<int> nums = new List<int>() { 1, 2, 3 };
            ParallelLoopResult result = Parallel.ForEach<int>(nums, Random);
            watch3.Stop();
            TimeSpan span3 = watch3.Elapsed;
            Console.WriteLine($"time Parallel.ForEach: {span3}");

            Parallel.Invoke(Msg,
            () =>
            {
                Console.WriteLine($"wait a lil pls");
                Thread.Sleep(3000);
            },
            () => SieveEratosthenes());



            Task<int> res1 = new Task<int>(() => plus(22, 88));
            res1.Start();

            Task<int> res2 = new Task<int>(() => plusDouble(101, 109));
            res2.Start();

            Task<int> res3 = new Task<int>(() => minus(342, 2));
            res3.Start();

            Task<int> res4 = new Task<int>(() => res1.Result + res2.Result + res3.Result);
            res4.Start();
            Console.WriteLine(res4.Result);



            Task task01 = new Task(() =>
            {
                Console.WriteLine($"wait a lil pls");
            });
            
            Task task02 = task01.ContinueWith(Msg);
            task01.Start();
            task02.Wait();


            goods();


            Console.ReadKey();
        }
        static int plus(int x, int y) 
        {
            return x + y;
        }
        static int plusDouble(int x, int y)
        {
            return (x + y)*2;
        }
        static int minus(int x, int y)
        {
            return (x - y);
        }
        static void Msg()
        {
            Console.WriteLine($"wait a lil pls");
            Thread.Sleep(3000);
        }
        static void Msg(Task t)
        {
            Console.WriteLine($"state in time: {t.Status}");
           
            Console.WriteLine("finish method Main");
            Console.WriteLine($"id: {t.Id}");
            Console.WriteLine($"state after finish: {t.Status}");
            Thread.Sleep(3000);
        }
        static void SieveEratosthenes()
        {
            Console.WriteLine("enter n");
            int n = int.Parse(Console.ReadLine());
            var list = new List<int>();
            for (var i = 2; i < n; i++)
            {
                list.Add(i);
            }

            for (var i = 0; i < list.Count; i++)
            {
                for (var j = 2; j < n; j++)
                {
                    //удаляем кратные числа из списка
                    list.Remove(list[i] * j);
                }
            }

           
            foreach (var i in list) 
            {
                Console.WriteLine(i);
            }

        }
        static async void SieveEratosthenesAsync()
        {
            Console.WriteLine("---- begin SieveEratosthenesAsync");
            await Task.Run(() => SieveEratosthenes());                // выполняется асинхронно
            Console.WriteLine("---- end SieveEratosthenesAsync");
        }
        
        static void Random(int x)
        {
            Random rand = new Random();
            int[] nums = new int[1000000];
            for (int i = 0; i < nums.Length; i++)
            {
                nums[i] = rand.Next(10);
            }
            Thread.Sleep(3000);
        }
        
        static void goods()
        {
            Task p1 = new Task(producer);
            Task p2 = new Task(producer);
            Task p3 = new Task(producer);
            Task p4 = new Task(producer);
            Task p5 = new Task(producer);
    
            Task c1 = new Task(consumer);
            Task c2 = new Task(consumer);
            Task c3 = new Task(consumer);
            Task c5 = new Task(consumer);
            Task c6 = new Task(consumer);
            Task c7 = new Task(consumer);
            Task c8 = new Task(consumer);
            Task c9 = new Task(consumer);
            Task c10 = new Task(consumer);

            p1.Start();
            p2.Start();
            p3.Start();
            p4.Start();
            p5.Start();
            c1.Start();
            c2.Start();
            c3.Start();
            c5.Start();
            c6.Start();
            c7.Start();
            c8.Start();
            c9.Start();
            c10.Start();
        }
        static int mod = 1;
        static BlockingCollection<int> bc = new BlockingCollection<int>(5);
        static void producer()
        {
            mod++;
            for (int i = (mod - 1); i < mod; i++)
            {
                bc.Add(i);
                Thread.Sleep(500);
                Console.WriteLine("added: " + i);
                foreach (var j in bc)
                {
                    Console.WriteLine("amount of products: " + j);
                    Thread.Sleep(500);
                }
                Thread.Sleep(500);
            }
        }
        static void consumer()
        {
            mod++;
            int i;
            while (!bc.IsCompleted)
            {
                Thread.Sleep(500);
                if (bc.TryTake(out i))
                {
                    Console.WriteLine("deleted: " + i);
                    Thread.Sleep(500);
                }
                else
                {
                    if (i == 0)
                    {
                        Console.WriteLine("empty");
                    }
                }
                Thread.Sleep(500);
            }
        }
    }

}
