﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using FreeMedHelp.InfrastructureServices.Gateways.Database;

namespace FreeMedHelp.WebService.Migrations
{
    [DbContext(typeof(MedContext))]
    [Migration("20200509130754_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3");

            modelBuilder.Entity("FreeMedHelp.DomainObjects.MedPoint", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("FullName")
                        .HasColumnType("TEXT");

                    b.Property<string>("IsMedHelpFree")
                        .HasColumnType("TEXT");


                    b.HasKey("Id");

                    b.ToTable("MedPoints");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                             FullName = "Государственное бюджетное учреждение города Москвы «Станция скорой и неотложной медицинской помощи им. А.С. Пучкова» Департамента здравоохранения города Москвы", 
                        IsMedHelpFree = "Да", 
                        },
                        new
                        {
                            Id = 2L,
                          FullName = "Государственное бюджетное учреждение здравоохранения города Москвы «Научно-исследовательский институт скорой помощи им. Н.В. Склифосовского Департамента здравоохранения города Москвы»", 
                        IsMedHelpFree = "Да", 

                        },
                        new
                        {
                            Id = 3L,
                            FullName = "Государственное бюджетное учреждение здравоохранения города Москвы «Центр патологии речи и нейрореабилитации Департамента здравоохранения города Москвы»", 
                        IsMedHelpFree = "Нет", 

                        },
                        new
                        {
                            Id = 4L,
                            FullFullName = "Государственное бюджетное учреждение здравоохранения города Москвы «Московский городской центр реабилитации больных со спинномозговой травмой и последствиями детского церебрального паралича Департамента здравоохранения города Москвы»",
                            IsMedHelpFree = "Нет",

                        });
                });

#pragma warning restore 612, 618
        }
    }
}
