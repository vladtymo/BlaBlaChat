using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.Configurations
{
    class ChatConfig : EntityTypeConfiguration<Chat>
    {
        public ChatConfig()
        {
            //primary key
            this.HasKey(k => k.Id);

            //property
            this.Property(p => p.Name)
                .HasMaxLength(100)
                .IsRequired();

            //foreigh keys
            this.HasMany(p => p.Users).WithMany(p => p.Chats);

            this.HasMany(p => p.Messages)
                .WithRequired(p => p.Chat)
                .HasForeignKey(k => k.ChatID)
                .WillCascadeOnDelete(false);
        }
    }
}
