using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MiniSuperPF_YustinA.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class OptionsPage : ContentPage
    {
        public OptionsPage()
        {
            InitializeComponent();
        }

        private async void BtnServiceManagment_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MyServiceListPage());
        }

        private async void BtnUserManagment_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new UserManagmentPage());
        }



    }
}