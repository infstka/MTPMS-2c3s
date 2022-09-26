using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace oop_lab10
{
    interface ISet<T>
    {
        bool Add(T item);
        bool Contains(T item);
        void Clear(T item);
        void view();
    }
    public class Image<T> : ISet<T>, IEnumerable<T>
    {

        public static int count = 0;
        public string color { get; set; }
        public string size { get; set; }
        public string type { get; set; }
        public Image() { }
        public Image(string color, string size, string type)
        {
            this.color = color;
            this.size = size;
            this.type = type;
        }
        public void vectorToRastrum()
        {
            if (this.type == "vector")
            {
                this.type = "rastrum";
            }
        }
        public void rastrumToVector()
        {
            if (this.type == "rastrum")
            {
                this.type = "vector";
            }
        }

        LinkedList<T> link = new LinkedList<T>();
        bool ISet<T>.Add(T item)
        {
            if (count == 0)
            {
                link.AddFirst(item);
                count++;
                return true;
            }
            else
            {
                link.AddLast(item);
                count++;
                return true;
            }

        }
        void ISet<T>.Clear(T item)
        {
            for (int i = 0; i < link.Count; i++)
            {

                link.Remove(item);
            }
        }
        bool ISet<T>.Contains(T item)
        {

            if (link.Find(item) != null)
            {
                Console.WriteLine(" -- this element is in the list -- ");
                return true;
            }
            else
            {
                Console.WriteLine(" -- this element is NOT in the list -- ");
                return false;
            }


        }

        void ISet<T>.view()
        {
            Console.WriteLine("LINKEDLIST: ");
            foreach (T item in link)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
        }
        public int Amount()
        {
            return count;
        }
        public IEnumerator<T> GetEnumerator()
        {
            return ((IEnumerable<T>)link).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)link).GetEnumerator();
        }


    }




    class Program
    {
        static void Main(string[] args)
        {
            Image<string> img1 = new Image<string>();
            ((ISet<string>)img1).Add("van gogh");
            ((ISet<string>)img1).Add("pablo picasso");
            ((ISet<string>)img1).Add("leonardo da vinci");
            ((ISet<string>)img1).Add("michelangelo");
            ((ISet<string>)img1).view();

            ((ISet<string>)img1).Contains("pablo");

            ((ISet<string>)img1).Contains("pablo picasso");
            ((ISet<string>)img1).Clear("michelangelo");
            ((ISet<string>)img1).view();

            Image<string> img2 = new Image<string>();
            ((ISet<string>)img2).Add("Rembrandt");
            ((ISet<string>)img2).Add("Vermeer");
            ((ISet<string>)img2).Add("Eugene Delacroix");

            int c = img1.Amount();
            Queue<string> queue = new Queue<string>();


            foreach (string item in img1)
            {
                queue.Enqueue(item);
            }
            Console.WriteLine("QUEUE: ");
            foreach (string item in queue)
            {

                Console.WriteLine(item);
            }

            ObservableCollection<Image<string>> collectionOfImage = new ObservableCollection<Image<string>>();
            collectionOfImage.CollectionChanged += Image_CollectionChanged;
            collectionOfImage.Add(img1);
            collectionOfImage.Add(img2);

            foreach(Image<string> item in collectionOfImage)
            {
                Console.WriteLine(item);
            }

            Console.ReadKey();
        }
        private static void Image_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add: // если добавление
                    Image<string> newImg = e.NewItems[0] as Image<string>;
                    Console.WriteLine($"Добавлен новый объект.");
                    break;
                case NotifyCollectionChangedAction.Remove: // если удаление
                    Image<string> oldImg = e.OldItems[0] as Image<string>;
                    Console.WriteLine($"Удален объект.");
                    break;
                //case NotifyCollectionChangedAction.Replace: // если замена
                //    Image<string> replacedImg = e.OldItems[0] as Image<string>;
                //    Image<string> replacingImg = e.NewItems[0] as Image<string>;
                //    Console.WriteLine($"Объект заменен другим объектом");
                //    break;
            }
        }

    }

    

}
