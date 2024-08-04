using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryExe
{
    /// <summary>
    /// Custom user register collection class with required methods
    /// </summary>
    public sealed class UserRegister
    {
        private List<User> Users;

        public UserRegister()
        {
            Users = new List<User>();
        }

        private void AddUser(User data)
        {
            Users.Add(data);
        }

        public void AddUsersToRegister(User data)
        {
            AddUser(data);
        }

        public User GetUser(User data)
        {
            return Users.Find(x => x.Name == data.Name);
        }

        public List<User> GetUsers()
        {
            return Users;
        }

        public bool CheckIfExists(User data)
        {
            User user = Users.Find(x => x.Name == data.Name && x.Lastname == data.Lastname);
            if (Users.Contains(user))
                return true;
            else
                return false;
        }
    }
}
