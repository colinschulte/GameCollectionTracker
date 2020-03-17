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
            StringContent content = new StringContent("fields *; where id = (" + id + ");");
            HttpResponseMessage response = await client.PostAsync(path, content);
            if (response.IsSuccessStatusCode)
            {
                jsonGame = await response.Content.ReadAsStringAsync();
                games = JsonConvert.DeserializeObject<Game[]>(jsonGame);
            }
            return games;
        }

        async Task<Image[]> GetImageAsync(string path, string id)
        {
            Image[] images = null;
            string jsonImage = "";
            StringContent content = new StringContent("fields *; where id = (" + id + ");");
            HttpResponseMessage response = await client.PostAsync(path, content);
            if (response.IsSuccessStatusCode)
            {
                jsonImage = await response.Content.ReadAsStringAsync();
                images = JsonConvert.DeserializeObject<Image[]>(jsonImage);
            }
            return images;
        }

        async Task<Screenshot[]> GetScreenshotAsync(string path, string id)
        {
            Screenshot[] screenshots = null;
            string jsonScreenshot = "";
            StringContent content = new StringContent("fields *; where id = (" + id + ");");
            HttpResponseMessage response = await client.PostAsync(path, content);
            if (response.IsSuccessStatusCode)
            {
                jsonScreenshot = await response.Content.ReadAsStringAsync();
                screenshots = JsonConvert.DeserializeObject<Screenshot[]>(jsonScreenshot);
            }
            return screenshots;
        }

        async Task<Genre[]> GetGenreAsync(string path, string ids)
        {
            Genre[] genres = null;
            string jsonGenre = "";
            StringContent content = new StringContent("fields *; where id = (" + ids + ");");
            HttpResponseMessage response = await client.PostAsync(path, content);
            if (response.IsSuccessStatusCode)
            {
                jsonGenre = await response.Content.ReadAsStringAsync();
                genres = JsonConvert.DeserializeObject<Genre[]>(jsonGenre);
            }
            return genres;
        }

        async Task<ReleaseDate[]> GetReleaseDateAsync(string path, string ids)
        {
            ReleaseDate[] releasedates = null;
            string jsonReleaseDate = "";
            StringContent content = new StringContent("fields *; where id = (" + ids + ");");
            HttpResponseMessage response = await client.PostAsync(path, content);
            if (response.IsSuccessStatusCode)
            {
                jsonReleaseDate = await response.Content.ReadAsStringAsync();
                releasedates = JsonConvert.DeserializeObject<ReleaseDate[]>(jsonReleaseDate);
            }
            return releasedates;
        }

        public IActionResult Index()
        {
            ViewBag.Title = "My Collection";

            IList<Game> games = context.Games
                .ToList();

            foreach(Game game in games)
            {
                if (game.CoverId != 0)
                {
                    game.Cover = context.Covers.Find(game.CoverId);
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
                if(response == null)
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
                    if (newGame.CoverId != 0)
                    {
                        if (!context.Covers.Any(c => c.Id == newGame.CoverId))
                        {
                            var covers = await GetImageAsync("/covers/", newGame.CoverId.ToString());
                            foreach (Image newCover in covers)
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
                        Genre[] genres = await GetGenreAsync("/genres/",  genreIds);
                        foreach (Genre genre in genres)
                        {
                            if (!context.Genres.Any(g => g.Id == genre.Id))
                            {
                                context.Genres.Add(genre);
                            }
                            if ((!context.GenreGameIds.Any(g => g.GenreId == genre.Id)) || (!context.GenreGameIds.Any(g => g.GameId == newGame.Id)))
                            {
                                GenreGameId genreGameId = new GenreGameId
                                {
                                    GenreId = genre.Id,
                                    GameId = newGame.Id
                                };
                                context.GenreGameIds.Add(genreGameId);
                            }
                            using (var transaction = context.Database.BeginTransaction())
                            {
                                context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.Genres ON;");
                                context.SaveChanges();
                                context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.Genres OFF;");
                                transaction.Commit();
                            }
                        }
                    }
                    if (newGame.ReleaseDateIds != null)
                    {
                        string releaseDateIds = "";
                        bool first = true;
                        foreach (int releaseDateId in newGame.ReleaseDateIds)
                        {
                            if (first == true)
                            {
                                releaseDateIds += (releaseDateId.ToString());
                                first = false;
                            }
                            else
                            {
                                releaseDateIds += ("," + releaseDateId.ToString());
                            }
                        }
                        ReleaseDate[] releaseDates = await GetReleaseDateAsync("release_dates/", releaseDateIds);
                        foreach (ReleaseDate releaseDate in releaseDates)
                        {
                            if (!context.ReleaseDates.Any(r => r.Id == releaseDate.Id))
                            {
                                context.ReleaseDates.Add(releaseDate);
                            }
                            if ((!context.ReleaseGameIds.Any(r => r.ReleaseDateId == releaseDate.Id)) || (!context.ReleaseGameIds.Any(r => r.GameId == newGame.Id)))
                            {
                                ReleaseGameId releaseGameId = new ReleaseGameId
                                {
                                    ReleaseDateId = releaseDate.Id,
                                    GameId = newGame.Id
                                };
                                context.ReleaseGameIds.Add(releaseGameId);
                            }
                            using (var transaction = context.Database.BeginTransaction())
                            {
                                context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.ReleaseDates ON;");
                                context.SaveChanges();
                                context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.ReleaseDates OFF;");
                                transaction.Commit();
                            }
                        }
                    }
                    if (newGame.ScreenshotIds != null)
                    {
                        string screenshotIds = "";
                        bool first = true;
                        foreach (int screenshotId in newGame.ScreenshotIds)
                        {
                            if (first == true)
                            {
                                screenshotIds += (screenshotId.ToString());
                                first = false;
                            }
                            else
                            {
                                screenshotIds += ("," + screenshotId.ToString());
                            }
                        }
                        Screenshot[] screenshots = await GetScreenshotAsync("/screenshots/", screenshotIds);
                        foreach (Screenshot screenshot in screenshots)
                        {
                            if (!context.Screenshots.Any(s => s.Id == screenshot.Id))
                            {
                                context.Screenshots.Add(screenshot);
                            }
                            if ((!context.ScreenshotGameIds.Any(s => s.ScreenshotId == screenshot.Id)) || (!context.ScreenshotGameIds.Any(s => s.GameId == newGame.Id)))
                            {
                                ScreenshotGameId screenshotGameId = new ScreenshotGameId
                                {
                                    ScreenshotId = screenshot.Id,
                                    GameId = newGame.Id
                                };
                                context.ScreenshotGameIds.Add(screenshotGameId);
                            }
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
            IList<ReleaseGameId> releaseGameIds = null;
            IList<ScreenshotGameId> screenshotGameIds = null;

            if (game.CoverId != 0)
            {
                game.Cover = context.Covers.Find(game.CoverId);
            }

            if (context.GenreGameIds.Any(g => g.GameId == game.Id))
            {
                genreGameIds = context
                    .GenreGameIds
                    .Include(ggid => ggid.Genre)
                    .Where(ggid => ggid.GameId == game.Id)
                    .ToList();
            }

            if (context.ReleaseGameIds.Any(r => r.GameId == game.Id))
            {
                releaseGameIds = context
                    .ReleaseGameIds
                    .Include(rgid => rgid.ReleaseDate)
                    .Where(rgid => rgid.GameId == game.Id)
                    .ToList();
            }

            if (context.ScreenshotGameIds.Any(s => s.GameId == game.Id))
            {
                screenshotGameIds = context
                    .ScreenshotGameIds
                    .Include(sgid => sgid.Screenshot)
                    .Where(sgid => sgid.GameId == game.Id)
                    .ToList();
            }

            GameDetailsViewModel viewModel = new GameDetailsViewModel
            {
                Game = game,
                Genres = genreGameIds,
                ReleaseDates = releaseGameIds,
                Screenshots = screenshotGameIds
                
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
