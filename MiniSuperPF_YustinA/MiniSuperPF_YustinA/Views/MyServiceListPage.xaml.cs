using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiniSuperPF_YustinA.ViewModels;
using MiniSuperPF_YustinA.Models;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MiniSuperPF_YustinA.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MyServiceListPage : ContentPage
    {
        UserViewModel vm;


        public MyServiceListPage()
        {
            InitializeComponent();

           BindingContext = vm = new UserViewModel();

            LoadService(GlobalObjects.LocalUser.IdUsuario);

        }

        private async void LoadService(int pUserID)
        {
            LstServiceList.ItemsSource = await vm.GetServiceList(pUserID);
        }
    }
}
