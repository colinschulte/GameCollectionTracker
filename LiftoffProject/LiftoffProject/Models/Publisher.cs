using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LiftoffProject.Models
{
    public class Publisher : Company
    {
        [NotMapped]
        [JsonProperty(PropertyName = "games")]
        public int[] Games { get; set; }

        public IList<PubGame> PubGames { get; set; }
    }
}
