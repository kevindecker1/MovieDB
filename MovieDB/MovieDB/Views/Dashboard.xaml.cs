using MovieDB.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MovieDB.Api.TMDB.Models;

namespace MovieDB
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Dashboard : ContentPage
    {
        private Session _session = null;

        public Dashboard()
        {
            InitializeComponent();

            _session = App.Session;

            var welcomeExpression = "Hi " + _session.GetSessionFirstName() + ",";
            lblName.Text = welcomeExpression;
        }

        private async void txtSearch_Completed(object sender, EventArgs e)
        {
            var searchQuery = txtSearch.Text;
            if (searchQuery.HasValue())
            {
                _session.AddRecentSearch(searchQuery);
                // General search

                List<BaseListReport> List = new List<BaseListReport>();

                // Search by movies first
                var moviesRequest = new Api.TMDB.Requests.MovieListRequest(searchQuery);
                var moviesResponse = Api.Api<Api.TMDB.Models.MovieListResponse>.SendRequest(moviesRequest);

                if (moviesResponse != null && moviesResponse.Results.Any())
                {
                    foreach (Api.TMDB.Models.MovieResult mResult in moviesResponse.Results)
                    {
                        BaseListReport report = new BaseListReport();
                        report.ID = mResult.ID;
                        report.Title = mResult.Title;
                        report.Summary = mResult.Overview;
                        report.ApiSource = Enums.ApiSource.TMDB;

                        var omdbRequest = new Api.OMDb.Requests.MovieRequest(report.Title);
                        var omdbResponse = Api.Api<Api.OMDb.Models.MovieResponse>.SendRequest(omdbRequest);

                        if (omdbResponse != null)
                        {
                            report.ImageUrl = omdbResponse.Poster;
                            report.Rating = omdbResponse.Rated;
                            report.Runtime = omdbResponse.Runtime;
                            report.Type = omdbResponse.Type;
                        }

                        List.Add(report);
                    }
                }

                // search by tv shows
                var showsRequest = new Api.TVMaze.Requests.ShowsRequest(searchQuery);
                var showsResponse = Api.Api<Api.TVMaze.Models.ShowResponse>.SendListRequest(showsRequest);

                if (showsResponse != null && showsResponse.Any())
                {
                    foreach (Api.TVMaze.Models.ShowResponse sResult in showsResponse)
                    {
                        BaseListReport report = new BaseListReport();
                        report.ID = sResult.Show.Externals.TheTVDB.ToInt64();
                        report.Title = sResult.Show.Name;
                        report.ApiSource = Enums.ApiSource.TVMaze;

                        var summary = sResult.Show.Summary;
                        if (summary.HasValue())
                        {
                            summary = summary.RemoveHtmlTags();
                        }

                        report.Summary = summary;
                        report.Rating = string.Empty;

                        var imageUrl = sResult.Show.Image.Medium;
                        if (imageUrl.HasValue())
                        {
                            imageUrl = imageUrl.Replace("http", "https");
                        }

                        report.ImageUrl = imageUrl;
                        report.Runtime = sResult.Show.Runtime + " min";
                        report.Type = "Series";

                        List.Add(report);
                    }
                }

                // search by people
                var peopleRequest = new Api.TMDB.Requests.PersonRequest(searchQuery);
                var peopleResponse = Api.Api<Api.TMDB.Models.PeopleResponse>.SendRequest(peopleRequest);

                if (peopleResponse != null && peopleResponse.Results.Any())
                {
                    foreach (Api.TMDB.Models.PeopleResult pResult in peopleResponse.Results)
                    {
                        BaseListReport report = new BaseListReport();
                        report.Title = pResult.Name;
                        report.Summary = "Known For: " + string.Join(",", pResult.Works.Select(x => x.Title));
                        report.Rating = string.Empty;
                        report.Type = pResult.Career;
                        report.ImageUrl = pResult.ProfilePath;
                        report.Runtime = string.Empty;
                        report.ApiSource = Enums.ApiSource.TMDB;

                        List.Add(report);
                    }
                }

                if (List.Any())
                {
                    var listCount = _session.ListCount;
                    var takeResults = List.Take(listCount);
                    takeResults = takeResults.OrderByDescending(t => t.Title.Equals(searchQuery));

                    await Navigation.PushAsync(new List(takeResults));
                }
                else
                {
                    // No results found
                }
            }
            else
            {
                
            }
        }

        private void ViewCell_Tapped(object sender, EventArgs e)
        {

        }

        private void txtSearch_Focused(object sender, FocusEventArgs e)
        {
            var list = new List<string>() { "peaky blinders", "girls" };
            RecentSearches.IsVisible = true;
            RecentSearches.ItemsSource = list;
            //var recentSearches = _session.GetRecentSearches();
            //if (recentSearches.Any())
            //{
            //    RecentSearches.IsVisible = true;
            //    RecentSearches.ItemsSource = recentSearches;
            //}
        }

        private void txtSearch_Unfocused(object sender, FocusEventArgs e)
        {
            RecentSearches.FadeTo(0);
            RecentSearches.IsVisible = false;
        }
    }
}