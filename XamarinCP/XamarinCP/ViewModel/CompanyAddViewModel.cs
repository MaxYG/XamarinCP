using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using XamarinCP.Model;

namespace XamarinCP.ViewModel
{
    public class CompanyAddViewModel: BaseViewModel
    {
        
        private string _name;
        private string _address;
        private readonly INavigation _navigation;
        private readonly ObservableCollection<Company> _allCompanies;
        public CompanyAddViewModel(INavigation navigation, ObservableCollection<Company> allCompanies)
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
                    var company = new Company()
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
