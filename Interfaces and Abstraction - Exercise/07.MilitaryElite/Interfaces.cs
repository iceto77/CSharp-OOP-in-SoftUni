using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite
{
    public interface ISoldier 
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

    public interface IPrivate :ISoldier
    {
        public decimal Salary { get; set; }
    }
    public interface ILieutenantGeneral : IPrivate
    {
        public List<IPrivate> Privates { get; set; }
    }
    public interface ISpecialisedSoldier : IPrivate
    {
        public Corps Corps { get; set; }
    }
    public interface IEngineer : ISpecialisedSoldier
    {
        public List<IRepair> Repairs { get; set; }
    }
    public interface ICommando : ISpecialisedSoldier
    {
        public List<IMission> Missions { get; set; }
        public void CompleteMission(string codeName);
    }
    public interface ISpy : ISoldier
    {
        public int CodeNumber { get; set; } 
    } 
    public interface IRepair
    {
        public string PartName { get; set; }
        public int HoursWorked { get; set; }
    }
    public interface IMission
    {
        public string CodeName { get; set; }
        public Status Status { get; set; }
    }
}
