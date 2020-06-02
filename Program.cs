using MyMap.Model;
using System;

namespace MyMap
{
    class Program
    {
        static void Main(string[] args)
        {

            var myMap = new MyDic<int, string>();
            myMap.Add(new Item<int, string>(1, "One"));
            myMap.Add(new Item<int, string>(2, "Two"));
            myMap.Add(new Item<int, string>(3, "Three"));
            myMap.Add(new Item<int, string>(4, "Four"));
            myMap.Add(new Item<int, string>(5, "Five"));
            foreach (var item in myMap)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
            Console.WriteLine(myMap.Search(6) ?? "Not found");
            myMap.Remove(4);
            myMap.Remove(2);
            foreach (var item in myMap)
            {
                Console.Write(item+" ");
            }
            Console.WriteLine();

            var easyMap = new EasyMap<int, string>();
            easyMap.Add(new Item<int, string>(1, "One"));
            easyMap.Add(new Item<int, string>(2, "Two"));
            easyMap.Add(new Item<int, string>(3, "Three"));
            foreach (var item in easyMap)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
            Console.WriteLine(easyMap.Search(5) ?? "Not found");
            Console.WriteLine(easyMap.Search(2) ?? "Not found");
            Console.ReadLine();
        }
    }
}
