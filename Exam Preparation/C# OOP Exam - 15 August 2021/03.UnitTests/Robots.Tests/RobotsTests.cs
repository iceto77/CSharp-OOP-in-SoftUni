namespace Robots.Tests
{
    using NUnit.Framework;
    using System;
    using System.Linq;


    [TestFixture]
    public class RobotsTests
    {
        [Test]
        public void ConstructorShouldSetCapacity()
        {
            var robotManager = new RobotManager(5);
            Assert.AreEqual(5, robotManager.Capacity);
        }

        [Test]
        public void ConstructorShouldThrowException()
        {
            Assert.Throws<ArgumentException>(() => new RobotManager(-5));
        }

        [Test]
        public void CountShouldGetValue()
        {
            var robots = new RobotManager(5);
            robots.Add(new Robot("RoboCop", 13));
            robots.Add(new Robot("Rambo", 11));
            robots.Add(new Robot("Spiderman", 6));
            Assert.AreEqual(3, robots.Count);

        }
        [Test]
        public void CountShouldBeCountOfZeroByEmptyRobotManager()
        {
            var robots = new RobotManager(5);
            Assert.AreEqual(0, robots.Count);
        }
        [Test]
        public void AddMethodShouldWorkProperly()
        {
            var robots = new RobotManager(5);
            robots.Add(new Robot("RoboCop", 13));
            Assert.AreEqual(1, robots.Count);
        }
        [Test]
        public void AddMethodThrowExceptionIfRobotIsExist()
        {
            var robots = new RobotManager(5);
            robots.Add(new Robot("RoboCop", 13));
            Assert.Throws<InvalidOperationException>(() => robots.Add(new Robot("RoboCop", 13)));
        }
        [Test]
        public void AddMethodThrowExceptionIsFullCapacyti()
        {
            var robots = new RobotManager(1);
            robots.Add(new Robot("RoboCop", 13));
            Assert.Throws<InvalidOperationException>(() => robots.Add(new Robot("RoboCop", 13)));
        }
        [Test]
        public void RemoveMethodShouldWorkProperly()
        {
            var robots = new RobotManager(5);
            robots.Add(new Robot("RoboCop", 13));
            robots.Add(new Robot("Rambo", 11));
            robots.Add(new Robot("Spiderman", 6));
            robots.Remove("RoboCop");
            Assert.AreEqual(2, robots.Count);
            robots.Remove("Spiderman");
            Assert.AreEqual(1, robots.Count);
        }
        [Test]
        public void RemoveMethodThrowExceptionWhileRobotIsNotExsist()
        {
            var robots = new RobotManager(5);
            robots.Add(new Robot("RoboCop", 13));
            Assert.Throws<InvalidOperationException>(() => robots.Remove("Spiderman"));
        }
        [Test]
        public void WorkMethodShouldWorkProperly()
        {
            var robots = new RobotManager(5);
            var robot = new Robot("RoboCop", 100);
            robots.Add(robot);
            robots.Work("RoboCop", "jump", 20);            
            Assert.AreEqual(80, robot.Battery);
        }
        [Test]
        public void WorkMethodThrowExceptionWhileRobotsNameIsNotExsist()
        {
            var robots = new RobotManager(5);
            robots.Add(new Robot("RoboCop", 13));
            Assert.Throws<InvalidOperationException>(() => robots.Work("Spiderman", "up", 30));
        }
        [Test]
        public void WorkMethodThrowExceptionWhileRobotsBateryIsNotEnoght()
        {
            var robots = new RobotManager(5);
            robots.Add(new Robot("RoboCop", 13));
            Assert.Throws<InvalidOperationException>(() => robots.Work("RoboCop", "up", 30));
        }
        [Test]
        public void ChargeMethodShouldWorkProperly()
        {
            var robots = new RobotManager(5);
            var robot = new Robot("RoboCop", 100);
            robots.Add(robot);
            robots.Work("RoboCop", "up", 30);
            robots.Charge("RoboCop");
            Assert.AreEqual(robot.MaximumBattery, robot.Battery);
        }
        [Test]
        public void ChargeMethodThrowExceptionWhileRobotsNameIsNotExsist()
        {
            var robots = new RobotManager(5);
            robots.Add(new Robot("RoboCop", 13));
            Assert.Throws<InvalidOperationException>(() => robots.Charge("Spiderman"));
        }
    }
}
