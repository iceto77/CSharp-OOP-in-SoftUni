using System;
using System.Collections.Generic;
using System.Text;

namespace FootballTeamGenerator
{
    public class Player
    {
        private string name;
        private int endurance;
        private int sprint;
        private int dribble;
        private int passing;
        private int shooting;

        public Player(string name, int endurance, int sprint, int dribble, int passing, int shooting)
        {
            this.Name = name;
            this.Endurance = endurance;
            this.Sprint = sprint;
            this.Dribble = dribble;
            this.Passing = passing;
            this.Shooting = shooting;
        }

        public string Name
        {
            get => this.name;

            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("A name should not be empty.");
                }
                name = value;
            }
        }
        public int Endurance
        {
            get => this.endurance;

            private set
            {
                ValueValidation(nameof(Endurance), value);
                endurance = value;
            }
        }
        public int Sprint
        {
            get => this.sprint;

            private set
            {
                ValueValidation(nameof(Sprint), value);
                sprint = value;
            }
        }
        public int Dribble
        {
            get => this.dribble;

            private set
            {
                ValueValidation(nameof(Dribble), value);
                dribble = value;
            }
        }
        public int Passing
        {
            get => this.passing;

            private set
            {
                ValueValidation(nameof(Passing), value);
                passing = value;
            }
        }
        public int Shooting
        {
            get => this.shooting;

            private set
            {
                ValueValidation(nameof(Shooting), value);
                shooting = value;
            }
        }
        public double OverallSkillLevel => (this.Endurance + this.Sprint + this.Passing + this.Shooting + this.Dribble) / 5.0;     
        private void ValueValidation(string propName, int value)
        {
            if (value < 0 || value > 100)
            {
                throw new ArgumentException($"{propName} should be between 0 and 100.");
            }
        }
    }
}
