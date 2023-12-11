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

        private async void BtnScheduleManagment_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SchedulePage()); 
        }

        private async void BtnService_Clicked(object sender, EventArgs e) //Se creo este boton
        {
            await Navigation.PushAsync(new ServicePage());
        }

       
        private async void BtnProducto_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ProductPage());
        }

        private async void BtnOfert_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new OfertPage());
        }

        private async void BtnCancel_Cliked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}