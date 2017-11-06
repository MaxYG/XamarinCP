using System.Collections.ObjectModel;
using Xamarin.Forms;
using XamarinCP.Model;

namespace XamarinCP.ViewModel.CompanyModel
{
    public class CompanyAddViewModel: BaseViewModel
    {
        
        private string _name;
        private string _address;
        private readonly INavigation _navigation;
        private CompanyViewModel _companyViewModel;
        public CompanyAddViewModel(INavigation navigation, CompanyViewModel companyViewModel)
        {
            _navigation = navigation;
            _companyViewModel = companyViewModel;
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

        public Command AddCommand
        {
            get
            {
                return new Command(async () =>
                {
                    var company = new Model.Company()
                    {
                        Name = this.Name,
                        Address = this.Address,
                        ImageUrl = "icon.png",
                    };

                    await App.Database.SaveCompanyAsync(company);
                    _companyViewModel.AllCompanies.Add(company);
                    _companyViewModel.AllCompanies = _companyViewModel.AllCompanies;
                    await _navigation.PopAsync();
                });
            }
        }
    }
}
