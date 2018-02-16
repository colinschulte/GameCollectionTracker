using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LiftoffProject.Models
{
    public class TimeToBeat
    {
        [Key]
        public int LocalId { get; set; }

        [JsonProperty(PropertyName = "hastly")]
        public int Hastly { get; set; }

        [JsonProperty(PropertyName = "normally")]
        public int Normally { get; set; }

        [JsonProperty(PropertyName = "completely")]
        public int Completely { get; set; }
    }
}
