﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using tradeofexile.persistance;

namespace tradeofexile.persistance.Migrations
{
    [DbContext(typeof(TradeOfExileDbContext))]
    partial class TradeOfExileDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.4");

            modelBuilder.Entity("tradeofexile.models.Items.Extended", b =>
                {
                    b.Property<byte[]>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("varbinary(16)");

                    b.Property<string>("BaseType")
                        .HasColumnType("text");

                    b.Property<int>("Category")
                        .HasColumnType("int");

                    b.Property<byte[]>("ItemId")
                        .HasColumnType("varbinary(16)");

                    b.HasKey("Id");

                    b.ToTable("Extendeds");
                });

            modelBuilder.Entity("tradeofexile.models.Items.Item", b =>
                {
                    b.Property<byte[]>("Id")
                        .HasColumnType("varbinary(16)");

                    b.Property<string>("IconLink")
                        .HasColumnType("text");

                    b.Property<int>("League")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Items");
                });

            modelBuilder.Entity("tradeofexile.models.Items.Price", b =>
                {
                    b.Property<byte[]>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("varbinary(16)");

                    b.Property<double>("Ammount")
                        .HasColumnType("double");

                    b.Property<int>("CurrencyType")
                        .HasColumnType("int");

                    b.Property<byte[]>("ItemId")
                        .HasColumnType("varbinary(16)");

                    b.HasKey("Id");

                    b.HasIndex("ItemId")
                        .IsUnique();

                    b.ToTable("Prices");
                });

            modelBuilder.Entity("tradeofexile.models.Items.Item", b =>
                {
                    b.HasOne("tradeofexile.models.Items.Extended", "Extended")
                        .WithOne("Item")
                        .HasForeignKey("tradeofexile.models.Items.Item", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Extended");
                });

            modelBuilder.Entity("tradeofexile.models.Items.Price", b =>
                {
                    b.HasOne("tradeofexile.models.Items.Item", "Item")
                        .WithOne("Price")
                        .HasForeignKey("tradeofexile.models.Items.Price", "ItemId");

                    b.Navigation("Item");
                });

            modelBuilder.Entity("tradeofexile.models.Items.Extended", b =>
                {
                    b.Navigation("Item");
                });

            modelBuilder.Entity("tradeofexile.models.Items.Item", b =>
                {
                    b.Navigation("Price");
                });
#pragma warning restore 612, 618
        }
    }
}
