using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DoctorWhoUniverse.Models
{
    public class Character
    {
        public string CharacterName { get; set; }
        public HashSet<Species> Species { get; set; }
        public bool Companion { get; set; }
        public List<Character> Lovers { get; set; }
        public Planet Planet { get; set; }
        public List<string> Things { get; set; }
        public bool Enemy { get; set; }
        public bool Ally { get; set; }
        public List<Actor> Actors { get; set; }
        public Dictionary<string, int> StartDates { get; set; }
        public string WikipediaUri { get; set; }
    }
}
