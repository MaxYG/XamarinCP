using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Xamarin.Forms;
using XamarinCP.Model;
using XamarinCP.Pages;

namespace XamarinCP.ViewModel
{
    public class CompanyViewModel:INotifyPropertyChanged
    {
        private readonly INavigation _navigation;
        
        public CompanyViewModel(INavigation navigation)
        {
            _navigation = navigation;
        }
     
        public static IEnumerable<Company> AllCompanies { set; get; }

        public event PropertyChangedEventHandler PropertyChanged;

        public ICommand DetailCommand { 
            get
            {
                
                return new Command(async (companyId) =>
                {
                    var companyIdCopy = int.Parse(companyId.ToString());
                    var companyDetailPage =new CompanyDetailPage
                    {
                        BindingContext = (object)AllCompanies.First(x => x.Id == companyIdCopy)                            
                    };
                    await _navigation.PushAsync(companyDetailPage);
                });
            }
        }
        
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
