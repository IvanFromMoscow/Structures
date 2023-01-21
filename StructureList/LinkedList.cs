using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StructureList
{
    public class LinkedList<T> : IEnumerable
    {
        public Item<T> Head { get; private set; }
        public Item<T> Tail { get; private set; }
        public int Count { get; private set; }
        public LinkedList()
        {
            Clear();
        }
        public LinkedList(T data)
        {
            setHeadTailAndCount(data);
        }
        public void Add(T data)
        {
            if (Head == null)
            {
                setHeadTailAndCount(data);
                return;
            }
            var item = new Item<T>(data);
            Tail.Next = item;
            Tail = item;
            Count++;
        }

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
                setHeadTailAndCount(data);
            }
        }
        public void AppendHead(T data)
        {
            var item = new Item<T>(data)
            {
                Next = Head
            };
            Head = item;
            Count++;
        }
        public void Clear()
        {
            Head = null;
            Tail = null;
            Count = 0;
        }

        private void setHeadTailAndCount(T data)
        {
            var item = new Item<T>(data);
            Tail = item;
            Head = item;
            Count = 1;
        }
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
