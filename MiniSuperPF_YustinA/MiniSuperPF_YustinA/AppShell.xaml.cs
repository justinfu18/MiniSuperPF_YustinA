using MiniSuperPF_YustinA.ViewModels;
using MiniSuperPF_YustinA.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace MiniSuperPF_YustinA
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
        }

        private async void OnMenuItemClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//LoginPage");
        }
    }
}
