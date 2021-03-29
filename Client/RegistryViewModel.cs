using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;

namespace Client
{
    public class RegistryViewModel:ViewModelBase
    {
        private ICollection<string> months = new ObservableCollection<string>();
        public IEnumerable<string> Months => months;
        public RegistryViewModel()
        {
            months = new ObservableCollection<string>(DateTimeFormatInfo.CurrentInfo.MonthNames); 
        }
        private string? _mail;


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
        private string? _month;
        public string? Month
        {
            get => _month;
            set => SetProperty(ref _month, value);
        }
        private string? _day;
        public string? Day
        {
            get => _day;
            set => SetProperty(ref _day, value);
        }
        private string? _year;
        public string? Year
        {
            get => _year;
            set => SetProperty(ref _year, value);
        }
        private DateTime? _validatingDate;
        public DateTime? ValidatingDate
        {
            get => _validatingDate;
            set => SetProperty(ref _validatingDate, value);
        }
    }
}
