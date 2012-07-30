using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Neo4jClient;

namespace DoctorWhoUniverse.Services
{
    public abstract class BaseService
    {
        protected GraphClient db;
        public BaseService(GraphClient db)
        {
            this.db = db;
        }
    }
}
