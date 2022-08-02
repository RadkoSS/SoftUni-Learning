namespace Formula1.Repositories
{
    using System.Collections.Generic;

    using Contracts;

    public abstract class Repository<T> : IRepository<T>
    {
        private readonly ICollection<T> _models;

        protected Repository() => this._models = new List<T>();

        public IReadOnlyCollection<T> Models => this._models as IReadOnlyCollection<T>;

        public void Add(T model) => this._models.Add(model);

        public bool Remove(T model) => this._models.Remove(model);

        public abstract T FindByName(string name);
    }
}
