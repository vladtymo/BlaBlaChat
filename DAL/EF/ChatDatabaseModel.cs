namespace Dal
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;

    public class ChatDatabaseModel : DbContext
    {
        public ChatDatabaseModel()
            : base("Data Source=den1.mssql7.gear.host;Initial Catalog=blablachatdb;Persist Security Info=True;User ID=blablachatdb;Password=Zo848Ut-j87~")
        {
            Database.SetInitializer(new Initializer());

        }
        public virtual DbSet<Chat> Chats { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Message> Messages { get; set; }
    }

}