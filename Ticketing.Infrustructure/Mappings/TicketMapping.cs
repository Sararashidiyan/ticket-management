using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Ticketing.Domain.Entities.Users;
using Ticketing.Domain.Entities.Tickets;

namespace Ticketing.Infrustructure.Mappings
{
    public class TicketMapping : IEntityTypeConfiguration<Ticket>
    {
        public void Configure(EntityTypeBuilder<Ticket> builder)
        {
            builder.ToTable("Tickets");
            builder.HasKey(x => x.Id);
            builder.Property(s => s.Title).IsRequired();
            builder.Property(s => s.Description).IsRequired();
            builder.Property(s => s.CreatedByUserId).IsRequired();
            builder.Property(s => s.CreatedAt).IsRequired();
            builder.Property(s => s.AssignedToUserId).IsRequired(false);
            builder.Property(s => s.UpdatedAt).IsRequired(false);
            builder.Property(s => s.Status).IsRequired();
            builder.Property(s => s.Priority).IsRequired();
        }
    }
}
