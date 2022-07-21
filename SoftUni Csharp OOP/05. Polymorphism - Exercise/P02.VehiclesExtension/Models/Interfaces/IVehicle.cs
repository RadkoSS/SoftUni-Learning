namespace VehiclesExtension.Models.Interfaces
{
    public interface IVehicle
    {
        string Drive(double distance);

        bool Refuel(double litersOfFuel);
    }
}
