namespace Formula1.Repositories
{
    using System;
    using System.Collections.Generic;
    
    using Contracts;
    using Models.Contracts;

    public class PilotRepository : IRepository<IPilot>
    {
        public IReadOnlyCollection<IPilot> Models { get; private set; }

        public void Add(IPilot model)
        {
            throw new NotImplementedException();
        }

        public bool Remove(IPilot model)
        {
            throw new NotImplementedException();
        }

        public IPilot FindByName(string name)
        {
            throw new NotImplementedException();
        }
    }
}
