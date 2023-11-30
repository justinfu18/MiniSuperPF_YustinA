using Acr.UserDialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using MiniSuperPF_YustinA.ViewModels;

namespace MiniSuperPF_YustinA.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ServiceLoginPage : ContentPage
    {

        UserViewModel viewModel;
        public ServiceLoginPage()
        {
            InitializeComponent();

            this.BindingContext = viewModel = new UserViewModel();

        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            //Login

            bool R = false;
            if (TxtEmail.Text != null && ! string.IsNullOrEmpty(TxtEmail.Text.Trim()) &&
                TxtPassword.Text != null && !string.IsNullOrEmpty(TxtPassword.Text.Trim()) )

            {
                try
                {
                    UserDialogs.Instance.ShowLoading("Revisando el acceso de Usuario");
                    await Task.Delay(2000);

                    string email = TxtEmail.Text.Trim();
                    string password = TxtPassword.Text.Trim();
                    
                    R = await viewModel.UserAccessValidation(email, password);
               
                
                }
                catch (Exception)
                {

                    throw;
                }
                finally
                {
                    UserDialogs.Instance.HideLoading();
                }
            }

            else
            {
                await DisplayAlert("Error de Validacion", "Correo y Contraseña son requeridos!", "OK");
                return;
            }

           if (R)
            {

               
                await Navigation.PushAsync(new OptionsPage());
                    return;
            }
           else
            {
                 await DisplayAlert("Validacion Denegada", "Acceso Denegado!", "OK");
                return;
            }


        }

        private async void BtnSignUp_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SignUpPage());
        }
    }
}