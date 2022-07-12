namespace CollectionHierarchy.Models.Interfaces
{
    public interface IMyList<T> : IRemovableCollection<T>
    {
        int Used { get; }
    }
}
