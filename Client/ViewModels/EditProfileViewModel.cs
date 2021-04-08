using Client.Command;
using Client.Models.Services;
using GrpcChatService;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;

namespace Client.ViewModels
{
    class EditProfileViewModel:ViewModelBase
    {
        NavigationService NavigationService;
        private Command.Command _saveCommand;
        private Command.Command _addPictures;
      
        public EditProfileViewModel()
        {
           
            _saveCommand = new DelegateCommand(Save_Executed, Save_CanExecute);
            PropertyChanged += (s, args) =>
            {
                _saveCommand.RaiseCanExecuteChanged();
            };
            _addPictures = new DelegateCommand(OpenFileDialog_);
        }
        public ICommand AddPictures => _addPictures;
        public ICommand NextCommand => _saveCommand;
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
        private string _bio;
        public string Bio
        {
            get => _bio;
            set => SetProperty(ref _bio, value);
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
