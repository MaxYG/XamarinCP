using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using XamarinCP.Service;
using XamarinCP.Views;

namespace XamarinCP.ViewModel
{
    public class MainViewModel : BaseViewModel
    {
        private string _username;
        private string _password;
        private string _errorMessage;
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
        
        private void ExecuteLoginCommand(object obj)
        {
            var isLogin=LoginService.Login(_username, _password);
            if (isLogin)
            {
                var companyListView = new CompanyListPage();
                _navigation.PushAsync(companyListView);
            }
            else
            {
                ErrorMessage = "login failed!";
            }
        }

        private bool CanExecuteLoginCommand(object arg)
        {
            return true;
        }
    }
}
