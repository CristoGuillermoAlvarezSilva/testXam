using System.ComponentModel;
using Xamarin.Forms;
using Xamarinconversor.ViewModels;

namespace Xamarinconversor.Views
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