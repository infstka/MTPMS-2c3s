//using System;
//using System.Text;
//using System.Collections.Generic; // Включаем пространство имен, в котором определен класс LinkedList<T>.

//public class Example
//{
//    public static void Main()
//    {
//        // Создаем массив строк.
//        string[] wordsMass =
//            { "мохнатый", "лис", "прыгнул", "через", "мохнатый", "пень" };
//        // Создаем объект связанного списка и инициализируем его массивом строк.
//        LinkedList<string> Listsentence = new LinkedList<string>(wordsMass);

//        DisplayList(Listsentence, "Коллекция Listsentence:");
//        Console.WriteLine("Listsentence.Contains(\"прыгнул\") = {0}",
//            Listsentence.Contains("прыгнул"));

//        // Добавляем в коллекцию строку “Сегодня” на первую позицию.
//        Listsentence.AddFirst("Сегодня");
//        DisplayList(Listsentence, "Шаг 1: Добавляем строку 'сегодня' в начало списка:");

//        // Переместим начальный элемент списка в его конец.
//        LinkedListNode<string> tempList = Listsentence.First;
//        Listsentence.RemoveFirst();
//        Listsentence.AddLast(tempList);
//        DisplayList(Listsentence, "Шаг 2: перемешаем первый элемент в конец списка:");

//        // Изменяем последний элемент списка.
//        Listsentence.RemoveLast();
//        Listsentence.AddLast("вчера");
//        DisplayList(Listsentence, "Шаг 3: Изменяем последний элемент списка на строку ‘вчера’:");

//        // Перемещаем последний элемент в начало.
//        tempList = Listsentence.Last;
//        Listsentence.RemoveLast();
//        Listsentence.AddFirst(tempList);
//        DisplayList(Listsentence, "Шаг 4: перемещаем последний элемент в начало списка:");


//        // Ищем строку ‘мохнатый’.
//        Listsentence.RemoveFirst();
//        LinkedListNode<string> TempElement = Listsentence.FindLast("мохнатый");
//        IndicateNode(TempElement, "Шаг 5: ищем последнее вхождение в список строки 'мохнатый':");

//        // Добавляем строки 'кривой' и 'старый' после строки 'мохнатый'.
//        Listsentence.AddAfter(TempElement, "старый");
//        Listsentence.AddAfter(TempElement, "кривой");
//        IndicateNode(TempElement, "Шаг 6: Добавляем строки 'кривой' и 'старый' после строки 'мохнатый':");

//        // Ищем строку 'лис'.
//        TempElement = Listsentence.Find("лис");
//        IndicateNode(TempElement, "Шаг 7: ищем строку 'лис':");

//        // Добавляем строки 'быстрый' and 'бурый' перед строкой 'лис':
//        Listsentence.AddBefore(TempElement, "быстрый");
//        Listsentence.AddBefore(TempElement, "бурый");
//        IndicateNode(TempElement, "Шаг 8: добавляем строки 'быстрый' and 'бурый' перед строкой 'лис':");

//        // Сохраняем ссылку на предыдущий элемент, ‘лис’,
//        // и ищем строку ‘пес’.
//        tempList = TempElement;
//        LinkedListNode<string> TempList2 = tempList.Previous;
//        TempElement = Listsentence.Find("Пес");
//        IndicateNode(TempElement, "Шаг 9: ищем строку 'пес':");

//        Console.WriteLine("Шаг 10: пытаемся добавить элемент (лис), который уже есть в списке:");
//        try
//        {
//            // Метод вызовет исключение, поскольку такой элемент уже есть в списке. 
//            Listsentence.AddBefore(TempElement, tempList);
//        }
//        // Ловим исключение.
//        catch (InvalidOperationException ex)
//        {
//            Console.WriteLine("Сообщение исключения: {0}", ex.Message);
//        }
//        Console.WriteLine();


//        // Удаляем строку ‘старый’ из списка. Поиск строки начинается с начала списка.
//        Listsentence.Remove("старый");
//        DisplayList(Listsentence, "Шаг 11: удаляем строку 'старый' из списка:");

//        Console.WriteLine("Шаг 12: Копируем содержимое списка в массив:");

//        // создаем строковый массив и переносим туда все элементы из связанного списка.
//        string[] strArray = new string[Listsentence.Count];
//        Listsentence.CopyTo(strArray, 0);

//        foreach (string s in strArray)
//        {
//            Console.WriteLine(s);
//        }

//        // Очищаем все записи связанного списка.
//        Listsentence.Clear();
//    }
//    // Метод отображения содержания списка.
//    private static void DisplayList(LinkedList<string> words, string test)
//    {
//        Console.WriteLine(test);
//        foreach (string word in words)
//        {
//            Console.Write(word + " ");
//        }
//        Console.WriteLine();
//        Console.WriteLine();
//    }
//    // Метод сравнения строк. Используется для поиска строки внутри элемента.
//    private static void IndicateNode(LinkedListNode<string> node, string test)
//    {
//        Console.WriteLine(test);
//        if (node.List == null)
//        {
//            Console.WriteLine("строка '{0}' отсутствует в списке.\n",
//                node.Value);
//            return;
//        }

//        StringBuilder result = new StringBuilder("(" + node.Value + ")");
//        LinkedListNode<string> nodeP = node.Previous;

//        while (nodeP != null)
//        {
//            result.Insert(0, nodeP.Value + " ");
//            nodeP = nodeP.Previous;
//        }

//        node = node.Next;
//        while (node != null)
//        {
//            result.Append(" " + node.Value);
//            node = node.Next;
//        }

//        Console.WriteLine(result);
//        Console.WriteLine();
//    }
//}