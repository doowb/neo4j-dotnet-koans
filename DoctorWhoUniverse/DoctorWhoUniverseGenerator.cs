using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Neo4jClient;
using DoctorWhoUniverse.Services;
using DoctorWhoUniverse.Relationships;

namespace DoctorWhoUniverse
{
    public class DoctorWhoUniverseGenerator
    {
        private GraphClient db;
        public DoctorWhoUniverseGenerator(GraphClient db)
        {
            this.db = db;
        }

        public void GenerateUniverse()
        {
        }

    }
}
