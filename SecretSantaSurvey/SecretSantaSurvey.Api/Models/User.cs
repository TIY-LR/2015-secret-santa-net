using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SecretSantaSurvey.Api.Models
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public virtual List<Survey> Survey { get; set;}


        public User()
        {
            Survey = new List<Survey>();
        }
    }
}