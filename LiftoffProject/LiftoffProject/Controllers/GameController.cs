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

        async Task<Cover[]> GetCoverAsync(string path, string id)
        {
            Cover[] covers = null;
            string jsonCover = "";
            StringContent content = new StringContent("fields *; where id = " + id + ";");
            HttpResponseMessage response = await client.PostAsync(path, content);
            if (response.IsSuccessStatusCode)
            {
                jsonCover = await response.Content.ReadAsStringAsync();
                covers = JsonConvert.DeserializeObject<Cover[]>(jsonCover);
            }
            return covers;
        }

        async Task<Developer[]> GetDeveloperAsync(string path)
        {
            Developer[] devs = null;
            string jsonDev = "";
            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                jsonDev = await response.Content.ReadAsStringAsync();
                devs = JsonConvert.DeserializeObject<Developer[]>(jsonDev);
            }
            return devs;
        }

        async Task<Publisher[]> GetPublisherAsync(string path)
        {
            Publisher[] pubs = null;
            string jsonPub = "";
            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                jsonPub = await response.Content.ReadAsStringAsync();
                pubs = JsonConvert.DeserializeObject<Publisher[]>(jsonPub);
            }
            return pubs;
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
                .Include(g => g.GameCover)
                .ToList();
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
                //Console.WriteLine(id);

                RunAsync().GetAwaiter().GetResult();
                var games = await GetGameAsync("/games/", id.ToString());
                foreach (Game newGame in games)
                {
                    if (newGame.Cover != 0)
                    {
                        if (!context.Covers.Any(c => c.id == newGame.Cover))
                        {
                            var covers = await GetCoverAsync("/covers/", newGame.Cover.ToString());
                            foreach (Cover newCover in covers)
                            {
                                context.Covers.Add(newCover);
                                using (var transaction = context.Database.BeginTransaction())
                                {
                                    context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.Covers ON;");
                                    context.SaveChanges();
                                    context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.Covers OFF;");
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

                    if (newGame.Screenshots != null)
                    {
                        foreach(Image screenshot in newGame.Screenshots)
                        {
                            screenshot.GameId = newGame.Id;
                            context.Screenshots.Add(screenshot);
                        }
                        context.SaveChanges();
                    }

                    if (newGame.Videos != null)
                    {
                        foreach(Video video in newGame.Videos)
                        {
                            video.GameId = newGame.Id;
                            context.Videos.Add(video);
                        }
                        context.SaveChanges();
                    }

                    if (newGame.DeveloperIds != null)
                    {
                        string devIds = "";
                        bool first = true;
                        foreach (int devId in newGame.DeveloperIds)
                        {
                                if (first == true)
                                {
                                    devIds += (devId.ToString());
                                    first = false;
                                }
                                else
                                {
                                    devIds += ("," + devId.ToString());
                                }
                        }
                        Developer[] devs = await GetDeveloperAsync("companies/" + devIds);
                        foreach (Developer dev in devs)
                        {
                            if(!context.Developers.Any(d => d.Id == dev.Id) && dev.Name != null)
                            {
                                context.Developers.Add(dev);
                                using (var transaction = context.Database.BeginTransaction())
                                {
                                    context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.Developers ON;");
                                    context.SaveChanges();
                                    context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.Developers OFF;");
                                    transaction.Commit();
                                }
                            }
                            if(!context.DevGames.Any(dg => dg.DeveloperId == dev.Id && dg.GameId == newGame.Id))
                            {
                                DevGame devGame = new DevGame
                                {
                                    DeveloperId = dev.Id,
                                    GameId = newGame.Id
                                };
                                context.DevGames.Add(devGame);
                            }
                            context.SaveChanges();
                        }
                    }
                    if (newGame.PublisherIds != null)
                    {
                        string pubIds = "";
                        bool first = true;
                        foreach (int pubId in newGame.PublisherIds)
                        {
                                if (first == true)
                                {
                                    pubIds += (pubId.ToString());
                                    first = false;
                                }
                                else
                                {
                                    pubIds += ("," + pubId.ToString());
                                }
                        }
                        Publisher[] pubs = await GetPublisherAsync("companies/" + pubIds);
                        foreach (Publisher pub in pubs)
                        {
                            if (!context.Publishers.Any(p => p.Id == pub.Id))
                            {
                                context.Publishers.Add(pub);
                            }
                            PubGame pubGame = new PubGame
                            {
                                PublisherId = pub.Id,
                                GameId = newGame.Id
                            };
                            context.PubGames.Add(pubGame);
                        }

                        using (var transaction = context.Database.BeginTransaction())
                        {
                            context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.Publishers ON;");
                            context.SaveChanges();
                            context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.Publishers OFF;");
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
            context.Screenshots.RemoveRange(context.Screenshots.Where(s => s.GameId == game.Id));
            context.Videos.RemoveRange(context.Videos.Where(v => v.GameId == game.Id));
            context.SaveChanges();
            return Redirect("/game");
        }

        public IActionResult Details(int gameId)
        {
            Game game = context.Games.Single(g => g.Id == gameId);

            List<GenreGameId> genreGameIds = null;
            List<DevGame> devGames = null;
            List<PubGame> pubGames = null;
            List<Image> screenshots = null;
            List<Video> videos = null;

            if (game.Cover != 0)
            {
                game.GameCover = context.Covers.Find(game.Cover);
            }

            if (context.Screenshots.Any(s => s.GameId == game.Id))
            {
                screenshots = context
                    .Screenshots
                    .Where(s => s.GameId == game.Id)
                    .ToList();
            }

            if (context.Videos.Any(v => v.GameId == game.Id))
            {
                videos = context
                    .Videos
                    .Where(v => v.GameId == game.Id)
                    .ToList();
            }

            if (context.DevGames.Any(d => d.GameId == game.Id))
            {
                devGames = context
                    .DevGames
                    .Include(dg => dg.Developer)
                    .Where(dg => dg.GameId == game.Id)
                    .ToList();
            }
            if (context.PubGames.Any(p => p.GameId == game.Id))
            {
                pubGames = context
                    .PubGames
                    .Include(pg => pg.Publisher)
                    .Where(pg => pg.GameId == game.Id)
                    .ToList();
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
                DevGames = devGames,
                PubGames = pubGames,
                Screenshots = screenshots,
                Videos = videos
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
