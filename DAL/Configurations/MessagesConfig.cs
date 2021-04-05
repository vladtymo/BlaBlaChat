using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.Configurations
{
    class MessagesConfig : EntityTypeConfiguration<Message>
    {
        public MessagesConfig()
        {
            //primary key

            this.HasKey(k => k.Id);

            //property

            this.Property(p => p.Text)
                .HasMaxLength(1000)
                .IsRequired();
            this.Property(p => p.Date)
                .IsRequired();

            //foreigh keys

            
        }
    }
}
