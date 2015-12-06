using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SecretSantaSurvey.Api.Models
{
    public class Survey
    {
        //initialize to an empty list
        

        public int Id { get; set; }
        public User UserID { get; set; }

        public virtual ICollection<Question> Questions { get; set; }

        public Survey()
        {
            Questions = new List<Question>();
        }
    }

    public class Question
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public Survey ParentSurvey { get; set; }
    }
}