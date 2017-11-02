using Xamarin.Forms;
using XamarinCP.Database;
using XamarinCP.IService;
using XamarinCP.Service;

namespace XamarinCP
{
    public partial class App : Application
    {
        static XamarinCPDatabase _database;
        public static ServiceManager ServiceManager { get; private set; }
        public App()
        {
            InitializeComponent();
            ServiceManager =new ServiceManager(new CompanyService(),new AccountService());
            MainPage = new NavigationPage(new XamarinCP.MainPage());
        }

        public static XamarinCPDatabase Database
        {
            get
            {
                if (_database == null)
                {
                    _database = new XamarinCPDatabase(DependencyService.Get<IFileHelper>().GetLocalFilePath("XamarinCPSQLite.db3"));
                }
                return _database;
            }
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
