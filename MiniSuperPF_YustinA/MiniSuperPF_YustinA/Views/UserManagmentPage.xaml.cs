using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MiniSuperPF_YustinA.Services;
using MiniSuperPF_YustinA.ViewModels;
using System.Xml.Linq;
using System.ComponentModel.Design;
using MiniSuperPF_YustinA.Models;

namespace MiniSuperPF_YustinA.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UserManagmentPage : ContentPage
    {
        UserViewModel vm;

        public UserManagmentPage()
        {
            InitializeComponent();

            BindingContext = vm = new UserViewModel();

            LoadUserData();
        }

        private void LoadUserData ()
        {
            TxtID.Text = GlobalObjects.LocalUser.IdUsuario.ToString();
            TxtName.Text = GlobalObjects.LocalUser.Nombre;
            TxtEmail.Text = GlobalObjects.LocalUser.Correo;
            TxtPhoneNumber.Text = GlobalObjects.LocalUser.NumeroTelefono;
            TxtCardID.Text = GlobalObjects.LocalUser.Cedula;
            TxtAddress.Text = GlobalObjects.LocalUser.Direccion;
            
        }

        private async void Aplicar_Cliked(object sender, EventArgs e)
        {
            if (ValidateUserData())
            {
                UserDTO BackUpUser = new UserDTO();
                BackUpUser = GlobalObjects.LocalUser;


                BackUpUser.Nombre = TxtName.Text.Trim();
                BackUpUser.Correo = TxtEmail.Text.Trim();
                BackUpUser.NumeroTelefono = TxtPhoneNumber.Text.Trim();
                BackUpUser.Cedula = TxtCardID.Text.Trim();
                BackUpUser.Direccion = TxtAddress.Text.Trim();


                if (TxtPassword.Text != null && !string.IsNullOrEmpty(TxtPassword.Text.Trim()))
                {
                    BackUpUser.Contrasennia = TxtPassword.Text.Trim();
                }
                var answer = await DisplayAlert("Confirmacion requerida", "Estas segur(a) de cambiar tu informacion", "Yes", "No");

                if (answer)
                {
                    try
                    {
                        bool R = await vm.UpdateUser(BackUpUser);


                        if (R)
                        {
                            await DisplayAlert(";", "Usuario actualizado", "OK");
                            await Navigation.PopAsync();

                        }
                        else
                        {
                            await DisplayAlert(";(", " Algo malo paso!", "OK");
                            GlobalObjects.LocalUser = BackUpUser;
                        }
                    }



                    catch (Exception)
                    {
                        GlobalObjects.LocalUser = BackUpUser;
                    }


                }
            }
        }
        private bool ValidateUserData()
        {
            bool R = false;
            if (TxtName.Text != null && !string.IsNullOrEmpty(TxtName.Text.Trim()) &&
                TxtEmail.Text != null && !string.IsNullOrEmpty(TxtEmail.Text.Trim()) &&
                TxtPhoneNumber.Text != null && !string.IsNullOrEmpty(TxtPhoneNumber.Text.Trim()))

            {

                R = true;
            }
            else
            {
                if (TxtName.Text == null || string.IsNullOrEmpty(TxtName.Text.Trim()))
                {
                    DisplayAlert("Error de Validacion", "El nombre es requerido", "OK");

                    TxtName.Focus();
                    return false;
                }
            }
            if (TxtEmail.Text == null || string.IsNullOrEmpty(TxtEmail.Text.Trim()))
            {
                DisplayAlert("Error de Validacion", "El email es requerido", "OK");

                TxtEmail.Focus();
                return false;
            }
            if (TxtPhoneNumber.Text == null || string.IsNullOrEmpty(TxtPhoneNumber.Text.Trim()))
            {
                DisplayAlert("Error de Validacion", "El numero de telefono es requerido", "OK");

                TxtPhoneNumber.Focus();
                
            }
            return R;
        }

        private async void BtnCancel_Cliked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}
        
    
        
