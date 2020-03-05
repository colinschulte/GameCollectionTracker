using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LiftoffProject.Models
{
    public class GameEngine : GameBase
    {
        //logo(object, optional),
        [JsonProperty(PropertyName = "logo")]
        public Image Logo { get; set; }

        //platforms(Array[integer], optional),
        [JsonProperty(PropertyName = "platforms")]
        public int[] Platforms { get; set; }

        //companies(Array[integer], optional)
        [JsonProperty(PropertyName = "companies")]
        public int[] Companies { get; set; }
    }
}
