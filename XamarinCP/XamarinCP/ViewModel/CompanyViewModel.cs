using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using XamarinCP.Model;
using XamarinCP.Service;
using XamarinCP.Views;
using static XamarinCP.App;

namespace XamarinCP.ViewModel
{
    public class CompanyViewModel: BaseViewModel
    {
        private string _searchText;
        private ObservableCollection<Company> _allCompanies;
        private readonly INavigation _navigation;
      
        public CompanyViewModel(INavigation navigation)
        {
            _navigation = navigation;
            LoadCompaniesData();
        }

        private void LoadCompaniesData()
        {
           var companiesTask = App.Database.GetCompaniesAsync();
            companiesTask.ContinueWith(t =>
            {
                AllCompanies = new ObservableCollection<Company>(t.Result);
            });
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

        public ObservableCollection<Company> AllCompanies {
            get
            {
                if (_allCompanies==null)
                {
                    _allCompanies=new ObservableCollection<Company>();
                }
                return _allCompanies;
            }
            set
            {
                _allCompanies = value;
                OnPropertyChanged();
            }
        }
        
        public ICommand GoDetailCommand { 
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

        public Command SearchCommand
        {
            get
            {
                return new Command(() =>
                {
                    var companyName = _searchText;
                    var companiesTask = App.Database.GetCompaniesAsync();
                    companiesTask.ContinueWith(t =>
                    {
                        AllCompanies = new ObservableCollection<Company>(t.Result.Where(x => x.Name.Contains(companyName.ToString())).ToList());
                    });
                });
            }
        }

        public Command GoAddCommand
        {
            get
            {
                return new Command(async () =>
                {
                    var companyAddPage = new CompanyAddPage()
                    {
                        BindingContext = new CompanyAddViewModel(_navigation,AllCompanies)
                        
                    };

                    await _navigation.PushAsync(companyAddPage);
                });
            }
        }
    }
}
