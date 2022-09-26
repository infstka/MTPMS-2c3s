using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oop_lab11
{
    public partial class car
    {

        public static int id = 0;
        public string label { get; set; } = "none";
        public string model { get; set; } = "none";
        private int year;
        public int Year
        {
            set
            {
                year = value;
            }
            get { return year; }


        }
        public string color { get; set; } = "none";
        public int price { get; set; } = 0;
        public readonly int regNum; //тока для чтения
        public int car_age { get; set; } = 0;
        static int carCounter { get; set; } = 0; // статическое поле //классическое св-во

        public car() //конструкутор без аргументов
        {
            id++;

            label = "not found";
            model = "not found";
            year = 0;
            color = "not found";
            price = 0;
            regNum = 0000000;

            Console.WriteLine("enter other info please");
        }

        public car(string label, string model, int year,
            string color, int price, int regNum) //закрытый конструктор
        {
            id++;

            this.label = label;
            this.model = model;
            this.year = year;
            this.color = color;
            this.price = price;
            this.regNum = regNum;
            car.addCar();

        }


        static car() //статический конструктор
        {
            Console.WriteLine("the FIRST car!");
        }
        public int carAge() //метод подсчета возраста машины
        {
            car_age = 2020 - year;
            Console.WriteLine($"car age of {label}: " + car_age);
            return car_age;
        }
        static int addCar() //статический метод
        {
            if (carCounter == 0)
            {
                Console.WriteLine("there're no cars in garage");

            }
            return carCounter++;
        }

        public void about()
        {
            Console.WriteLine($"{id}\n{label}\n{model}\n{year}\n{color}\n{price}\n{regNum}\n\n");

        }

        public override int GetHashCode()
        {
            Console.WriteLine($"\nHASHCODE of car {this.label} is: {label.GetHashCode()}\n-------------------\n");
            return label.GetHashCode();
        }

        public override string ToString()
        {
            return $" {label} - {model} - {year} - {color} - {price} - {regNum}\n";
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            car el = obj as car;
            if (el as car == null)
                return false;

            return el.label == this.label && el.model == this.model;
        }



        public const int wheels = 4; //поле-константа
        public static void Wheels(ref int wheels, out int wheels_out)
        {
            wheels_out = wheels;
        }


    }
    class Program
    {
        static void Main(string[] args)
        {
            string[] m = new [] { "December", "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November" };
            int n = 7;
            var selectedN = from t in m // определяем каждый объект из m как t
                                where t.Length == n //фильтрация по критерию
                                select t; // выбираем объект
            foreach (string s in selectedN)
                Console.WriteLine(s);
            Console.WriteLine("\n");

            var selectedSummerOrWinter = from t in m // определяем каждый объект из m как t
                            where t == "December" || t== "January" || t == "February" || t == "June" || t == "July" || t == "August"
                                         orderby t
                                         select t; // выбираем объект
            foreach (string s in selectedSummerOrWinter)
                Console.WriteLine(s);
            Console.WriteLine("\n");

            var selectedAlphabet = from t in m 
                                         orderby t
                                         select t; 
            foreach (string s in selectedAlphabet)
                Console.WriteLine(s);
            Console.WriteLine("\n");

            var selectedUN = from t in m 
                            where t.Length > 4 && t.Contains("u")    
                            select t; 
            foreach (string s in selectedUN)
                Console.WriteLine(s);
            Console.WriteLine("\n");

            car car1 = new car("audi", "v3", 2000, "green", 2300, 01294);
            car car2 = new car("opel", "v3", 2003, "black", 1000, 01234);
            car car3 = new car("volvo", "v56", 2005, "silver", 3400, 67329);
            car car4 = new car("bentley", "v1", 2010, "white", 4900, 60029);
            car car5 = new car("lexus", "v6", 2007, "red", 3790, 65748);
            car car6 = new car("bugatti", "m2", 2017, "black", 1790, 19748);
            car car7 = new car("jeep", "v6", 2007, "red", 2000, 34548);
            car car8 = new car("volvo", "v98.0", 2013, "black", 3100, 60008);
            car car9 = new car("reno", "v2", 2011, "black", 2200, 67222);
            List<car> listCars = new List<car> {car1, car2, car3, car4, car5, car6, car7, car8, car9 };

            var selectedCar = listCars.Where(t => t.label.Contains("o"));

            foreach (var s in selectedCar)
                Console.WriteLine(s);
            Console.WriteLine("\n");

            car[] arrayOfCars = new car[] { car1, car2, car3, car4, car5, car6, car7, car8, car9 };
            var selectedCarLabel = listCars.Where(t => t.label == "volvo");

            foreach (var s in selectedCarLabel)
                Console.WriteLine(s);
            Console.WriteLine("\n");

            var selectedCarLabelN = listCars.Where(t => t.label == "volvo" && t.carAge() > 1);

            foreach (var s in selectedCarLabelN)
                Console.WriteLine(s);
            Console.WriteLine("\n");

            var selectedPriceColor = listCars.Where(t => t.color == "red" || t.color == "black" && t.price > 1000);

            foreach (var s in selectedPriceColor)
                Console.WriteLine(s);
            Console.WriteLine("\n");

            
            int old = listCars.Max(a => a.car_age); 
            var selectedOld = from t in listCars 
                              where t.car_age == old
                                         select t; 

            foreach (var s in selectedOld)
                Console.WriteLine(s);
            Console.WriteLine("\n");

            var selectedYoung = listCars.Take(5).OrderByDescending(t=> t.car_age);

            foreach (var s in selectedYoung)
                Console.WriteLine(s);
            Console.WriteLine("\n");


            var selectedPrice = listCars.OrderBy(t => t.price);

            foreach (var s in selectedPrice)
                Console.WriteLine(s);
            Console.WriteLine("\n");

            

            Console.WriteLine("----------------");
            var selectedMY = listCars.Where(t => t.color.StartsWith("b")).Where(t => t.label.Equals("volvo")).Select(t => t.price);

            foreach (var s in selectedMY)
                Console.WriteLine(s);
            Console.WriteLine("\n");

            string[] car = { car1.label, car2.label, car3.label, car4.label, car5.label, car6.label, car7.label, car8.label, car9.label };
            int[] lengthOfLabel = { 4, 6, 5, 7 };
            var sometype = car.Join(
            lengthOfLabel, // внутренняя
            w => w.Length, // внешний ключ выбора
            q => q, // внутренний ключ выбора
            (w, q) => new // результат
{
                lengthOfLabel = string.Format("{0} ", q),
                car = w,
            });
            foreach (var item in sometype)
                Console.WriteLine(item);

            Console.ReadKey();


        }

    }
}
