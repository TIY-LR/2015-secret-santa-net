using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace SecretSantaSurvey.API.Models
{
    [JsonObject(Title ="Question")]
    public class CreateQuestionVM
    {
        public string Text { get; set; }
        public int Survey { get; set; }
        public string Answer { get; set; }
    }
}