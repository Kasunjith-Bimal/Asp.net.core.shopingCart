using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using ProjectTest.Data;

namespace ProjectTest.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20171011065439_second")]
    partial class second
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.0-rtm-21431")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ProjectTest.Data.Model.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CategoryName");

                    b.Property<string>("Description");

                    b.HasKey("CategoryId");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("ProjectTest.Data.Model.Drink", b =>
                {
                    b.Property<int>("DrinkId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CategoryId");

                    b.Property<string>("ImageThumbnealUrl");

                    b.Property<string>("ImageUrl");

                    b.Property<int>("InStock");

                    b.Property<bool>("IsPrefeedDrink");

                    b.Property<string>("LongtDescription");

                    b.Property<string>("Name");

                    b.Property<decimal>("Price");

                    b.Property<string>("ShortDescription");

                    b.HasKey("DrinkId");

                    b.HasIndex("CategoryId");

                    b.ToTable("Drinks");
                });

            modelBuilder.Entity("ProjectTest.Data.Model.ShopingCardItem", b =>
                {
                    b.Property<int>("ShopingCardItemId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Amount");

                    b.Property<int?>("DrinkId");

                    b.Property<string>("ShopingCardId");

                    b.HasKey("ShopingCardItemId");

                    b.HasIndex("DrinkId");

                    b.ToTable("ShopingCardItems");
                });

            modelBuilder.Entity("ProjectTest.Data.Model.Drink", b =>
                {
                    b.HasOne("ProjectTest.Data.Model.Category", "Category")
                        .WithMany("Drinks")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ProjectTest.Data.Model.ShopingCardItem", b =>
                {
                    b.HasOne("ProjectTest.Data.Model.Drink", "Drink")
                        .WithMany()
                        .HasForeignKey("DrinkId");
                });
        }
    }
}
