using Gewichtsdatenapp_LiveChart.ViewModel;

namespace Gewichtsdatenapp_LiveChart.View
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            (BindingContext as BaseViewModel)?.ReloadData();
        }
    }
}

