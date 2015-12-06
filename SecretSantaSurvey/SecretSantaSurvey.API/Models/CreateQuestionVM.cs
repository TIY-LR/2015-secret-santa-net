using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace SecretSantaSurvey.API.Models
{
    [JsonObject("Question")]
    public class CreateQuestionVM
    {
        [Required]
        public string Text { get; set; }
        public int Survey { get; set; }
        [Required]
        public string Answer { get; set; }
    }
}