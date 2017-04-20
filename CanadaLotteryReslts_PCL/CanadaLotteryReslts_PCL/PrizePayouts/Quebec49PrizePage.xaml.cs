using CanadaLotteryReslts_PCL.AdMob;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CanadaLotteryReslts_PCL.PrizePayouts
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Quebec49PrizePage : ContentPage
    {
        public Quebec49PrizePage()
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
                });
            }
        }
    }
}
