using CarRacing.Core.Contracts;
using CarRacing.Models.Maps;
using CarRacing.Models.Maps.Contracts;
using CarRacing.Repositories;
using CarRacing.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using CarRacing.Models.Cars.Contracts;
using CarRacing.Models.Cars;
using CarRacing.Models.Racers.Contracts;
using CarRacing.Models.Racers;

namespace CarRacing.Core
{
    public class Controller : IController
    {
        private CarRepository cars;
        private RacerRepository racers;
        private IMap map;


        public Controller()
        {
            cars = new CarRepository();
            racers = new RacerRepository();
            map = new Map();
        }
        public string AddCar(string type, string make, string model, string VIN, int horsePower)
        {
            ICar car;
            if (type == "SuperCar")
            {
                car = new SuperCar(make, model, VIN, horsePower);
            }
            else if (type == "TunedCar")
            {
                car = new TunedCar(make, model, VIN, horsePower);
            }
            else
            {
                throw new ArgumentException(ExceptionMessages.InvalidCarType);
            }
            this.cars.Add(car);
            return $"Successfully added car {car.Make} {car.Model} ({car.VIN}).";
        }

        public string AddRacer(string type, string username, string carVIN)
        {
            IRacer racer;
            ICar car = this.cars.FindBy(carVIN);
            if (car == null)
            {
                throw new ArgumentException(ExceptionMessages.CarCannotBeFound);
            }

            if (type == "ProfessionalRacer")
            {
                racer = new ProfessionalRacer(username, car);
            }
            else if (type == "StreetRacer")
            {
                racer = new StreetRacer(username, car);
            }
            else
            {
                throw new ArgumentException(ExceptionMessages.InvalidRacerType);
            }
            this.racers.Add(racer);
            return $"Successfully added racer {racer.Username}.";
        }

        public string BeginRace(string racerOneUsername, string racerTwoUsername)
        {
            if (this.racers.FindBy(racerOneUsername) == null)
            {
                throw new ArgumentException($"Racer {racerOneUsername} cannot be found!");
            }
            IRacer racerOne = this.racers.FindBy(racerOneUsername);
            if (this.racers.FindBy(racerTwoUsername) == null)
            {
                throw new ArgumentException($"Racer {racerTwoUsername} cannot be found!");
            }
            IRacer racerTwo = this.racers.FindBy(racerTwoUsername);
            return this.map.StartRace(racerOne, racerTwo);
        }

        public string Report()
        {
            var racers = this.racers.Models.OrderByDescending(x => x.DrivingExperience)
                .ThenBy(x => x.Username);
            var sb = new StringBuilder();
            foreach (var item in racers)
            {
                sb.AppendLine(item.ToString());
            }
            return sb.ToString().TrimEnd();
        }
    }
}
