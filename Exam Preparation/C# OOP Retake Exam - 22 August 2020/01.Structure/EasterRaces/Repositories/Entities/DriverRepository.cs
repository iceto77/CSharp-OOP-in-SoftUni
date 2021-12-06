using EasterRaces.Models.Drivers.Contracts;
using EasterRaces.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasterRaces.Repositories.Entities
{
    public class DriverRepository : IRepository<IDriver>
    {
        public void Add(IDriver model)
        {
            throw new NotImplementedException();
        }

        public IReadOnlyCollection<IDriver> GetAll()
        {
            throw new NotImplementedException();
        }

        public IDriver GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public bool Remove(IDriver model)
        {
            throw new NotImplementedException();
        }
    }
}
