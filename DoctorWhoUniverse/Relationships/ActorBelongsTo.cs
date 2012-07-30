using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Neo4jClient;
using DoctorWhoUniverse.Models;

namespace DoctorWhoUniverse.Relationships
{
    public class ObjectBelongsTo:
        Relationship,
        IRelationshipAllowingSourceNode<Actor>,
        IRelationshipAllowingSourceNode<Character>,
        IRelationshipAllowingSourceNode<Episode>,
        IRelationshipAllowingSourceNode<Planet>,
        IRelationshipAllowingSourceNode<Species>,
        IRelationshipAllowingTargetNode<RootNode>
    {

        public ObjectBelongsTo(NodeReference targetNode) : base(targetNode) { }

        public const string TypeKey = "OBJECT_BELONGS_TO";
        public override string RelationshipTypeKey
        {
            get { return TypeKey; }
        }
    }
}
