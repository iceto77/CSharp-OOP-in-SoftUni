using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasterRaces.Repositories.Entities
{
    public class CarRepository : IRepository<ICar>
    {
        public void Add(ICar model)
        {
            throw new NotImplementedException();
        }

        public IReadOnlyCollection<ICar> GetAll()
        {
            throw new NotImplementedException();
        }

        public ICar GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public bool Remove(ICar model)
        {
            throw new NotImplementedException();
        }
    }
}
