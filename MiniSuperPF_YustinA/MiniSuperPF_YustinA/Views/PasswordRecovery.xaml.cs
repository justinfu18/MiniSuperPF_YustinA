﻿using System;
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
    public partial class PasswordRecovery : ContentPage
    {
        UserViewModel viewModel;

        public PasswordRecovery()
        {
            InitializeComponent();
            BindingContext = viewModel = new UserViewModel();
        }           
        private async void BtnSendRecoveryCode_Clicked(object sender, EventArgs e)
        {

            if (!string.IsNullOrEmpty(TxtEmail.Text.Trim()))
            {
                bool R = await viewModel.AddRecoveryCode(TxtEmail.Text.Trim());
                if (R)
                {
                    TxtEmail.IsEnabled = false;
                    await DisplayAlert("....", "Codigo enviado correctamente","OK");
                }
            }
        }

        private async void BtnCancelar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
       
    }
}