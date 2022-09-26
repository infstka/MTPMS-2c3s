using System;

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using oop_lab7;

namespace oop_lab5
{
    class Program
    {
        enum animals
        {
            frog, //0
            horse, //1
            snake, //2
            lion //3
        }
        struct Choco
        {
            public string color;
            public int gr;

            public void about()
            {
                Console.WriteLine($"color of chocolate is {color} & wheight is {gr}gr");
            }
        }

        partial interface IInfo
        {
            // реализация метода по умолчанию
            void info();

        }
        abstract class Goods
        {
            public string name { get; set; } = "bag of sweets";
            public int gr { get; set; }

            public void info()
            {
                Console.WriteLine($" -- you have a new good in the shop: {name} -- ");
            }




        }
         class Flowers : Goods
        {
            
            public Flowers(string flower_name, int gr)
            {
                this.name = flower_name;
                this.gr = gr;
            }


            public override int GetHashCode()
            {
                Console.WriteLine($"\nHASHCODE of car {this.name} is: {name.GetHashCode()}\n-------------------\n");
                return name.GetHashCode();
            }

            public override string ToString()
            {
                return $"{name}\n";
            }

            public override bool Equals(object obj)
            {
                if (obj == null)
                    return false;
                Flowers el = obj as Flowers;
                if (el as Flowers == null)
                    return false;

                return el.name == this.name;
            }


        }
        class Watches : Goods //, IInfo
        {

            public string color;
            public int model;
            public Watches()
            {
                
            }
            public Watches(string watches_label, int gr)
            {
                this.name = watches_label;
                this.gr = gr;

            }
            public Watches(string watches_label, string color, int model)
            {
                this.name = watches_label;
                this.model = model;
                this.color = color;
            }
            public new void info()
            {
                Console.WriteLine($" -- the description: {name} {model} {color} -- ");
            }
            public override string ToString()
            {
                return $"{name} - {model} - {color}\n";
            }


        }
        class Cake
        {
            private int Cake_Gr;
            public string cake_name;
            public int cake_gr
            { get { return Cake_Gr;}
                set 
                { if (value < 0 || value == 0)
                        throw new WeightException("Вес не может быть равен 0 или меньше 0! ");
                    else {
                        Cake_Gr = value;
                    }
                }
            }
            public Cake()
            {



            }
            public Cake(string cake_name, int cake_gr)
            {
                
                this.cake_name = cake_name;
                this.cake_gr = cake_gr;

            }
            public void info()
            {
                Console.WriteLine($" -- the description: {cake_name} -- ");
            }
            public override string ToString()
            {
                return $"{cake_name}\n";
            }

        }
        sealed class Candy : IInfo
        {
            private string candy_name_private;

            public string candy_name
            { 
                get 
                { 
                    return candy_name_private; 
                }
                set 
                {
                    if (value.Length == 0)
                    {
                        throw new WhatException("Что-то пошло не так..Похоже вы дали пустое имя.");
                    }
                    else 
                    {
                        candy_name_private = value;
                    }
                }
            }
            public int candy_gr;
            public Candy(string candy_name, int candy_gr)
            {
                
                this.candy_gr = candy_gr;
                this.candy_name = candy_name;
            }

            public void info()
            {
                Console.WriteLine($" -- the description: {candy_name} -- ");
            }
            public override string ToString()
            {
                return $"{candy_name}\n";
            }

        }
        class Sweets : Goods
        {
            public Cake cake;
            public Candy candy;

            public Sweets(Cake ck, Candy cd, int gr)
            {
                cake = ck;
                candy = cd;
                this.gr = gr;

                //Console.WriteLine($"in the sweet bag you have ");

            }
            public void Info(Cake ck, Candy cd)
            {

                Console.WriteLine($" -- in the bag: {ck.cake_name} & {cd.candy_name} -- ");
            }
            public override string ToString()
            {
                return $"congrats!! you have a {name}\n";
            }
        }
        class Print
        {
            public void IAmPrinting(Goods someobj)
            {
                Console.WriteLine($" -- type of obj is: " + someobj.GetType() + " -- ");
                Console.WriteLine(someobj.ToString());

            }
        }

        
        class Gift
        {

            public Gift()
            {

                container = new List<Goods>();
                return;
            }
            public static List<Goods> container { get; set; }
            public Goods this[int index]
            {
                get { return container[index]; }
                set { container[index] = value; }
            }

            public void AddItem(Goods g) => container.Add(g);
            public void DeleteItem(Goods g) => container.Remove(g);

            public void Print()
            {
                Console.WriteLine("IN CONTEINER");
                for (int i = 0; i < container.Count; i++)
                {

                    Console.WriteLine(container[i].name);
                }
            }

            public static class Controller
            {
                public static void Amount(List<Goods> c)
                {
                    int _count = 0;
                    for (int i = 0; i < c.Count; i++)
                    {
                        _count++;
                    }
                    Console.WriteLine(_count);


                }

                public static void FindMin(List<Goods> c)
                {
                    
                   
                        int temp;
                        for (int i = 0; i < c.Count - 1; i++)
                        {
                            for (int j = i + 1; j < c.Count; j++)
                            {
                                if (c[i].gr > c[j].gr)
                                {
                                    temp = c[i].gr;
                                    c[i].gr = c[j].gr;
                                    c[j].gr = temp;
                                }
                            }
                        }
                    
                    Console.WriteLine(c[0].gr);

                }

            }


           

                

            static void Main()
            {


                // Товар (Продукт, (Кондитерское изделие (Торт, Конфеты)), Цветы,  Часы)



                Cake cake1 = new Cake("banana cake", 1000);
                Cake cake2 = new Cake("strawberry cake", 2000);
                Candy candy1 = new Candy("choco candy", 600);
                Candy candy2 = new Candy("rose candy", 370);

                //cake1.info();
                Sweets bag1 = new Sweets(cake1, candy1, 500);
                Sweets bag2 = new Sweets(cake2, candy2, 500);
                // bag1.info();
                //bag1.Info(cake1, candy1);
                Flowers flower1 = new Flowers("roses", 1000);

                Watches watches2 = new Watches("rolex", 170);

                Gift gift = new Gift();
                gift.AddItem(bag2);
                gift.AddItem(flower1);
                gift.AddItem(watches2);

               // gift.Print();
                Controller.Amount(container);
                Controller.FindMin(container);

                //flower1.info();
                //Console.WriteLine(flower1.ToString());

                //Watches watches1 = new Watches("rolex", "silver", 2020);
                //watches1.info();

                //dynamic[] arrayOfGoods = new dynamic[] { watches1, flower1, bag1 };
                //Print print = new Print();
                //print.IAmPrinting(watches1);
                //print.IAmPrinting(flower1);
                //print.IAmPrinting(bag1);

                //Choco white;
                //white.color = "white";
                //white.gr = 180;
                //white.about();

                //Gift gift = new Gift();
                //gift.Add(flower1);
                //Console.WriteLine(gift.ToString());

                try
                {
                    Cake cake55 = new Cake("lavander cake", -1000);

                }
                catch (WeightException ex)
                {
                    Console.WriteLine("Ошибка: " + ex.Message);
                    Console.WriteLine("Метод: " + ex.TargetSite);
                    Console.WriteLine("Источник: " + ex.Source);
                    Console.WriteLine("Стек: " + ex.StackTrace); 
                    
                }
                Console.Read();

                try
                {
                    Candy candy55 = new Candy("", 1000);
                }
                catch (WhatException ex)
                {
                    Console.WriteLine("Ошибка: " + ex.Message);
                    Console.WriteLine("Метод: " + ex.TargetSite);
                    Console.WriteLine("Источник: " + ex.Source);
                    Console.WriteLine("Стек: " + ex.StackTrace);
                    
                }
                 finally
                {
                    Console.WriteLine("--- ---");

                }
                Console.Read();


                try
                {
                    int[] array = new[] { 12, 12, 12 };
                    int index = 100;
                    if (array.Length < index) 
                    {
                        throw new ArgumentOutOfRangeException();
                    }
                    Console.WriteLine(array[index]);
                }
                catch (ArgumentOutOfRangeException ex) 
                {
                    Console.WriteLine("Ошибка: " + ex.Message);
                    Console.WriteLine("Метод: " + ex.TargetSite);
                    Console.WriteLine("Источник: " + ex.Source);
                    Console.WriteLine("Стек: " + ex.StackTrace);
                    
                }
                finally
                {
                    Console.WriteLine("--- Убедитесь что вы написали правильный индекс! ---");

                }
                Console.Read();

                try
                {
                    string str = null;
                    if (str == null) 
                    {
                        throw new NullException("Было присвоено значение NULL ");
                    }
                    Console.WriteLine(str);
                }
                catch (NullException ex)
                {
                    Console.WriteLine("Ошибка: " + ex.Message);
                    Console.WriteLine("Метод: " + ex.TargetSite);
                    Console.WriteLine("Источник: " + ex.Source);
                    Console.WriteLine("Стек: " + ex.StackTrace);
                   
                }
                Console.Read();

                try
                {
                    int x = 5, y =0;
                    x = x / y;
                }
                catch (Exception ex) 
                {
                    Console.WriteLine("Ошибка: " + ex.Message);
                    Console.WriteLine("Метод: " + ex.TargetSite);
                    Console.WriteLine("Источник: " + ex.Source);
                    Console.WriteLine("Стек: " + ex.StackTrace);
                    
                }

                finally
                {
                    Console.WriteLine("Попытка деления на ноль не удалась.");
                }

                Console.ReadKey();
            }

        }


    }
}


