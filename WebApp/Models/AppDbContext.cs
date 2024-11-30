using Microsoft.EntityFrameworkCore;

namespace WebApp.Models;

public class AppDbContext : DbContext
{
    public DbSet<ContactEntity> Contacts { get; set; }
    public DbSet<OrganizationEntity> Organizations { get; set; }
    private string DbPath { get; set; }
    public AppDbContext()
    {
        var folder = Environment.SpecialFolder.LocalApplicationData;
        var path = Environment.GetFolderPath(folder);
        DbPath = Path.Join(path, "contacts.db");
        
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite($"Data source={DbPath}");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<OrganizationEntity>()
            .ToTable("Organizations")
            .HasData(
                new OrganizationEntity()
                {
                    Id = 101,
                    NIP = "321312321",
                    Name = "Wsei",
                    REGON = "321312321",
                },
                new OrganizationEntity()
                {
                    Id = 102,
                    NIP = "232332323",
                    Name = "Firma",
                    REGON = "2342342423"
                }
            );
        modelBuilder.Entity<OrganizationEntity>()
            .OwnsOne(o => o.Adress)
            .HasData(
                new {OrganizationEntityId = 101, Street = "Św.Filipa",City = "Kraków"},
                new{OrganizationEntityId = 102, Street = "ŚW Igora", City= "Kraków"}
            );
    modelBuilder.Entity<ContactEntity>()
        .Property(c => c.OrganizationId)
        .HasDefaultValue(101);
    modelBuilder.Entity<ContactEntity>()
            .HasData(new ContactEntity
            {
                Id = 1, 
                FirstName = "John", 
                LastName = "Doe", 
                Email = "john.doe@gmail.com",
                phoneNumber = "123 123 321",
                Birthday = new DateOnly(1980,1,1),
                Created = DateTime.Now,
                OrganizationId = 101,
            },new ContactEntity
            {
                Id = 2, 
                FirstName = "John", 
                LastName = "Doe", 
                Email = "john.doe@gmail.com" ,
                phoneNumber = "123 123 321",
                Birthday = new DateOnly(1980,1,1),
                Created = DateTime.Now,
                OrganizationId = 101,
            });
    }
}