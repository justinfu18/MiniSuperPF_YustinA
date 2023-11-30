using MiniSuperPF_YustinA.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace MiniSuperPF_YustinA.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}