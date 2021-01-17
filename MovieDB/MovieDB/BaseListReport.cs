using System;
using System.Collections.Generic;
using System.Text;

namespace MovieDB
{
    /// <summary>
    /// This class is used to convert our API responses into a reusable class for our List pages
    /// </summary>
    public class BaseListReport
    {
        public long ID { get; set; }
        public string Title { get; set; }
        public string Summary { get; set; }
        public string ImageUrl { get; set; }
        public string Rating { get; set; }
        public string Type { get; set; }
        public string Runtime { get; set; }
        public Enums.ApiSource ApiSource { get; set; }

        public string Description
        {
            get
            {
                var rating = string.Empty;
                if (this.Rating.HasValue())
                {
                    rating = $"Rating: {this.Rating}  ";
                }

                var runtime = string.Empty;
                if (this.Runtime.HasValue())
                {
                    if (!this.Runtime.EndsWith("min"))
                    {
                        this.Runtime += " min";
                    }

                    runtime = $"Runtime: {this.Runtime}  ";
                }

                var type = string.Empty;
                if (this.Type.HasValue())
                {
                    type = $" {this.Type.Capitalize()}";
                }

                var str = string.Empty;
                if (rating.HasValue())
                {
                    str += rating;
                }

                if (runtime.HasValue())
                {
                    str += runtime;
                }

                if (type.HasValue())
                {
                    str += type;
                }

                return str.Trim();
            }
        }

        public BaseListReport() { }

        //public BaseListReport(Api.OMDb.Models.MovieResponse omdbResponse, Api.TMDB.Models.MovieResult tmdbResponse, Api.TVMaze.Models.Show tvMazeResponse)
        //{
        //    if (omdbResponse != null)
        //    {
        //        this.Rating = omdbResponse.Rated;
        //        this.Runtime = omdbResponse.Runtime;
        //        this.ImageUrl = omdbResponse.Poster;
        //        this.Type = omdbResponse.Type;
        //    }

        //    if (tmdbResponse != null)
        //    {
        //        this.Title = tmdbResponse.Title;
        //        this.Summary = tmdbResponse.Overview;

        //        if (!this.Type.HasValue())
        //        {
        //            this.Type = "Film";
        //        }
        //    }

        //    if (tvMazeResponse != null)
        //    {
        //        this.Title = tvMazeResponse.Name;
        //        this.Runtime = tvMazeResponse.Runtime.ToSafeString() + " min";
        //        this.ImageUrl = tvMazeResponse.Image.Medium;
        //        this.Type = tvMazeResponse.Type;
        //        this.Summary = tvMazeResponse.Summary;
        //        this.Rating = string.Empty;
        //    }
        //}
    }
}
