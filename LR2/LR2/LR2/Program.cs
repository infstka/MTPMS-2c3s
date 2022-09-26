using System;
using System.Text;

namespace LR2
{
    class Program
    {
        static void Main(string[] args)
        {
            //Типы
            //Задание №1
            //a

            bool yes = true;
            int a = 10;
            char b = 'S';
            string hello = "world";
            byte cc = 2;
            long lg = 2147483646;
            short sh = 32767;
            double fl = 3.1;
            sbyte sby = -120;
            uint ui = 1;
            ulong ull = 18446744073309551614;
            ushort ush = 65534;



            Console.WriteLine("boolean : {0}", yes);
            Console.WriteLine("integer : {0}", a);
            Console.WriteLine("char: {0}", b);
            Console.WriteLine("string : {0}", hello);
            Console.WriteLine("byte : {0}", cc);
            Console.WriteLine("long : {0}", lg);
            Console.WriteLine("short : {0}", sh);
            Console.WriteLine("double : {0}", fl);
            Console.WriteLine("sbyte : {0}", sby);
            Console.WriteLine("uint : {0}", ui);
            Console.WriteLine("ulong : {0}", ull);
            Console.WriteLine("ushort : {0}", ush);

            Console.WriteLine("boolean,string,char,int");

            bool d = Convert.ToBoolean(Console.ReadLine());
            string SomeText = Convert.ToString(Console.ReadLine());
            char f = Convert.ToChar(Console.ReadLine());
            int j = Convert.ToInt32(Console.ReadLine());

            //b
            //Неявное преобразование 

            byte n = 15;
            short s = n;
            int q = n;
            long e = n;
            double t = n;

            Console.WriteLine(" short : {0}  int : {1} long : {2} double : {3}", s, q, e, t);

            //Явное преобразование 

            int qw = 22;
            long wer = Convert.ToInt32(qw);
            Console.WriteLine(wer);
            int ppp = 1;
            int iii = 2;
            int vv = ppp + iii;
            byte vv1 = (byte)vv;
            Console.WriteLine(vv.GetType());
            Console.WriteLine(vv1.GetType());

            //c
            //Распаковка и упаковка значимых типов 

            int i = 532;
            //Упаковка
            object p = i;
            Console.WriteLine(p);
            //Распкаовка
            i = (int)p;
            Console.WriteLine(p);

            //d
            //Неявно типизированные переменные

            var MyAge = 18;
            Console.WriteLine("Age: {0}", MyAge);

            //e
            //Nullable

            int? sda = null;
            int? das = 23;
            //Возвращает тот операнд,значение которого не равно null
            Console.WriteLine(sda ?? das);







            //Задание №2
            //Строки

            //a
            //Объявление строковых литераллов
            string str1 = "Str1";
            string str2 = "Str2";
            //Сравнение
            Console.WriteLine(str1.Equals(str2));
            Console.WriteLine(str1 + str2);

            //b

            string s1 = "Hi";
            string s2 = "My name is";
            string s3 = "Gleb";

            //Сцепление
            string s4 = string.Concat(s1 + " " + s2 + " " + s3);
            Console.WriteLine(s4);

            //Копирование

#pragma warning disable CS0618 // Тип или член устарел
            string s5 = string.Copy(s2);
#pragma warning restore CS0618 // Тип или член устарел
            Console.WriteLine(s5);

            //Выделение подстроки 

            Console.WriteLine(s2.Substring(3, 2));

            //Разделение строки на слова

            string[] words = s2.Split(' ');
            Console.WriteLine(words[0]);

            //Вставка подстроки в заданную позицию 
            Console.WriteLine(s2.Insert(2, s1));

            //Удаление заданной подстроки 

            Console.WriteLine(s2.Remove(0, 2));

            //c
            //Создание пустой строки 
            string s6 = "";
            bool blEmpty = String.IsNullOrEmpty(s6);
            Console.WriteLine("Null ot emptu : {0}", blEmpty);

            //Создание null строки

            string s7 = null;
            bool blEmpty2 = String.IsNullOrEmpty(s7);
            Console.WriteLine("Null ot empty : {0}", blEmpty2);


            //d
            //Создание строки на основе StringBuilder

            StringBuilder s8 = new StringBuilder("abc", 111);
            Console.WriteLine(s8);
            Console.WriteLine("Length : {0}", s8.Length);


            //Дополнение строки

            s8.AppendFormat(" def ");
            Console.WriteLine(s8);

            //Удаление части строки

            s8.Remove(5, 3);
            Console.WriteLine(s8);








            //Задание №3
            //Массивы

            // a
            // Двумерный массив
            int[,] nums = { { 0, 1, 2 }, { 3, 4, 5 }, { 5, 6, 7 }, { 8, 9, 10 } };
            int rows = nums.GetUpperBound(0) + 1;
            int columns = nums.Length / rows;
            for (int gh = 0; gh < rows; gh++)
            {
                for (int hj = 0; hj < columns; hj++)
                {
                    Console.Write($"{nums[gh, hj]} \t");

                }
                Console.WriteLine();
            }


            //b
            //Одномерный массив

            string[] mass1 = { "Hello", "My", "Name", "Is", "" };
            //определяем длину массива
            for (int z = 0; z < mass1.Length; z++)
            {
                //Вывод содержимого
                Console.WriteLine(mass1[z]);
            }

            //Меняем произвольный элемент
            //Пользователь выбирает номер элемента
            Console.WriteLine("Select the item number to change from 0 to {0}", mass1.Length);
            int s4r = Convert.ToInt32(Console.ReadLine());
            //Пользователь вводит строку с клавиатуры
            Console.WriteLine("Enter the string");
            string strs4r = Console.ReadLine();
            mass1[s4r] = strs4r;
            for (int z = 0; z < mass1.Length; z++)
            {
                //Вывод содержимого
                Console.WriteLine(mass1[z]);
            }

            //c
            //Ступенчатый массив

            int[][] myArr1 = new int[3][];
            myArr1[0] = new int[2];
            myArr1[1] = new int[3];
            myArr1[2] = new int[4];

            //Инициализируем массив
            int io = 0;
            for (; io < 2; io++)
            {
                int slo = Convert.ToInt32(Console.ReadLine());
                myArr1[0][io] = slo;
            }
            for (io = 0; io < 2; io++)
            {
                Console.WriteLine(myArr1[0][io]);
            }
            for (io = 0; io < 3; io++)
            {
                int slo1 = Convert.ToInt32(Console.ReadLine());
                myArr1[1][io] = slo1;
            }
            for (io = 0; io < 3; io++)
            {
                Console.WriteLine(myArr1[1][io]);
            }

            for (io = 0; io < 4; io++)
            {
                int slo2 = Convert.ToInt32(Console.ReadLine());
                myArr1[2][io] = slo2;
            }
            for (io = 0; io < 4; io++)
            {
                Console.WriteLine(myArr1[2][io]);
            }


            //d
            //Неявно типизированные переменные для хранения массива и строк

            var massN = new object[3];
#pragma warning disable CS0219 // Переменная назначена, но ее значение не используется
            var strN = "Hi";
#pragma warning restore CS0219 // Переменная назначена, но ее значение не используется


            //Задание №4
            //Кортежи
            //a
            //Задать кортеж с элементами типа int,string,char,string,ulong
            ValueTuple<int, string, char, long> cort1 = (5, "hello", 'v', 100000000000);

            //b
            //Вывод картежа
            Console.WriteLine($"{cort1}");
            //с

            //Распаковка 

            var (nm1, nm2, nm3, nm4) = cort1;
            Console.WriteLine(nm1);

            //Сравнение кортежей
            bool equals = (3, 9) == (9, 3);
            Console.WriteLine(equals);






            //Задание №5
            //Работа с функциями 


            void LocalFunc1(int[] args, string mew)
            {
                int maxValue = 0;
                int minValue = 0;

                //Сортируем массив,таким образом элементы выстраиваются от меньшего к большему
                //Соответственно последний элемент - наибольший
                Array.Sort(args);
                maxValue = args[args.Length - 1];

                //Первый элемент - наименьший элемент
                minValue = args[0];

                //Ищем сумму всех элементов массива
                int sum = 0;
                foreach (int value1 in args)
                {
                    sum += value1;
                }

                //С помощью подстроки находим 1 букву строки
                string slp = mew.Substring(0, 1);

                //Формируем кортеж элементов
                ValueTuple<int, int, int, string> cort2 = (maxValue, minValue, sum, slp);
                Console.WriteLine(cort2);
            }
            int[] array = new int[] { 2, 3, 4 };
            LocalFunc1(array, "Fdw");





            //Задание №6
            //Работа с checked/ unchecked:

            //Определяем 2 локальный функции
            //Checked
            int ten = 10;
            void LocalFunc2()
            {
                checked
                {
                    int val1 = int.MaxValue + ten;
                }
            }
            LocalFunc2();

            void LocalFunc3()
            {
                unchecked
                {
                    int val2 = int.MaxValue + ten;
                }
            }
            LocalFunc3();
        }
    }
}
