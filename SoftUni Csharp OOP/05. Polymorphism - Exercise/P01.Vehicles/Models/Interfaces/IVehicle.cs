namespace Vehicles.Models.Interfaces
{
    public interface IVehicle
    {
        string Drive(double distance);

        void Refuel(double litersOfFuel);
    }
}
