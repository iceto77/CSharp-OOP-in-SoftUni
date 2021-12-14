using NUnit.Framework;
using System;

namespace Gyms.Tests
{
    [TestFixture]
    public class GymsTests
    {
        [Test]
        public void NameThrowExceptionWhenNameIsNull()
        {
            var gym = new Gym("Ico", 5);
            Assert.Throws<ArgumentNullException>(() => new Gym(null, 5));
        }
        [Test]
        public void NameThrowExceptionWhenNameIsEmpty()
        {
            var gym = new Gym("Ico", 5);
            Assert.Throws<ArgumentNullException>(() => new Gym("", 5));
        }

        [Test]
        public void NameShouldWorkCorectly()
        {
            var gym = new Gym("Ico", 5);
            string target = "Ico";
            string result = gym.Name;
            Assert.AreEqual(target, result);
        }

        [Test]
        public void CapacityThrowExceptionWhenValuesNegativ()
        {
            var gym = new Gym("Ico", 5);
            Assert.Throws<ArgumentException>(() => new Gym("Ico", -5));
        }

        [Test]
        public void CapacityShouldWorkCorectly()
        {
            var gym = new Gym("Ico", 5);
            int target = 5;
            int result = gym.Capacity;
            Assert.AreEqual(target, result);
        }

        [Test]
        public void MethodAddAthleteThrowExceptionWhenIsFull()
        {
            var gym = new Gym("test", 2);
            gym.AddAthlete(new Athlete("Ico"));
            gym.AddAthlete(new Athlete("Gosho"));
            Assert.Throws<InvalidOperationException>(() => gym.AddAthlete(new Athlete("Pesho")));
        }

        [Test]
        public void MethodAddAthletedWorkCorectly()
        {
            var gym = new Gym("test", 2);
            int result = gym.Count;
            Assert.AreEqual(0, result);
            gym.AddAthlete(new Athlete("Ico"));
            int target = 1;
            result = gym.Count;
            Assert.AreEqual(target, result);
        }

        [Test]
        public void CountWorkCorectly()
        {
            var gym = new Gym("test", 2);
            gym.AddAthlete(new Athlete("Ico"));
            int target = 1;
            int result = gym.Count;
            Assert.AreEqual(target, result);
        }

        [Test]
        public void MethodRemoveAthleteThrowExceptionWhenIsNull()
        {
            var gym = new Gym("test", 2);
            Assert.Throws<InvalidOperationException>(() => gym.RemoveAthlete("Pesho"));
        }

        [Test]
        public void MethodRemoveAthleteWorkCorectly()
        {
            var gym = new Gym("test", 5);
            gym.AddAthlete(new Athlete("Ico"));
            gym.AddAthlete(new Athlete("Gosho"));
            gym.AddAthlete(new Athlete("Pesho"));
            gym.RemoveAthlete("Pesho");
            int target = 2;
            int result = gym.Count;
            Assert.AreEqual(target, result);
        }

        [Test]
        [TestCase("Pesho")]
        [TestCase(null)]
        public void MethodInjureAthleteThrowExceptionWhenIsNullOrWrongName(string target)
        {
            var gym = new Gym("test", 5);
            gym.AddAthlete(new Athlete("Ico"));
            gym.AddAthlete(new Athlete("Gosho"));
            Assert.Throws<InvalidOperationException>(() => gym.InjureAthlete(null));
        }

        [Test]
        public void MethodInjureAthleteWorkCorectly()
        {
            var gym = new Gym("test", 5);
            var athlete = new Athlete("Ico");
            gym.AddAthlete(athlete);
            gym.AddAthlete(new Athlete("Gosho"));
            gym.AddAthlete(new Athlete("Pesho"));
            var target = athlete.FullName;
            var result = gym.InjureAthlete("Ico").FullName;
            Assert.AreEqual(target, result);
        }

        [Test]
        public void MethodReportWorkCorectly()
        {
            var gym = new Gym("test", 5);  
            gym.AddAthlete(new Athlete("Ico"));
            gym.AddAthlete(new Athlete("Gosho"));
            gym.AddAthlete(new Athlete("Pesho"));
            gym.InjureAthlete("Gosho");
            var target = "Active athletes at test: Ico, Pesho";
            var result = gym.Report();
            Assert.AreEqual(target, result);
        }
    }
}
