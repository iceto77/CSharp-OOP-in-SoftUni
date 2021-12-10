using Easter.Models.Bunnies.Contracts;
using Easter.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Easter.Repositories
{
    public class BunnyRepository : IRepository<IBunny>
    {
        private List<IBunny> bunnies;
        public BunnyRepository()
        {
            this.bunnies = new List<IBunny>();
        }

        public IReadOnlyCollection<IBunny> Models => this.bunnies;

        public void Add(IBunny model)
        {
            this.bunnies.Add(model);
        }
        public bool Remove(IBunny model)
        {
            if (model == null)
            {
                return false;
            }
            this.bunnies.Remove(model);
            return true;
        }

        public IBunny FindByName(string name)
        {
            return bunnies.FirstOrDefault(x => x.Name == name);
        }


    }
}
