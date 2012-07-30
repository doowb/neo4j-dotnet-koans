using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Neo4jClient;

namespace DoctorWhoUniverse.Relationships
{
    public class UsersBelongTo :
        Relationship,
        IRelationshipAllowingSourceNode<Users>,
        IRelationshipAllowingTargetNode<RootNode>
    {
        public UsersBelongTo(NodeReference targetNode) : base(targetNode) { }

        public const string TypeKey = "USERS_BELONG_TO";
        public override string RelationshipTypeKey
        {
            get { return TypeKey; }
        }
    }
}
