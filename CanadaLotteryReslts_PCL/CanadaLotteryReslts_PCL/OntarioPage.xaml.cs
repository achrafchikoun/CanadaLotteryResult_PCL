using CanadaLotteryReslts_PCL.PrizePayouts;
using CanadaLotteryReslts_PCL.Statistics;
using Plugin.Connectivity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CanadaLotteryReslts_PCL
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class OntarioPage : ContentPage
    {
        public OntarioPage()
        {
            InitializeComponent();
        }

        private void btnEncoreMiddayHistorical_Clicked(object sender, EventArgs e)
        {

        }

        private void btnEncoreEveningHistorical_Clicked(object sender, EventArgs e)
        {

        }

        private void btnMegaDicePrize_Clicked(object sender, EventArgs e)
        {
            if (!CrossConnectivity.Current.IsConnected)
            {
                DisplayAlert("Error", "Connect to the internet and try again.", "OK");
                return;
            }
            Navigation.PushAsync(new OntarioMegadicePrizePage());
        }

        private void btnMegaDiceStatitics_Clicked(object sender, EventArgs e)
        {
            if (!CrossConnectivity.Current.IsConnected)
            {
                DisplayAlert("Error", "Connect to the internet and try again.", "OK");
                return;
            }
            Navigation.PushAsync(new OntarioMegadiceStatisticsPage());
        }

        private void btnOntario49Prize_Clicked(object sender, EventArgs e)
        {
            if (!CrossConnectivity.Current.IsConnected)
            {
                DisplayAlert("Error", "Connect to the internet and try again.", "OK");
                return;
            }
            Navigation.PushAsync(new Ontario49PrizePage());
        }

        private void btnOntario49Statitics_Clicked(object sender, EventArgs e)
        {
            if (!CrossConnectivity.Current.IsConnected)
            {
                DisplayAlert("Error", "Connect to the internet and try again.", "OK");
                return;
            }
            Navigation.PushAsync(new Ontario49StatisticsPage());
        }

        private void btnKenoEveningHistorical_Clicked(object sender, EventArgs e)
        {

        }

        private void btnKenoMiddayHistorical_Clicked(object sender, EventArgs e)
        {

        }

        private void btnLottarioPrize_Clicked(object sender, EventArgs e)
        {
            if (!CrossConnectivity.Current.IsConnected)
            {
                DisplayAlert("Error", "Connect to the internet and try again.", "OK");
                return;
            }
            Navigation.PushAsync(new OntarioLottarioPrizePage());
        }

        private void btnLottarioStatitics_Clicked(object sender, EventArgs e)
        {
            if (!CrossConnectivity.Current.IsConnected)
            {
                DisplayAlert("Error", "Connect to the internet and try again.", "OK");
                return;
            }
            Navigation.PushAsync(new OntarioLottarioStatisticsPage());
        }

        private void btnPick2MiddayHistorical_Clicked(object sender, EventArgs e)
        {

        }

        private void btnPick2EveningHistorical_Clicked(object sender, EventArgs e)
        {

        }

        private void btnPick3MiddayHistorical_Clicked(object sender, EventArgs e)
        {

        }

        private void btnPick3EveningHistorical_Clicked(object sender, EventArgs e)
        {

        }

        private void btnPick4MiddayHistorical_Clicked(object sender, EventArgs e)
        {

        }

        private void btnPick4EveningHistorical_Clicked(object sender, EventArgs e)
        {

        }
    }
}
