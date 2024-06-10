using Microsoft.EntityFrameworkCore;
using TugasAkhir_VsCode.Models;

namespace TugasAkhir_VsCode.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {

    }

    public DbSet<Roles> tb_roles { get; }
    public DbSet<Users> tb_users { get; set; }
    public DbSet<Items> tb_items { get; set; }
    public DbSet<Booking> tb_bookings { get; set;}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // modelBuilder.Entity<Roles>().HasData(new Roles[]
        // {
        //     new Roles
        //     {
        //         RolesId = "R0001",
        //         Name = "Owner"
        //     },
        //     new Roles
        //     {
        //         RolesId = "R0002",
        //         Name ="Admin"
        //     }
        // });

        modelBuilder.Entity<Users>().HasData(new Users[]
        {
            new Users
            {
                UserId = "U0001",
                Name = "Administrator",
                Username = "admin",
                Password = "Admin2024",
                BgEffDate = DateTime.Now,
                Status = "0",
                Role_User = "Admin"
            }
        });
    }
}