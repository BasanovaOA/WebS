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
                    IsMedHelpFree = "Признак осуществления организацией здравоохранения деятельности в сфере бесплатного оказания гражданам медицинской помощи в городе Москве\nДа",
                    FullName = "Государственное бюджетное учреждение здравоохранения города Москвы \n"+
                    "«Центр патологии речи и нейрореабилитации Департамента здравоохранения города Москвы»"


                },
                new
                {
                    Id = 2L,
                    IsMedHelpFree = "Признак осуществления организацией здравоохранения деятельности в сфере бесплатного оказания гражданам медицинской помощи в городе Москве\nДа",
                    FullName = "Государственное бюджетное учреждение здравоохранения города Москвы\n" +
                    "«Научно-исследовательский институт скорой помощи им. Н.В. Склифосовского Департамента здравоохранения города Москвы»"

                },
                new
                {
                    Id = 3L,
                    IsMedHelpFree = "Признак осуществления организацией здравоохранения деятельности в сфере бесплатного оказания гражданам медицинской помощи в городе Москве\nНет",
                    FullName = "Государственное бюджетное учреждение здравоохранения города Москвы\n" +
                    "«Центр патологии речи и нейрореабилитации Департамента здравоохранения города Москвы»"

                },
                new
                {
                    Id = 4L,
                    IsMedHelpFree = "Признак осуществления организацией здравоохранения деятельности в сфере бесплатного оказания гражданам медицинской помощи в городе Москве\nНет",
                    FullName = "Государственное бюджетное учреждение здравоохранения города Москвы\n" +
                    "«Московский городской центр реабилитации больных со спинномозговой травмой и последствиями детского церебрального паралича\n" +
                    "Департамента здравоохранения города Москвы»"

                }
            );
        }
    }
}
