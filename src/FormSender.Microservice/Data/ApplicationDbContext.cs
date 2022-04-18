using FormSender.Microservice.Entities;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace FormSender.Microservice.Data
{
    public class ApplicationDbContext : DbContextBase
    {
        public ApplicationDbContext([NotNull]DbContextOptions options) : base(options) { }

        public DbSet<MessageForm> MessageForms { get; set; }
        public DbSet<WebDocument> Documents { get; set; }
        public DbSet<Content> Content { get; set; }
    }
}
