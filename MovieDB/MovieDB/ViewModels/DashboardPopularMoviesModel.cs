using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MovieDB.ViewModels
{
    public class DashboardPopularMoviesModel
    {
        public List<DashboardListItem> PopularMovies { get; set; }

        public DashboardPopularMoviesModel()
        {
            this.PopularMovies = new List<DashboardListItem>();
            this.PopulateMovies();
        }

        private void PopulateMovies()
        {
            var popularMoviesRequest = new Api.TMDB.Requests.MoviePopularRequest();
            var popularResponse = Api.Api<Api.TMDB.Models.MoviePopularResponse>.SendRequest(popularMoviesRequest);
            var popularMovies = popularResponse.Results.Take(7);

            this.PopularMovies = popularMovies.Select(x => new DashboardListItem()
            {
                Title = x.Title,
                ImageUrl = x.PosterPath.FormatMovieImageUrl()
            }).ToList();
        }
    }
}
