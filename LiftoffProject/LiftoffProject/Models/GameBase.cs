using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LiftoffProject.Models
{
    public class GameBase
    {
        [Key]
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        //name(string, optional),
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        //created_at(integer, optional),
        [JsonProperty(PropertyName = "created_at")]
        public long CreatedAt { get; set; }

        //updated_at(integer, optional),
        [JsonProperty(PropertyName = "updated_at")]
        public long UpdatedAt { get; set; }

        //slug(string, optional),
        [JsonProperty(PropertyName = "slug")]
        public string Slug { get; set; }

        //url(string, optional),
        [JsonProperty(PropertyName = "url")]
        public string Url { get; set; }

        //games(Array[integer], optional)
        //[NotMapped]
        //[JsonProperty(PropertyName = "games")]
        //public int[] Games { get; set; }
    }
}
