﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TestTask.Data;

#nullable disable

namespace TestTask.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20230919162351_q")]
    partial class q
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("TestTask.Models.Folder", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<int?>("FolderId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("FolderId");

                    b.ToTable("Folders");
                });

            modelBuilder.Entity("TestTask.Models.Folder", b =>
                {
                    b.HasOne("TestTask.Models.Folder", null)
                        .WithMany("Folders")
                        .HasForeignKey("FolderId");
                });

            modelBuilder.Entity("TestTask.Models.Folder", b =>
                {
                    b.Navigation("Folders");
                });
#pragma warning restore 612, 618
        }
    }
}
