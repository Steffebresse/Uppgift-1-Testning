using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserRegClasses
{
    public class UserBank
    {
        List<User> Users = new List<User>();

        public string AddUser(User user)
        {
            
            if (Users.Exists(u => u.Username == user.Username))
            {
                throw new ArgumentException("Username already exists.");
            }

            Users.Add(user);
            return $"{user.Username} has been sucessfully created!";
        }

    }
}
