using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
    public class Messages
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public DateTime Date { get; set; }
        
        //FK
        public int ChatID { get; set; }
        public int UserID { get; set; }
        //NAV
        public virtual Chat Chat { get; set; }
        public virtual User User { get; set; }

    }
}
