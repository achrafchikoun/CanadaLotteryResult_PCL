using Acr.UserDialogs;
using CanadaLotteryReslts_PCL.AdMob;
using CanadaLotteryReslts_PCL.Details;
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
    public partial class HomePage : ContentPage
    {

        public HomePage()
        {
            InitializeComponent();

            NavigationPage.SetBackButtonTitle(this, "");

            GlobalVariable.count++;

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
                var uri = new Uri("http://mobixapp.com/loto_canada_api/Api/getLastNational");
                var response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    dynamic responseJson = JsonConvert.DeserializeObject(content);
                    dynamic output = responseJson[0];

                    //lotto_max
                    dynamic lotto_max = output["lotto_max"];
                    lotto_max_n1.Text = lotto_max[0]["n1"].Value;
                    lotto_max_n2.Text = lotto_max[0]["n2"].Value;
                    lotto_max_n3.Text = lotto_max[0]["n3"].Value;
                    lotto_max_n4.Text = lotto_max[0]["n4"].Value;
                    lotto_max_n5.Text = lotto_max[0]["n5"].Value;
                    lotto_max_n6.Text = lotto_max[0]["n6"].Value;
                    lotto_max_n7.Text = lotto_max[0]["n7"].Value;
                    lotto_max_n8.Text = lotto_max[0]["n8"].Value;
                    lotto_max_tirage_du.Text = lotto_max[0]["tirage_du"].Value;

                    //lotto_649
                    dynamic lotto_649 = output["lotto_649"];
                    lotto_649_n1.Text = lotto_649[0]["n1"].Value;
                    lotto_649_n2.Text = lotto_649[0]["n2"].Value;
                    lotto_649_n3.Text = lotto_649[0]["n3"].Value;
                    lotto_649_n4.Text = lotto_649[0]["n4"].Value;
                    lotto_649_n5.Text = lotto_649[0]["n5"].Value;
                    lotto_649_n6.Text = lotto_649[0]["n6"].Value;
                    lotto_649_n7.Text = lotto_649[0]["n7"].Value;
                    lotto_649_tirage_du.Text = lotto_649[0]["tirage_du"].Value;

                    //daily_grand
                    dynamic daily_grand = output["daily_grand"];
                    daily_grand_n1.Text = daily_grand[0]["n1"].Value;
                    daily_grand_n2.Text = daily_grand[0]["n2"].Value;
                    daily_grand_n3.Text = daily_grand[0]["n3"].Value;
                    daily_grand_n4.Text = daily_grand[0]["n4"].Value;
                    daily_grand_n5.Text = daily_grand[0]["n5"].Value;
                    daily_grand_n6.Text = daily_grand[0]["n6"].Value;
                    daily_grand_tirage_du.Text = daily_grand[0]["tirage_du"].Value;


                    UserDialogs.Instance.HideLoading();

                    IAdInterstitial adInterstitial = DependencyService.Get<IAdInterstitial>();

                    adInterstitial.ShowAd();
                }
            }
            catch (Exception ex)
            {
                UserDialogs.Instance.HideLoading();
                await DisplayAlert("Erreur", "Une erreur s'est produite, réessayer à nouveau.", "OK");
                //Debug.WriteLine(@"ERROR {0}", ex.Message);
            }
        }

        private void btnLottoMaxDetail_Clicked(object sender, EventArgs e)
        {
            if (!CrossConnectivity.Current.IsConnected)
            {
                DisplayAlert("Error", "Connect to the internet and try again.", "OK");
                return;
            }
            Navigation.PushAsync(new LottoMaxDetailsPage());
        }

        private void btnLottoMaxPrize_Clicked(object sender, EventArgs e)
        {
            if (!CrossConnectivity.Current.IsConnected)
            {
                DisplayAlert("Error", "Connect to the internet and try again.", "OK");
                return;
            }
            Navigation.PushAsync(new LottoMaxPrizePage());
        }

        private void btnLottoMaxStatitics_Clicked(object sender, EventArgs e)
        {
            if (!CrossConnectivity.Current.IsConnected)
            {
                DisplayAlert("Error", "Connect to the internet and try again.", "OK");
                return;
            }
            Navigation.PushAsync(new LottoMaxStatisticsPage());
        }

        private void btnLotto649Detail_Clicked(object sender, EventArgs e)
        {
            if (!CrossConnectivity.Current.IsConnected)
            {
                DisplayAlert("Error", "Connect to the internet and try again.", "OK");
                return;
            }
            Navigation.PushAsync(new Lotto649DetailsPage());
        }

        private void btnLotto649Prize_Clicked(object sender, EventArgs e)
        {
            if (!CrossConnectivity.Current.IsConnected)
            {
                DisplayAlert("Error", "Connect to the internet and try again.", "OK");
                return;
            }
            Navigation.PushAsync(new Lotto649PrizePage());
        }

        private void btnLotto649Statitics_Clicked(object sender, EventArgs e)
        {
            if (!CrossConnectivity.Current.IsConnected)
            {
                DisplayAlert("Error", "Connect to the internet and try again.", "OK");
                return;
            }
            Navigation.PushAsync(new Lotto649StatiticsPage());
        }

        private void btnDailyDetail_Clicked(object sender, EventArgs e)
        {
            if (!CrossConnectivity.Current.IsConnected)
            {
                DisplayAlert("Error", "Connect to the internet and try again.", "OK");
                return;
            }
            Navigation.PushAsync(new DailyGrandDetailsPage());
        }

        private void btnDailyPrize_Clicked(object sender, EventArgs e)
        {
            if (!CrossConnectivity.Current.IsConnected)
            {
                DisplayAlert("Error", "Connect to the internet and try again.", "OK");
                return;
            }
            Navigation.PushAsync(new DailyGrandPrizePage());
        }

        private void btnDailyStatitics_Clicked(object sender, EventArgs e)
        {
            if (!CrossConnectivity.Current.IsConnected)
            {
                DisplayAlert("Error", "Connect to the internet and try again.", "OK");
                return;
            }
            Navigation.PushAsync(new DailyGrandStatiticsPage());
        }
    }
}
