using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LiftoffProject.Models
{
    public class ReleaseDate : Base
    { 
        [JsonProperty(PropertyName = "category")]
        public int Category { get; set; }

        [JsonProperty(PropertyName = "date")]
        public int Date { get; set; }

        [JsonProperty(PropertyName = "game")]
        public int GameId { get; set; }

        [JsonProperty(PropertyName = "human")]
        public string Human { get; set; }

        [JsonProperty(PropertyName = "m")]
        public int Month { get; set; }

        [JsonProperty(PropertyName = "platform")]
        public int Platform { get; set; }

        [JsonProperty(PropertyName = "region")]
        public int Region { get; set; }

        [JsonProperty(PropertyName = "y")]
        public int Year { get; set; }
    }
}
