using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
    public class User
    {
        public User()
        {
            this.Chats = new HashSet<Chat>();
            this.MyContacts = new HashSet<User>();
            this.Users = new HashSet<User>();
            this.Messages = new HashSet<Message>();
        }


        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Nickname { get; set; }
        public string Email { get; set; }
        public string AvatarLink { get; set; }
        public DateTime BirthDate { get; set; }
        public string Bio { get; set; }

        //FK
        //NAV
        public virtual ICollection<Chat> Chats { get; set; }
        public virtual ICollection<User> MyContacts { get; set; } 
        public virtual ICollection<User> Users { get; set; }
        public virtual ICollection<Message> Messages { get; set; }
    }
}
