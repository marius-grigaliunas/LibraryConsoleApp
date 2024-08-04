using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryExe
{
    /// <summary>
    /// Data class for user object
    /// </summary>
    public class User
    {
        public string Name { get; set; }
        public string Lastname { get; set; }
        public int TakenBooks { get; set; }

        public User(string name, string lastname)
        {
            this.Name = name;
            this.Lastname = lastname;
            this.TakenBooks = 1;
        }
    }
}
