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
    public partial class List : ContentPage
    {
        private ListViewModel listviewModel = new ListViewModel();

        public List(IEnumerable<BaseListReport> list)
        {
            InitializeComponent();

            listviewModel.List = list.ToList();

            this.BindingContext = listviewModel;
        }

        private async void ViewCell_Tapped(object sender, EventArgs e)
        {
            var viewCell = (ViewCell)sender;
            var dataRow = (BaseListReport)viewCell.View.BindingContext;

            // need to send to our Movie Detail page and pass the movie title with it
            if (dataRow != null)
            {
                //Navigation.SendTo(typeof(Detail));
                await Navigation.PushAsync(new Detail(dataRow));
            }
        }
    }

    public class ListViewModel
    {
        public List<BaseListReport> List { get; set; }

        public ListViewModel()
        {
            this.List = new List<BaseListReport>();
        }
    }
}