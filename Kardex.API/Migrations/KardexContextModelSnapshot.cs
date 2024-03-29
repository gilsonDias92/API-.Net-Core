﻿// <auto-generated />
using System;
using Kardex.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Kardex.API.Migrations
{
    [DbContext(typeof(KardexContext))]
    partial class KardexContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.8-servicing-32085")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Kardex.API.Models.Board", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Board");
                });

            modelBuilder.Entity("Kardex.API.Models.Card", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CardListId");

                    b.Property<string>("Content")
                        .HasMaxLength(200);

                    b.Property<DateTime>("DateAdded");

                    b.Property<string>("Lables");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<int>("UserId");

                    b.Property<bool?>("Visible");

                    b.HasKey("Id");

                    b.HasIndex("CardListId");

                    b.HasIndex("UserId");

                    b.ToTable("Card");
                });

            modelBuilder.Entity("Kardex.API.Models.CardList", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Creatable");

                    b.Property<int>("ProduceId");

                    b.Property<int?>("ProduceId1");

                    b.Property<string>("Title")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.HasIndex("ProduceId");

                    b.HasIndex("ProduceId1");

                    b.ToTable("CardList");
                });

            modelBuilder.Entity("Kardex.API.Models.Panel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("BoardId");

                    b.Property<int?>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("BoardId");

                    b.HasIndex("UserId");

                    b.ToTable("Panel");
                });

            modelBuilder.Entity("Kardex.API.Models.Produce", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("PanelId");

                    b.HasKey("Id");

                    b.HasIndex("PanelId");

                    b.ToTable("Produce");
                });

            modelBuilder.Entity("Kardex.API.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<string>("Icon");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.HasKey("Id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("Kardex.API.Models.Board", b =>
                {
                    b.HasOne("Kardex.API.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Kardex.API.Models.Card", b =>
                {
                    b.HasOne("Kardex.API.Models.CardList", "CardList")
                        .WithMany("Cards")
                        .HasForeignKey("CardListId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Kardex.API.Models.User", "User")
                        .WithMany("Cards")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Kardex.API.Models.CardList", b =>
                {
                    b.HasOne("Kardex.API.Models.Panel", "Produce")
                        .WithMany()
                        .HasForeignKey("ProduceId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Kardex.API.Models.Produce")
                        .WithMany("Cardlists")
                        .HasForeignKey("ProduceId1");
                });

            modelBuilder.Entity("Kardex.API.Models.Panel", b =>
                {
                    b.HasOne("Kardex.API.Models.Board", "Board")
                        .WithMany("Panels")
                        .HasForeignKey("BoardId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Kardex.API.Models.User")
                        .WithMany("Panels")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Kardex.API.Models.Produce", b =>
                {
                    b.HasOne("Kardex.API.Models.Panel", "Panel")
                        .WithMany("Produces")
                        .HasForeignKey("PanelId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
