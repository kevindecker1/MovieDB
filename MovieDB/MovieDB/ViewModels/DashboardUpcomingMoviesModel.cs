using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MovieDB.ViewModels
{
    public class DashboardUpcomingMoviesModel
    {
        public List<DashboardListItem> UpcomingMovies { get; set; }

        public DashboardUpcomingMoviesModel()
        {
            this.UpcomingMovies = new List<DashboardListItem>();
            this.PopulateMovies();
        }

        private void PopulateMovies()
        {
            var upcomingMoviesRequest = new Api.TMDB.Requests.MovieUpcomingRequest();
            var upcomingResponse = Api.Api<Api.TMDB.Models.MovieUpcomingResponse>.SendRequest(upcomingMoviesRequest);
            var upcomingMovies = upcomingResponse.Results.Take(7);

            this.UpcomingMovies = upcomingMovies.Select(x => new DashboardListItem()
            {
                Title = x.Title,
                ImageUrl = x.PosterPath.FormatMovieImageUrl()
            }).ToList();
        }
    }
}
