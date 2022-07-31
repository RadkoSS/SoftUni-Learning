namespace Formula1.Repositories
{
    using System;
    using System.Collections.Generic;
    
    using Contracts;
    using Models.Contracts;

    public class RaceRepository : IRepository<IRace>
    {
        public IReadOnlyCollection<IRace> Models { get; private set; }

        public void Add(IRace model)
        {
            throw new NotImplementedException();
        }

        public bool Remove(IRace model)
        {
            throw new NotImplementedException();
        }

        public IRace FindByName(string name)
        {
            throw new NotImplementedException();
        }
    }
}
