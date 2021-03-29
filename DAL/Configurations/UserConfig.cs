using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;

namespace Dal.Configurations
{
    class UserConfig : EntityTypeConfiguration<User>
    {
        public UserConfig()
        {
            //primary key
            this.HasKey(k => k.Id);

            //property
            this.Property(p => p.Email)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(p => p.Surname)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(p => p.Nickname)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(p => p.AvatarLink)
                .HasMaxLength(100);

            this.Property(p => p.BirthDate)
                .IsRequired();


            //foreign keys
            this.HasMany(p => p.Chats).WithMany(p => p.Users);

            this.HasMany(p => p.Messages)
                .WithRequired(p => p.User)
                .HasForeignKey(k=>k.UserID)
                .WillCascadeOnDelete(false);

            this.HasMany(p => p.Users).WithMany(p => p.MyContacts);
            
        }
    }
}
