using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using LiftoffProject.Models;
using LiftoffProject.Data;
using Microsoft.EntityFrameworkCore;
using System.Net.Http;
using System.Net.Http.Headers;
using System;
using System.Threading.Tasks;
using System.Web;
using LiftoffProject.ViewModels;
using Newtonsoft.Json;


namespace LiftoffProject.Controllers
{
    public class GameController : Controller
    {
        private GameDbContext context;

        public GameController(GameDbContext dbContext)
        {
            context = dbContext;
        }

        HttpClient client = new HttpClient();

        async Task RunAsync()
        {
            client.BaseAddress = new Uri("https://api-v3.igdb.com");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Add("user-key", "46de38ddead6ac81de90921b389143bb ");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        async Task<Game[]> GetGameAsync(string path)
        {
            Game[] games = null;
            string jsonGame = "";
            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                jsonGame = await response.Content.ReadAsStringAsync();
                games = JsonConvert.DeserializeObject<Game[]>(jsonGame);
            }
            return games;
        }

        async Task<Game[]> GetGameAsync(string path, string id)
        {
            Game[] games = null;
            string jsonGame = "";
            StringContent content = new StringContent("fields name, cover; where id = " + id + ";");
            HttpResponseMessage response = await client.PostAsync(path, content);
            if (response.IsSuccessStatusCode)
            {
                jsonGame = await response.Content.ReadAsStringAsync();
                games = JsonConvert.DeserializeObject<Game[]>(jsonGame);
            }
            return games;
        }

        async Task<Image[]> GetCoverAsync(string path, string id)
        {
            Image[] covers = null;
            string jsonCover = "";
            StringContent content = new StringContent("fields *; where id = " + id + ";");
            HttpResponseMessage response = await client.PostAsync(path, content);
            if (response.IsSuccessStatusCode)
            {
                jsonCover = await response.Content.ReadAsStringAsync();
                covers = JsonConvert.DeserializeObject<Image[]>(jsonCover);
            }
            return covers;
        }


        async Task<Genre[]> GetGenreAsync(string path)
        {
            Genre[] genres = null;
            string jsonGenre = "";
            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                jsonGenre = await response.Content.ReadAsStringAsync();
                genres = JsonConvert.DeserializeObject<Genre[]>(jsonGenre);
            }
            return genres;
        }

        public IActionResult Index()
        {
            ViewBag.Title = "My Collection";

            IList<Game> games = context.Games
                .ToList();

            foreach(Game game in games)
            {
                if (game.Cover != 0)
                {
                    game.GameCover = context.Covers.Find(game.Cover);
                }
            }

            return View(games);
        }

        public IActionResult Add()
        {
            AddGameViewModel addGameViewModel = new AddGameViewModel();
            return View(addGameViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddGameViewModel addGameViewModel)
        {
            RunAsync().GetAwaiter().GetResult();

            if (ModelState.IsValid)
            {
                var response = await GetGameAsync("/games/?search=" + addGameViewModel.Name + "&fields=name");
                if(response.Length == 0)
                {
                    TempData["NoResults"] = "NoResults";
                }
                else
                {
                    TempData["response"] = response;
                }
            }

            return View(addGameViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> AddCollection(int id)
        {
            if (ModelState.IsValid)
            {
                RunAsync().GetAwaiter().GetResult();
                var games = await GetGameAsync("/games/", id.ToString());
                foreach (Game newGame in games)
                {
                    if (newGame.Cover != 0)
                    {
                        if (!context.Covers.Any(c => c.id == newGame.Cover))
                        {
                            var covers = await GetCoverAsync("/covers/", newGame.Cover.ToString());
                            foreach (Image newCover in covers)
                            {
                                context.Covers.Add(newCover);
                                using (var transaction = context.Database.BeginTransaction())
                                {
                                    context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.Image ON;");
                                    context.SaveChanges();
                                    context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.Image OFF;");
                                    transaction.Commit();
                                }
                            }
                        }
                    }

                    if (!context.Games.Any(g => g.Id == newGame.Id))
                    {
                        context.Games.Add(newGame);
                        using (var transaction = context.Database.BeginTransaction())
                        {
                            context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.Games ON;");
                            context.SaveChanges();
                            context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.Games OFF;");
                            transaction.Commit();
                        }
                    }
                    if (newGame.GenreIds != null)
                    {
                        string genreIds = "";
                        bool first = true;
                        foreach (int genreId in newGame.GenreIds)
                        {
                            if (first == true)
                            {
                                genreIds += (genreId.ToString());
                                first = false;
                            }
                            else
                            {
                                genreIds += ("," + genreId.ToString());
                            }
                        }
                        Genre[] genres = await GetGenreAsync("genres/" + genreIds);
                        foreach (Genre genre in genres)
                        {
                            if (!context.Genres.Any(g => g.Id == genre.Id))
                            {
                                context.Genres.Add(genre);
                            }

                            GenreGameId genreGameId = new GenreGameId
                            {
                                GenreId = genre.Id,
                                GameId = newGame.Id

                            };
                            context.GenreGameIds.Add(genreGameId);
                            using (var transaction = context.Database.BeginTransaction())
                            {
                                context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.Genres ON;");
                                context.SaveChanges();
                                context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.Genres OFF;");
                                transaction.Commit();
                            }
                        }
                    }
                }
                return Redirect("/game");
            }
            else
            {
                return Redirect("/game/add");
            }
        }

        public IActionResult Delete(int gameId)
        {
            Game game = context.Games.Single(g => g.Id == gameId);
            context.Games.Remove(game);
            context.SaveChanges();
            return Redirect("/game");
        }

        public IActionResult Details(int gameId)
        {
            Game game = context.Games.Single(g => g.Id == gameId);
            IList<GenreGameId> genreGameIds = null;

            if (game.Cover != 0)
            {
                game.GameCover = context.Covers.Find(game.Cover);
            }

            if (context.GenreGameIds.Any(g => g.GameId == game.Id))
            {
                genreGameIds = context
                    .GenreGameIds
                    .Include(ggid => ggid.Genre)
                    .Where(ggid => ggid.GameId == game.Id)
                    .ToList();
            }
            GameDetailsViewModel viewModel = new GameDetailsViewModel
            {
                Game = game,
                Genres = genreGameIds,
                
            };

            return View(viewModel);
        }

        public async Task<IActionResult> Test()
        {
            RunAsync().GetAwaiter().GetResult();

            var response = await GetGameAsync("games/1?fields=name");

            return View(response);
        }
    }
}
