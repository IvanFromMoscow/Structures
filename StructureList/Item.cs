using System;
namespace StructureList
{
    /// <summary>
    /// элемент списка
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Item<T>
    {
        /// <summary>
        /// Данные элемента списка
        /// </summary>
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
        /// <summary>
        /// Ссылка на следующий элемент в списке
        /// </summary>
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
