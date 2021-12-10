using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceStation.Repositories
{
    public class AstronautRepository : IRepository<IAstronaut>
    {
        private List<IAstronaut> models;
        public AstronautRepository()
        {
            models = new List<IAstronaut>();
        }

        public IReadOnlyCollection<IAstronaut> Models => this.models;

        public void Add(IAstronaut model)
        {
            throw new NotImplementedException();
        }

        public IAstronaut FindByName(string name)
        {
            throw new NotImplementedException();
        }

        public bool Remove(IAstronaut model)
        {
            throw new NotImplementedException();
        }
    }
}
