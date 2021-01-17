using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MovieDB.ViewModels
{
    public class DashboardNowPlayingMoviesModel
    {
        public List<DashboardListItem> NowPlayingMovies { get; set; }

        public DashboardNowPlayingMoviesModel()
        {
            this.NowPlayingMovies = new List<DashboardListItem>();
            this.PopulateMovies();
        }

        private void PopulateMovies()
        {
            var nowPlayingMoviesRequest = new Api.TMDB.Requests.MovieNowPlayingRequest();
            var nowPlayingResponse = Api.Api<Api.TMDB.Models.MovieNowPlayingResponse>.SendRequest(nowPlayingMoviesRequest);
            var nowPlayingMovies = nowPlayingResponse.Results.Take(7);

            this.NowPlayingMovies = nowPlayingMovies.Select(x => new DashboardListItem() 
            {
                Title = x.Title,
                ImageUrl = x.PosterPath.FormatMovieImageUrl()
            }).ToList();
        }
    }
}
