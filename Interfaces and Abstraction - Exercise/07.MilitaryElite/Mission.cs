using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite
{
    public class Mission : IMission
    {
        public Mission(string codeName, Status status)
        {
            CodeName = codeName;
            Status = status;
        }

        public string CodeName { get; set; }
        public Status Status { get; set; }
        public override string ToString()
        {
            return $"Code Name: {this.CodeName} State: {this.Status}";
        }
    }
}
