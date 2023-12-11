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
	public partial class ProductPage : ContentPage
	{
		public ProductPage ()
		{
			InitializeComponent ();
		}

        private async void BtnCancel_Cliked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}