using Entities.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Configuration;

public class ContextBase : IdentityDbContext<ApplicationUser>
{
    public ContextBase(DbContextOptions<ContextBase> options) : base(options)
    {
    }

    public DbSet<Message> Message { get; set; }
    public DbSet<ApplicationUser> ApplicationUser { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer(GetConnectionString());
            base.OnConfiguring(optionsBuilder);
        }
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<ApplicationUser>().ToTable("ASPNETUSERS").HasKey(t => t.Id);
        base.OnModelCreating(builder);
    }


    public string GetConnectionString() => "Data Source = localhost\\SQLEXPRESS; Initial Catalog=API_DDD_2022; Integrated Security=False; USER ID = sa; Password=AdminSql2022; Timeout=15;Encrypt=False; TrustCertificate=False";

}
