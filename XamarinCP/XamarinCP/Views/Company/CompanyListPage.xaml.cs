using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinCP.ViewModel;

namespace XamarinCP.Views.Company
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CompanyListPage : ContentPage
    {
        public CompanyListPage()
        {
            InitializeComponent();      
            this.BindingContext=new CompanyViewModel(this.Navigation);
        }
    }
}