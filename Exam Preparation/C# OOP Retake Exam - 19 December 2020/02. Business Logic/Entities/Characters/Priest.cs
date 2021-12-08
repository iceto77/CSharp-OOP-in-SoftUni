using System;
using System.Collections.Generic;
using System.Text;
using WarCroft.Constants;
using WarCroft.Entities.Characters.Contracts;
using WarCroft.Entities.Inventory;

namespace WarCroft.Entities.Characters
{
    public class Priest : Character, IHealer
    {
        public Priest(string name) 
            : base(name, 50, 25, 40, new Backpack())
        {
        }
        public void Heal(Character character)
        {
            if (character.IsAlive == false)
            {
                throw new InvalidOperationException(ExceptionMessages.AffectedCharacterDead);
            }
            this.EnsureAlive();
            character.Health += this.AbilityPoints;
        }
    }
}
