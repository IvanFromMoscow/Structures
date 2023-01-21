using System;
namespace StructureList
{
    public class Item<T>
    {
        private T data;
        public T Data
        {
            get => data;
            set
            {
                if (data == null)
                    data = value;
                else
                    throw new ArgumentNullException(nameof(data));

            }
        }
        public Item<T> Next { get; set; }

        public Item() 
        {
            data = default(T);
            Next = null;
        }
        public Item(T data)
        {
            this.data = data;
            Next = null;
        }
        public override string ToString()
        {
            return data.ToString();
        }
    }
}
