﻿using Acr.UserDialogs;
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
    public partial class OntarioEncoreEveningPage : ContentPage
    {
        public OntarioEncoreEveningPage()
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
                var encores = new List<Encore>();
                HttpClient client = new HttpClient();
                var uri = new Uri("http://mobixapp.com/loto_canada_api/Api/getAllOntario_Encore_Evening");
                var response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var responseJson = JsonConvert.DeserializeObject(content);
                    JArray output = JArray.Parse(responseJson.ToString());

                    for (int i = 0; i < output.Count; i++)
                    {
                        string n1 = output.ElementAt(i)["n1"].ToString();
                        string tirage_du = output.ElementAt(i)["tirage_du"].ToString();
                        encores.Add(new Encore { n1 = n1, tirage_du = tirage_du });

                    }
                    listView.ItemsSource = encores;

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
