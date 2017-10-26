using System;
using Xamarin.Forms;
using XamarinCP.Model;
using XamarinCP.Pages;

namespace XamarinCP
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        async void OnLoginButtonClicked(object sender, EventArgs e)
        {
            if (CheckUsernameAndPassword()) return;
            var loginUser = new LoginUserModel()
            {
                Username = this.Username.Text,
                Password = this.Password.Text,
            };
            var compareLoginUser = CompareLoginUser(loginUser);
            if (compareLoginUser)
            {
                await Navigation.PushAsync(new CompanyListPage());
            }
            else
            {
                ErrorMessage.Text = "Login failed!";
            }
            
        }

        private bool CheckUsernameAndPassword()
        {
            if (this.Username.Text == null || this.Password == null || this.Username.Text.Equals("") ||
                this.Password.Text.Equals(""))
            {
                ErrorMessage.Text = "Username and password are required!";
                return true;
            }
            return false;
        }


        private bool CompareLoginUser(LoginUserModel loginUserModel)
        {
            return loginUserModel.Username.Equals("test") && loginUserModel.Password.Equals("test");
        }
    }
}
