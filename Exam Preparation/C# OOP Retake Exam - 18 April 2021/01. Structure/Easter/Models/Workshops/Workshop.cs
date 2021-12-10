using Easter.Models.Bunnies.Contracts;
using Easter.Models.Eggs.Contracts;
using Easter.Models.Workshops.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Easter.Models.Workshops
{
    public class Workshop : IWorkshop
    {
        public Workshop()
        {
        }

        public void Color(IEgg egg, IBunny bunny)
        {
            var currentDye = bunny.Dyes.First();

            while (bunny.Energy > 0 && bunny.Dyes.Count > 0)
            {
                bunny.Work();
                egg.GetColored();
                currentDye.Use();
                if (egg.IsDone())
                {
                    break;
                }
                if (currentDye.IsFinished())
                {
                    int num = bunny.Dyes.Count - 1;
                    bunny.Dyes.Remove(bunny.Dyes.First());
                    if (bunny.Dyes.Count > 0)
                    {
                        currentDye = bunny.Dyes.First();
                    }
                }
            }
        }
    }
}
