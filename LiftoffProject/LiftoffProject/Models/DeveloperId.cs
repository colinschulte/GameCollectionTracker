using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LiftoffProject.Models
{
    public class DeveloperId
    {
        public int Id { get; set; }

        [ForeignKey("Game")]
        public int GameId { get; set; }
    }
}
