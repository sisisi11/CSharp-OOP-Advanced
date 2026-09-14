namespace TheTankGame.Core
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using Contracts;
    using Entities.Parts.Contracts;
    using Entities.Parts.Factories;
    using Entities.Parts.Factories.Contracts;
    using Entities.Vehicles.Contracts;
    using Entities.Vehicles.Factories;
    using Entities.Vehicles.Factories.Contracts;
    using Utils;

    public class TankManager : IManager
    {
        private readonly IDictionary<string, IVehicle> vehicles;
        private readonly IDictionary<string, IPart> parts;
        private readonly IList<string> vehicleOrder;
        private readonly IList<string> defeatedVehicles;
        private readonly IBattleOperator battleOperator;
        private readonly IVehicleFactory vehicleFactory;
        private readonly IPartFactory partFactory;

        public TankManager(IBattleOperator battleOperator)
        {
            this.battleOperator = battleOperator;
            this.vehicleFactory = new VehicleFactory();
            this.partFactory = new PartFactory();

            this.vehicles = new Dictionary<string, IVehicle>();
            this.parts = new Dictionary<string, IPart>();
            this.vehicleOrder = new List<string>();
            this.defeatedVehicles = new List<string>();
        }

        public string AddVehicle(IList<string> arguments)
        {
            string vehicleType = arguments[0];
            string model = arguments[1];
            double weight = double.Parse(arguments[2]);
            decimal price = decimal.Parse(arguments[3]);
            int attack = int.Parse(arguments[4]);
            int defense = int.Parse(arguments[5]);
            int hitPoints = int.Parse(arguments[6]);

            IVehicle vehicle = this.vehicleFactory.CreateVehicle(
                vehicleType,
                model,
                weight,
                price,
                attack,
                defense,
                hitPoints);

            this.vehicles.Add(vehicle.Model, vehicle);
            this.vehicleOrder.Add(vehicle.Model);

            return string.Format(
                GlobalConstants.VehicleSuccessMessage,
                vehicleType,
                vehicle.Model);
        }

        public string AddPart(IList<string> arguments)
        {
            string vehicleModel = arguments[0];
            string partType = arguments[1];
            string model = arguments[2];
            double weight = double.Parse(arguments[3]);
            decimal price = decimal.Parse(arguments[4]);
            int additionalParameter = int.Parse(arguments[5]);

            IPart part = this.partFactory.CreatePart(
                partType,
                model,
                weight,
                price,
                additionalParameter);

            switch (partType)
            {
                case "Arsenal":
                    this.vehicles[vehicleModel].AddArsenalPart(part);
                    break;
                case "Shell":
                    this.vehicles[vehicleModel].AddShellPart(part);
                    break;
                case "Endurance":
                    this.vehicles[vehicleModel].AddEndurancePart(part);
                    break;
            }

            this.parts.Add(part.Model, part);

            return string.Format(
                GlobalConstants.PartSuccessMessage,
                partType,
                part.Model,
                vehicleModel);
        }

        public string Inspect(IList<string> arguments)
        {
            string model = arguments[0];

            return this.vehicles.ContainsKey(model)
                ? this.vehicles[model].ToString()
                : this.parts[model].ToString();
        }

        public string Battle(IList<string> arguments)
        {
            string attackerVehicleModel = arguments[0];
            string targetVehicleModel = arguments[1];

            string winnerVehicleModel = this.battleOperator.Battle(
                this.vehicles[attackerVehicleModel],
                this.vehicles[targetVehicleModel]);

            string defeatedVehicleModel = winnerVehicleModel == attackerVehicleModel
                ? targetVehicleModel
                : attackerVehicleModel;

            this.vehicles[defeatedVehicleModel]
                .Parts
                .ToList()
                .ForEach(p => this.parts.Remove(p.Model));

            this.vehicles.Remove(defeatedVehicleModel);
            this.defeatedVehicles.Add(defeatedVehicleModel);

            return string.Format(
                GlobalConstants.BattleSuccessMessage,
                attackerVehicleModel,
                targetVehicleModel,
                winnerVehicleModel);
        }

        public string Terminate(IList<string> arguments)
        {
            StringBuilder result = new StringBuilder();

            var remainingVehicles = this.vehicleOrder
                .Where(v => this.vehicles.ContainsKey(v))
                .ToList();

            var defeated = this.vehicleOrder
                .Where(v => this.defeatedVehicles.Contains(v))
                .ToList();

            result.Append("Remaining Vehicles: ");
            result.AppendLine(remainingVehicles.Count > 0
                ? string.Join(", ", remainingVehicles)
                : "None");

            result.Append("Defeated Vehicles: ");
            result.AppendLine(defeated.Count > 0
                ? string.Join(", ", defeated)
                : "None");

            result.Append("Currently Used Parts: ");
            result.Append(this.parts.Count);

            return result.ToString();
        }
    }
}
