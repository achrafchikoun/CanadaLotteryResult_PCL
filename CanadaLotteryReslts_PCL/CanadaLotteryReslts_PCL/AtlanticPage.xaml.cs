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
    public partial class AtlanticPage : ContentPage
    {
        IAdInterstitial adInterstitial;

        public AtlanticPage()
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
                var uri = new Uri("http://mobixapp.com/loto_canada_api/Api/getLastAtlantic");
                var response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    dynamic responseJson = JsonConvert.DeserializeObject(content);
                    dynamic output = responseJson[0];

                    //atlantic_49
                    dynamic atlantic_49 = output["atlantic_49"];
                    atlantic_49_n1.Text = atlantic_49[0]["n1"].Value;
                    atlantic_49_n2.Text = atlantic_49[0]["n2"].Value;
                    atlantic_49_n3.Text = atlantic_49[0]["n3"].Value;
                    atlantic_49_n4.Text = atlantic_49[0]["n4"].Value;
                    atlantic_49_n5.Text = atlantic_49[0]["n5"].Value;
                    atlantic_49_n6.Text = atlantic_49[0]["n6"].Value;
                    atlantic_49_n7.Text = atlantic_49[0]["n7"].Value;
                    atlantic_49_tirage_du.Text = atlantic_49[0]["tirage_du"].Value;

                    //atlantic_salsa_bing
                    dynamic atlantic_bucko = output["atlantic_bucko"];
                    bucko_n1.Text = atlantic_bucko[0]["n1"].Value;
                    bucko_n2.Text = atlantic_bucko[0]["n2"].Value;
                    bucko_n3.Text = atlantic_bucko[0]["n3"].Value;
                    bucko_n4.Text = atlantic_bucko[0]["n4"].Value;
                    bucko_n5.Text = atlantic_bucko[0]["n5"].Value;
                    bucko_tirage_du.Text = atlantic_bucko[0]["tirage_du"].Value;

                    //atlantic_salsa_bing
                    dynamic atlantic_salsa_bing = output["atlantic_salsa_bing"];
                    salsa_bingo_n1.Text = atlantic_salsa_bing[0]["n1"].Value;
                    salsa_bingo_n2.Text = atlantic_salsa_bing[0]["n2"].Value;
                    salsa_bingo_n3.Text = atlantic_salsa_bing[0]["n3"].Value;
                    salsa_bingo_n4.Text = atlantic_salsa_bing[0]["n4"].Value;
                    salsa_bingo_n5.Text = atlantic_salsa_bing[0]["n5"].Value;
                    salsa_bingo_n6.Text = atlantic_salsa_bing[0]["n6"].Value;
                    salsa_bingo_n7.Text = atlantic_salsa_bing[0]["n7"].Value;
                    salsa_bingo_n8.Text = atlantic_salsa_bing[0]["n8"].Value;
                    salsa_bingo_n9.Text = atlantic_salsa_bing[0]["n9"].Value;
                    salsa_bingo_n10.Text = atlantic_salsa_bing[0]["n10"].Value;
                    salsa_bingo_n11.Text = atlantic_salsa_bing[0]["n11"].Value;
                    salsa_bingo_n12.Text = atlantic_salsa_bing[0]["n12"].Value;
                    salsa_bingo_n13.Text = atlantic_salsa_bing[0]["n13"].Value;
                    salsa_bingo_n14.Text = atlantic_salsa_bing[0]["n14"].Value;
                    salsa_bingo_n15.Text = atlantic_salsa_bing[0]["n15"].Value;
                    salsa_bingo_n16.Text = atlantic_salsa_bing[0]["n16"].Value;
                    salsa_bingo_n17.Text = atlantic_salsa_bing[0]["n17"].Value;
                    salsa_bingo_n18.Text = atlantic_salsa_bing[0]["n18"].Value;
                    salsa_bingo_n19.Text = atlantic_salsa_bing[0]["n19"].Value;
                    salsa_bingo_n20.Text = atlantic_salsa_bing[0]["n20"].Value;
                    salsa_bingo_n21.Text = atlantic_salsa_bing[0]["n21"].Value;
                    salsa_bingo_n22.Text = atlantic_salsa_bing[0]["n22"].Value;
                    salsa_bingo_n23.Text = atlantic_salsa_bing[0]["n23"].Value;
                    salsa_bingo_n24.Text = atlantic_salsa_bing[0]["n24"].Value;
                    salsa_bingo_n25.Text = atlantic_salsa_bing[0]["n25"].Value;
                    salsa_bingo_n26.Text = atlantic_salsa_bing[0]["n26"].Value;
                    salsa_bingo_n27.Text = atlantic_salsa_bing[0]["n27"].Value;
                    salsa_bingo_n28.Text = atlantic_salsa_bing[0]["n28"].Value;
                    salsa_bingo_tirage_du.Text = atlantic_salsa_bing[0]["tirage_du"].Value;

                    //atlantic_tag
                    dynamic atlantic_tag = output["atlantic_tag"];
                    tag_n1.Text = atlantic_tag[0]["n1"].Value;
                    tag_tirage_du.Text = atlantic_tag[0]["tirage_du"].Value;

                    //atlantic_keno
                    dynamic atlantic_keno = output["atlantic_keno"];
                    keno_n1.Text = atlantic_keno[0]["n1"].Value;
                    keno_n2.Text = atlantic_keno[0]["n2"].Value;
                    keno_n3.Text = atlantic_keno[0]["n3"].Value;
                    keno_n4.Text = atlantic_keno[0]["n4"].Value;
                    keno_n5.Text = atlantic_keno[0]["n5"].Value;
                    keno_n6.Text = atlantic_keno[0]["n6"].Value;
                    keno_n7.Text = atlantic_keno[0]["n7"].Value;
                    keno_n8.Text = atlantic_keno[0]["n8"].Value;
                    keno_n9.Text = atlantic_keno[0]["n9"].Value;
                    keno_n10.Text = atlantic_keno[0]["n10"].Value;
                    keno_n11.Text = atlantic_keno[0]["n11"].Value;
                    keno_n12.Text = atlantic_keno[0]["n12"].Value;
                    keno_n13.Text = atlantic_keno[0]["n13"].Value;
                    keno_n14.Text = atlantic_keno[0]["n14"].Value;
                    keno_n15.Text = atlantic_keno[0]["n15"].Value;
                    keno_n16.Text = atlantic_keno[0]["n16"].Value;
                    keno_n17.Text = atlantic_keno[0]["n17"].Value;
                    keno_n18.Text = atlantic_keno[0]["n18"].Value;
                    keno_n19.Text = atlantic_keno[0]["n19"].Value;
                    keno_n20.Text = atlantic_keno[0]["n20"].Value;
                    keno_tirage_du.Text = atlantic_keno[0]["tirage_du"].Value;


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
            if (!CrossConnectivity.Current.IsConnected)
            {
                DisplayAlert("Error", "Connect to the internet and try again.", "OK");
                return;
            }
            Navigation.PushAsync(new AtlanticBuckoHistoricalPage());
        }

        private void btnLottoSalsaHistorical_Clicked(object sender, EventArgs e)
        {
            if (!CrossConnectivity.Current.IsConnected)
            {
                DisplayAlert("Error", "Connect to the internet and try again.", "OK");
                return;
            }
            Navigation.PushAsync(new AtlanticSalsaBingoHistoricalPage());
        }

        private void btnLottoTagHistorical_Clicked(object sender, EventArgs e)
        {
            if (!CrossConnectivity.Current.IsConnected)
            {
                DisplayAlert("Error", "Connect to the internet and try again.", "OK");
                return;
            }
            Navigation.PushAsync(new AtlanticTagHistoricalPage());
        }

        private void btnLottoKenoHistorical_Clicked(object sender, EventArgs e)
        {
            if (!CrossConnectivity.Current.IsConnected)
            {
                DisplayAlert("Error", "Connect to the internet and try again.", "OK");
                return;
            }
            Navigation.PushAsync(new AtlanticKenoHistoricalPage());
        }
    }
}
