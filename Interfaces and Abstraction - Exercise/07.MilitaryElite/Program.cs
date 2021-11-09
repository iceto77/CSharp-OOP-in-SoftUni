using System;
using System.Collections.Generic;

namespace MilitaryElite
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Dictionary<string, ISoldier> soldiers = new Dictionary<string, ISoldier>();
            while (input != "End")
            {
                string[] info = input.Split();
                string soldiersType = info[0];
                string id = info[1];
                string firstName = info[2];
                string lastName = info[3];
                switch (soldiersType)
                {
                    case "Private":
                        decimal salary = decimal.Parse(info[4]);
                        soldiers.Add(id, new Private(id, firstName, lastName, salary));
                        break;
                    case "LieutenantGeneral":
                        salary = decimal.Parse(info[4]);
                        ILieutenantGeneral lieutenantGeneral = new LieutenantGeneral(id, firstName, lastName, salary);
                        for (int i = 5; i < info.Length; i++)
                        {
                            IPrivate currentSolder = soldiers[info[i]] as IPrivate;
                            lieutenantGeneral.Privates.Add(currentSolder);
                        }
                        soldiers.Add(id, lieutenantGeneral);
                        break;
                    case "Engineer":
                        salary = decimal.Parse(info[4]);
                        bool isValidEnum = Enum.TryParse(info[5], out Corps corps);
                        if (isValidEnum)
                        {
                            IEngineer engineer = new Engineer(id, firstName, lastName, salary, corps);
                            for (int i = 6; i < info.Length; i += 2)
                            {
                                IRepair repair = new Repair(info[i], int.Parse(info[i + 1]));
                                engineer.Repairs.Add(repair);
                            }
                            soldiers.Add(id, engineer);
                        }
                        break;
                    case "Commando":
                        salary = decimal.Parse(info[4]);
                        isValidEnum = Enum.TryParse(info[5], out corps);
                        if (isValidEnum)
                        {
                            ICommando commando = new Commando(id, firstName, lastName, salary, corps);
                            for (int i = 6; i < info.Length; i += 2)
                            {
                                bool isStatusValid = Enum.TryParse(info[i + 1], out Status status);
                                if (isStatusValid)
                                {
                                    IMission mission = new Mission(info[i], status);
                                    commando.Missions.Add(mission);
                                }
                            }
                            soldiers.Add(id, commando);
                        }
                        break;
                    case "Spy":
                        int codeNumber = int.Parse(info[4]);
                        soldiers.Add(id, new Spy(id, firstName, lastName, codeNumber));
                        break;
                }
                input = Console.ReadLine();
            }
            foreach (var item in soldiers)
            {
                Console.WriteLine(item.Value.ToString());
            }
        }
    }
}
