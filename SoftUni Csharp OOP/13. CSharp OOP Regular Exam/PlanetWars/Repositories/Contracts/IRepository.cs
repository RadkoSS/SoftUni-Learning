namespace PlanetWars.Repositories.Contracts
{
    using System.Collections.Generic;

    public interface IRepository<T>
    {
        IReadOnlyCollection<T> Models { get; }

        void AddItem(T model);

        T FindByName(string name);

        bool RemoveItem(string name);
    }
}
