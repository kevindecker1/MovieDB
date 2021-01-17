using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MovieDB
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Detail : ContentPage
    {
        private DetailReport.BaseDetailReport DetailReport { get; set; }

        public Detail(BaseListReport report)
        {
            InitializeComponent();

            if (report != null)
            {
                var responses = _getDetailResponses(report);
                if (responses.Count > 1)
                {
                    var tmdbResponse = responses.Where(x => x.GetType() == typeof(Api.TMDB.Models.MovieDetailResponse)).FirstOrDefault();
                    var omdbResponse = responses.Where(x => x.GetType() == typeof(Api.OMDb.Models.MovieResponse)).FirstOrDefault();
                    DetailReport = new DetailReport.BaseDetailReport((Api.OMDb.Models.MovieResponse)omdbResponse, (Api.TMDB.Models.MovieDetailResponse)tmdbResponse);
                }
                else
                {
                    DetailReport = new DetailReport.BaseDetailReport((Api.TVMaze.Models.ShowLookup)responses.FirstOrDefault());
                }
            }
        }

        private List<Api.BaseResponse> _getDetailResponses(BaseListReport report)
        {
            List<Api.BaseResponse> responses = new List<Api.BaseResponse>();
            switch (report.ApiSource)
            {
                case Enums.ApiSource.TMDB:
                case Enums.ApiSource.OMDb:
                    var tmdbRequest = new Api.TMDB.Requests.MovieDetailRequest(report.ID.ToInt32());
                    var tmdbReponse = Api.Api<Api.TMDB.Models.MovieDetailResponse>.SendRequest(tmdbRequest);

                    var omdbRequest = new Api.OMDb.Requests.MovieRequest(tmdbReponse.Title);
                    var omdbResponse = Api.Api<Api.OMDb.Models.MovieResponse>.SendRequest(omdbRequest);

                    responses.Add(tmdbReponse);
                    responses.Add(omdbResponse);
                    break;
                case Enums.ApiSource.TMS:
                    break;
                case Enums.ApiSource.TVMaze:
                    var tvMazeRequest = new Api.TVMaze.Requests.ShowRequest();
                    tvMazeRequest.TheTVDB = report.ID;

                    var tvMazeResponse = Api.Api<Api.TVMaze.Models.ShowLookup>.SendRequest(tvMazeRequest);
                    responses.Add(tvMazeResponse);
                    break;
                default:
                    break;
            }

            return responses;
        }

        public class Responses
        {
            public Api.BaseResponse Response { get; set; }
            public Enums.ApiSource Source { get; set; }
        }
    }
}