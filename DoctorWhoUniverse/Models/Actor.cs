using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DoctorWhoUniverse.Models
{
    public class Actor
    {
        public string ActorName { get; set; }
        public int Cash { get; set; }
        public string WikipediaUri { get; set; }

        public List<string> CharacterNames { get; set; }

        public Actor()
        {
            CharacterNames = new List<string>();
            Cash = -1;
        }
        
    }
}
