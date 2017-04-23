using CanadaLotteryReslts_PCL.AdMob;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace CanadaLotteryReslts_PCL
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new CanadaLotteryReslts_PCL.MainPage();
            /*MainPage = new NavigationPage(new MainPage())
            {
                BarBackgroundColor = Color.FromHex("#01477e"),
                BarTextColor = Color.White,
            };*/

            

        }

        protected override void OnStart()
        {
            
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            
        }
    }
}
