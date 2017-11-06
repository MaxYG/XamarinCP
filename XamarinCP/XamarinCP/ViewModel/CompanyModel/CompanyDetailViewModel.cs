using System.Diagnostics;
using Acr.UserDialogs;
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
                        var company = await App.Database.GetCompanyByIdAsync(Id);
                        await App.Database.DeleteCompanyAsync(company);
                        await _navigation.PopAsync();
                    }
                });
            }
        }
    }
}
