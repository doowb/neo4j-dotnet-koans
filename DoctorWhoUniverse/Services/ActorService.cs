using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Neo4jClient;
using Neo4jClient.Gremlin;
using DoctorWhoUniverse.Models;
using DoctorWhoUniverse.Relationships;

namespace DoctorWhoUniverse.Services
{
    class ActorService : BaseService
    {
        /// <summary>
        /// Initializes a new instance of the ActorService class.
        /// </summary>
        public ActorService(GraphClient db) : base(db) { }


        public NodeReference EnsureActorGroupExists()
        {
            // try to find the actor group node in the graph
            var groupNode = db.RootNode.In<ActorGroup>(ActorGroupBelongsTo.TypeKey).SingleOrDefault();
            NodeReference groupNodeReference = null;
            if (groupNode == null)
            {
                groupNodeReference = CreateActorGroup(new ActorGroup());
            }
            else
            {
                groupNodeReference = groupNode.Reference;
            }
            return groupNodeReference;
        }

        public NodeReference EnsureActorIsInDb(Actor actor)
        {
            var actorNode = db.QueryIndex<Node<Actor>>("actor", 
                IndexFor.Node, 
                String.Format("ActorName={0}", actor.ActorName)).FirstOrDefault();

            NodeReference actorNodeReference = null;
            if (actorNode == null)
            {
                var groupNodeReference = EnsureActorGroupExists() as NodeReference<ActorGroup>;
                actorNodeReference = CreateActor(actor, groupNodeReference);
            }
            else
            {
                actorNodeReference = actorNode.Reference;
            }
            return actorNodeReference;

        }

        public NodeReference CreateActorGroup(ActorGroup group)
        {
            return db.Create<ActorGroup>(group, new ActorGroupBelongsTo(db.RootNode));
        }

        public NodeReference CreateActor(Actor actor, NodeReference<ActorGroup> actorGroup)
        {
            return db.Create<Actor>(actor, new ActorBelongsTo(actorGroup));
        }
    }
}
