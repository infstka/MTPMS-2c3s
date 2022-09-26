using System;

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            public string color { get; set; }
            public int gr { get; set; }

            public void about()
            {
                Console.WriteLine($"color of chocolate is {color} & wheight is {gr}gr");
            }
            public Choco(string color, int gr) {
                this.color = color;
                this.gr = gr;
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
        partial class Flowers : Goods
        {

            public Flowers(string flower_name, int gr)
            {
                this.name = flower_name;
                this.gr = gr;
            }


            //public override int GetHashCode()
            //{
            //    Console.WriteLine($"\nHASHCODE of car {this.name} is: {name.GetHashCode()}\n-------------------\n");
            //    return name.GetHashCode();
            //}

            //public override string ToString()
            //{
            //    return $"{name}\n";
            //}

            //public override bool Equals(object obj)
            //{
            //    if (obj == null)
            //        return false;
            //    Flowers el = obj as Flowers;
            //    if (el as Flowers == null)
            //        return false;

            //    return el.name == this.name;
            //}


        }
        class Watches : Goods 
        {

            public string color;
            public int model;
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

            public string cake_name;
            public int cake_gr;
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

            public string candy_name;
            public int candy_gr;
            public Candy(string candy_name, int candy_gr)
            {
                // bag = any_bag;
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



                Cake cake1 = new Cake("banana cake", 100);
                Cake cake2 = new Cake("strawberry cake", 200);
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

                gift.Print();
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

                Choco white = new Choco("white", 180);
                white.about();

                animals a;
                a = animals.frog;
                Console.WriteLine(a);
                Console.WriteLine((int)a);




                Console.ReadKey();
            }

        }


    }
}

