using System;
using System.Threading.Tasks;
using Acr.UserDialogs;
using AndroidHUD;
using Xamarin.Forms;
using XamarinCP.Service;
using XamarinCP.Views;
using XamarinCP.Views.MasterPage;

namespace XamarinCP.ViewModel
{
    public class MainViewModel : BaseViewModel
    {
        private string _username="test";
        private string _password="test";
        private string _errorMessage;
        private bool _isLogin;
       
        private Command _loginCommand;
        private readonly INavigation _navigation;

        public MainViewModel(INavigation navigation)
        {
            _navigation = navigation;
        }

        public string ErrorMessage
        {
            get => _errorMessage;
            set
            {
                _errorMessage = value;
                OnPropertyChanged();
            }
        }
        public string Password
        {
            get => _password;
            set
            {
                _password = value;
                OnPropertyChanged();
            }
        }
        public string Username
        {
            get => _username;
            set
            {
                _username = value;
                OnPropertyChanged();
            }
        }
        
        public Command LoginCommand
        {
            get
            {
                if (_loginCommand == null)
                {
                    _loginCommand = new Command(ExecuteLoginCommand, CanExecuteLoginCommand);
                }

                return _loginCommand;
            }
        }
        
        private async void ExecuteLoginCommand(object obj)
        {
            UserDialogs.Instance.ShowLoading();
                
//            var loginTask = App.ServiceManager.LoginAsync(_username, _password);
//            _isLogin = await loginTask;
            await Task.Delay(1000);
            _isLogin = true;
            UserDialogs.Instance.HideLoading();
            if (_isLogin)
            {
                //var companyListPage = new Views.Company.CompanyListPage();
                var marterPage = new XamarinCPMasterDetailPage();
//                var mainPage=new MainPage();
//                _navigation.InsertPageBefore(marterPage, mainPage);
//                await _navigation.PopAsync();
                Application.Current.MainPage = marterPage;
            }
            else
            {
                ErrorMessage = "login failed!";
            }
        }
        
        private bool CanExecuteLoginCommand(object arg)
        {
            return !(string.IsNullOrEmpty(Username) && string.IsNullOrEmpty(Password));
        }
    }
}
