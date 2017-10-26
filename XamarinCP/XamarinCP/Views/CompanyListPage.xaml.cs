
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinCP.ViewModel;

namespace XamarinCP.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CompanyListPage : ContentPage
    {
        public CompanyListPage()
        {
            InitializeComponent();      
            var companyViewModel=new CompanyViewModel(this.Navigation);
            BindingContext = companyViewModel;
            this.CompanyList.ItemsSource = companyViewModel.AllCompanies;
        }
        
    }
}