using SecretSantaSurvey.API.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SecretSantaSurvey.Api.Models
{
    public class Survey
    {
        //initialize to an empty list


        public int Id { get; set; }

        //[ForeignKey("User")]
        //public Int32? UserId { get; set; }

        public virtual User User { get; set; }

        public virtual ICollection<Question> Questions { get; set; }

        public Survey()
        {
            Questions = new List<Question>();
        }
    }
}