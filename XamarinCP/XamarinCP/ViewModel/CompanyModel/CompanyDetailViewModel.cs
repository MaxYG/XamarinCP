using System.Diagnostics;
using System.Linq;
using Acr.UserDialogs;
using Xamarin.Forms;

namespace XamarinCP.ViewModel.CompanyModel
{
    public class CompanyDetailViewModel:BaseViewModel
    {
        private string _name;
        private string _address;
        private int _id;
        private readonly INavigation _navigation;
        private CompanyViewModel _companyViewModel;
        public CompanyDetailViewModel(INavigation navigation,Model.Company company,CompanyViewModel companyViewModel)
        {
            Name = company.Name;
            Id = company.Id;
            Address = company.Address;
            _navigation = navigation;
            _companyViewModel = companyViewModel;
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

        public Command GoEditCommand
        {
            get
            {
                return new Command(() =>
                {
                    var companyEditPage = new Views.Company.CompanyEditPage()
                    {

                        BindingContext = new CompanyModel.CompanyEditViewModel(this._navigation, this,_companyViewModel)
                    };
                    _navigation.PushAsync(companyEditPage);
                });
            }
        }

        public Command DeleteCommand
        {
            get
            {
                return new Command(async () =>
                {
                    var result = await UserDialogs.Instance.ConfirmAsync(new ConfirmConfig
                    {
                        Message = "Delete this company?",
                        OkText = "Delete",
                        CancelText = "Cancel"
                    });
                    if (result)
                    {
                        var removeCompany = _companyViewModel.AllCompanies.First(x => x.Id == this.Id);
                        await App.Database.DeleteCompanyAsync(removeCompany);
                        _companyViewModel.AllCompanies.Remove(removeCompany);
                        await _navigation.PopAsync();
                    }
                });
            }
        }
    }
}
