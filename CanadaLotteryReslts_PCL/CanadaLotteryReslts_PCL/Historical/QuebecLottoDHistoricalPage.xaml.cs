using Acr.UserDialogs;
using CanadaLotteryReslts_PCL.AdMob;
using CanadaLotteryReslts_PCL.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CanadaLotteryReslts_PCL.Historical
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class QuebecLottoDHistoricalPage : ContentPage
    {
        public QuebecLottoDHistoricalPage()
        {
            InitializeComponent();

            GlobalVariable.count++;

            Device.BeginInvokeOnMainThread(() =>
            {
                if (GlobalVariable.count == 4)
                {
                    GlobalVariable.count = 0;

                    IAdInterstitial adInterstitial = DependencyService.Get<IAdInterstitial>();

                    adInterstitial.ShowAd();
                }

                callAPI();
            });
        }

        private async Task callAPI()
        {
            UserDialogs.Instance.ShowLoading("Please wait...", MaskType.Black);
            try
            {
                var lottoDs = new List<LottoD>();
                HttpClient client = new HttpClient();
                var uri = new Uri("http://mobixapp.com/loto_canada_api/Api/getAllQuebec_Lotto_D");
                var response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var responseJson = JsonConvert.DeserializeObject(content);
                    JArray output = JArray.Parse(responseJson.ToString());

                    for (int i = 0; i < output.Count; i++)
                    {
                        string n1 = output.ElementAt(i)["n1"].ToString();
                        string n2 = output.ElementAt(i)["n2"].ToString();
                        string n3 = output.ElementAt(i)["n3"].ToString();
                        string n4 = output.ElementAt(i)["n4"].ToString();
                        string n5 = output.ElementAt(i)["n5"].ToString();
                        string n6 = output.ElementAt(i)["n6"].ToString();
                        string n7 = output.ElementAt(i)["n7"].ToString();
                        string n8 = output.ElementAt(i)["n8"].ToString();
                        string tirage_du = output.ElementAt(i)["tirage_du"].ToString();
                        lottoDs.Add(new LottoD { n1 = n1, n2 = n2, n3 = n3, n4 = n4, n5 = n5, n6 = n6, n7 = n7, n8 = n8, tirage_du = tirage_du });

                    }
                    listView.ItemsSource = lottoDs;

                    UserDialogs.Instance.HideLoading();
                }
            }
            catch (Exception ex)
            {
                UserDialogs.Instance.HideLoading();
                await DisplayAlert("Error", "An error has occurred, please try again.", "OK");
                //Debug.WriteLine(@"ERROR {0}", ex.Message);
            }
        }
    }
}
