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
    public partial class OntarioPage : ContentPage
    {
        IAdInterstitial adInterstitial;

        public OntarioPage()
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
                var uri = new Uri("http://mobixapp.com/loto_canada_api/Api/getLastOntario");
                var response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    dynamic responseJson = JsonConvert.DeserializeObject(content);
                    dynamic output = responseJson[0];

                    //ontario_49
                    dynamic ontario_49 = output["ontario_49"];
                    ontario_49_n1.Text = ontario_49[0]["n1"].Value;
                    ontario_49_n2.Text = ontario_49[0]["n2"].Value;
                    ontario_49_n3.Text = ontario_49[0]["n3"].Value;
                    ontario_49_n4.Text = ontario_49[0]["n4"].Value;
                    ontario_49_n5.Text = ontario_49[0]["n5"].Value;
                    ontario_49_n6.Text = ontario_49[0]["n6"].Value;
                    ontario_49_n7.Text = ontario_49[0]["n7"].Value;
                    ontario_49_tirage_du.Text = ontario_49[0]["tirage_du"].Value;

                    //ontario_lottario
                    dynamic ontario_lottario = output["ontario_lottario"];
                    lottario_n1.Text = ontario_lottario[0]["n1"].Value;
                    lottario_n2.Text = ontario_lottario[0]["n2"].Value;
                    lottario_n3.Text = ontario_lottario[0]["n3"].Value;
                    lottario_n4.Text = ontario_lottario[0]["n4"].Value;
                    lottario_n5.Text = ontario_lottario[0]["n5"].Value;
                    lottario_n6.Text = ontario_lottario[0]["n6"].Value;
                    lottario_n7.Text = ontario_lottario[0]["n7"].Value;
                    lottario_tirage_du.Text = ontario_lottario[0]["tirage_du"].Value;

                    //ontario_megadice
                    dynamic ontario_megadice = output["ontario_megadice"];
                    megadice_n1.Text = ontario_megadice[0]["n1"].Value;
                    megadice_n2.Text = ontario_megadice[0]["n2"].Value;
                    megadice_n3.Text = ontario_megadice[0]["n3"].Value;
                    megadice_n4.Text = ontario_megadice[0]["n4"].Value;
                    megadice_n5.Text = ontario_megadice[0]["n5"].Value;
                    megadice_n6.Text = ontario_megadice[0]["n6"].Value;
                    megadice_n7.Text = ontario_megadice[0]["n7"].Value;
                    megadice_tirage_du.Text = ontario_megadice[0]["tirage_du"].Value;

                    //ontario_encore_midday
                    dynamic ontario_encore_midday = output["ontario_encore_midday"];
                    encore_midday_n1.Text = ontario_encore_midday[0]["n1"].Value;
                    encore_midday_tirage_du.Text = ontario_encore_midday[0]["tirage_du"].Value;

                    //ontario_encore_evening
                    dynamic ontario_encore_evening = output["ontario_encore_evening"];
                    encore_evening_n1.Text = ontario_encore_evening[0]["n1"].Value;
                    encore_evening_tirage_du.Text = ontario_encore_evening[0]["tirage_du"].Value;

                    //ontario_pick_2_midday
                    dynamic ontario_pick_2_midday = output["ontario_pick_2_midday"];
                    pick_2_midday_n1.Text = ontario_pick_2_midday[0]["n1"].Value;
                    pick_2_midday_n2.Text = ontario_pick_2_midday[0]["n2"].Value;
                    lottario_tirage_du.Text = ontario_pick_2_midday[0]["tirage_du"].Value;

                    //ontario_pick_2_evening
                    dynamic ontario_pick_2_evening = output["ontario_pick_2_evening"];
                    pick_2_midday_n1.Text = ontario_pick_2_evening[0]["n1"].Value;
                    pick_2_midday_n2.Text = ontario_pick_2_evening[0]["n2"].Value;
                    lottario_tirage_du.Text = ontario_pick_2_evening[0]["tirage_du"].Value;

                    //ontario_pick_3_midday
                    dynamic ontario_pick_3_midday = output["ontario_pick_3_midday"];
                    pick_3_midday_n1.Text = ontario_pick_3_midday[0]["n1"].Value;
                    pick_3_midday_n2.Text = ontario_pick_3_midday[0]["n2"].Value;
                    pick_3_midday_n3.Text = ontario_pick_3_midday[0]["n3"].Value;
                    pick_3_midday_tirage_du.Text = ontario_pick_3_midday[0]["tirage_du"].Value;

                    //ontario_pick_3_evening
                    dynamic ontario_pick_3_evening = output["ontario_pick_3_evening"];
                    pick_3_evening_n1.Text = ontario_pick_3_evening[0]["n1"].Value;
                    pick_3_evening_n2.Text = ontario_pick_3_evening[0]["n2"].Value;
                    pick_3_evening_n3.Text = ontario_pick_3_evening[0]["n3"].Value;
                    pick_3_evening_tirage_du.Text = ontario_pick_3_evening[0]["tirage_du"].Value;

                    //ontario_pick_4_midday
                    dynamic ontario_pick_4_midday = output["ontario_pick_4_midday"];
                    pick_4_midday_n1.Text = ontario_pick_4_midday[0]["n1"].Value;
                    pick_4_midday_n2.Text = ontario_pick_4_midday[0]["n2"].Value;
                    pick_4_midday_n3.Text = ontario_pick_4_midday[0]["n3"].Value;
                    pick_4_midday_n4.Text = ontario_pick_4_midday[0]["n4"].Value;
                    pick_4_midday_tirage_du.Text = ontario_pick_4_midday[0]["tirage_du"].Value;

                    //ontario_pick_4_evening
                    dynamic ontario_pick_4_evening = output["ontario_pick_4_evening"];
                    pick_4_evening_n1.Text = ontario_pick_4_evening[0]["n1"].Value;
                    pick_4_evening_n2.Text = ontario_pick_4_evening[0]["n2"].Value;
                    pick_4_evening_n3.Text = ontario_pick_4_evening[0]["n3"].Value;
                    pick_4_evening_n4.Text = ontario_pick_4_evening[0]["n4"].Value;
                    pick_4_evening_tirage_du.Text = ontario_pick_4_evening[0]["tirage_du"].Value;

                    //ontario_keno_midday
                    dynamic ontario_keno_midday = output["ontario_keno_midday"];
                    keno_midday_n1.Text = ontario_keno_midday[0]["n1"].Value;
                    keno_midday_n2.Text = ontario_keno_midday[0]["n2"].Value;
                    keno_midday_n3.Text = ontario_keno_midday[0]["n3"].Value;
                    keno_midday_n4.Text = ontario_keno_midday[0]["n4"].Value;
                    keno_midday_n5.Text = ontario_keno_midday[0]["n5"].Value;
                    keno_midday_n6.Text = ontario_keno_midday[0]["n6"].Value;
                    keno_midday_n7.Text = ontario_keno_midday[0]["n7"].Value;
                    keno_midday_n8.Text = ontario_keno_midday[0]["n8"].Value;
                    keno_midday_n9.Text = ontario_keno_midday[0]["n9"].Value;
                    keno_midday_n10.Text = ontario_keno_midday[0]["n10"].Value;
                    keno_midday_n11.Text = ontario_keno_midday[0]["n11"].Value;
                    keno_midday_n12.Text = ontario_keno_midday[0]["n12"].Value;
                    keno_midday_n13.Text = ontario_keno_midday[0]["n13"].Value;
                    keno_midday_n14.Text = ontario_keno_midday[0]["n14"].Value;
                    keno_midday_n15.Text = ontario_keno_midday[0]["n15"].Value;
                    keno_midday_n16.Text = ontario_keno_midday[0]["n16"].Value;
                    keno_midday_n17.Text = ontario_keno_midday[0]["n17"].Value;
                    keno_midday_n18.Text = ontario_keno_midday[0]["n18"].Value;
                    keno_midday_n19.Text = ontario_keno_midday[0]["n19"].Value;
                    keno_midday_n20.Text = ontario_keno_midday[0]["n20"].Value;
                    keno_midday_tirage_du.Text = ontario_keno_midday[0]["tirage_du"].Value;

                    //ontario_keno_evening
                    dynamic ontario_keno_evening = output["ontario_keno_evening"];
                    keno_evening_n1.Text = ontario_keno_evening[0]["n1"].Value;
                    keno_evening_n2.Text = ontario_keno_evening[0]["n2"].Value;
                    keno_evening_n3.Text = ontario_keno_evening[0]["n3"].Value;
                    keno_evening_n4.Text = ontario_keno_evening[0]["n4"].Value;
                    keno_evening_n5.Text = ontario_keno_evening[0]["n5"].Value;
                    keno_evening_n6.Text = ontario_keno_evening[0]["n6"].Value;
                    keno_evening_n7.Text = ontario_keno_evening[0]["n7"].Value;
                    keno_evening_n8.Text = ontario_keno_evening[0]["n8"].Value;
                    keno_evening_n9.Text = ontario_keno_evening[0]["n9"].Value;
                    keno_evening_n10.Text = ontario_keno_evening[0]["n10"].Value;
                    keno_evening_n11.Text = ontario_keno_evening[0]["n11"].Value;
                    keno_evening_n12.Text = ontario_keno_evening[0]["n12"].Value;
                    keno_evening_n13.Text = ontario_keno_evening[0]["n13"].Value;
                    keno_evening_n14.Text = ontario_keno_evening[0]["n14"].Value;
                    keno_evening_n15.Text = ontario_keno_evening[0]["n15"].Value;
                    keno_evening_n16.Text = ontario_keno_evening[0]["n16"].Value;
                    keno_evening_n17.Text = ontario_keno_evening[0]["n17"].Value;
                    keno_evening_n18.Text = ontario_keno_evening[0]["n18"].Value;
                    keno_evening_n19.Text = ontario_keno_evening[0]["n19"].Value;
                    keno_evening_n20.Text = ontario_keno_evening[0]["n20"].Value;
                    keno_evening_tirage_du.Text = ontario_keno_evening[0]["tirage_du"].Value;


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

        private void btnEncoreMiddayHistorical_Clicked(object sender, EventArgs e)
        {
            if (!CrossConnectivity.Current.IsConnected)
            {
                DisplayAlert("Error", "Connect to the internet and try again.", "OK");
                return;
            }
            Navigation.PushAsync(new OntarioEncoreMiddayPage());
        }

        private void btnEncoreEveningHistorical_Clicked(object sender, EventArgs e)
        {
            if (!CrossConnectivity.Current.IsConnected)
            {
                DisplayAlert("Error", "Connect to the internet and try again.", "OK");
                return;
            }
            Navigation.PushAsync(new OntarioEncoreEveningPage());
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
            if (!CrossConnectivity.Current.IsConnected)
            {
                DisplayAlert("Error", "Connect to the internet and try again.", "OK");
                return;
            }
            Navigation.PushAsync(new OntarioKenoEveningPage());
        }

        private void btnKenoMiddayHistorical_Clicked(object sender, EventArgs e)
        {
            if (!CrossConnectivity.Current.IsConnected)
            {
                DisplayAlert("Error", "Connect to the internet and try again.", "OK");
                return;
            }
            Navigation.PushAsync(new OntarioKenoMiddayPage());
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
            if (!CrossConnectivity.Current.IsConnected)
            {
                DisplayAlert("Error", "Connect to the internet and try again.", "OK");
                return;
            }
            Navigation.PushAsync(new OntarioPick2MiddayPage());
        }

        private void btnPick2EveningHistorical_Clicked(object sender, EventArgs e)
        {
            if (!CrossConnectivity.Current.IsConnected)
            {
                DisplayAlert("Error", "Connect to the internet and try again.", "OK");
                return;
            }
            Navigation.PushAsync(new OntarioPick2EveningPage());
        }

        private void btnPick3MiddayHistorical_Clicked(object sender, EventArgs e)
        {
            if (!CrossConnectivity.Current.IsConnected)
            {
                DisplayAlert("Error", "Connect to the internet and try again.", "OK");
                return;
            }
            Navigation.PushAsync(new OntarioPick3MiddayPage());
        }

        private void btnPick3EveningHistorical_Clicked(object sender, EventArgs e)
        {
            if (!CrossConnectivity.Current.IsConnected)
            {
                DisplayAlert("Error", "Connect to the internet and try again.", "OK");
                return;
            }
            Navigation.PushAsync(new OntarioPick3EveningPage());
        }

        private void btnPick4MiddayHistorical_Clicked(object sender, EventArgs e)
        {
            if (!CrossConnectivity.Current.IsConnected)
            {
                DisplayAlert("Error", "Connect to the internet and try again.", "OK");
                return;
            }
            Navigation.PushAsync(new OntarioPick4MiddayPage());
        }

        private void btnPick4EveningHistorical_Clicked(object sender, EventArgs e)
        {
            if (!CrossConnectivity.Current.IsConnected)
            {
                DisplayAlert("Error", "Connect to the internet and try again.", "OK");
                return;
            }
            Navigation.PushAsync(new OntarioPick4EveningPage());
        }
    }
}
