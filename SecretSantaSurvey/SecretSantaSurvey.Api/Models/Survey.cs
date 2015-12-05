using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SecretSantaSurvey.Api.Models
{
    public class Survey
    {
        public int Id { get; set; }
        public User User { get; set; }
        public string Name { get; set; }

        public ICollection<Question> Questions { get; set; }

    }

    public class Question
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public string Answers { get; set; }
        public Survey ParentSurvey { get; set; }
    }
}