using System.Linq;
using Xamarin.Forms;

namespace XamarinCP.ViewModel.CompanyModel
{
    public class CompanyEditViewModel : BaseViewModel
    {
        private readonly INavigation _navigation;
        private string _name;
        private string _address;
        private int _id;
        private CompanyViewModel _companyViewModel;
        private CompanyDetailViewModel _companyDetailViewModel;
        public CompanyEditViewModel(INavigation navigation, CompanyDetailViewModel companyDetailViewModel,
            CompanyViewModel companyViewModel)
        {
            _navigation = navigation;
            GetCompanyById(companyDetailViewModel);
            _companyViewModel = companyViewModel;
            _companyDetailViewModel = companyDetailViewModel;
        }

        private void GetCompanyById(CompanyDetailViewModel companyDetailViewModel)
        {
            this.Id = companyDetailViewModel.Id;
            this.Name = companyDetailViewModel.Name;
            this.Address = companyDetailViewModel.Address;
        }

        public int Id
        {
            get => _id;
            set
            {
                _id = value;
                OnPropertyChanged();
            }
        }
        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged();
            }
        }
        public string Address
        {
            get => _address;
            set
            {
                _address = value;
                OnPropertyChanged();
            }
        }

        public Command EditCommand
        {
            get
            {
                return new Command(async () =>
                {
                    var company = new Model.Company()
                    {
                        Id = this.Id,
                        Name = this.Name,
                        Address = this.Address,
                        ImageUrl = "icon.png"
                    };
                    
                    await App.Database.SaveCompanyAsync(company);
                    _companyDetailViewModel.Name = this.Name;
                    _companyDetailViewModel.Address = this.Address;
                    var removeCompany = _companyViewModel.AllCompanies.First(x => x.Id == this.Id);
                    _companyViewModel.AllCompanies.Remove(removeCompany);
                    _companyViewModel.AllCompanies.Add(company);
                    _companyViewModel.AllCompanies = _companyViewModel.AllCompanies;
                    await _navigation.PopAsync();
                });
            }
        }

        
    }
}