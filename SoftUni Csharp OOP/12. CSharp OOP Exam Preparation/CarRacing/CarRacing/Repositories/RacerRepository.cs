namespace CarRacing.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Contracts;
    using Models.Racers.Contracts;

    public class RacerRepository : IRepository<IRacer>
    {
        public IReadOnlyCollection<IRacer> Models => throw new NotImplementedException();

        public void Add(IRacer model)
        {
            throw new NotImplementedException();
        }

        public bool Remove(IRacer model)
        {
            throw new NotImplementedException();
        }

        public IRacer FindBy(string property)
        {
            throw new NotImplementedException();
        }
    }
}
