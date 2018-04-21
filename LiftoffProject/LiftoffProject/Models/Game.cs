using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LiftoffProject.Models
{
    public class Game : GameBase
    {
        //summary(string, optional),
        [JsonProperty(PropertyName = "summary")]
        public string Summary { get; set; }

        //storyline(string, optional),
        [JsonProperty(PropertyName = "storyline")]
        public string Storyline { get; set; }

        //collection(Collection, optional),
        [JsonProperty(PropertyName = "collection")]
        public long Collection { get; set; }

        //franchise(Franchise, optional),
        [JsonProperty(PropertyName = "franchise")]
        public long Franchise { get; set; }

        //hypes(integer, optional),
        [JsonProperty(PropertyName = "hypes")]
        public int Hypes { get; set; }

        //rating(number, optional),
        [JsonProperty(PropertyName = "rating")]
        public float Rating { get; set; }

        //popularity(number, optional),
        [JsonProperty(PropertyName = "popularity")]
        public float Popularity { get; set; }

        //aggregated_rating(number, optional),
        [JsonProperty(PropertyName = "aggregated_rating")]
        public float AggregatedRating { get; set; }

        //aggregated_rating_count(integer, optional),
        [JsonProperty(PropertyName = "aggregated_rating_count")]
        public int AggregatedRatingCount { get; set; }

        //total_rating(number, optional),
        [JsonProperty(PropertyName = "total_rating")]
        public float TotalRating { get; set; }

        //total_rating_count(integer, optional),
        [JsonProperty(PropertyName = "total_rating_count")]
        public int TotalRatingCount { get; set; }

        //rating_count(integer, optional),
        [JsonProperty(PropertyName = "rating_count")]
        public int RatingCount { get; set; }

        //game(Game, optional),
        [NotMapped]
        [JsonProperty(PropertyName = "game")]
        public Game GameGame { get; set; }

        //tags(Array[integer], optional),
        [NotMapped]
        [JsonProperty(PropertyName = "tags")]
        public int[] Tags { get; set; }

        //developers(Array[integer], optional),
        [NotMapped]
        [JsonProperty(PropertyName = "developers")]
        public ICollection<int> DeveloperIds { get; set; }

        public ICollection<Developer> Developers { get; set; }

        public IList<DevGame> DevGames { get; set; }

        //publishers(Array[integer], optional),
        [NotMapped]
        [JsonProperty(PropertyName = "publishers")]
        public int[] PublisherIds { get; set; }

        public ICollection<Publisher> Publishers { get; set; }

        public IList<PubGame> PubGames { get; set; }

        //game_engines(Array[GameEngine], optional),
        [NotMapped]
        [JsonProperty(PropertyName = "game_engines")]
        public int[] GameEngineIds { get; set; }

        //public ICollection<GameEngine> GameEngines { get; set; }

        //category(integer, optional),
        [JsonProperty(PropertyName = "category")]
        public int Category { get; set; }

        //time_to_beat(object, optional),
        [JsonProperty(PropertyName = "time_to_beat")]
        public TimeToBeat TimeToBeat { get; set; }

        //player_perspectives(Array[PlayerPerspective], optional),
        [NotMapped]
        [JsonProperty(PropertyName = "player_perspectives")]
        public int[] PlayerPerspectives { get; set; }

        //game_modes(Array[GameMode], optional),
        [NotMapped]
        [JsonProperty(PropertyName = "game_modes")]
        public int[] GameModes { get; set; }

        //keywords(Array[Keyword], optional),
        [NotMapped]
        [JsonProperty(PropertyName = "keywords")]
        public int[] Keywords { get; set; }

        //themes(Array[Theme], optional),
        [NotMapped]
        [JsonProperty(PropertyName = "themes")]
        public int[] Themes { get; set; }

        //genres(Array[Genre], optional),
        [NotMapped]
        [JsonProperty(PropertyName = "genres")]
        public int[] GenreIds{ get; set; }

        public ICollection<Genre> Genres { get; set; }

        public IList<GenreGameId> GenreGameIds { get; set; }

        //first_release_date(integer, optional),
        [JsonProperty(PropertyName = "first_release_date")]
        public long FirstReleaseDate { get; set; }

        //status(integer, optional),
        [JsonProperty(PropertyName = "status")]
        public int Status { get; set; }

        //pulse_count(integer, optional),
        [JsonProperty(PropertyName = "pulse_count")]
        public int PulseCount { get; set; }

        //release_dates(Array[Inline Model 1], optional),
        [NotMapped]
        [JsonProperty(PropertyName = "release_date")]
        public int[] ReleaseDateIds { get; set; }

        public ICollection<ReleaseDate> ReleaseDates { get; set; }

        //alternative_names(Array[Inline Model 2], optional),
        [NotMapped]
        [JsonProperty(PropertyName = "alternative_names")]
        public ICollection<AlternativeName> AlternativeNames { get; set; }

        //screenshots(Array[Inline Model 3], optional),
        [NotMapped]
        [JsonProperty(PropertyName = "screenshots")]
        public ICollection<Image> Screenshots { get; set; }

        //videos(Array[Inline Model 4], optional),
        [NotMapped]
        [JsonProperty(PropertyName = "videos")]
        public ICollection<Video> Videos { get; set; }

        public int CoverId { get; set; }

        //cover(object, optional),
        [JsonProperty(PropertyName = "cover")]
        public Cover Cover { get; set; }

        //esrb(object, optional),
        [NotMapped]
        [JsonProperty(PropertyName = "esrb")]
        public Rating Esrb { get; set; }

        //pegi(object, optional),
        [NotMapped]
        [JsonProperty(PropertyName = "pegi")]
        public Rating Pegi{ get; set; }

        //websites(Array[Inline Model 5], optional)
        [NotMapped]
        [JsonProperty(PropertyName = "websites")]
        public ICollection<Website> Websites { get; set; }
    }
}
