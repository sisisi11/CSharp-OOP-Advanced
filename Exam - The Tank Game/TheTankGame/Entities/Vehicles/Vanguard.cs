namespace TheTankGame.Entities.Vehicles
{
    using TheTankGame.Entities.Miscellaneous;

    public class Vanguard : BaseVehicle
    {
        public Vanguard(string model, double weight, decimal price, int attack, int defense, int hitPoints)
            : base(model, weight, price, attack, defense, hitPoints, new VehicleAssembler())
        {
        }
    }
}
