namespace CollectionHierarchy.Models
{
    using Interfaces;

    using System.Collections.Generic;

    public class AddRemoveCollection<T> : IRemovableCollection<T>
    {
        private readonly IList<T> values;

        public AddRemoveCollection()
        {
            this.values = new List<T>();
        }

        public int Add(T element)
        {
            this.values.Insert(0, element);

            return 0;
        }

        public T Remove()
        {
            var lastItem = this.values[this.values.Count - 1];

            this.values.RemoveAt(this.values.Count - 1);

            return lastItem;
        }
    }
}
