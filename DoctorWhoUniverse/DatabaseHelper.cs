using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Neo4jClient;
using Neo4jClient.Gremlin;

namespace DoctorWhoUniverse
{
    public class DatabaseHelper
    {
        private GraphClient db;

        public DatabaseHelper(GraphClient db)
        {
            this.db = db;
        }

        public static GraphClient CreateDatabase()
        {
            var db = new GraphClient(new Uri("http://localhost:7474/db/data"));
            db.Connect();
            return db;
        }

    }
}
