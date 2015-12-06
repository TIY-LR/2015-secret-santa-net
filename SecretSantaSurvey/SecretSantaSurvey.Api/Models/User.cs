using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SecretSantaSurvey.Api.Models
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public ICollection<Survey> Survey { get; set;}

        public User()
        {
            Survey = new List<Survey>();
        }
    }
}