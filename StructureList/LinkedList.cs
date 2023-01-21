using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StructureList
{
    /// <summary>
    /// Класс односвязного списка
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class LinkedList<T> : IEnumerable
    {
        /// <summary>
        /// Первый элемент односвязного списка
        /// </summary>
        public Item<T> Head { get; private set; }
        /// <summary>
        /// Последний элемент односвязного списка
        /// </summary>
        public Item<T> Tail { get; private set; }
        /// <summary>
        /// Количество элементов в списке
        /// </summary>
        public int Count { get; private set; }
        public LinkedList()
        {
            Clear();
        }
        public LinkedList(T data)
        {
            setHeadAndTail(data);
        }
        /// <summary>
        /// Добавление элемента в список
        /// </summary>
        /// <param name="data">Данные для добавления в список</param>
        public void Add(T data)
        {
            if (Head == null)
            {
                setHeadAndTail(data);
                return;
            }
            var item = new Item<T>(data);
            Tail.Next = item;
            Tail = item;
            Count++;
        }
        /// <summary>
        /// Удаление первого вхождение элемента в список
        /// </summary>
        /// <param name="data">данные элемента которые нужно удалить</param>
        public void Delete(T data)
        {
            var item = new Item<T>(data);
            if (Head == null)
            {
                return;
            }
            if (Head.Data.Equals(data))
            {
                Head = Head.Next;
                Count--;
                return;
            }
            var current = Head.Next;
            var prev = Head;

            while (current != null)
            {
                if (current.Data.Equals(data))
                {
                    prev.Next = current.Next;
                    if (prev.Next == null)
                    {
                        Tail = prev;
                    }
                    Count--;
                    return;
                }
                prev = current;
                current = current.Next;
            }
        }
        /// <summary>
        /// Вставска после определенного элемента нового элемента в список
        /// </summary>
        /// <param name="target"></param>
        /// <param name="data"></param>
        public void insertAfter(T target, T data)
        {
            if (Head != null)
            {  
                var item = new Item<T>(data);
                var current = Head;
               
                while (current != null)
                {
                    if (current.Data.Equals(target))
                    {
                        item.Next = current.Next;
                        current.Next = item;
                        if (item.Next == null)
                        {
                            Tail = item;
                        }
                        Count++;
                        return;
                    }
                    current = current.Next;
                }
            } else
            {
                setHeadAndTail(data);
            }
        }
        /// <summary>
        /// Добавление элемента в начало списка
        /// </summary>
        /// <param name="data"></param>
        public void AppendHead(T data)
        {
            var item = new Item<T>(data)
            {
                Next = Head
            };
            Head = item;
            Count++;
        }
        /// <summary>
        /// Добавление элемента в конец списка
        /// </summary>
        /// <param name="data"></param>
        public void AppendLast(T data)
        {
            var item = new Item<T>(data);
            if (Head != null)
            {
                Tail.Next = item; 
                Tail = item;
                Count++;
            } else
            {
                setHeadAndTail(data);
            }
        }
        public void Clear()
        {
            Head = null;
            Tail = null;
            Count = 0;
        }

        /// <summary>
        /// Установка элемента, если он был пустой
        /// </summary>
        /// <param name="data"></param>
        private void setHeadAndTail(T data)
        {
            var item = new Item<T>(data);
            Tail = item;
            Head = item;
            Count = 1;
        }
        /// <summary>
        /// Получение перечислителя для возможности перебора элементов списка
        /// </summary>
        /// <returns></returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            var current = Head;

            while (current != null)
            {
                yield return current;
                current = current.Next;
            }

        }
        public override string ToString()
        {
            return "Односвязный список из " + Count + " эл.";
        }
    }
}
