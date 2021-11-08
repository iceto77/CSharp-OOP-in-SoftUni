using System;

namespace Telephony
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string[] phones = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string[] webs = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            foreach (var item in phones)
            {
                try
                {
                    if (item.Length == 7)
                    {
                        StationaryPhone phone = new StationaryPhone(item);
                        phone.Caling();
                    }
                    else if (item.Length == 10)
                    {
                        Smartphone gsm = new Smartphone();
                        gsm.AddPhoneNumber(item);
                        gsm.Caling();
                    }
                    else
                    {
                        throw new ArgumentException($"Invalid number!");
                    }

                }
                catch (Exception excp)
                {
                    Console.WriteLine(excp.Message);
                }
            }
            foreach (var item in webs)
            {
                try
                {
                        Smartphone gsm = new Smartphone();
                        gsm.AddWebSite(item);
                        gsm.Browsing();
                }
                catch (Exception excp)
                {
                    Console.WriteLine(excp.Message);
                }
            }

        }
    }
}
