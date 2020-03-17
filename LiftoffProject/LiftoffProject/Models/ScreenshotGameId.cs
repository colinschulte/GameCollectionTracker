using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LiftoffProject.Models
{
    public class ScreenshotGameId
    {
        public int ScreenshotId { get; set; }

        [ForeignKey("ScreenshotId")]
        public Screenshot Screenshot { get; set; }

        public int GameId { get; set; }

        [ForeignKey("GameId")]
        public Game Game { get; set; }
    }
}
