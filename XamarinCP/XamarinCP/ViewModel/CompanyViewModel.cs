using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Xamarin.Forms;
using XamarinCP.Model;
using XamarinCP.Service;
using XamarinCP.Views;

namespace XamarinCP.ViewModel
{
    public class CompanyViewModel: BaseViewModel
    {
        private readonly INavigation _navigation;
        
        public CompanyViewModel(INavigation navigation)
        {
            _navigation = navigation;
            AllCompanies = CompanyService.GetCompanyies();
        }

        public IEnumerable<Company> AllCompanies { get; set; }//ObservableCollection
        
        public ICommand DetailCommand { 
            get
            {
                return new Command(async (companyId) =>
                {
                    var companyIdCopy = int.Parse(companyId.ToString());
                    var companyDetailPage =new CompanyDetailPage()
                    {
                        BindingContext = (object)AllCompanies.First(x => x.Id == companyIdCopy)                            
                    };
                    await _navigation.PushAsync(companyDetailPage);
                });
            }
        }
        
    }
}
