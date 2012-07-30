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

        public void Generate()
        {

        }

        public NodeReference EnsureActor(Actor actor)
        {
            var newActor = CreateActor(actor);
            //var characterService = new CharacterService(db);
            //foreach (var character in actor.Characters)
            //{
            //    var newCharacter = db.EnsureCharacter(character);
            //}
            return newActor;
        }

        public NodeReference CreateActor(Actor actor)
        {
            var newActor = db.Create<Actor>(actor, new ObjectBelongsTo(db.RootNode));
            return newActor;
        }
    }
}
