namespace Formula1.Repositories
{
    using System;
    using System.Collections.Generic;
    
    using Contracts;
    using Models.Contracts;

    public class FormulaOneCarRepository : IRepository<IFormulaOneCar>
    {
        public IReadOnlyCollection<IFormulaOneCar> Models { get; private set; }

        public void Add(IFormulaOneCar model)
        {
            throw new NotImplementedException();
        }

        public bool Remove(IFormulaOneCar model)
        {
            throw new NotImplementedException();
        }

        public IFormulaOneCar FindByName(string name)
        {
            throw new NotImplementedException();
        }
    }
}
