using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MiniSuperPF_YustinA.Models;
using MiniSuperPF_YustinA.ViewModels;



namespace MiniSuperPF_YustinA.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SignUpPage : ContentPage
    {
        UserViewModel viewModel;


        public SignUpPage()
        {
            InitializeComponent();
            BindingContext= viewModel = new UserViewModel();

            LoadUserRolesList();
        }

        private async void LoadUserRolesList()
        {
            PickerUserRole.ItemsSource = await viewModel.GetUserRoles();

        }

        private void B(object sender, EventArgs e)
        {

        }

        private async void BtnCancel_Cliked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

      
        private async void Aplicar_Cliked(object sender, EventArgs e)
        {
            UserRole SelectedUserRole = PickerUserRole.SelectedItem as UserRole;


            bool R = await viewModel.AddUser(TxtEmail.Text.Trim(),
                                      TxtName.Text.Trim(),
                                     TxtPhoneNumber.Text.Trim(),
                                      TxtPassword.Text.Trim(),
                                     TxtAddress.Text.Trim(),
                                     TxtCardID.Text.Trim(),
                                      SelectedUserRole.UserRoleId);

            if (R)
            {
                await DisplayAlert(".....", "Usuario agregado al sistema", "OK");
                await Navigation.PopAsync();
            }
            else
            {
                await DisplayAlert(".....", "Algo Salio Mal", "OK");
            }

        }
    }
}