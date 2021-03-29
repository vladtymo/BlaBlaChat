using System;
using System.Collections.Generic;
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
    /// Логика взаимодействия для PageAutorizationEnterSendEmail.xaml
    /// </summary>
    public partial class PageAutorizationEnterSendEmail : Page
    {

        public PageAutorizationEnterSendEmail()
        {
            InitializeComponent();
           
          
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new PageEnterCodeEmail());
            // Navigate to URI using the Source property
           //  this.Source = new Uri("HomePage.xaml", UriKind.Relative); 
            // Navigate to URI using the Navigate method
            //this.Navigate(new Uri("HomePage.xaml", UriKind.Relative));
            // Navigate to object using the Navigate method
             //this.Navigate(new PageEnterCodeEmail());
        }
    }
}
