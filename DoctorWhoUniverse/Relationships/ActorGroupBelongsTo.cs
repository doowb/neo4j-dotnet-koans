using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Neo4jClient;
using DoctorWhoUniverse.Models;

namespace DoctorWhoUniverse.Relationships
{
    class ActorGroupBelongsTo :
        Relationship,
        IRelationshipAllowingSourceNode<ActorGroup>,
        IRelationshipAllowingTargetNode<RootNode>
    {

        public ActorGroupBelongsTo(NodeReference targetNode) : base(targetNode) { }

        public const string TypeKey = "ACTORGROUP_BELONGS_TO";
        public override string RelationshipTypeKey
        {
            get { return TypeKey; }
        }
    }
}
