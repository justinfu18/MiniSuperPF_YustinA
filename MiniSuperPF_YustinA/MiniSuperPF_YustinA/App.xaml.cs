using MiniSuperPF_YustinA.Services;
using MiniSuperPF_YustinA.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MiniSuperPF_YustinA
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            //Pag de inicio
            MainPage = new NavigationPage(new ServiceLoginPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
