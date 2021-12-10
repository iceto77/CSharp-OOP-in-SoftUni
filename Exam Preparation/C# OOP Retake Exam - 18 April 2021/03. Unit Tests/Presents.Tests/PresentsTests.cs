namespace Presents.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class PresentsTests
    {

        [Test]
        public void ConstructorShouldCreateListOfPresentsCorectly()
        {
            var bag = new Bag();
            Present present = new Present("Ico", 44);
            bag.Create(present);
            Assert.AreEqual(present, bag.GetPresent("Ico"));
        }

        [Test]
        public void MethodCreateThrowExceptionWhenPresentIsNull()
        {
            var bag = new Bag();
            Assert.Throws<ArgumentNullException>(() => bag.Create(null));
        }

        [Test]
        public void MethodCreateThrowExceptionWhenPresentAlreadyExsistl()
        {
            var bag = new Bag();
            Present present = new Present("Ico", 44);
            bag.Create(present);
            Assert.Throws<InvalidOperationException>(() => bag.Create(present));
        }

        [Test]
        public void MethodCreateShouldWorkCorectly()
        {
            var bag = new Bag();
            Present present = new Present("Ico", 44);
            string target = $"Successfully added present {present.Name}.";
            string result = bag.Create(present);
            Assert.AreEqual(target, result);
        }

        [Test]
        public void MethodRemoveShouldWorkCorectly()
        {
            var bag = new Bag();
            Present present = new Present("Ico", 44);
            bag.Create(present);
            Assert.AreEqual(true, bag.Remove(present));
        }

        [Test]
        public void MethodGetPresentWithLeastMagicShouldWorkCorectly()
        {
            var bag = new Bag();
            Present present = new Present("Gosho", 30);
            bag.Create(present);
            Present present2 = new Present("Ico", 44);
            bag.Create(present2);
            Present present3 = new Present("Petio", 24);
            bag.Create(present3);
            Assert.AreEqual(present3, bag.GetPresentWithLeastMagic());
        }

        [Test]
        public void MethodGetPresentShouldWorkCorectly()
        {
            var bag = new Bag();
            Present present = new Present("Gosho", 30);
            bag.Create(present);
            Present present2 = new Present("Ico", 44);
            bag.Create(present2);
            Present present3 = new Present("Petio", 24);
            bag.Create(present3);
            Assert.AreEqual(present2, bag.GetPresent("Ico"));
        }
    }
}
