using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinCP.Service;
using XamarinCP.ViewModel;

namespace XamarinCP.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CompanyListPage : ContentPage
    {
        public CompanyListPage()
        {
            InitializeComponent();
            BindingContext = new CompanyViewModel(this.Navigation);
            this.CompanyListView.ItemsSource = CompanyService.GetCompanyies().ToList();
        }

        public void OnSearchTextClick(object sender, EventArgs e)
        {
            var searchText = SearchText.Text ?? (this.SearchText.Text = string.Empty);
            this.CompanyListView.ItemsSource = CompanyService.GetCompanyies().Where(x => x.Name.Contains(searchText)).ToList();
        }
    }
}