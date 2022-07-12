namespace CollectionHierarchy.Core
{
    using Interfaces;

    using IO.Interfaces;

    using Models;
    using Models.Interfaces;

    public class Engine : IEngine
    {
        private readonly IReader reader;

        private readonly IWriter writer;

        private readonly IAddCollection<string> addCollection;

        private readonly IRemovableCollection<string> removableCollection;

        private readonly IMyList<string> myList;

        private Engine()
        {
            this.addCollection = new AddCollection<string>();
            this.removableCollection = new AddRemoveCollection<string>();
            this.myList = new MyList<string>();
        }

        public Engine(IReader reader, IWriter writer) : this()
        {
            this.reader = reader;
            this.writer = writer;
        }

        public void Start()
        {
            string[] texts = this.reader.ReadLine().Split();

            int totalRemoveOperations = int.Parse(this.reader.ReadLine());

            AddToCollection(this.addCollection, texts);

            AddToCollection(this.removableCollection, texts);

            AddToCollection(this.myList, texts);

            RemoveFromCollection(this.removableCollection, totalRemoveOperations);

            RemoveFromCollection(this.myList, totalRemoveOperations);
        }

        private void AddToCollection(IAddCollection<string> collection, string[] strings)
        {
            for (int i = 0; i < strings.Length; i++)
            {
                this.writer.Write($"{collection.Add(strings[i])} ");
            }

            this.writer.WriteLine();
        }

        private void RemoveFromCollection(IRemovableCollection<string> collection, int countOfOperations)
        {
            for (int i = 0; i < countOfOperations; i++)
            {
                this.writer.Write($"{collection.Remove()} ");
            }

            this.writer.WriteLine();
        }
    }
}
