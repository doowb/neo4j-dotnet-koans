using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DoctorWhoUniverse.Models
{
    public class Species
    {
        public string SpeciesName { get; set; }
        public Planet Planet { get; set; }
        public List<Character> Enemies { get; set; }
        public List<Species> EnemySpecies { get; set; }
    }
}
