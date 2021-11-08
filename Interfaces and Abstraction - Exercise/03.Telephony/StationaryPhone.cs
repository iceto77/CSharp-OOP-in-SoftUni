using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Telephony
{
    public class StationaryPhone : ICalling
    {
        private string phoneNumber;

        public StationaryPhone(string phoneNumber)
        {
            this.PhoneNumber = phoneNumber;
        }

        public string PhoneNumber
        {
            get => this.phoneNumber;

            private set
            {
                if (!value.All(char.IsDigit))
                {
                    throw new ArgumentException($"Invalid number!");
                }
                this.phoneNumber = value;
            }
        }

        public void Caling()
        {
            Console.WriteLine($"Dialing... {this.phoneNumber}");
        }
    }
}
