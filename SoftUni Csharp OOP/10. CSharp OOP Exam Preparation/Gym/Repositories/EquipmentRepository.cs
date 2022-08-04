namespace Gym.Repositories
{
    using System.Linq;
    using System.Collections.Generic;

    using Contracts;
    using Models.Equipment.Contracts;

    public class EquipmentRepository : IRepository<IEquipment>
    {
        private readonly ICollection<IEquipment> _equipment;

        public EquipmentRepository()
        {
            this._equipment = new List<IEquipment>();
        }

        public IReadOnlyCollection<IEquipment> Models => this._equipment as IReadOnlyCollection<IEquipment>;

        public void Add(IEquipment model) => this._equipment.Add(model);

        public bool Remove(IEquipment model) => this._equipment.Remove(model);

        public IEquipment FindByType(string type) =>
            this._equipment.FirstOrDefault(equipment => equipment.GetType().Name == type);
    }
}
