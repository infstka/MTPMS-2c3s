using System;

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oop_lab6
{
    abstract class Goods
    {
        public string name { get; set; } = "bag of sweets";

        public void info()
        {
            Console.WriteLine($" -- you have a new good in the shop: {name} -- ");
        }


    }
    partial class Flowers : Goods
    {

        //public Flowers(string flower_name)
        //{
        //    this.name = flower_name;
        //}

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
}
