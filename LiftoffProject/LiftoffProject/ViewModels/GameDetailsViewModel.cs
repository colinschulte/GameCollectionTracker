using LiftoffProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LiftoffProject.ViewModels
{
    public class GameDetailsViewModel
    {
        public Game Game { get; set; }

        public IList<GenreGameId> Genres { get; set; }
        public IList<DevGame> DevGames { get; set; }
        public IList<PubGame> PubGames { get; set; }
    }
}
