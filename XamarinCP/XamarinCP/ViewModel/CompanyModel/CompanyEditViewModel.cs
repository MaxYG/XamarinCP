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
        public CompanyEditViewModel(INavigation navigation,int companyId)
        {
            _navigation = navigation;
            var companiesTask = App.Database.GetCompaniesAsync();
            companiesTask.ContinueWith(x =>
            {
                var company = x.Result.First(c => c.Id == companyId);
                this.Id = company.Id;
                this.Name = company.Name;
                this.Address = company.Address;
            });
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
                        Address = this.Address
                    };

                    await App.Database.SaveCompanyAsync(company);
                    await _navigation.PopAsync();
                });
            }
        }
    }
}