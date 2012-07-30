using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Neo4jClient;
using Neo4jClient.Gremlin;
using DoctorWhoUniverse;
using DoctorWhoUniverse.Services;
using DoctorWhoUniverse.Relationships;

namespace Koans
{
    [TestClass]
    public class UniverseGeneratorTests
    {
        [TestMethod]
        public void GenerateUniverseTest()
        {
            GraphClient db = DatabaseHelper.CreateDatabase();
            var generator = new DoctorWhoUniverseGenerator(db);
            generator.GenerateUniverse();
        }

        [TestMethod]
        public void UpdateExistingNodeTest()
        {
            GraphClient db = DatabaseHelper.CreateDatabase();

        }
    }
}
