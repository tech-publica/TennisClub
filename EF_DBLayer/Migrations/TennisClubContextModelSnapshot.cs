﻿// <auto-generated />
using EF_DBLayer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EF_DBLayer.Migrations
{
    [DbContext(typeof(TennisClubContext))]
    partial class TennisClubContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.2-servicing-10034")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TennisClubModel.Court", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CourtType");

                    b.Property<bool>("HasRoof");

                    b.Property<decimal>("HourlyCourtCost");

                    b.Property<decimal>("HourlyIlluminationCost");

                    b.Property<double>("Length");

                    b.Property<double>("Width");

                    b.HasKey("Id");

                    b.ToTable("Courts");

                    b.HasDiscriminator<int>("CourtType");
                });

            modelBuilder.Entity("TennisClubModel.PadelCourt", b =>
                {
                    b.HasBaseType("TennisClubModel.Court");

                    b.HasDiscriminator().HasValue(2);
                });

            modelBuilder.Entity("TennisClubModel.TennisCourt", b =>
                {
                    b.HasBaseType("TennisClubModel.Court");

                    b.HasDiscriminator().HasValue(1);
                });
#pragma warning restore 612, 618
        }
    }
}
