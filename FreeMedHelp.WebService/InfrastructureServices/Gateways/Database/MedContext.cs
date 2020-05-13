using Microsoft.EntityFrameworkCore;
using FreeMedHelp.DomainObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace FreeMedHelp.InfrastructureServices.Gateways.Database
{
    public class MedContext : DbContext
    {
        public DbSet<MedPoint> MedPoints { get; set; }

        public MedContext(DbContextOptions options)
            : base(options)
        { }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            FillTestData(modelBuilder);
        }
        private void FillTestData(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<MedPoint>().HasData(
                new
                {
                    Id = 1L,
                    IsMedHelpFree = "591",
                    FullName = @"Метро ""Войковская"" - Станция Ховрино",
                
                },
                new
                {
                    Id = 2L,
                    IsMedHelpFree = "191",
                    FullName = @"Метро ""Селигерская"" - Станция Ховрино",

                },
                new
                {
                    Id = 3L,
                    IsMedHelpFree = "215к",
                    FullName = @"Метро ""Селигерская"" - Станция Ховрино",

                },
                new
                {
                    Id = 4L,
                    IsMedHelpFree = "59",
                    FullName = @"Метро ""Сокол"" - Улица Генерала Глаголева",
 
                }
            );
        }
    }
}
