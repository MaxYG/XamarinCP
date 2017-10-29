using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using XamarinCP.Model;
using XamarinCP.Service;
using XamarinCP.Views;

namespace XamarinCP.ViewModel
{
    public class CompanyViewModel: BaseViewModel
    {
        public string _searchText;
        public Task<List<Company>> allCompanies;
        private readonly INavigation _navigation;
        
        public CompanyViewModel(INavigation navigation)
        {
            _navigation = navigation;
            AllCompanies = App.ServiceManager.GetCompaniesAsync();
        }
        

        public string SearchText
        {
            get { return _searchText; }
            set
            {
                _searchText = value;
                OnPropertyChanged(); 
            }
        }

        public Task<List<Company>> AllCompanies {
            get
            {
                allCompanies= App.ServiceManager.GetCompaniesAsync();
                return allCompanies;
                /*if (!allCompanies.Any())
                {
                    if (!string.IsNullOrEmpty(_searchText))
                    {
                        return allCompanies;
                    }
                    allCompanies = await  App.ServiceManager.GetCompaniesAsync();
                    return allCompanies;
                }
                return allCompanies;*/
            }
            set
            {
                allCompanies = value;
                OnPropertyChanged();
            }
        }
        //ObservableCollection
        
        public ICommand DetailCommand { 
            get
            {
                return new Command(async (companyId) =>
                {
                    var companyIdCopy = int.Parse(companyId.ToString());
                    var companyDetailPage =new CompanyDetailPage()
                    {
                        BindingContext = (object)AllCompanies.Result.First(x => x.Id == companyIdCopy)                            
                    };
                    await _navigation.PushAsync(companyDetailPage);
                });
            }
        }

        public Command SearchCommand
        {
            get
            {
                return new Command(() =>
                {
                    var companyName = _searchText;
                    //AllCompanies = CompanyService.GetCompanyies().Where(x => x.Name.Contains(companyName.ToString())).ToList();
                });
            }
        }


    }
}
