using Gym.Core.Contracts;
using Gym.Models.Athletes;
using Gym.Models.Athletes.Contracts;
using Gym.Models.Equipment;
using Gym.Models.Equipment.Contracts;
using Gym.Models.Gyms;
using Gym.Models.Gyms.Contracts;
using Gym.Repositories;
using Gym.Repositories.Contracts;
using Gym.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gym.Core
{
    public class Controller : IController
    {
        private readonly IRepository<IEquipment> equipmentR;
        private List<IGym> gyms;
        public Controller()
        {
            this.equipmentR = new EquipmentRepository();
            this.gyms = new List<IGym>();
        }

        public string AddGym(string gymType, string gymName)
        {
            switch (gymType)
            {
                case nameof(BoxingGym):
                    this.gyms.Add(new BoxingGym(gymName));
                    break;
                case nameof(WeightliftingGym):
                    this.gyms.Add(new WeightliftingGym(gymName));
                    break;
                default: throw new InvalidOperationException(ExceptionMessages.InvalidGymType);
            }
            return string.Format(OutputMessages.SuccessfullyAdded, gymType);
        }
        public string AddEquipment(string equipmentType)
        {
            switch (equipmentType)
            {
                case nameof(BoxingGloves):
                    this.equipmentR.Add(new BoxingGloves());
                    break;
                case nameof(Kettlebell):
                    this.equipmentR.Add(new Kettlebell()); ;
                    break;
                default: throw new InvalidOperationException(ExceptionMessages.InvalidEquipmentType);
            }
            return string.Format(OutputMessages.SuccessfullyAdded, equipmentType);
        }
        public string InsertEquipment(string gymName, string equipmentType)
        {
            var targetGym = this.gyms.FirstOrDefault(x => x.Name == gymName);
            var targetEquipment = this.equipmentR.FindByType(equipmentType);
            if (targetEquipment == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.InexistentEquipment, equipmentType));
            }
            targetGym.AddEquipment(targetEquipment);
            this.equipmentR.Remove(targetEquipment);
            return string.Format(OutputMessages.EntityAddedToGym, equipmentType, gymName);
        }
        public string AddAthlete(string gymName, string athleteType, string athleteName, string motivation, int numberOfMedals)
        {
            IAthlete targetAthlete;
            switch (athleteType)
            {
                case nameof(Boxer):
                    targetAthlete = new Boxer(athleteName, motivation, numberOfMedals);
                    break;
                case nameof(Weightlifter):
                    targetAthlete = new Weightlifter(athleteName, motivation, numberOfMedals);
                    break;
                default: throw new InvalidOperationException(ExceptionMessages.InvalidAthleteType);
            }
            IGym targetGym = this.gyms.FirstOrDefault(x => x.Name == gymName);
            if (targetGym.GetType().Name[0] == targetAthlete.GetType().Name[0])
            {
                this.gyms.FirstOrDefault(x => x.Name == gymName).AddAthlete(targetAthlete);
            }
            else
            {
                return string.Format(OutputMessages.InappropriateGym);
            }
            return string.Format(OutputMessages.EntityAddedToGym, athleteType, gymName);
        }
        public string TrainAthletes(string gymName)
        {
            var targetGym = this.gyms.FirstOrDefault(x => x.Name == gymName);
            targetGym.Exercise();
            int count = targetGym.Athletes.Count;
            return string.Format(OutputMessages.AthleteExercise, count);
        }
        public string EquipmentWeight(string gymName)
        {
            var totalWeight = this.gyms.Sum(x => x.EquipmentWeight);
            return string.Format(OutputMessages.EquipmentTotalWeight, gymName, $"{totalWeight:f2}");
        }
        public string Report()
        {
            var sb = new StringBuilder();
            foreach (var gym in this.gyms)
            {
                sb.AppendLine(gym.GymInfo());
            }
            return sb.ToString().TrimEnd();
        }


    }
}
