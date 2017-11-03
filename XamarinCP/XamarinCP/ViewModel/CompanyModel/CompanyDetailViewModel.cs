using Xamarin.Forms;

namespace XamarinCP.ViewModel.CompanyModel
{
    public class CompanyDetailViewModel:BaseViewModel
    {
        private readonly INavigation _navigation;
        public CompanyDetailViewModel(INavigation navigation,Model.Company company)
        {
            Name = company.Name;
            Id = company.Id;
            Address = company.Address;
            _navigation = navigation;
        }

        public string Name { get; }
        public string Address { get; }
        public int Id { get; }

        public Command GoEditCommand
        {
            get
            {
                return new Command(() =>
                {
                    var companyEditPage = new Views.Company.CompanyEditPage()
                    {

                        BindingContext = new CompanyModel.CompanyEditViewModel(this._navigation, Id)
                    };
                    _navigation.PushAsync(companyEditPage);
                });
            }
        }
    }
}
