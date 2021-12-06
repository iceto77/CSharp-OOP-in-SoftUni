using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Models.Drivers.Contracts;
using EasterRaces.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasterRaces.Models.Drivers.Entities
{
    public class Driver : IDriver
    {
        private string name;
        private ICar car;
        private int numberOfWins;
        private bool isCanParticipate;
        public Driver(string name)
        {
            this.Name = name;
            isCanParticipate = false;
            
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < 5)
                {
                    throw new ArgumentException($"Name {value} cannot be less than 5 symbols.");
                }
                this.name = value;
            }
        }

        public ICar Car => this.car;

        public int NumberOfWins => this.numberOfWins;

        public bool CanParticipate
        {
            get => this.isCanParticipate;
            private set
            {
                if (this.car == null)
                {
                    this.isCanParticipate = false;
                }
                else
                {
                    this.isCanParticipate = true;
                }
            }
        }

        public void AddCar(ICar car)
        {
            if (car == null)
            {
                throw new ArgumentNullException(ExceptionMessages.CarInvalid);
            }
            this.car = car;
            this.isCanParticipate = true;
        }

        public void WinRace()
        {
            this.numberOfWins++;
        }
    }
}
