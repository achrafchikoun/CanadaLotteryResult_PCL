using Acr.UserDialogs;
using CanadaLotteryReslts_PCL.AdMob;
using CanadaLotteryReslts_PCL.Historical;
using CanadaLotteryReslts_PCL.PrizePayouts;
using CanadaLotteryReslts_PCL.Statistics;
using Newtonsoft.Json;
using Plugin.Connectivity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CanadaLotteryReslts_PCL
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WesternPage : ContentPage
    {
        IAdInterstitial adInterstitial;

        public WesternPage()
        {
            InitializeComponent();

            GlobalVariable.count++;

            if (GlobalVariable.count == 4)
            {
                GlobalVariable.count = 0;

                adInterstitial = DependencyService.Get<IAdInterstitial>();

                adInterstitial.ShowAd();
            }

            Device.BeginInvokeOnMainThread(() =>
            {
                callAPI();
            });
        }

        private async Task callAPI()
        {
            UserDialogs.Instance.ShowLoading("Veuillez patienter...", MaskType.Black);
            try
            {
                HttpClient client = new HttpClient();
                var uri = new Uri("http://mobixapp.com/loto_canada_api/Api/getLastWestern");
                var response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    dynamic responseJson = JsonConvert.DeserializeObject(content);
                    dynamic output = responseJson[0];

                    //western_649
                    dynamic western_649 = output["western_649"];
                    western_649_n1.Text = western_649[0]["n1"].Value;
                    western_649_n2.Text = western_649[0]["n2"].Value;
                    western_649_n3.Text = western_649[0]["n3"].Value;
                    western_649_n4.Text = western_649[0]["n4"].Value;
                    western_649_n5.Text = western_649[0]["n5"].Value;
                    western_649_n6.Text = western_649[0]["n6"].Value;
                    western_649_n7.Text = western_649[0]["n7"].Value;
                    western_649_tirage_du.Text = western_649[0]["tirage_du"].Value;

                    //western_extra
                    dynamic western_extra = output["western_extra"];
                    extra_n1.Text = western_extra[0]["n1"].Value;
                    extra_tirage_du.Text = western_extra[0]["tirage_du"].Value;

                    //western_max
                    dynamic western_max = output["western_max"];
                    western_max_n1.Text = western_max[0]["n1"].Value;
                    western_max_n2.Text = western_max[0]["n2"].Value;
                    western_max_n3.Text = western_max[0]["n3"].Value;
                    western_max_n4.Text = western_max[0]["n4"].Value;
                    western_max_n5.Text = western_max[0]["n5"].Value;
                    western_max_n6.Text = western_max[0]["n6"].Value;
                    western_max_n7.Text = western_max[0]["n7"].Value;
                    western_max_n8.Text = western_max[0]["n8"].Value;
                    western_max_tirage_du.Text = western_max[0]["tirage_du"].Value;

                    //western_pick_3
                    dynamic western_pick_3 = output["western_pick_3"];
                    pick_3_n1.Text = western_pick_3[0]["n1"].Value;
                    pick_3_n2.Text = western_pick_3[0]["n2"].Value;
                    pick_3_n3.Text = western_pick_3[0]["n3"].Value;
                    pick_3_tirage_du.Text = western_pick_3[0]["tirage_du"].Value;


                    UserDialogs.Instance.HideLoading();
                }
            }
            catch (Exception ex)
            {
                UserDialogs.Instance.HideLoading();
                await DisplayAlert("Erreur", "Une erreur s'est produite, réessayer à nouveau.", "OK");
                //Debug.WriteLine(@"ERROR {0}", ex.Message);
            }
        }

        private void btnLottoWestern649Prize_Clicked(object sender, EventArgs e)
        {
            if (!CrossConnectivity.Current.IsConnected)
            {
                DisplayAlert("Error", "Connect to the internet and try again.", "OK");
                return;
            }
            Navigation.PushAsync(new Western649PrizePage());
        }

        private void btnLottoWestern649Statitics_Clicked(object sender, EventArgs e)
        {
            if (!CrossConnectivity.Current.IsConnected)
            {
                DisplayAlert("Error", "Connect to the internet and try again.", "OK");
                return;
            }
            Navigation.PushAsync(new Western649StatisticsPage());
        }

        private void btnExtraHistorical_Clicked(object sender, EventArgs e)
        {
            if (!CrossConnectivity.Current.IsConnected)
            {
                DisplayAlert("Error", "Connect to the internet and try again.", "OK");
                return;
            }
            Navigation.PushAsync(new WesternExtraHistoricalPage());
        }

        private void btnWesternMaxPrize_Clicked(object sender, EventArgs e)
        {
            if (!CrossConnectivity.Current.IsConnected)
            {
                DisplayAlert("Error", "Connect to the internet and try again.", "OK");
                return;
            }
            Navigation.PushAsync(new WesternMaxPrizePage());
        }

        private void btnWesternMaxStatitics_Clicked(object sender, EventArgs e)
        {
            if (!CrossConnectivity.Current.IsConnected)
            {
                DisplayAlert("Error", "Connect to the internet and try again.", "OK");
                return;
            }
            Navigation.PushAsync(new WesternMaxStatisticsPage());
        }

        private void btnPick3Historical_Clicked(object sender, EventArgs e)
        {
            if (!CrossConnectivity.Current.IsConnected)
            {
                DisplayAlert("Error", "Connect to the internet and try again.", "OK");
                return;
            }
            Navigation.PushAsync(new WesternPick3HistoricalPage());
        }
    }
}
