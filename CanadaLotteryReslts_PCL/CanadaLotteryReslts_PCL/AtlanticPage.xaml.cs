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
    public partial class AtlanticPage : ContentPage
    {
        public AtlanticPage()
        {
            InitializeComponent();
        }

        private void btnLottoAtlantic49Prize_Clicked(object sender, EventArgs e)
        {
            if (!CrossConnectivity.Current.IsConnected)
            {
                DisplayAlert("Error", "Connect to the internet and try again.", "OK");
                return;
            }
            Navigation.PushAsync(new Atlantic49PrizePage());
        }

        private void btnLottoAtlantic49Statitics_Clicked(object sender, EventArgs e)
        {
            if (!CrossConnectivity.Current.IsConnected)
            {
                DisplayAlert("Error", "Connect to the internet and try again.", "OK");
                return;
            }
            Navigation.PushAsync(new Atlantic49StatiticsPage());
        }

        private void btnLottoBuckoHistorical_Clicked(object sender, EventArgs e)
        {

        }

        private void btnLottoSalsaHistorical_Clicked(object sender, EventArgs e)
        {

        }

        private void btnLottoTagHistorical_Clicked(object sender, EventArgs e)
        {

        }

        private void btnLottoKenoHistorical_Clicked(object sender, EventArgs e)
        {

        }
    }
}
