namespace CollectionHierarchy.Models
{
    using Interfaces;

    using System.Collections.Generic;

    public class AddCollection<T> : IAddCollection<T>
    {
        private readonly IList<T> values;

        public AddCollection()
        {
            this.values = new List<T>();
        }

        public int Add(T element)
        {
            this.values.Add(element);

            return this.values.Count - 1;
        }
    }
}
