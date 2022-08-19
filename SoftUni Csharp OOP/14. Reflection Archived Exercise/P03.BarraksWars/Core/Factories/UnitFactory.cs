namespace _03BarracksFactory.Core.Factories
{
    using System;
    using System.Linq;
    using System.Reflection;

    using Contracts;

    public class UnitFactory : IUnitFactory
    {
        public IUnit CreateUnit(string unitType)
        {
            Type type = Assembly.GetCallingAssembly().GetTypes().FirstOrDefault(x => x.Name == unitType);

            if (type == null)
            {
                throw new InvalidOperationException($"{unitType} is an invalid type of unit!");
            }

            IUnit unit = Activator.CreateInstance(type) as IUnit;

            return unit;
        }
    }
}
