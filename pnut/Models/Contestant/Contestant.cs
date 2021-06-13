using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pnut
{
    public class Contestant : Entity
    {
        public char Group { get; private set; }
        public string SourcesDirectory { get; private set; }
        public string City { get; private set; }
        public string Country { get; private set; }


        public Contestant(string name, char group, string sourcesDirectory, string city, string country) : base(name)
        {
            Group = group;
            SourcesDirectory = sourcesDirectory;
            City = city;
            Country = country;
        }
    }
}
