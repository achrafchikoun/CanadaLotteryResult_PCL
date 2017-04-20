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
    public partial class QuebecPage : ContentPage
    {
        IAdInterstitial adInterstitial;

        public QuebecPage()
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
                var uri = new Uri("http://mobixapp.com/loto_canada_api/Api/getLastQuebec");
                var response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    dynamic responseJson = JsonConvert.DeserializeObject(content);
                    dynamic output = responseJson[0];

                    //quebec_49
                    dynamic quebec_49 = output["quebec_49"];
                    quebec_49_n1.Text = quebec_49[0]["n1"].Value;
                    quebec_49_n2.Text = quebec_49[0]["n2"].Value;
                    quebec_49_n3.Text = quebec_49[0]["n3"].Value;
                    quebec_49_n4.Text = quebec_49[0]["n4"].Value;
                    quebec_49_n5.Text = quebec_49[0]["n5"].Value;
                    quebec_49_n6.Text = quebec_49[0]["n6"].Value;
                    quebec_49_n7.Text = quebec_49[0]["n7"].Value;
                    quebec_49_tirage_du.Text = quebec_49[0]["tirage_du"].Value;

                    //quebec_astro
                    dynamic quebec_astro = output["quebec_astro"];
                    astro_n1.Text = quebec_astro[0]["n1"].Value;
                    astro_n2.Text = quebec_astro[0]["n2"].Value;
                    astro_n3.Text = quebec_astro[0]["n3"].Value;
                    astro_n4.Text = quebec_astro[0]["n4"].Value;
                    astro_tirage_du.Text = quebec_49[0]["tirage_du"].Value;

                    //quebec_banco
                    dynamic quebec_banco = output["quebec_banco"];
                    banco_n1.Text = quebec_banco[0]["n1"].Value;
                    banco_n2.Text = quebec_banco[0]["n2"].Value;
                    banco_n3.Text = quebec_banco[0]["n3"].Value;
                    banco_n4.Text = quebec_banco[0]["n4"].Value;
                    banco_n5.Text = quebec_banco[0]["n5"].Value;
                    banco_n6.Text = quebec_banco[0]["n6"].Value;
                    banco_n7.Text = quebec_banco[0]["n7"].Value;
                    banco_n8.Text = quebec_banco[0]["n8"].Value;
                    banco_n9.Text = quebec_banco[0]["n9"].Value;
                    banco_n10.Text = quebec_banco[0]["n10"].Value;
                    banco_n11.Text = quebec_banco[0]["n11"].Value;
                    banco_n12.Text = quebec_banco[0]["n12"].Value;
                    banco_n13.Text = quebec_banco[0]["n13"].Value;
                    banco_n14.Text = quebec_banco[0]["n14"].Value;
                    banco_n15.Text = quebec_banco[0]["n15"].Value;
                    banco_n16.Text = quebec_banco[0]["n16"].Value;
                    banco_n17.Text = quebec_banco[0]["n17"].Value;
                    banco_n18.Text = quebec_banco[0]["n18"].Value;
                    banco_n19.Text = quebec_banco[0]["n19"].Value;
                    banco_n20.Text = quebec_banco[0]["n20"].Value;
                    banco_tirage_du.Text = quebec_banco[0]["tirage_du"].Value;

                    //quebec_extra
                    dynamic quebec_extra = output["quebec_extra"];
                    extra_n1.Text = quebec_extra[0]["n1"].Value;
                    extra_tirage_du.Text = quebec_extra[0]["tirage_du"].Value;

                    //quebec_la_mini
                    dynamic quebec_la_mini = output["quebec_la_mini"];
                    la_mini_n1.Text = quebec_la_mini[0]["n1"].Value;
                    la_mini_tirage_du.Text = quebec_la_mini[0]["tirage_du"].Value;

                    //quebec_le_quotidienne_3
                    dynamic quebec_le_quotidienne_3 = output["quebec_le_quotidienne_3"];
                    la_quotidienne_3_n1.Text = quebec_le_quotidienne_3[0]["n1"].Value;
                    la_quotidienne_3_n2.Text = quebec_le_quotidienne_3[0]["n2"].Value;
                    la_quotidienne_3_n3.Text = quebec_le_quotidienne_3[0]["n3"].Value;
                    la_quotidienne_3_tirage_du.Text = quebec_le_quotidienne_3[0]["tirage_du"].Value;

                    //quebec_le_quotidienne_4
                    dynamic quebec_le_quotidienne_4 = output["quebec_le_quotidienne_4"];
                    la_quotidienne_4_n1.Text = quebec_le_quotidienne_4[0]["n1"].Value;
                    la_quotidienne_4_n2.Text = quebec_le_quotidienne_4[0]["n2"].Value;
                    la_quotidienne_4_n3.Text = quebec_le_quotidienne_4[0]["n3"].Value;
                    la_quotidienne_4_n4.Text = quebec_le_quotidienne_4[0]["n4"].Value;
                    la_quotidienne_4_tirage_du.Text = quebec_le_quotidienne_4[0]["tirage_du"].Value;

                    //quebec_lotto_d
                    dynamic quebec_lotto_d = output["quebec_lotto_d"];
                    lotto_d_n1.Text = quebec_lotto_d[0]["n1"].Value;
                    lotto_d_n2.Text = quebec_lotto_d[0]["n2"].Value;
                    lotto_d_n3.Text = quebec_lotto_d[0]["n3"].Value;
                    lotto_d_n4.Text = quebec_lotto_d[0]["n4"].Value;
                    lotto_d_n5.Text = quebec_lotto_d[0]["n5"].Value;
                    lotto_d_n6.Text = quebec_lotto_d[0]["n6"].Value;
                    lotto_d_n7.Text = quebec_lotto_d[0]["n7"].Value;
                    lotto_d_n8.Text = quebec_lotto_d[0]["n8"].Value;
                    lotto_d_tirage_du.Text = quebec_lotto_d[0]["tirage_du"].Value;

                    //quebec_max
                    dynamic quebec_max = output["quebec_max"];
                    quebec_max_n1.Text = quebec_max[0]["n1"].Value;
                    quebec_max_n2.Text = quebec_max[0]["n2"].Value;
                    quebec_max_n3.Text = quebec_max[0]["n3"].Value;
                    quebec_max_n4.Text = quebec_max[0]["n4"].Value;
                    quebec_max_n5.Text = quebec_max[0]["n5"].Value;
                    quebec_max_n6.Text = quebec_max[0]["n6"].Value;
                    quebec_max_n7.Text = quebec_max[0]["n7"].Value;
                    quebec_max_n8.Text = quebec_max[0]["n8"].Value;
                    quebec_max_tirage_du.Text = quebec_max[0]["tirage_du"].Value;

                    //quebec_sprinto
                    dynamic quebec_sprinto = output["quebec_sprinto"];
                    sprinto_n1.Text = quebec_sprinto[0]["n1"].Value;
                    sprinto_n2.Text = quebec_sprinto[0]["n2"].Value;
                    sprinto_n3.Text = quebec_sprinto[0]["n3"].Value;
                    sprinto_n4.Text = quebec_sprinto[0]["n4"].Value;
                    sprinto_n5.Text = quebec_sprinto[0]["n5"].Value;
                    sprinto_tirage_du.Text = quebec_sprinto[0]["tirage_du"].Value;

                    //quebec_tout_ou_rien
                    dynamic quebec_tout_ou_rien = output["quebec_tout_ou_rien"];
                    toutourien_n1.Text = quebec_tout_ou_rien[0]["n1"].Value;
                    toutourien_n2.Text = quebec_tout_ou_rien[0]["n2"].Value;
                    toutourien_n3.Text = quebec_tout_ou_rien[0]["n3"].Value;
                    toutourien_n4.Text = quebec_tout_ou_rien[0]["n4"].Value;
                    toutourien_n5.Text = quebec_tout_ou_rien[0]["n5"].Value;
                    toutourien_n6.Text = quebec_tout_ou_rien[0]["n6"].Value;
                    toutourien_n7.Text = quebec_tout_ou_rien[0]["n7"].Value;
                    toutourien_n8.Text = quebec_tout_ou_rien[0]["n8"].Value;
                    toutourien_n9.Text = quebec_tout_ou_rien[0]["n9"].Value;
                    toutourien_n10.Text = quebec_tout_ou_rien[0]["n10"].Value;
                    toutourien_n11.Text = quebec_tout_ou_rien[0]["n11"].Value;
                    toutourien_n12.Text = quebec_tout_ou_rien[0]["n12"].Value;
                    toutourien_tirage_du.Text = quebec_tout_ou_rien[0]["tirage_du"].Value;

                    //quebec_triplex
                    dynamic quebec_triplex = output["quebec_triplex"];
                    triplex_n1.Text = quebec_triplex[0]["n1"].Value;
                    triplex_n2.Text = quebec_triplex[0]["n2"].Value;
                    triplex_n3.Text = quebec_triplex[0]["n3"].Value;
                    triplex_n4.Text = quebec_triplex[0]["n4"].Value;
                    triplex_n5.Text = quebec_triplex[0]["n5"].Value;
                    triplex_tirage_du.Text = quebec_triplex[0]["tirage_du"].Value;


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
            if (!CrossConnectivity.Current.IsConnected)
            {
                DisplayAlert("Error", "Connect to the internet and try again.", "OK");
                return;
            }
            Navigation.PushAsync(new QuebecAstroHistoricalPage());
        }

        private void btnBancoHistorical_Clicked(object sender, EventArgs e)
        {
            if (!CrossConnectivity.Current.IsConnected)
            {
                DisplayAlert("Error", "Connect to the internet and try again.", "OK");
                return;
            }
            Navigation.PushAsync(new QuebecBancoHistoricalPage());
        }

        private void btnExtraHistorical_Clicked(object sender, EventArgs e)
        {
            if (!CrossConnectivity.Current.IsConnected)
            {
                DisplayAlert("Error", "Connect to the internet and try again.", "OK");
                return;
            }
            Navigation.PushAsync(new QuebecExtraHistoricalPage());
        }

        private void btnLaMiniHistorical_Clicked(object sender, EventArgs e)
        {
            if (!CrossConnectivity.Current.IsConnected)
            {
                DisplayAlert("Error", "Connect to the internet and try again.", "OK");
                return;
            }
            Navigation.PushAsync(new QuebecLaMiniHistoricalPage());
        }

        private void btnQuotidienne3Historical_Clicked(object sender, EventArgs e)
        {
            if (!CrossConnectivity.Current.IsConnected)
            {
                DisplayAlert("Error", "Connect to the internet and try again.", "OK");
                return;
            }
            Navigation.PushAsync(new QuebecLaQuotidienne3HistoricalPage());
        }

        private void btnQuotidienne4Historical_Clicked(object sender, EventArgs e)
        {
            if (!CrossConnectivity.Current.IsConnected)
            {
                DisplayAlert("Error", "Connect to the internet and try again.", "OK");
                return;
            }
            Navigation.PushAsync(new QuebecLaQuotidienne4HistoricalPage());
        }

        private void btnLottoDHistorical_Clicked(object sender, EventArgs e)
        {
            if (!CrossConnectivity.Current.IsConnected)
            {
                DisplayAlert("Error", "Connect to the internet and try again.", "OK");
                return;
            }
            Navigation.PushAsync(new QuebecLottoDHistoricalPage());
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
            if (!CrossConnectivity.Current.IsConnected)
            {
                DisplayAlert("Error", "Connect to the internet and try again.", "OK");
                return;
            }
            Navigation.PushAsync(new QuebecTriplexHistoricalPage());
        }

        private void btnSprintoHistorical_Clicked(object sender, EventArgs e)
        {
            if (!CrossConnectivity.Current.IsConnected)
            {
                DisplayAlert("Error", "Connect to the internet and try again.", "OK");
                return;
            }
            Navigation.PushAsync(new QuebecSprintoHistoricalPage());
        }

        private void btnToutouRienHistorical_Clicked(object sender, EventArgs e)
        {
            if (!CrossConnectivity.Current.IsConnected)
            {
                DisplayAlert("Error", "Connect to the internet and try again.", "OK");
                return;
            }
            Navigation.PushAsync(new QuebecToutOuRienHistoricalPage());
        }
    }
}
