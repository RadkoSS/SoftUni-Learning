namespace CollectionHierarchy.Models.Interfaces
{
    public interface IRemovableCollection<T> : IAddCollection<T>
    {
        T Remove();
    }
}
