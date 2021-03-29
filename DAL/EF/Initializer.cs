using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Dal
{
    internal class Initializer : DropCreateDatabaseIfModelChanges<ChatDatabaseModel>
    {
        protected override void Seed(ChatDatabaseModel context)
        {
            base.Seed(context);
        }
    }
}
