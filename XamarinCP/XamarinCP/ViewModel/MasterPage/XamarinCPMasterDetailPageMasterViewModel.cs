using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XamarinCP.Model;
using XamarinCP.Views.Company;
using XamarinCP.Views.MasterPage;

namespace XamarinCP.ViewModel.MasterPage
{
    public class XamarinCPMasterDetailPageMasterViewModel:BaseViewModel
    {
        public ObservableCollection<XamarinCPMasterDetailPageMenuItem> MenuItems { get; set; }

        public XamarinCPMasterDetailPageMasterViewModel()
        {
            MenuItems = new ObservableCollection<XamarinCPMasterDetailPageMenuItem>(new[]
            {
                new XamarinCPMasterDetailPageMenuItem { Id = 0, Title = "Company",TargetType = typeof(CompanyListPage)},
            });
        }
    }
}
