using System;
using System.Collections.Generic;
using System.Linq;

namespace FootballTeamGenerator
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Dictionary<string, Team> teams = new Dictionary<string, Team>();
            string input = Console.ReadLine();
            while (input != "END")
            {
                string[] command = input.Split(';');
                try
                {
                    switch (command[0])
                    {
                        case "Team":
                            teams.Add(command[1], new Team(command[1]));
                            break;
                        case "Add":
                            if (!teams.ContainsKey(command[1]))
                            {
                                throw new ArgumentException($"Team {command[1]} does not exist.");
                            }
                            int endurance = int.Parse(command[3]);
                            int sprint = int.Parse(command[4]);
                            int dribble = int.Parse(command[5]);
                            int passing = int.Parse(command[6]);
                            int shooting = int.Parse(command[7]);
                            Player currentPlayer = new Player(command[2], endurance, sprint, dribble, passing, shooting);
                            teams[command[1]].AddPlayer(currentPlayer);
                            break;
                        case "Remove":
                            teams[command[1]].RemovePlayer(command[2]);
                            break;
                        case "Rating":
                            if (!teams.ContainsKey(command[1]))
                            {
                                throw new ArgumentException($"Team {command[1]} does not exist.");
                            }
                            Console.WriteLine($"{command[1]} - {teams[command[1]].Rating}");
                            break;
                    }
                }
                catch (Exception excp)
                {
                    Console.WriteLine(excp.Message);
                }
                input = Console.ReadLine();
            }
        }
    }
}
