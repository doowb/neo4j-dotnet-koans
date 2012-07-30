using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Neo4jClient;
using Neo4jClient.Gremlin;
using DoctorWhoUniverse.Relationships;

namespace DoctorWhoUniverse.Services
{
    public class UserService : BaseService
    {
        /// <summary>
        /// Initializes a new instance of the UserService class.
        /// </summary>
        public UserService(GraphClient db) : base(db) { }

        public NodeReference EnsureUsersNodeExists()
        {
            // try to find the users node in the graph
            var usersNode = db.RootNode.In<Users>(UsersBelongTo.TypeKey).SingleOrDefault();
            NodeReference usersNodeReference = null;
            if (usersNode == null)
            {
                usersNodeReference = CreateUserGroup(new Users());
            }
            else
            {
                usersNodeReference = usersNode.Reference;
            }
            return usersNodeReference;
        }

        public NodeReference CreateUserGroup(Users users)
        {
            var node = db.Create<Users>(users, new UsersBelongTo(db.RootNode));
            return node;
        }

        public NodeReference CreateUser(User user, NodeReference<Users> users)
        {
            user.Username = user.Username.ToLowerInvariant();
            var node = db.Create<User>(user, new UserBelongsTo(users));
            return node;
        }

        public void UpdateUser(NodeReference<User> userNodeReference, Action<User> updateCallback)
        {
            db.Update(userNodeReference, u => { updateCallback(u); });
        }

        public void UpdateUser(Node<User> userNode, Action<User> updateCallback)
        {
            UpdateUser(userNode.Reference, updateCallback);
        }
    }
}
