using Client.Command;
using Client.Models.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Navigation;
using static GrpcChatService.CheckConfirmCodeResponse.Types;

namespace Client.ViewModels
{
    public class PageEnterCodeViewModel : ViewModelBase
    {
        private string _time;
        public string Time
        {
            get => _time;
            set
            {
                _time = value;
                OnPropertyChanged();
            }
        }

        private Command.Command _sendCodeCommand;

        private string _code;

        public string Code
        {
            get => _code;
            set => SetProperty(ref _code, value);
        }

        NavigationService NavigationService;
        string Email { get; set; }
        public PageEnterCodeViewModel(NavigationService navigationService, Task<TimeSpan> timeSpan, string email)
        {
            NavigationService = navigationService;
            Email = email;
            StartTimer(timeSpan);
            _sendCodeCommand = new DelegateCommand(ConfirmCode);
        }

        private async void ConfirmCode()
        {
            GrpcChatService.CheckConfirmCodeResponse.Types.StatusCheckCode Status = await AuthenticationServise.CheckConfirmCodeAsync(Code);
            MessageBox.Show(Status.ToString());
            switch (Status)
            {
                case StatusCheckCode.Incorrect:
                    //error message
                    break;
                case StatusCheckCode.UserNotFound:
                    NavigationService.Navigate(new PageRegistry(NavigationService, Email));
                    break;
                case StatusCheckCode.Authenticated:
                    //show page chat window
                    break;
            }
        }
        public ICommand SendCodeCommand => _sendCodeCommand;

        async void StartTimer(Task<TimeSpan> timeSpan)
        {
            _ = Task.Factory.StartNew(() =>
              {
                  TimeSpan ts = timeSpan.Result;
                  while (ts.Seconds != -1)
                  {
                      Time = ts.ToString(@"mm\:ss");
                      Thread.Sleep(1000);
                      ts = ts.Subtract(new TimeSpan(0, 0, 1));
                  }
              });
        }
    }
}
