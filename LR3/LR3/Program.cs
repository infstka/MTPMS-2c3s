using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    public partial class stdnt
    {
        public void func_1()
        {
            Console.Write("def, ");
        }
    }

    public class Students
    {

        private string name;
        public string Name
        {
            set
            {
                if (name == "") 
                {
                    Console.WriteLine("name не задано");
                }
                else
                {
                    name = value;
                }
            }
            get
            {
                return name;
            }
        }

        private string surname;
        public string Surname
        {
            set
            {
                if (surname == "")
                {
                    Console.WriteLine("fac не задано");
                }
                else
                {
                    surname = value;
                }
            }
            get
            {
                return surname;
            }
        }

        private string lastname;
        public string Lastname
        {
            set
            {
                if (lastname== "")
                {
                    Console.WriteLine("lastname не задано");
                }
                else
                {
                    lastname = value;
                }
            }
            get
            {
                return lastname;
            }
        }
        public int birth { get; set; }
        public string adress { get; set; }
        public int phone { get; set; }
        public string faculty { get; set; }
        public int year { get; set; }
        public int group { get; set; }

        public static int count = 0; //!

        //public Random rnd = new Random();

        public readonly int ID; //!

        static Students()
        {
            Console.WriteLine("Начинаем");
        }
        public Students(string name, string surname, string lastname, int birth, string adress, int phone, string faculty, int year, int group, int ID)
        {
            this.name = name;
            this.surname = surname;
            this.lastname = lastname;
            this.birth = birth;
            this.adress = adress;
            this.phone = phone;
            this.faculty = faculty;
            this.year = year;
            this.group = group;
            //this.ID = rnd.Next();
            count++;
            Print();
        }
        string a;
        private Students(string a) 
        {
             this.a = a;
        }
        

        public void Print()
        {
            Console.WriteLine("name: " + name);
            Console.WriteLine("surname: " + surname);
            Console.WriteLine("lastname: " + lastname);
            Console.WriteLine("birth: " + birth);
            Console.WriteLine("adress: " + adress);
            Console.WriteLine("phone: " + phone);
            Console.WriteLine("faculty: " + faculty);
            Console.WriteLine("year: " + year);
            Console.WriteLine("group: " + group);
            var testpri = new Students("private is work");
            Console.WriteLine(testpri.a);
            Console.WriteLine();
        }

        public static void Stat(ref int count) //!
        {
            Console.WriteLine("Количество хранящихся объектов: " + count);
        }
    }

    class Program
    {
        static void Create(Students[] students)
        {
            Console.WriteLine("Student name: ");
            string name = Console.ReadLine();
            Console.WriteLine("Student surname: ");
            string surname = Console.ReadLine();
            Console.WriteLine("Student lastname: ");
            string lastname = Console.ReadLine();
            Console.WriteLine("Student birthday: ");
            int birth = int.Parse(Console.ReadLine());
            Console.WriteLine("Student adress: ");
            string adress = Console.ReadLine();
            Console.WriteLine("Student phone: ");
            int phone = int.Parse(Console.ReadLine());
            Console.WriteLine("Student faculty: ");
            string faculty = Console.ReadLine();
            Console.WriteLine("Student year: ");
            int year = int.Parse(Console.ReadLine());
            Console.WriteLine("Student group: ");
            int group = int.Parse(Console.ReadLine());
            int ID = 0;
            
            
            Students Student0 = new Students(name, surname, lastname, birth, adress, phone, faculty, year, group, ID);
            students[0] = Student0;
           
            if (name == "") Student0.Name = "";
            if (surname == "") Student0.Surname = "";
            if (lastname == "") Student0.Lastname = "";
        }
        static void Main(string[] args)
        {
            Students Student1 = new Students("name1", "surname1", "lastname1", 2003, "adress1", 0, "fit", 2, 1, 0);
            Students Student2 = new Students("name2", "surname2", "lastname2", 2002, "adress2", 6, "fit", 2, 2, 0);



            Students[] students = new Students[3];
            Create(students);
            students[1] = Student1;
            students[2] = Student2;
            Console.ReadKey();

            Console.WriteLine("Введите fac: ");
            string faculty = Console.ReadLine();
            for (int i = 0; i < students.Length; i++)
            {
                if (students[i].faculty == faculty)
                {
                    Console.WriteLine("name: " + students[i].Name);
                    Console.WriteLine("surname: " + students[i].Surname);
                    Console.WriteLine("lastname: " + students[i].Lastname);
                    Console.WriteLine("birth: " + students[i].year);
                    Console.WriteLine("adress: " + students[i].adress);
                    Console.WriteLine("phone: " + students[i].phone);
                    Console.WriteLine("faculty: " + students[i].faculty);
                    Console.WriteLine("year: " + students[i].year);
                    Console.WriteLine("group: " + students[i].group);
                    Console.WriteLine();
                }
            }
            Console.ReadKey();

            Console.WriteLine("Введите group: ");
            int group = int.Parse(Console.ReadLine());
            for (int i = 0; i < students.Length; i++)
            {
                if (students[i].group == group)
                {
                    Console.WriteLine("name: " + students[i].Name);
                    Console.WriteLine("surname: " + students[i].Surname);
                    Console.WriteLine("lastname: " + students[i].Lastname);
                    Console.WriteLine("birth: " + students[i].year);
                    Console.WriteLine("adress: " + students[i].adress);
                    Console.WriteLine("phone: " + students[i].phone);
                    Console.WriteLine("faculty: " + students[i].faculty);
                    Console.WriteLine("year: " + students[i].year);
                    Console.WriteLine("group: " + students[i].group);
                    Console.WriteLine();
                }
            }
            Console.ReadKey();

            stdnt nerevar = new stdnt();
            nerevar.func_1();
            nerevar.func_2();
            Console.ReadKey();

            Students.Stat(ref Students.count);
            Console.ReadKey();
      
        }
    }
}
