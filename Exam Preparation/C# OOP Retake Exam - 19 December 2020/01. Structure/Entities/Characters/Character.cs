using System;

using WarCroft.Constants;
using WarCroft.Entities.Inventory;
using WarCroft.Entities.Items;

namespace WarCroft.Entities.Characters.Contracts
{
    public abstract class Character
    {
        // TODO: Implement the rest of the class.
        private string name;
        private double baseHealth;
        private double health;
        private double baseArmor;
        private double armor;
        private double abilityPoints;
        private Bag bag;

        public Character(string name, double health, double armor, double abilityPoints, Bag bag)
        {
            this.Name = name;
            this.Health = health;
            this.Armor = armor;
            this.AbilityPoints = abilityPoints;
            this.Bag = bag;
        }
        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.CharacterNameInvalid);
                }
                this.name = value;
            }
        }
        public double BaseHealth { get; set; }
        public double Health
        {
            get => this.health;
            set
            {
                if (value < 0)
                {
                    value = 0;
                }
                if (value > this.BaseHealth)
                {
                    value = this.BaseHealth;
                }
                this.health = value;
            }
        }
        public double BaseArmor { get; set; }
        public double Armor
        {
            get => this.armor;
            set
            {
                if (value < 0)
                {
                    value = 0;
                }
                if (value > this.BaseArmor)
                {
                    value = this.BaseArmor;
                }
                this.armor = value;
            }
        }
        public double AbilityPoints { get; set; }
        public Bag Bag { get; set; }
        public bool IsAlive { get; set; } = true;
        public void TakeDamage(double hitPoints)
        {
            this.EnsureAlive();
            if (this.Armor - hitPoints <= 0)
            {
                hitPoints -= this.Armor;
                this.Armor = 0;
            }
            else
            {
                this.Armor -= hitPoints;
                hitPoints = 0;
            }
            if (this.Health - hitPoints > 0)
            {
                this.Health -= hitPoints;
            }
            else
            {
                this.IsAlive = false;
            }
        }
        public void UseItem(Item item)
        {
            this.EnsureAlive();
            item.AffectCharacter(this);
        }
        protected void EnsureAlive()
        {
            if (!this.IsAlive)
            {
                throw new InvalidOperationException(ExceptionMessages.AffectedCharacterDead);
            }
        }
    }
}