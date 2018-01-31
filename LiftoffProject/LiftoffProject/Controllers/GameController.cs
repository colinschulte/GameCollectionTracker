using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using LiftoffProject.Models;
using LiftoffProject.Data;
using Microsoft.EntityFrameworkCore;

namespace LiftoffProject.Controllers
{
    public class GameController : Controller
    {
        private GameDbContext context;

        public GameController(GameDbContext dbContext)
        {
            context = dbContext;
        }

        //static HttpClient client = new HttpClient();

        //static async Task RunAsync()
        //{
        //    client.BaseAddress = new Uri("https://api-2445582011268.apicast.io");
        //    client.DefaultRequestHeaders.Accept.Clear();
        //    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        //}

        //static async Task<Game> GetProductAsync(string path)
        //{
        //    Game game = null;
        //    HttpResponseMessage response = await client.GetAsync(path);
        //    if (response.IsSuccessStatusCode)
        //    {
        //        game = await response.Content.ReadAsAsync<Game>();
        //    }
        //    return game;
        //}

        public IActionResult Index()
        {
            IList<Game> games = context.Games.ToList();
            return View(games);
        }
    }
}
