using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Koans
{
    [TestClass]
    public class Koan01
    {
        [TestMethod]
        public void JustEmitsThePathToTheDatabase()
        {
            var db = new Neo4jClient.GraphClient(new Uri("http://localhost:7474/db/data"));
            db.Connect();
            Assert.IsNotNull(db);
        }
    }
}
