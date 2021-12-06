using EasterRaces.Core.Contracts;
using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Models.Cars.Entities;
using EasterRaces.Models.Drivers.Contracts;
using EasterRaces.Models.Drivers.Entities;
using EasterRaces.Models.Races.Contracts;
using EasterRaces.Models.Races.Entities;
using EasterRaces.Repositories.Contracts;
using EasterRaces.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace EasterRaces.Core.Entities
{
    public class ChampionshipController : IChampionshipController
    {
        private readonly IRepository<IDriver> driverRepository;
        private readonly IRepository<ICar> carRepository;
        private readonly IRepository<IRace> raceRepository;
        public ChampionshipController()
        {
            this.driverRepository = new DriverRepository();
            this.carRepository = new CarRepository();
            this.raceRepository = new RaceRepository();
        }
        public string CreateDriver(string driverName)
        {
            var driverExist = this.driverRepository.GetByName(driverName);
            if (driverExist != null)
            {
                throw new ArgumentException($"Driver {driverName} is already created.");
            }
            this.driverRepository.Add(new Driver(driverName));
            return $"Driver {driverName} is created.";
        }
        public string CreateCar(string type, string model, int horsePower)
        {
            if (this.carRepository.GetByName(model) != null)
            {
                throw new ArgumentException($"Car {model} is already created.");
            }
            ICar newCar = null;
            if (type == "Muscle")
            {
                newCar = new MuscleCar(model, horsePower);
            }
            else if (type == "Sports")
            {
                newCar = new SportsCar(model, horsePower);
            }
            this.carRepository.Add(newCar);
            return $"{newCar.GetType().Name} {model} is created.";
        }
        public string AddCarToDriver(string driverName, string carModel)
        {
            var currentCar = carRepository.GetByName(carModel);
            var currentDriver = driverRepository.GetByName(driverName);
            if (currentDriver == null)
            {
                throw new InvalidOperationException($"Driver {driverName} could not be found.");
            }
            if (currentCar == null)
            {
                throw new InvalidOperationException($"Car {carModel} could not be found.");
            }
            currentDriver.AddCar(currentCar);
            return $"Driver {driverName} received car {carModel}.";
        }

        public string AddDriverToRace(string raceName, string driverName)
        {
            var currentDriver = driverRepository.GetByName(driverName);
            var currentRace = raceRepository.GetByName(raceName);
            if (currentRace == null)
            {
                throw new InvalidOperationException($"Race {raceName} could not be found.");
            }
            if (currentDriver == null)
            {
                throw new InvalidOperationException($"Driver {driverName} could not be found.");
            }
            currentRace.AddDriver(currentDriver);
            return $"Driver {driverName} added in {raceName} race.";
        }
        public string CreateRace(string name, int laps)
        {
            if (this.raceRepository.GetByName(name) != null)
            {
                throw new InvalidOperationException($"Race {name} is already create.");
            }
            Race newRace = new Race(name, laps);
            this.raceRepository.Add(newRace);
            return $"Race {name} is created.";
        }

        public string StartRace(string raceName)
        {
            var curentRases = this.raceRepository.GetByName(raceName);
            if (curentRases == null)
            {
                throw new InvalidOperationException($"Race {raceName} could not be found.");
            }
            if (curentRases.Drivers.Count < 3)
            {
                throw new InvalidOperationException($"Race {raceName} cannot start with less than 3 participants.");
            }
            var driversInRase  = curentRases.Drivers.OrderByDescending(x => x.Car.CalculateRacePoints(curentRases.Laps)).ToList();
            var sb = new StringBuilder();
            sb.AppendLine($"Driver {driversInRase[0].Name} wins {raceName} race.");
            sb.AppendLine($"Driver {driversInRase[1].Name} is second in {raceName} race.");
            sb.AppendLine($"Driver {driversInRase[2].Name} is third in {raceName} race.");
            this.raceRepository.Remove(curentRases);
            return sb.ToString().TrimEnd();
        }
    }
}
