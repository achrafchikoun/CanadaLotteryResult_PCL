using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CanadaLotteryReslts_PCL
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MasterPage : ContentPage
    {
        public ListView ListView { get { return listView; } }

        public MasterPage()
        {
            InitializeComponent();

            var masterPageItems = new List<MasterPageItem>();
            masterPageItems.Add(new MasterPageItem
            {
                Title = "National",
                IconSource = "ic_menu.png",
                TargetType = typeof(HomePage)
            });
            masterPageItems.Add(new MasterPageItem
            {
                Title = "Atlantic Canada",
                IconSource = "ic_menu.png",
                TargetType = typeof(AtlanticPage)
            });
            masterPageItems.Add(new MasterPageItem
            {
                Title = "Ontario",
                IconSource = "ic_menu.png",
                TargetType = typeof(OntarioPage)
            });
            masterPageItems.Add(new MasterPageItem
            {
                Title = "Quebec",
                IconSource = "ic_menu.png",
                TargetType = typeof(QuebecPage)
            });
            masterPageItems.Add(new MasterPageItem
            {
                Title = "Western Canada",
                IconSource = "ic_menu.png",
                TargetType = typeof(WesternPage)
            });
            masterPageItems.Add(new MasterPageItem
            {
                Title = "British Columbia",
                IconSource = "ic_menu.png",
                TargetType = typeof(BritishColumbiaPage)
            });

            listView.ItemsSource = masterPageItems;
        }
    }
}
