using Client.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Navigation;

namespace Client.ViewModels
{
  public  class PageEnterCodeViewModel : ViewModelBase
  {


        private string _time;
        public string Time { get=>_time; 
            set {

                _time = value;
                OnPropertyChanged();
            } 
        }

        private Command.Command _sendCodeCommand;

        private string _mail;

        public string Mail
        {
            get => _mail;
            set => SetProperty(ref _mail, value);
        }

        NavigationService NavigationService;

        public PageEnterCodeViewModel(NavigationService navigationService)
        {
            NavigationService = navigationService;
            StartTimer();
            _sendCodeCommand = new DelegateCommand(ConfirmCode);
        }

        private void ConfirmCode()
        {



            NavigationService.Navigate(new PageRegistry(NavigationService));
        }
        public ICommand SendCodeCommand => _sendCodeCommand;



        void StartTimer()
        {

            TimeSpan ts = new TimeSpan(0, 1, 0);
            Task.Factory.StartNew(() =>
            {

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
