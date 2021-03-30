using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Windows.Navigation;

namespace Client
{
    public class RegistryViewModel:ViewModelBase
    {
        NavigationService NavigationService;
        private ICollection<string> months = new ObservableCollection<string>();
        public IEnumerable<string> Months => months;
        public RegistryViewModel(NavigationService navigationService)
        {
            NavigationService = navigationService;
            months = new ObservableCollection<string>(DateTimeFormatInfo.CurrentInfo.MonthNames); 
        }
        private string? _mail;

        //????? what this??
        public string? Mail
        {
            get => _mail;
            set => SetProperty(ref _mail, value);
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
    }
}
