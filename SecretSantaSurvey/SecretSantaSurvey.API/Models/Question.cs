using SecretSantaSurvey.Api.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SecretSantaSurvey.API.Models
{
    public class Question
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public string Answer { get; set; }
        [Required]
        public virtual Survey ParentSurvey { get; set; }
    }
}