using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace MovieDB.DetailReport
{
    public class BaseDetailReport
    {
        // Properties that all responses will have
        public long ID { get; set; }
        public string Title { get; set; }
        public string Url { get; set; }
        public string Type { get; set; }
        public List<Genre> Genres { get; set; }
        public string Status { get; set; }
        public string Runtime { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public string Summary { get; set; }
        public string ImageUrl { get; set; }

        // More specific Properties
        public BelongsToCollection Collection { get; set; }
        public long? Budget { get; set; }
        public long? Revenue { get; set; }
        public List<ProductionCompany> ProductionCompanies { get; set; }
        public List<ProductionCountry> ProductionCountries { get; set; }
        public string Tagline { get; set; }
        public string Rated { get; set; }

        public string Language { get; set; }
        public DateTime? Premiered { get; set; }
        public Schedule Schedule { get; set; }
        public Network Network { get; set; }

        public List<Rating> Ratings { get; set; }
        public Image Image { get; set; }
        public List<string> Awards { get; set; }
        public string Metascore { get; set; }
        public string ImdbRating { get; set; }
        public string ImdbVotes { get; set; }
        public string TotalSeasons { get; set; }
        public List<string> Actors { get; set; }
        public List<string> Writers { get; set; }
        public List<string> Directors { get; set; }


        public BaseDetailReport()
        {
            this.Genres = new List<Genre>();
            this.ProductionCompanies = new List<ProductionCompany>();
            this.ProductionCountries = new List<ProductionCountry>();
            this.Ratings = new List<Rating>();
            this.Actors = new List<string>();
            this.Writers = new List<string>();
            this.Directors = new List<string>();
            this.Awards = new List<string>();
        }

        public BaseDetailReport(Api.OMDb.Models.MovieResponse response)
            : this()
        {

        }

        public BaseDetailReport(Api.TMDB.Models.MovieDetailResponse response)
            : this()
        {

        }

        public BaseDetailReport(Api.OMDb.Models.MovieResponse omdbResponse, Api.TMDB.Models.MovieDetailResponse tmdbResponse)
            : this()
        {
            this.ID = tmdbResponse.ID;
            this.Title = tmdbResponse.Title;

            if (tmdbResponse.Collection != null)
            {
                this.Collection = new BelongsToCollection() 
                { 
                     ID = tmdbResponse.Collection.ID,
                     Name = tmdbResponse.Collection.Name,
                     BackdropPath = tmdbResponse.Collection.BackdropPath,
                     PosterPath = tmdbResponse.Collection.PosterPath
                };
            }

            this.Budget = tmdbResponse.Budget;

            tmdbResponse.Genres.ForEach(x => 
                this.Genres.Add(new Genre() 
                { 
                    ID = x.ID,
                    Name = x.Name
                })
            );

            this.Summary = tmdbResponse.Overview;

            var productionCompanies = tmdbResponse.ProductionCompanies.Select(x => new ProductionCompany() { ID = x.ID, Name = x.Name, Country = x.Country, LogoPath = x.LogoPath }).ToList();
            this.ProductionCompanies.AddRange(productionCompanies);

            var productionCountries = tmdbResponse.ProductionCountries.Select(x => new ProductionCountry() { ISO = x.ISO, Name = x.Name }).ToList();
            this.ProductionCountries.AddRange(productionCountries);

            this.ReleaseDate = tmdbResponse.ReleaseDate;
            this.Revenue = tmdbResponse.Revenue;
            this.Runtime = tmdbResponse.Runtime.ToSafeString();
            this.Status = tmdbResponse.Status;
            this.Tagline = tmdbResponse.Tagline;

            this.Rated = omdbResponse.Rated;
            this.Directors = omdbResponse.Director.ToStringList();
            this.Writers = omdbResponse.Writer.ToStringList();
            this.Actors = omdbResponse.Actors.ToStringList();
            this.Language = omdbResponse.Language;
            this.Awards = omdbResponse.Awards.ToStringList();
            this.Metascore = omdbResponse.Metascore;
            this.ImdbRating = omdbResponse.ImdbRating;
            this.ImdbVotes = omdbResponse.ImdbVotes;
            this.Type = omdbResponse.Type;
            this.TotalSeasons = omdbResponse.TotalSeasons;

            var ratings = omdbResponse.Ratings.Select(x => new Rating() { Source = x.Source, Value = x.Value }).ToList();
            this.Ratings.AddRange(ratings);
        }

        public BaseDetailReport(Api.TVMaze.Models.ShowLookup response)
            : this()
        {
            this.ID = response.ID;
            this.Url = response.Url;
            this.Title = response.Name;
            this.Type = response.Type;
            this.Language = response.Language;

            response.Genres.ForEach(x =>
                this.Genres.Add(new Genre()
                { 
                    ID = (int?)null,
                    Name = x
                })
            );

            this.Status = response.Status;
            this.Runtime = response.Runtime.ToSafeString();
            this.Premiered = response.Premiered;

            if (response.Schedule != null)
            {
                this.Schedule = new Schedule() 
                { 
                    Time = response.Schedule.Time, 
                    Days = response.Schedule.Days 
                };
            }

            if (response.Rating != null)
            {
                this.Ratings.Add(new Rating()
                {
                     Source = string.Empty,
                     Value = response.Rating.Average.ToSafeString()
                });
            }

            if (response.Network != null)
            {
                this.Network = new Network()
                {
                     ID = response.Network.ID,
                     Country = new Country() 
                     { 
                         Name = response.Network.Country.Name,
                         Code = response.Network.Country.Code,
                         Timezone = response.Network.Country.Timezone
                     },
                     Name = response.Network.Name,
                     WebChannel = response.Network.WebChannel
                };
            }

            if (response.Image != null)
            {
                this.Image = new Image() 
                { 
                     Medium = response.Image.Medium,
                    Original = response.Image.Original
                };
            }

            // Let's get the cast
            var castRequest = new Api.TVMaze.Requests.CastRequest(this.ID.ToInt32());
            var castResponse = Api.Api<Api.TVMaze.Models.Cast>.SendListRequest(castRequest);
            if (castResponse != null)
            {
                this.Actors = castResponse.Select(x => x.Person.Name).ToSafeString().ToStringList();
            }
        }
    }

    public class Genre
    {
        public int? ID { get; set; }
        public string Name { get; set; }
    }

    public class BelongsToCollection
    {
        public long? ID { get; set; }
        public string Name { get; set; }
        public string PosterPath { get; set; }
        public string BackdropPath { get; set; }
    }

    public class ProductionCompany
    {
        public int ID { get; set; }
        public string LogoPath { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
    }

    public class ProductionCountry
    {
        public string ISO { get; set; }
        public string Name { get; set; }
    }

    public class Schedule
    {
        public string Time { get; set; }
        public List<string> Days { get; set; }
    }

    public class Rating
    {
        public string Source { get; set; }
        public string Value { get; set; }
    }

    public class Image
    {
        public string Medium { get; set; }
        public string Original { get; set; }
    }
    
    public class Network
    {
        public int? ID { get; set; }
        public string Name { get; set; }
        public Country Country { get; set; }
        public string WebChannel { get; set; }
    }

    public class Country
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public string Timezone { get; set; }
    }
}
