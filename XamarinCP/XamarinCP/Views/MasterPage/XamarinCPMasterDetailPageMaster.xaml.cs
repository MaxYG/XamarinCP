using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinCP.ViewModel.MasterPage;

namespace XamarinCP.Views.MasterPage
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class XamarinCPMasterDetailPageMaster : ContentPage
    {
        public ListView ListView;

        public XamarinCPMasterDetailPageMaster()
        {
            InitializeComponent();

            BindingContext = new XamarinCPMasterDetailPageMasterViewModel();
            ListView = MenuItemsListView;
        }
    }
}