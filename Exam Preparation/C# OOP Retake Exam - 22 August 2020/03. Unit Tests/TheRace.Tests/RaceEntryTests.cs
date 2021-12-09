using NUnit.Framework;
using System;
using TheRace;

namespace TheRace.Tests
{
    public class RaceEntryTests
    {

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void MethodAddDriverThrowExceptionIfDriverIsNull()
        {
            var race = new RaceEntry();
            Assert.Throws<InvalidOperationException>(() => race.AddDriver(null));
        }
        [Test]
        public void MethodAddDriverThrowExceptionIfDriverIsExsist()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                var race = new RaceEntry();
                UnitDriver driver = new UnitDriver("Ivan", new UnitCar("BMW", 125, 2500));
                race.AddDriver(driver);
                race.AddDriver(driver);
            });
        }

        [Test]
        public void MethodAddDriverShouldWorkCorectly()
        {
            var race = new RaceEntry();
            UnitCar car = new UnitCar("BMW", 125, 2500);
            UnitDriver driver = new UnitDriver("Ivan", car);
            var result = race.AddDriver(driver);
            string target = $"Driver Ivan added in race.";
            Assert.AreEqual(target, result);
        }

        [Test]
        public void MethodCalculateAverageHorsePowerThrowExceptionIfDriversCountIsLessMinParticipants()
        {
            var race = new RaceEntry();
            Assert.Throws<InvalidOperationException>(() => race.CalculateAverageHorsePower());
        }

        [Test]
        public void MethodCalculateAverageHorsePowerShouldWorkCorectly()
        {
            var race = new RaceEntry();
            UnitCar car = new UnitCar("BMW", 125, 2500);
            race.AddDriver(new UnitDriver("Ivan", car));
            race.AddDriver(new UnitDriver("Kalin", car));
            double result = race.CalculateAverageHorsePower();
            Assert.AreEqual(125, result);
        }

        [Test]
        public void CounterShouldWorkCorectly()
        {
            var race = new RaceEntry();
            UnitCar car = new UnitCar("BMW", 125, 2500);
            race.AddDriver(new UnitDriver("Ivan", car));
            race.AddDriver(new UnitDriver("Kalin", car));
            Assert.AreEqual(2, race.Counter);
        }


    }

}