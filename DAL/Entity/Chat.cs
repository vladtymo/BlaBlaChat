using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
    public class Chat
    {
        public int Id { get; set; }
        public string Name { get; set; }
        //FK
        //NAV
        public virtual ICollection<User> Users { get; set; }
        public virtual ICollection<Messages> Messages { get; set; }
    }
}
