using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Neo4jClient;
using Neo4jClient.Gremlin;
using DoctorWhoUniverse.Relationships;

namespace DoctorWhoUniverse.Models
{
    public class Actor
    {
        public string ActorName { get; set; }
        public int Cash { get; set; }
        public string WikipediaUri { get; set; }

        //public List<Character> Characters { get; set; }
        private List<string> characterNames = new List<string>();

        public Actor(string actorName)
        {
            this.ActorName = actorName;
            Cash = -1;
        }

        public Actor Played(params string[] characterNames)
        {
            this.characterNames.AddRange(characterNames);
            return this;
        }

        public Actor Salary(int cash)
        {
            this.Cash = cash;
            return this;
        }

        public void Fact(GraphClient db)
        {
        }

        private Node<Actor> EnsureActorIsInDb(GraphClient db)
        {
            if (!db.CheckIndexExists("Actors", IndexFor.Node))
            {
                db.CreateIndex("Actors",
                    new IndexConfiguration { Provider = IndexProvider.lucene, Type = IndexType.exact },
                    IndexFor.Node);
            }

            var actor = db.RootNode
                .Out<Actor>(ObjectBelongsTo.TypeKey, i => i.ActorName == this.ActorName)
                .FirstOrDefault();

            if (actor == null)
            {
                var actorRef = db.Create<Actor>(this, new ObjectBelongsTo(db.RootNode));
                actor = db.Get<Actor>(actorRef);
            }

            return actor;
        }

        private void EnsureCharacterIsInDb(Node<Actor> actor, GraphClient db)
        {
            foreach (string characterName in this.characterNames)
            {
                //new Character(characterName).Fact(db);

                var character = db.RootNode
                    .Out<Character>(ObjectBelongsTo.TypeKey, i => i.CharacterName == characterName)
                    .FirstOrDefault();

                if (actor != null && character != null)
                {
                    EnsureRelationshipInDb(actor, character, db);
                }
            }
        }

        private void EnsureRelationshipInDb(Node<Actor> actor, Node<Character> character, GraphClient db)
        {
            var rel = actor
                .Out<Character>(ActorPlayed.TypeKey, i => i.CharacterName == character.Data.CharacterName)
                .InE()
                .FirstOrDefault();

            if (rel == null)
            {
                db.CreateRelationship<Actor, ActorPlayed>(actor.Reference, new ActorPlayed(character.Reference));
            }
        }
        
    }
}
