namespace _03BarracksFactory.Data
{
    using System;
    using Contracts;
    using System.Text;
    using System.Collections.Generic;

    class UnitRepository : IRepository
    {
        private IDictionary<string, int> amountOfUnits;

        public UnitRepository()
        {
            this.amountOfUnits = new SortedDictionary<string, int>();
        }

        public string Statistics
        {
            get
            {
                StringBuilder statBuilder = new StringBuilder();
                foreach (var entry in this.amountOfUnits)
                {
                    string formattedEntry = $"{entry.Key} -> {entry.Value}";

                    statBuilder.AppendLine(formattedEntry);
                }

                return statBuilder.ToString().TrimEnd();
            }
        }

        public void AddUnit(IUnit unit)
        {
            string unitType = unit.GetType().Name;
            if (!this.amountOfUnits.ContainsKey(unitType))
            {
                this.amountOfUnits.Add(unitType, 0);
            }

            this.amountOfUnits[unitType]++;
        }

        public void RemoveUnit(string unitType)
        {
            if (!this.amountOfUnits.ContainsKey(unitType) || this.amountOfUnits[unitType] == 0)
            {
                throw new ArgumentException("No such units in repository.");
            }

            this.amountOfUnits[unitType]--;
        }
    }
}
