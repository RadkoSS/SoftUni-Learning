namespace CollectionHierarchy.Models
{
    using Interfaces;

    using System.Collections.Generic;

    public class MyList<T> : IMyList<T>
    {
        private readonly IList<T> values;

        public MyList()
        {
            this.values = new List<T>();
        }

        public int Used => this.values.Count;

        public int Add(T element)
        {
            this.values.Insert(0, element);

            return 0;
        }

        public T Remove()
        {
            var firstItem = this.values[0];

            this.values.RemoveAt(0);

            return firstItem;
        }
    }
}
