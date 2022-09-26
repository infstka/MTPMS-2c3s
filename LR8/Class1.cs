using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oop_lab8
{
    class Goods
    {
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

      
    }
     class Watches : Goods
    {

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
       

    }
}
