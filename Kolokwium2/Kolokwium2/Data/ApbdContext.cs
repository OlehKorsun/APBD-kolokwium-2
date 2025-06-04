using System;
using System.Collections.Generic;
using Kolokwium2.Models;
using Microsoft.EntityFrameworkCore;

namespace Kolokwium2.Data;

public partial class ApbdContext : DbContext
{
    
    public DbSet<ProgramEntity> Programs { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Washing_Machine> WashingMachines { get; set; }
    public DbSet<Available_Program> AvailablePrograms { get; set; }
    public DbSet<Purchase_History> PurchaseHistory { get; set; }
    
    public ApbdContext()
    {
    }

    public ApbdContext(DbContextOptions<ApbdContext> options)
        : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=ConnectionStrings:DefaultConnection");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        OnModelCreatingPartial(modelBuilder);
        // Sees 
        modelBuilder.Entity<Customer>().HasData(new List<Customer>()
        {
            new Customer(){CustomerId = 1, FirstName = "John", LastName = "Doe"},
            new Customer(){CustomerId = 2, FirstName = "Jane", LastName = "Doe"},
            new Customer(){CustomerId = 3, FirstName = "Julie", LastName = "Doe"},
        });


        modelBuilder.Entity<Washing_Machine>().HasData(new List<Washing_Machine>()
        {
            new Washing_Machine(){WashingMachineId = 1, MaxWeight = 96.5, SerialNumber = "Serial number 1"},
            new Washing_Machine(){WashingMachineId = 2, MaxWeight = 106.0, SerialNumber = "Serial number 2"},
            new Washing_Machine(){WashingMachineId = 3, MaxWeight = 57.4, SerialNumber = "Serial number 3"},
        });

        modelBuilder.Entity<ProgramEntity>().HasData(new List<ProgramEntity>()
        {
            new ProgramEntity(){ProgramId = 1, Name = "Program 1", DurationMinutes = 50, TemperatureCelsius = 90},
            new ProgramEntity(){ProgramId = 2, Name = "Program 2", DurationMinutes = 60, TemperatureCelsius = 60},
            new ProgramEntity(){ProgramId = 3, Name = "Program 3", DurationMinutes = 15, TemperatureCelsius = 30},
        });


        modelBuilder.Entity<Available_Program>().HasData(new List<Available_Program>()
        {
            new Available_Program(){AvailableProgramId = 1, WashingMachineId = 1, ProgramId = 1, Price = 9.99},
            new Available_Program(){AvailableProgramId = 2, WashingMachineId = 1, ProgramId = 2, Price = 15.99},
            new Available_Program(){AvailableProgramId = 3, WashingMachineId = 2, ProgramId = 3, Price = 68.99},
            new Available_Program(){AvailableProgramId = 4, WashingMachineId = 3, ProgramId = 2, Price = 19.99},
            new Available_Program(){AvailableProgramId = 5, WashingMachineId = 3, ProgramId = 3, Price = 95.99},
        });


        modelBuilder.Entity<Purchase_History>().HasData(new List<Purchase_History>()
        {
            new Purchase_History(){AvailableProgramId = 1, CustomerId = 1, PurchaseDate = DateTime.Parse("2024-05-06"), Rating = 3},
            new Purchase_History(){AvailableProgramId = 2, CustomerId = 1, PurchaseDate = DateTime.Parse("2024-05-07"), Rating = 3},
            new Purchase_History(){AvailableProgramId = 3, CustomerId = 2, PurchaseDate = DateTime.Parse("2024-07-08")},
            new Purchase_History(){AvailableProgramId = 4, CustomerId = 3, PurchaseDate = DateTime.Parse("2024-05-09")},
            new Purchase_History(){AvailableProgramId = 5, CustomerId = 2, PurchaseDate = DateTime.Parse("2024-09-16")},
        });
        

        
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
