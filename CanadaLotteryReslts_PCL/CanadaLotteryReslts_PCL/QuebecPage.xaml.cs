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
    public partial class QuebecPage : ContentPage
    {
        public QuebecPage()
        {
            InitializeComponent();
        }

        private void btnLottoQuebec49Prize_Clicked(object sender, EventArgs e)
        {
            if (!CrossConnectivity.Current.IsConnected)
            {
                DisplayAlert("Error", "Connect to the internet and try again.", "OK");
                return;
            }
            Navigation.PushAsync(new Quebec49PrizePage());
        }

        private void btnLottoQuebec49Statitics_Clicked(object sender, EventArgs e)
        {
            if (!CrossConnectivity.Current.IsConnected)
            {
                DisplayAlert("Error", "Connect to the internet and try again.", "OK");
                return;
            }
            Navigation.PushAsync(new Quebec49StatisticsPage());
        }

        private void btnAstroHistorical_Clicked(object sender, EventArgs e)
        {

        }

        private void btnBancoHistorical_Clicked(object sender, EventArgs e)
        {

        }

        private void btnExtraHistorical_Clicked(object sender, EventArgs e)
        {

        }

        private void btnLaMiniHistorical_Clicked(object sender, EventArgs e)
        {

        }

        private void btnQuotidienne3Historical_Clicked(object sender, EventArgs e)
        {

        }

        private void btnQuotidienne4Historical_Clicked(object sender, EventArgs e)
        {

        }

        private void btnLottoDHistorical_Clicked(object sender, EventArgs e)
        {

        }

        private void btnLottoQuebecMaxStatitics_Clicked(object sender, EventArgs e)
        {
            if (!CrossConnectivity.Current.IsConnected)
            {
                DisplayAlert("Error", "Connect to the internet and try again.", "OK");
                return;
            }
            Navigation.PushAsync(new QuebecMaxStatisticsPage());
        }

        private void btnLottoQuebecMaxPrize_Clicked(object sender, EventArgs e)
        {
            if (!CrossConnectivity.Current.IsConnected)
            {
                DisplayAlert("Error", "Connect to the internet and try again.", "OK");
                return;
            }
            Navigation.PushAsync(new QuebecMaxPrizePage());
        }

        private void btnTriplexHistorical_Clicked(object sender, EventArgs e)
        {

        }

        private void btnSprintoHistorical_Clicked(object sender, EventArgs e)
        {

        }

        private void btnToutouRienHistorical_Clicked(object sender, EventArgs e)
        {

        }
    }
}
