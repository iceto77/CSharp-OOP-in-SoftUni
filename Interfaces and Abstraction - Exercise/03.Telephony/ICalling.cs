using System;
using System.Collections.Generic;
using System.Text;

namespace Telephony
{
    public interface ICalling
    {
        public string PhoneNumber { get; }
        void Caling();
    }

    public interface IBrowsing
    {
        public string WebSite { get; }
        void Browsing();
    }
}
