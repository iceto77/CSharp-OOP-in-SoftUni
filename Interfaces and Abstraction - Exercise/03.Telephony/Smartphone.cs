using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Telephony
{
    public class Smartphone : ICalling, IBrowsing
    {
        private string phoneNumber;
        private string webSite;

        public Smartphone()
        {
            this.PhoneNumber = "";
            this.WebSite = "";
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
        public string WebSite
        {
            get => this.webSite;

            private set
            {
                if (value.Any(char.IsDigit))
                {
                    throw new ArgumentException($"Invalid URL!");
                }
                this.webSite = value; 
            }
        }
        public void AddPhoneNumber(string phoneNumber)
        {
            this.PhoneNumber = phoneNumber;
        }
        public void AddWebSite(string webSite)
        {
            this.WebSite = webSite;
        }
        public void Browsing()
        {
            Console.WriteLine($"Browsing: {this.webSite}!");
        }

        public void Caling()
        {
            Console.WriteLine($"Calling... {this.phoneNumber}");
        }
    }

}
