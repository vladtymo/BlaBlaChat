using Client.Command;
using Client.Models.Services;
using Google.Protobuf.WellKnownTypes;
using GrpcChatService;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;

namespace Client
{
    public class RegistryViewModel : ViewModelBase
    {
        NavigationService NavigationService;
        private Command.Command _nextCommand;
        private Command.Command _addPictures;
        private ICollection<string> months = new ObservableCollection<string>();
        public IEnumerable<string> Months => months;
        public RegistryViewModel(NavigationService navigationService,string email)
        {
            Email = email;
            NavigationService = navigationService;
            months = new ObservableCollection<string>(DateTimeFormatInfo.CurrentInfo.MonthNames);
            _nextCommand = new DelegateCommand(Save_Executed, Save_CanExecute);
            PropertyChanged += (s, args) =>
            {
                _nextCommand.RaiseCanExecuteChanged();
            };
            _addPictures = new DelegateCommand(OpenFileDialog_);
        }
        public ICommand AddPictures => _addPictures;
        public ICommand NextCommand => _nextCommand;
        private string? _email;
        public string? Email
        {
            get => _email;
            set => SetProperty(ref _email, value);
        }
        private string? _name;
        public string? Name
        {
            get => _name;
            set => SetProperty(ref _name, value);
        }
        private string? _surname;
        public string? Surname
        {
            get => _surname;
            set => SetProperty(ref _surname, value);
        }
        private string? _nickname;
        public string? Nickname
        {
            get => _nickname;
            set => SetProperty(ref _nickname, value);
        }

        private DateTime? _validatingDate;
        public DateTime? ValidatingDate
        {
            get => _validatingDate;
            set => SetProperty(ref _validatingDate, value);
        }

        private BitmapImage _picture;
        public BitmapImage Picture
        {
            get => _picture;
            set => SetProperty(ref _picture, value);
        }
        private void OpenFileDialog_()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Multiselect = true;
            openFileDialog.Filter = "JPEG Files (*.jpeg)|*.jpeg|PNG Files (*.png)|*.png|JPG Files (*.jpg)|*.jpg|GIF Files (*.gif)|*.gif";
            if (openFileDialog.ShowDialog() == true)
            {
                Picture = new BitmapImage(new Uri(openFileDialog.FileName, UriKind.Relative));
            }
        }
        private async void Save_Executed()
        {
            RegistrationRequest registrationRequest=new RegistrationRequest() {Name=Name,Surname=Surname,Nickname=Nickname,BirthDate= Timestamp.FromDateTime(ValidatingDate.Value.ToUniversalTime()),Email=Email};
            MessageBox.Show((await AuthenticationServise.Registration(registrationRequest)).ToString());
        }
        private bool Save_CanExecute()
        {
            return !(string.IsNullOrEmpty(Name)
                || string.IsNullOrEmpty(Surname)
                || string.IsNullOrEmpty(Nickname)
                || string.IsNullOrEmpty(ValidatingDate.ToString()) || Picture == null);
        }
    }
}