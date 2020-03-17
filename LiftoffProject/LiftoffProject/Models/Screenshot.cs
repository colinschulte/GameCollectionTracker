using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LiftoffProject.Models
{
    public class Screenshot : Image
    {
        [NotMapped]
        [JsonProperty(PropertyName = "games")]
        public int[] Games { get; set; }

        public IList<ScreenshotGameId> ScreenshotGameIds { get; set; }
    }
}
