namespace Aquariums.Tests
{
    using NUnit.Framework;
    using System;
    using System.Linq;

    [TestFixture]
    public class AquariumsTests
    {
        [Test]
        public void ConstructorShouldSetName()
        {
            var aquarium = new Aquarium("Ivan", 100);
            Assert.AreEqual("Ivan", aquarium.Name);
        }

        [Test]
        public void ConstructorShouldSetCapacity()
        {
            var aquarium = new Aquarium("Ivan", 100);
            Assert.AreEqual(100, aquarium.Capacity);
        }

        [Test]
        public void PropertyNameShouldThrowExceptionIfIsNull()
        {
            Assert.Throws<ArgumentNullException>(() => new Aquarium(null, 55));
        }

        [Test]
        public void PropertyNameShouldThrowExceptionIfIsEmpty()
        {
            Assert.Throws<ArgumentNullException>(() => new Aquarium(string.Empty, 55));

        }

        [Test]
        public void PropertyCapacityShouldThrowExceptionIfLessThanZero()
        {
            Assert.Throws<ArgumentException>(() => new Aquarium("Ivan", -5));

        }

        [Test]
        public void FishConstructorShouldSetName()
        {
            var fish = new Fish("Nemo");
            Assert.AreEqual("Nemo", fish.Name);
        }

        [Test]
        public void MethodAddFishShouldAddCorectly()
        {
            var aquarium = new Aquarium("Ivan", 100);
            Assert.AreEqual(0, aquarium.Count);
            aquarium.Add(new Fish("GoldFish"));
            Assert.AreEqual(1, aquarium.Count);
        }

        [Test]
        public void MethodAddFishShouldThrowExceptionWhenAquariumIsFull()
        {
            var aquarium = new Aquarium("Ivan", 2);
            aquarium.Add(new Fish("GoldFish"));
            aquarium.Add(new Fish("BlackFish"));
            Assert.Throws<InvalidOperationException>(() => aquarium.Add(new Fish("Shark")));
        }

        [Test]
        public void MethodRemoveFishShouldRemoveCorectly()
        {
            var aquarium = new Aquarium("Ivan", 100);
            aquarium.Add(new Fish("GoldFish"));
            aquarium.Add(new Fish("BlackFish"));
            aquarium.Add(new Fish("shark"));
            Assert.AreEqual(3, aquarium.Count);
            aquarium.RemoveFish("shark");
            Assert.AreEqual(2, aquarium.Count);
        }

        [Test]
        public void MethodRemoveFishShouldThrowExceptionWhenFishIsNotExsist()
        {
            var aquarium = new Aquarium("Ivan", 2);
            Assert.Throws<InvalidOperationException>(() => aquarium.RemoveFish("shark"));
        }

        [Test]
        public void CountShouldGetValue()
        {
            var aquarium = new Aquarium("Ivan", 100);
            aquarium.Add(new Fish("GoldFish"));
            aquarium.Add(new Fish("BlueFish"));
            aquarium.Add(new Fish("BlackFish"));
            Assert.AreEqual(3, aquarium.Count);
        }
        [Test]
        public void CountShouldBeCountOfZeroByEmptyAquarium()
        {
            var aquarium = new Aquarium("Ivan", 100);
            Assert.AreEqual(0, aquarium.Count);
        }

        [Test]
        public void MethodSellFishShouldReturnCorectlyRequestedFish()
        {
            var aquarium = new Aquarium("Ivan", 100);
            aquarium.Add(new Fish("GoldFish"));
            Fish shark = new Fish("shark");
            aquarium.Add(shark);
            aquarium.Add(new Fish("BlackFish"));
            Assert.AreEqual(shark, aquarium.SellFish("shark"));
        }

        [Test]
        public void MethodReportShouldReturnValue()
        {
            var aquarium = new Aquarium("Ivan", 100);
            aquarium.Add(new Fish("GoldFish"));
            aquarium.Add(new Fish("shark"));
            aquarium.Add(new Fish("BlackFish"));
            string result = $"Fish available at {aquarium.Name}: GoldFish, shark, BlackFish";
            Assert.AreEqual(result, aquarium.Report());
        }
    }
}
