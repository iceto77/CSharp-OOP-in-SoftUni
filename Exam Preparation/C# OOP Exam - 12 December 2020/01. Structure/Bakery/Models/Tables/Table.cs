using Bakery.Models.BakedFoods.Contracts;
using Bakery.Models.Drinks.Contracts;
using Bakery.Models.Tables.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bakery.Models.Tables
{
    public abstract class Table : ITable
    {
        private int tableNumber;
        private int capacity;
        private decimal pricePerPerson;
        private List<ITable> foodOrders;
        private List<IDrink> drinkOrders;
        private bool isReserved;
        private decimal price;
        public Table(int tableNumber, int capacity, decimal pricePerPerson)
        {
            this.TableNumber = tableNumber;
            this.Capacity = capacity;
            this.PricePerPerson = pricePerPerson;
            this.foodOrders = new List<ITable>();
            this.drinkOrders = new List<IDrink>();
        }

        public int TableNumber { get; private set; }

        public int Capacity { get; private set; }

        public int NumberOfPeople { get; private set; }


        public decimal PricePerPerson { get; private set; }

        public bool IsReserved { get; private set; }

        public decimal Price { get; private set; }
        public void Reserve(int numberOfPeople)
        {
            throw new NotImplementedException();
        }
        public void OrderFood(IBakedFood food)
        {
            throw new NotImplementedException();
        }
        public void OrderDrink(IDrink drink)
        {
            throw new NotImplementedException();
        }
        public decimal GetBill()
        {
            throw new NotImplementedException();
        }
        public void Clear()
        {
            throw new NotImplementedException();
        }
        public string GetFreeTableInfo()
        {
            throw new NotImplementedException();
        }






    }
}
