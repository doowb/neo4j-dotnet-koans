using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Neo4jClient;
using DoctorWhoUniverse.Models;

namespace DoctorWhoUniverse.Relationships
{
    public class ActorPlayed : Relationship,
        IRelationshipAllowingSourceNode<Actor>,
        IRelationshipAllowingTargetNode<Character>
    {
        public ActorPlayed(NodeReference targetNode) : base(targetNode) { }

        public const string TypeKey = Constants.PLAYED;
        public override string RelationshipTypeKey
        {
            get { return TypeKey; }
        }
    }
}
