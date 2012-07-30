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
            var userService = new UserService(db);

            // get a user node
            var userNode = db.RootNode.
                In<Users>(UsersBelongTo.TypeKey).
                In<User>(UserBelongsTo.TypeKey, 
                    u => u.Username == "bwoodward").
                FirstOrDefault();

            // stupid work around because || is not supported
            if (userNode == null)
            {
                userNode = db.RootNode.
                In<Users>(UsersBelongTo.TypeKey).
                In<User>(UserBelongsTo.TypeKey,
                    u => u.Username == "bwoodward test").
                FirstOrDefault();
            }

            if (userNode != null)
            {
                userService.UpdateUser(userNode, u => u.Username = u.Username.IndexOf("test") > -1 ? "bwoodward" : "bwoodward test");
            }

        }
    }
}
