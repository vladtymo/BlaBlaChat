using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Navigation;

namespace Client.ViewModels
{
    class UserInfo : INotifyPropertyChanged
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Nickname { get; set; }
        public string Email { get; set; }
        public string AvatarLink { get; set; }
        public DateTime BirthDate { get; set; }
        public string Bio { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
    class PageChatViewModel : ViewModelBase
    {
        NavigationService NavigationService;
        readonly int IdUser;
        public PageChatViewModel(NavigationService navigationService,int idUser)
        {
            NavigationService = navigationService;
            IdUser = idUser;
        }
    }
}
