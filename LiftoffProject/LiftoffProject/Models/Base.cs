using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LiftoffProject.Models
{
    public class Base
    {
        [Key]
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        //created_at(integer, optional),
        [NotMapped]
        [JsonProperty(PropertyName = "created_at")]
        public int CreatedAtUTC { get; set; }

        public DateTime CreatedAt { get; set; }

        //name(string, optional),
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        //slug(string, optional),
        [JsonProperty(PropertyName = "slug")]
        public string Slug { get; set; }

        //updated_at(integer, optional),
        [JsonProperty(PropertyName = "updated_at")]
        public int UpdatedAtUTC { get; set; }

        public DateTime UpdatedAt { get; set; }

        //url(string, optional),
        [JsonProperty(PropertyName = "url")]
        public string Url { get; set; }
        
    }
}
