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
    public partial class AtlanticSalsaBingoHistoricalPage : ContentPage
    {
        public AtlanticSalsaBingoHistoricalPage()
        {
            InitializeComponent();

            GlobalVariable.count++;
            if (GlobalVariable.count == 4)
            {
                GlobalVariable.count = 0;
                Device.BeginInvokeOnMainThread(() =>
                {
                    IAdInterstitial adInterstitial = DependencyService.Get<IAdInterstitial>();

                    adInterstitial.ShowAd();

                    callAPI();
                });
            }
        }

        private async Task callAPI()
        {
            UserDialogs.Instance.ShowLoading("Please wait...", MaskType.Black);
            try
            {
                var salsaBingos = new List<SalsaBingo>();
                HttpClient client = new HttpClient();
                var uri = new Uri("http://mobixapp.com/loto_canada_api/Api/getAllAtlantic_Salsa_Bing");
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
                        string n9 = output.ElementAt(i)["n9"].ToString();
                        string n10 = output.ElementAt(i)["n10"].ToString();
                        string n11 = output.ElementAt(i)["n11"].ToString();
                        string n12 = output.ElementAt(i)["n12"].ToString();
                        string n13 = output.ElementAt(i)["n13"].ToString();
                        string n14 = output.ElementAt(i)["n14"].ToString();
                        string n15 = output.ElementAt(i)["n15"].ToString();
                        string n16 = output.ElementAt(i)["n16"].ToString();
                        string n17 = output.ElementAt(i)["n17"].ToString();
                        string n18 = output.ElementAt(i)["n18"].ToString();
                        string n19 = output.ElementAt(i)["n19"].ToString();
                        string n20 = output.ElementAt(i)["n20"].ToString();
                        string n21 = output.ElementAt(i)["n21"].ToString();
                        string n22 = output.ElementAt(i)["n22"].ToString();
                        string n23 = output.ElementAt(i)["n23"].ToString();
                        string n24 = output.ElementAt(i)["n24"].ToString();
                        string n25 = output.ElementAt(i)["n25"].ToString();
                        string n26 = output.ElementAt(i)["n26"].ToString();
                        string n27 = output.ElementAt(i)["n27"].ToString();
                        string n28 = output.ElementAt(i)["n28"].ToString();
                        string tirage_du = output.ElementAt(i)["tirage_du"].ToString();
                        salsaBingos.Add(new SalsaBingo { n1 = n1, n2 = n2, n3 = n3, n4 = n4, n5 = n5, n6 = n6, n7 = n7, n8 = n8, n9 = n9, n10 = n10, n11 = n11, n12 = n12, n13 = n13, n14 = n14, n15 = n15, n16 = n16, n17 = n17, n18 = n18, n19 = n19, n20 = n20, n21 = n21, n22 = n22, n23 = n23, n24 = n24, n25 = n25, n26 = n26, n27 = n27, n28 = n28, tirage_du = tirage_du });

                    }
                    listView.ItemsSource = salsaBingos;

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
