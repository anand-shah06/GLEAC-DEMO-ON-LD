using System;
using System.Collections.Generic;
using System.Text;

namespace Gleac.Anand.Levenshtein.Distance
{
    public class UserModel
    {
        public UserModel() { }

        public string Username { get; set; }
        public string Password { get; set; }
        public string EmailAddress { get; set; }
        public DateTime DateOfJoining { get; set; }
    }
}
