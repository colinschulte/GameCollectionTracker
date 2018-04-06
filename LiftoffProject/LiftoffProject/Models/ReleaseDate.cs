using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LiftoffProject.Models
{
    public class ReleaseDate
    {
        //id(integer, optional),
        [Key]
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        //name(string, optional),
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        //created_at(integer, optional),
        [JsonProperty(PropertyName = "created_at")]
        public int CreatedAt { get; set; }

        //updated_at(integer, optional),
        [JsonProperty(PropertyName = "updated_at")]
        public int UpdatedAt { get; set; }

        [JsonProperty(PropertyName = "category")]
        public int Category { get; set; }

        [JsonProperty(PropertyName = "platform")]
        public int Platform { get; set; }

        [JsonProperty(PropertyName = "human")]
        public string Human { get; set; }

        [JsonProperty(PropertyName = "date")]
        public int Date { get; set; }

        [JsonProperty(PropertyName = "region")]
        public int Region { get; set; }

        [JsonProperty(PropertyName = "y")]
        public int Year { get; set; }

        [JsonProperty(PropertyName = "m")]
        public int Month { get; set; }

    }
}
