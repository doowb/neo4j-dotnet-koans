using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Neo4jClient;
using DoctorWhoUniverse.Models;

namespace DoctorWhoUniverse.Relationships
{
    class ActorBelongsTo:
        Relationship,
        IRelationshipAllowingSourceNode<Actor>,
        IRelationshipAllowingTargetNode<ActorGroup>
    {

        public ActorBelongsTo(NodeReference targetNode) : base(targetNode) { }

        public const string TypeKey = "ACTOR_BELONGS_TO";
        public override string RelationshipTypeKey
        {
            get { return TypeKey; }
        }
    }
}
