using EasterRaces.Models.Races.Contracts;
using EasterRaces.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasterRaces.Repositories.Entities
{
    public class RaceRepository : IRepository<IRace>
    {
        public void Add(IRace model)
        {
            throw new NotImplementedException();
        }

        public IReadOnlyCollection<IRace> GetAll()
        {
            throw new NotImplementedException();
        }

        public IRace GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public bool Remove(IRace model)
        {
            throw new NotImplementedException();
        }
    }
}
