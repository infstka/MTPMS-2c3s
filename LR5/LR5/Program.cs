using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oop_lab5
{
    class Program
    {
         interface IMovable //2
        {
            // реализация метода по умолчанию
            void info();

        }
        abstract class Goods { //2
            public string name { get; set; } = "bag of sweets";

            public void info()
            {
                Console.WriteLine($" -- you have a new good in the shop: {name} -- ");
            }


        }
        

         class Flowers : Goods
        {
            
            public Flowers(string flower_name)
            {
                this.name = flower_name;
            }

            public override int GetHashCode()
            {
                Console.WriteLine($"\nHASHCODE of car {this.name} is: {name.GetHashCode()}\n-------------------\n");
                return name.GetHashCode();
            }

            public override void GetType()
            {
                Console.WriteLine("type is flowers");
                return;
            }

            public override string ToString()
            {
                return $"{name}\n";
            }

            public override bool Equals(object obj) //5
            {
                if (obj == null)
                    return false;
                Flowers el = obj as Flowers;
                if (el as Flowers == null) 
                    return false;

                return el.name == this.name;
            }


        }
         partial class Watches : Goods , IMovable {
            
            public string color;
            public int model;
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
        sealed class Cake { //3
           
            public string cake_name;
            public Cake(string cake_name) {
                
                this.cake_name = cake_name;
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
        sealed class Candy : IMovable {
           
            public string candy_name;
            public Candy( string candy_name)
            {
               
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
        class Sweets : Goods {
            public Cake cake;
            public Candy candy;
            public Sweets(Cake ck, Candy cd)
            {
                cake = ck;
                candy = cd;
            }
            public void Info(Cake ck, Candy cd) {
                
                Console.WriteLine($" -- in the bag: {ck.cake_name} & {cd.candy_name} -- ");
            }
            public override string ToString()
            {
                return $"congrats!! you have a {name}\n";
            }
        }
        class Print {
            public void IAmPrinting(Goods someobj) 
            {
                Console.WriteLine($" -- type of obj is: "+ someobj.GetType()+" -- ");
                Console.WriteLine(someobj.ToString());
            
        }   }

        static void Main(string[] args)
        {
            // Товар (Продукт, (Кондитерское изделие (Торт, Конфеты)), Цветы,  Часы)

            

            Cake cake1 = new Cake("banana cake");
            Candy candy1 = new Candy("choco candy");
            cake1.info();
            Sweets bag1 = new Sweets(cake1, candy1);
            bag1.info();
            bag1.Info(cake1, candy1);

            Flowers flower1 = new Flowers("rose");
            flower1.info();

            //Goods good = new Goods("corn"); //5

            //Flowers flower2 = good as Flowers;
            //if (flower2 == null)
            //{
            //    Console.WriteLine("Преобразование прошло неудачно");
            //}
            //else
            //{
            //    Console.WriteLine("Преобразование прошло удачно");
            //}
            
            //if (good is Flowers) //5
            //{
            //    Flowers flower2 = (Flowers)god;
            //    Console.WriteLine("Преобразование допустимо");
            //}
            //else
            //{
            //    Console.WriteLine("Преобразование не допустимо");
            //}

            Watches watches1 = new Watches("rolex", "silver", 2021);
            watches1.info();

            dynamic[] arrayOfGoods = new dynamic[] {watches1, flower1, bag1};
            Print print = new Print();
            print.IAmPrinting(watches1);
            print.IAmPrinting(flower1);
            print.IAmPrinting(bag1);

            Console.ReadKey();
        }
    }
}
