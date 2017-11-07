using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using Xamarin.Forms;
using XamarinCP.Model;

namespace XamarinCP.ViewModel.CompanyModel
{
    public class CompanyViewModel: BaseViewModel
    {
        private string _searchText;
        private bool _isRefresh;
        private ObservableCollection<Company> _allCompanies;
        private readonly INavigation _navigation;


        public CompanyViewModel(INavigation navigation)
        {
            _navigation = navigation;
            LoadCompaniesData();
            IsRefresh = false;
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
        public bool IsRefresh
        {
            get { return _isRefresh; }
            set
            {
                _isRefresh = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<Company> AllCompanies {
            get
            {
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
                    var companyDetail = AllCompanies.First(x => x.Id == companyIdCopy);
                    var companyDetailPage =new Views.Company.CompanyDetailPage()
                    {
                        
                        BindingContext = new CompanyModel.CompanyDetailViewModel(this._navigation,companyDetail,this)                            
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
                    var companyAddPage = new Views.Company.CompanyAddPage()
                    {
                        BindingContext = new CompanyModel.CompanyAddViewModel(_navigation, this)
                    };

                    await _navigation.PushAsync(companyAddPage);
                });
            }
        }

        public Command RefreshCommand
        {
            get
            {                
                return new Command(async () =>
                {
                    IsRefresh = true;
                    var companiesTask =await App.Database.GetCompaniesAsync();
                    this.AllCompanies =new ObservableCollection<Company>(companiesTask);
                    this.AllCompanies = this.AllCompanies;
                    IsRefresh = false;
                });
            }
        }
    }
}
