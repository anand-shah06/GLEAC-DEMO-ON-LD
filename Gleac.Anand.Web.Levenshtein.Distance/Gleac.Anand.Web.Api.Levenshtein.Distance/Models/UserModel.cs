using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gleac.Anand.Web.Api.Levenshtein.Distance.Models
{
    public class UserModel
    {
        public UserModel(){}

        public string Username{ get; set; }
        public string Password { get; set; }
        public string EmailAddress { get; set; }
        public DateTime DateOfJoining { get; set; }

    }
}
