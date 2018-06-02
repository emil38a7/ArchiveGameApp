using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ArchiveGameApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoadingPage : ContentPage
    {

        public LoadingPage()
        {
            //httpServices = new httpService();
            InitializeComponent();
            RotateElement();
            //LoadQuestion();
        }
        private async Task RotateElement()
        {
            while (true)
            {
                await loadingImage.RotateTo(360, 2000, Easing.Linear);
                await loadingImage.RotateTo(0, 0);
            }
        }
    }
}

