namespace TheTankGame.Tests
{
    using System;
    using System.Linq;

    using NUnit.Framework;
    using TheTankGame.Entities.Miscellaneous;
    using TheTankGame.Entities.Parts;
    using TheTankGame.Entities.Vehicles;

    [TestFixture]
    public class BaseVehicleTests
    {
        [Test]
        public void ConstructorShouldSetAllProperties()
        {
            BaseVehicle vehicle = new TestVehicle("Tank", 100, 500, 50, 40, 300);

            Assert.AreEqual("Tank", vehicle.Model);
            Assert.AreEqual(100, vehicle.Weight);
            Assert.AreEqual(500, vehicle.Price);
            Assert.AreEqual(50, vehicle.Attack);
            Assert.AreEqual(40, vehicle.Defense);
            Assert.AreEqual(300, vehicle.HitPoints);
        }

        [TestCase(null)]
        [TestCase("")]
        [TestCase("   ")]
        public void ConstructorShouldThrowWhenModelIsInvalid(string model)
        {
            Assert.Throws<ArgumentException>(() => new TestVehicle(model, 100, 500, 50, 40, 300));
        }

        [TestCase(0)]
        [TestCase(-1)]
        public void ConstructorShouldThrowWhenWeightIsInvalid(double weight)
        {
            Assert.Throws<ArgumentException>(() => new TestVehicle("Tank", weight, 500, 50, 40, 300));
        }

        [TestCase(0)]
        [TestCase(-1)]
        public void ConstructorShouldThrowWhenPriceIsInvalid(double price)
        {
            Assert.Throws<ArgumentException>(() => new TestVehicle("Tank", 100, (decimal)price, 50, 40, 300));
        }

        [Test]
        public void ConstructorShouldThrowWhenAttackIsNegative()
        {
            Assert.Throws<ArgumentException>(() => new TestVehicle("Tank", 100, 500, -1, 40, 300));
        }

        [Test]
        public void ConstructorShouldThrowWhenDefenseIsNegative()
        {
            Assert.Throws<ArgumentException>(() => new TestVehicle("Tank", 100, 500, 50, -1, 300));
        }

        [Test]
        public void ConstructorShouldThrowWhenHitPointsAreNegative()
        {
            Assert.Throws<ArgumentException>(() => new TestVehicle("Tank", 100, 500, 50, 40, -1));
        }

        [Test]
        public void TotalStatsShouldEqualBaseStatsWithoutParts()
        {
            BaseVehicle vehicle = new TestVehicle("Tank", 100, 500, 50, 40, 300);

            Assert.AreEqual(100, vehicle.TotalWeight);
            Assert.AreEqual(500, vehicle.TotalPrice);
            Assert.AreEqual(50, vehicle.TotalAttack);
            Assert.AreEqual(40, vehicle.TotalDefense);
            Assert.AreEqual(300, vehicle.TotalHitPoints);
        }

        [Test]
        public void AddArsenalPartShouldIncreaseAttackWeightAndPrice()
        {
            BaseVehicle vehicle = new TestVehicle("Tank", 100, 500, 50, 40, 300);
            ArsenalPart part = new ArsenalPart("Cannon", 20, 100, 30);

            vehicle.AddArsenalPart(part);

            Assert.AreEqual(120, vehicle.TotalWeight);
            Assert.AreEqual(600, vehicle.TotalPrice);
            Assert.AreEqual(80, vehicle.TotalAttack);
            Assert.AreEqual(1, vehicle.Parts.Count());
        }

        [Test]
        public void AddShellPartShouldIncreaseDefenseWeightAndPrice()
        {
            BaseVehicle vehicle = new TestVehicle("Tank", 100, 500, 50, 40, 300);
            ShellPart part = new ShellPart("Shield", 25, 150, 35);

            vehicle.AddShellPart(part);

            Assert.AreEqual(125, vehicle.TotalWeight);
            Assert.AreEqual(650, vehicle.TotalPrice);
            Assert.AreEqual(75, vehicle.TotalDefense);
            Assert.AreEqual(1, vehicle.Parts.Count());
        }

        [Test]
        public void AddEndurancePartShouldIncreaseHitPointsWeightAndPrice()
        {
            BaseVehicle vehicle = new TestVehicle("Tank", 100, 500, 50, 40, 300);
            EndurancePart part = new EndurancePart("Armor", 30, 200, 100);

            vehicle.AddEndurancePart(part);

            Assert.AreEqual(130, vehicle.TotalWeight);
            Assert.AreEqual(700, vehicle.TotalPrice);
            Assert.AreEqual(400, vehicle.TotalHitPoints);
            Assert.AreEqual(1, vehicle.Parts.Count());
        }

        [Test]
        public void MultiplePartsShouldBeSummedCorrectly()
        {
            BaseVehicle vehicle = new TestVehicle("Tank", 100, 500, 50, 40, 300);

            vehicle.AddArsenalPart(new ArsenalPart("Cannon1", 20, 100, 30));
            vehicle.AddArsenalPart(new ArsenalPart("Cannon2", 15, 80, 20));
            vehicle.AddShellPart(new ShellPart("Shield", 25, 150, 35));
            vehicle.AddEndurancePart(new EndurancePart("Armor", 30, 200, 100));

            Assert.AreEqual(190, vehicle.TotalWeight);
            Assert.AreEqual(1030, vehicle.TotalPrice);
            Assert.AreEqual(100, vehicle.TotalAttack);
            Assert.AreEqual(75, vehicle.TotalDefense);
            Assert.AreEqual(400, vehicle.TotalHitPoints);
            Assert.AreEqual(4, vehicle.Parts.Count());
        }

        [Test]
        public void ToStringShouldPrintNoneWhenVehicleHasNoParts()
        {
            BaseVehicle vehicle = new TestVehicle("Tank", 100, 500, 50, 40, 300);

            string result = vehicle.ToString();

            StringAssert.Contains("TestVehicle - Tank", result);
            StringAssert.Contains("Total Weight: 100.000", result);
            StringAssert.Contains("Total Price: 500.000", result);
            StringAssert.Contains("Parts: None", result);
        }

        [Test]
        public void ToStringShouldKeepPartsInInputOrder()
        {
            BaseVehicle vehicle = new TestVehicle("Tank", 100, 500, 50, 40, 300);

            vehicle.AddShellPart(new ShellPart("Shield", 25, 150, 35));
            vehicle.AddArsenalPart(new ArsenalPart("Cannon", 20, 100, 30));
            vehicle.AddEndurancePart(new EndurancePart("Armor", 30, 200, 100));

            StringAssert.Contains("Parts: Shield, Cannon, Armor", vehicle.ToString());
        }

        private class TestVehicle : BaseVehicle
        {
            public TestVehicle(string model, double weight, decimal price, int attack, int defense, int hitPoints)
                : base(model, weight, price, attack, defense, hitPoints, new VehicleAssembler())
            {
            }
        }
    }
}
