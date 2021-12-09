using AquaShop.Models.Decorations.Contracts;
using AquaShop.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AquaShop.Repositories
{
    public class DecorationRepository : IRepository<IDecoration>
    {
        private List<IDecoration> models;
        public DecorationRepository()
        {
            this.models = new List<IDecoration>();
        }

        public IReadOnlyCollection<IDecoration> Models => this.models;

        public void Add(IDecoration model)
        {
            this.models.Add(model);
        }
        public bool Remove(IDecoration model)
        {
            return this.models.Remove(model);
        }

        public IDecoration FindByType(string type)
        {
            return this.models.FirstOrDefault(x => x.GetType().Name == type);
        }


    }
}
