﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SimpleTrader.EntityFramework;

namespace SimpleTrader.EntityFramework.Migrations
{
    [DbContext(typeof(SimpleTraderDBContext))]
    partial class SimpleTraderDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SimpleTrader.Domain.Models.Account", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AccountHolderId");

                    b.Property<double>("Balance");

                    b.HasKey("Id");

                    b.HasIndex("AccountHolderId");

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("SimpleTrader.Domain.Models.AssetTransaction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AccountId");

                    b.Property<DateTime>("DateProcessed");

                    b.Property<bool>("IsPurchase");

                    b.Property<int>("Shares");

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.ToTable("AssetTransactions");
                });

            modelBuilder.Entity("SimpleTrader.Domain.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateJoined");

                    b.Property<string>("Email");

                    b.Property<string>("PasswordHash");

                    b.Property<string>("Username");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("SimpleTrader.Domain.Models.Account", b =>
                {
                    b.HasOne("SimpleTrader.Domain.Models.User", "AccountHolder")
                        .WithMany()
                        .HasForeignKey("AccountHolderId");
                });

            modelBuilder.Entity("SimpleTrader.Domain.Models.AssetTransaction", b =>
                {
                    b.HasOne("SimpleTrader.Domain.Models.Account", "Account")
                        .WithMany("AssetTransactions")
                        .HasForeignKey("AccountId");

                    b.OwnsOne("SimpleTrader.Domain.Models.Asset", "Asset", b1 =>
                        {
                            b1.Property<int>("AssetTransactionId")
                                .ValueGeneratedOnAdd()
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<double>("PricePerShare");

                            b1.Property<string>("Symbol");

                            b1.HasKey("AssetTransactionId");

                            b1.ToTable("AssetTransactions");

                            b1.HasOne("SimpleTrader.Domain.Models.AssetTransaction")
                                .WithOne("Asset")
                                .HasForeignKey("SimpleTrader.Domain.Models.Asset", "AssetTransactionId")
                                .OnDelete(DeleteBehavior.Cascade);
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
