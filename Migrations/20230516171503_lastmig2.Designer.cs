﻿// <auto-generated />
using Blogify.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Blogify.Migrations
{
    [DbContext(typeof(BlogifyContext))]
    [Migration("20230516171503_lastmig2")]
    partial class lastmig2
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Blogify.Models.Bildiri", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Mesaj")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Okundumu")
                        .HasColumnType("bit");

                    b.Property<int>("WriterId")
                        .HasColumnType("int");

                    b.Property<string>("WriterName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Bildiris");
                });

            modelBuilder.Entity("Blogify.Models.Blog", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("WriterId")
                        .HasColumnType("int");

                    b.Property<string>("WriterName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("blogCategory")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("blogDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("blogImage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("blogTitle")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Blogs");
                });

            modelBuilder.Entity("Blogify.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nickname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
