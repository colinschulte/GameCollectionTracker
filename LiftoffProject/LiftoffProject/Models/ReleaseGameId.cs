using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LiftoffProject.Models
{
    public class ReleaseGameId
    {
        public int ReleaseDateId { get; set; }

        [ForeignKey("ReleaseDateId")]
        public ReleaseDate ReleaseDate { get; set; }

        public int GameId { get; set; }

        [ForeignKey("GameId")]
        public Game Game { get; set; }
    }
}
