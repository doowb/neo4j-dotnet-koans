using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DoctorWhoUniverse.Models
{
    public class Episode
    {
        public string Title { get; set; }
        public List<Character> Companions { get; set; }
        public string EpisodeNumber { get; set; }
        public List<Actor> DoctorActors { get; set; }
        public List<Species> EnemySpecies { get; set; }
        public List<Character> Enemies { get; set; }
        public List<Character> Allies { get; set; }
        public List<Species> AlliedSpecies { get; set; }

        private Episode previousEpisode = null;
    }
}
