using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace XamarinCP.ViewModel.CompanyModel
{
    public class CompanyAddViewModel: BaseViewModel
    {
        
        private string _name;
        private string _address;
        private readonly INavigation _navigation;
        private readonly ObservableCollection<Model.Company> _allCompanies;
        public CompanyAddViewModel(INavigation navigation, ObservableCollection<Model.Company> allCompanies)
        {
            _navigation = navigation;
            _allCompanies = allCompanies;
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
                        Address = this.Address
                    };

                    await App.Database.SaveCompanyAsync(company);
                    _allCompanies.Add(company);
                    await _navigation.PopAsync();
                });
            }
        }
    }
}
