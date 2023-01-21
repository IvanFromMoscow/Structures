using System;

namespace StructureList
{
    internal class Program
    {
        static void Main(string[] args)
        {
            LinkedList<int> list = new LinkedList<int>();
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(4);
            list.Add(5);
            foreach(var item in list)
            {
                Console.Write(item + " ");
            }
            list.Delete(1);
            list.Delete(3);
            list.Delete(5);
            Console.WriteLine();
            foreach (var item in list)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();

            list.insertAfter(2, 10);
            foreach (var item in list)
            {
                Console.Write(item + " ");
            }
            //list.Clear();
            //list.insertAfter(2, 10);
            //list.insertAfter(4, 10);
            list.AppendLast(25);
            Console.WriteLine();
            foreach (var item in list)
            {
                Console.Write(item + " ");
            }
            list.Clear();
            list.AppendLast(25);
            
            list.Add(5);
            Console.WriteLine();
            foreach (var item in list)
            {
                Console.Write(item + " ");
            }
            Console.ReadLine();
        }
    }
}
