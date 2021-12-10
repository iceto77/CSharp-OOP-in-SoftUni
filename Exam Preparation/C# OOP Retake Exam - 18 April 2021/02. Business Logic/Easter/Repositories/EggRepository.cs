using Easter.Models.Eggs.Contracts;
using Easter.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Easter.Repositories
{
    public class EggRepository : IRepository<IEgg>
    {
        private List<IEgg> eggs;

        public EggRepository()
        {
            this.eggs = new List<IEgg>();
        }

        public IReadOnlyCollection<IEgg> Models => this.eggs;

        public void Add(IEgg model)
        {
            this.eggs.Add(model);
        }
        public bool Remove(IEgg model)
        {
            if (model == null)
            {
                return false;
            }
            this.eggs.Remove(model);
            return true;
        }
        public IEgg FindByName(string name)
        {
            return eggs.FirstOrDefault(x => x.Name == name);
        }
    }
}
