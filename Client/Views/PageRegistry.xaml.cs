using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Client
{
    /// <summary>
    /// Interaction logic for PageRegistry.xaml
    /// </summary>
    /// 

    public partial class PageRegistry : Page
    {
        public PageRegistry(NavigationService navigationService, string email)
        {
           
            InitializeComponent();
            this.DataContext = new RegistryViewModel(navigationService,email);
           
        }
    }
}
