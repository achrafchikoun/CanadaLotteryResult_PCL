using CanadaLotteryReslts_PCL.AdMob;
using CanadaLotteryReslts_PCL.iOS;
using Google.MobileAds;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using UIKit;
using Xamarin.Forms;

[assembly: Dependency(typeof(AdInterstitial_iOS))]
namespace CanadaLotteryReslts_PCL.iOS
{
    public class AdInterstitial_iOS : IAdInterstitial
    {
        Interstitial interstitial;

        public AdInterstitial_iOS()
        {
            // TODO: change this id to your admob id
            interstitial = new Interstitial("ca-app-pub-3940256099942544/1033173712");
            ShowAd();
        }

        void LoadAd()
        {

            var request = Request.GetDefaultRequest();
            interstitial.LoadRequest(request);
            interstitial.AdReceived += (sender, args) =>
            {
                if (interstitial.IsReady)
                {
                    var viewController = UIApplication.SharedApplication.KeyWindow.RootViewController;
                    interstitial.PresentFromRootViewController(viewController);
                }
            };
        }



        public void ShowAd()
        {
            LoadAd();
        }
    }
}
