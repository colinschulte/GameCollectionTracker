using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LiftoffProject.Models
{
    public class Developer : Company
    {
        [NotMapped]
        [JsonProperty(PropertyName = "games")]
        public int[] Games { get; set; }

        public IList<DevGame> DevGames { get; set; }
    }
}
