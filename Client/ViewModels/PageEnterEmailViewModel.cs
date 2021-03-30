using Client.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Navigation;

namespace Client.ViewModels
{
   public class PageEnterEmailViewModel : ViewModelBase
   {


        private Command.Command _sendCodeCommand;

        private string? _mail;

        public string? Mail
        {
            get => _mail;
            set => SetProperty(ref _mail, value);
        }
        NavigationService NavigationService;
        public PageEnterEmailViewModel(NavigationService navigationService)
        {
            NavigationService = navigationService;
            _sendCodeCommand = new DelegateCommand(SendCode);
        }
        private void SendCode()
        {
            NavigationService.Navigate(new PageEnterCodeEmail(NavigationService));
        }
        public ICommand SendCodeCommand => _sendCodeCommand;

   }
}
