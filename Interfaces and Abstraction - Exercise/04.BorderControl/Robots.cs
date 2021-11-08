using System;
using System.Collections.Generic;
using System.Text;

namespace BorderControl
{
    public class Robots : ISociety
    {
        private string model;
        private string id;

        public Robots(string model, string id)
        {
            this.Model = model;
            this.Id = id;
        }

        public string Model { get; set; }
        public string Id { get; set; }

    }
}
