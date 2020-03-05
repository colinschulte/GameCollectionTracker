using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LiftoffProject.Models
{
    public class Rating
    {
        [Key]
        public int RatingId { get; set; }

        [JsonProperty(PropertyName = "rating")]
        public int RatingInt { get; set; }

        [JsonProperty(PropertyName = "synopsis")]
        public string Synopsis { get; set; }
    }
}
