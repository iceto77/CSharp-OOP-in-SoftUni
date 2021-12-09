using NUnit.Framework;
using System;

namespace BankSafe.Tests
{
    public class BankVaultTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void MethodAddItemThrowExceptionIsCellNotExsist()
        {
            var bankVault = new BankVault();
            Item item = new Item("a", "b");
            Assert.Throws<ArgumentException>(() => bankVault.AddItem("baba", item));
        }

        [Test]
        public void MethodAddItemThrowExceptionIsCellTakenAlready()
        {
            var bankVault = new BankVault();
            Item item = new Item("a", "b");
            bankVault.AddItem("A1", item);
            Assert.Throws<ArgumentException>(() => bankVault.AddItem("A1", item));
        }

        [Test]
        public void MethodAddItemThrowExceptionIfItemAlreadyInCell()
        {
            var bankVault = new BankVault();
            Item item = new Item("a", "b");
            bankVault.AddItem("A1", item);
            Assert.Throws<InvalidOperationException>(() => bankVault.AddItem("B1", item));
        }

        [Test]
        public void MethodAddItemShouldWorkCorectly()
        {
            var bankVault = new BankVault();
            Item item = new Item("a", "b");            
            string target = $"Item:{item.ItemId} saved successfully!";
            string result = bankVault.AddItem("A1", item);
            Assert.AreEqual(target, result);
        }

        [Test]
        public void MethodRemoveItemThrowExceptionIsCellNotExsist()
        {
            var bankVault = new BankVault();
            Item item = new Item("a", "b");
            Assert.Throws<ArgumentException>(() => bankVault.RemoveItem("baba", item));
        }

        [Test]
        public void MethodRemoveItemThrowExceptionIsItemInCellNotExsist()
        {
            var bankVault = new BankVault();
            Item item = new Item("a", "b");
            Item item2 = new Item("x", "y");
            bankVault.AddItem("A1", item);
            Assert.Throws<ArgumentException>(() => bankVault.RemoveItem("A1", item2));
        }

        [Test]
        public void MethodRemoveItemShouldWorkCorectly()
        {
            var bankVault = new BankVault();
            Item item = new Item("a", "b");
            bankVault.AddItem("A1", item);
            string target = $"Remove item:{item.ItemId} successfully!";
            string result = bankVault.RemoveItem("A1", item);
            Assert.AreEqual(target, result);
        }

    }
}