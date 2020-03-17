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
    public class Game : Base
    {
        //age_ratings(Array[Inline Model 1], optional),
        [NotMapped]
        [JsonProperty(PropertyName = "age_ratings")]
        public int[] AgeRatingIds { get; set; }

        //public ICollection<AgeRating> AgeRatings { get; set; }

        //aggregated_rating(number, optional),
        [JsonProperty(PropertyName = "aggregated_rating")]
        public float AggregatedRating { get; set; }

        //aggregated_rating_count(integer, optional),
        [JsonProperty(PropertyName = "aggregated_rating_count")]
        public int AggregatedRatingCount { get; set; }

        //alternative_names(Array[Inline Model 2], optional),
        [NotMapped]
        [JsonProperty(PropertyName = "alternative_names")]
        public int[] AlternativeNameIds { get; set; }

        public ICollection<AlternativeName> AlternativeNames { get; set; }

        [NotMapped]
        [JsonProperty(PropertyName = "artworks")]
        public int[] ArtworkIds { get; set; }

        public ICollection<Image> Artworks { get; set; }

        [NotMapped]
        [JsonProperty(PropertyName = "bundles")]
        public int[] BundleIds { get; set; }

        //public ICollection<Game> Bundles { get; set; }

        //category(integer, optional),
        [JsonProperty(PropertyName = "category")]
        public int Category { get; set; }

        //collection(Collection, optional),
        [JsonProperty(PropertyName = "collection")]
        public int CollectionId { get; set; }

        //cover(object, optional),
        [JsonProperty(PropertyName = "cover")]
        public int CoverId { get; set; }

        [NotMapped]
        public Image Cover { get; set; }

        [NotMapped]
        [JsonProperty(PropertyName = "dlcs")]
        public int[] DLCIds { get; set; }

        [NotMapped]
        [JsonProperty(PropertyName = "expansions")]
        public int[] ExpansionIds { get; set; }

        [NotMapped]
        [JsonProperty(PropertyName = "external_games")]
        public int[] ExternalGameIds { get; set; }

        [JsonProperty(PropertyName = "first_release_date")]
        public int FirstReleaseDateUTC { get; set; }

        public DateTime FirstReleaseDate { get; set; }

        [JsonProperty(PropertyName = "follows")]
        public int Follows { get; set; }

        //franchise(Franchise, optional),
        [JsonProperty(PropertyName = "franchise")]
        public long Franchise { get; set; }

        [NotMapped]
        [JsonProperty(PropertyName = "franchises")]
        public long[] Franchises { get; set; }

        [NotMapped]
        [JsonProperty(PropertyName = "game_engines")]
        public int[] GameEngines { get; set; }

        //game_modes(Array[GameMode], optional),
        [NotMapped]
        [JsonProperty(PropertyName = "game_modes")]
        public int[] GameModes { get; set; }

        //genres(Array[Genre], optional),
        [NotMapped]
        [JsonProperty(PropertyName = "genres")]
        public int[] GenreIds{ get; set; }
        
        public ICollection<Genre> Genres { get; set; }

        public IList<GenreGameId> GenreGameIds { get; set; }
        
        //hypes(integer, optional),
        [JsonProperty(PropertyName = "hypes")]
        public int Hypes { get; set; }
        
        [NotMapped]
        [JsonProperty(PropertyName = "involved_companiess")]
        public int[] InvolvedCompanyIds { get; set; }

        //keywords(Array[Keyword], optional),
        [NotMapped]
        [JsonProperty(PropertyName = "keywords")]
        public int[] KeywordIds { get; set; }

        [NotMapped]
        [JsonProperty(PropertyName = "multiplayer_modes")]
        public int[] MultiplayerModeIds { get; set; }

        [JsonProperty(PropertyName = "parent_game")]
        public int ParentGameId { get; set; }

        [NotMapped]
        [JsonProperty(PropertyName = "platforms")]
        public int[] PlatformIds { get; set; }

        //player_perspectives(Array[PlayerPerspective], optional),
        [NotMapped]
        [JsonProperty(PropertyName = "player_perspectives")]
        public int[] PlayerPerspectiveIds { get; set; }

        //popularity(number, optional),
        [JsonProperty(PropertyName = "popularity")]
        public double Popularity { get; set; }

        [JsonProperty(PropertyName = "pulse_count")]
        public int PulseCount { get; set; }

        //rating(number, optional),
        [JsonProperty(PropertyName = "rating")]
        public double Rating { get; set; }

        //rating_count(integer, optional),
        [JsonProperty(PropertyName = "rating_count")]
        public int RatingCount { get; set; }

        //release_dates(Array[Inline Model 1], optional),
        [NotMapped]
        [JsonProperty(PropertyName = "release_dates")]
        public int[] ReleaseDateIds { get; set; }

        public ICollection<ReleaseDate> ReleaseDates { get; set; }

        public IList<ReleaseGameId> ReleaseGameIds { get; set; }

        //screenshots(Array[Inline Model 3], optional),
        [NotMapped]
        [JsonProperty(PropertyName = "screenshots")]
        public int[] ScreenshotIds { get; set; }

        public ICollection<Image> Screenshots { get; set; }

        [NotMapped]
        [JsonProperty(PropertyName = "similar_games")]
        public int[] SimilarGameIds { get; set; }

        [NotMapped]
        [JsonProperty(PropertyName = "standalone_expansions")]
        public int[] StandaloneExpansionIds { get; set; }

        [JsonProperty(PropertyName = "status")]
        public int Status { get; set; }

        //storyline(string, optional),
        [JsonProperty(PropertyName = "storyline")]
        public string Storyline { get; set; }

        //summary(string, optional),
        [JsonProperty(PropertyName = "summary")]
        public string Summary { get; set; }

        //tags(Array[integer], optional),
        [NotMapped]
        [JsonProperty(PropertyName = "tags")]
        public int[] Tags { get; set; }

        //themes(Array[Theme], optional),
        [NotMapped]
        [JsonProperty(PropertyName = "themes")]
        public int[] ThemeIds { get; set; }

        [JsonProperty(PropertyName = "time_to_beat")]
        public int TimeToBeatId { get; set; }

        //total_rating(number, optional),
        [JsonProperty(PropertyName = "total_rating")]
        public float TotalRating { get; set; }

        //total_rating_count(integer, optional),
        [JsonProperty(PropertyName = "total_rating_count")]
        public int TotalRatingCount { get; set; }

        [JsonProperty(PropertyName = "version_parent")]
        public int VersionParentId { get; set; }

        [JsonProperty(PropertyName = "version_title")]
        public string VersionTitle { get; set; }

        [NotMapped]
        [JsonProperty(PropertyName = "videos")]
        public int[] VideoIds { get; set; }

        [NotMapped]
        [JsonProperty(PropertyName = "websites")]
        public int[] WebsiteIds { get; set; }
    }
}
