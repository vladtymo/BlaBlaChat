using Client.Command;
using Client.Models.Services;
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

        private string _email;

        public string Email
        {
            get => _email;
            set => SetProperty(ref _email, value);
        }
        NavigationService NavigationService;
        public PageEnterEmailViewModel(NavigationService navigationService)
        {
            NavigationService = navigationService;
            _sendCodeCommand = new DelegateCommand(SendCode);
        }
        private async void SendCode()
        {
            NavigationService.Navigate(new PageEnterCodeEmail(NavigationService,AuthenticationServise.SendConfirmCodeAsync(Email), Email));
        }
        public ICommand SendCodeCommand => _sendCodeCommand;

    }
}
