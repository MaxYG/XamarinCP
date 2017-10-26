using Xamarin.Forms;
using XamarinCP.ViewModel;

namespace XamarinCP
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            this.BindingContext = new MainViewModel(this.Navigation);
        }
    }
}
