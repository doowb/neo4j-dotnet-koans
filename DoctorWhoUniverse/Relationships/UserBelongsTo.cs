using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Neo4jClient;

namespace DoctorWhoUniverse.Relationships
{
    public class User
    {
        public string Username { get; set; }

        public User()
        {
            
        }
    }
    public class Users
    {
        public Users()
        {
            
        }
    }
    public class UserBelongsTo :
        Relationship,
        IRelationshipAllowingSourceNode<User>,
        IRelationshipAllowingTargetNode<Users>
    {

        public UserBelongsTo(NodeReference targetNode) : base(targetNode) { }

        public const string TypeKey = "USER_BELONGS_TO";
        public override string RelationshipTypeKey
        {
            get { return TypeKey; }
        }
    }
}
