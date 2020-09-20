﻿// <auto-generated />
using System;
using GoodToCode.Locality.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace GoodToCode.Locality.Infrastructure.Persistence.Migrations.Migrations
{
    [DbContext(typeof(LocalityDbContextDeploy))]
    partial class LocalityDbContextDeployModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("GoodToCode.Locality.Models.AssociateLocation", b =>
                {
                    b.Property<Guid>("RowKey")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AssociateKey")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AssociateLocationKey")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("LocationKey")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("LocationTypeKey")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("PartitionKey")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RowKey");

                    b.HasIndex("AssociateKey", "LocationKey")
                        .IsUnique()
                        .HasName("IX_AssociateLocation_All");

                    b.ToTable("AssociateLocation","Locality");
                });

            modelBuilder.Entity("GoodToCode.Locality.Models.GeoDistance", b =>
                {
                    b.Property<Guid>("RowKey")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("EndLatLongKey")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("GeoDistanceKey")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("PartitionKey")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("StartLatLongKey")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("RowKey");

                    b.HasIndex("GeoDistanceKey")
                        .IsUnique()
                        .HasName("IX_GeoDistance_Key");

                    b.ToTable("GeoDistance","Locality");
                });

            modelBuilder.Entity("GoodToCode.Locality.Models.LatLong", b =>
                {
                    b.Property<Guid>("RowKey")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("LatLongKey")
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("Latitude")
                        .HasColumnType("float");

                    b.Property<double>("Longitude")
                        .HasColumnType("float");

                    b.Property<string>("PartitionKey")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RowKey");

                    b.HasIndex("LatLongKey")
                        .IsUnique()
                        .HasName("IX_LatLong_Key");

                    b.ToTable("LatLong","Locality");
                });

            modelBuilder.Entity("GoodToCode.Locality.Models.Location", b =>
                {
                    b.Property<Guid>("RowKey")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("LocationDescription")
                        .HasColumnType("nvarchar(2000)")
                        .HasMaxLength(2000);

                    b.Property<Guid>("LocationKey")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("LocationName")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("PartitionKey")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RowKey");

                    b.HasIndex("LocationKey")
                        .IsUnique();

                    b.ToTable("Location","Locality");
                });

            modelBuilder.Entity("GoodToCode.Locality.Models.LocationArea", b =>
                {
                    b.Property<Guid>("RowKey")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("LocationAreaKey")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("LocationKey")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("PartitionKey")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("PolygonKey")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("RowKey");

                    b.HasIndex("LocationAreaKey")
                        .IsUnique()
                        .HasName("IX_LocationArea_Key");

                    b.HasIndex("LocationKey")
                        .HasName("IX_LocationArea_LocationId");

                    b.HasIndex("LocationKey", "PolygonKey")
                        .IsUnique()
                        .HasName("IX_LocationArea_All");

                    b.ToTable("LocationArea","Locality");
                });

            modelBuilder.Entity("GoodToCode.Locality.Models.LocationType", b =>
                {
                    b.Property<Guid>("RowKey")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("LocationTypeDescription")
                        .HasColumnType("nvarchar(250)")
                        .HasMaxLength(250);

                    b.Property<Guid>("LocationTypeKey")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("LocationTypeName")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("PartitionKey")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RowKey");

                    b.HasIndex("LocationTypeKey")
                        .IsUnique()
                        .HasName("IX_LocationType_Key");

                    b.ToTable("LocationType","Locality");
                });

            modelBuilder.Entity("GoodToCode.Locality.Models.ResourceLocation", b =>
                {
                    b.Property<Guid>("RowKey")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("LocationKey")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("LocationTypeKey")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("PartitionKey")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("ResourceKey")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ResourceLocationKey")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("RowKey");

                    b.HasIndex("ResourceKey", "LocationKey")
                        .IsUnique()
                        .HasName("IX_ResourceLocation_All");

                    b.ToTable("ResourceLocation","Locality");
                });

            modelBuilder.Entity("GoodToCode.Locality.Models.VentureLocation", b =>
                {
                    b.Property<Guid>("RowKey")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("LocationKey")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("LocationTypeKey")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("PartitionKey")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("VentureKey")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("VentureLocationKey")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("RowKey");

                    b.HasIndex("VentureLocationKey")
                        .IsUnique()
                        .HasName("IX_VentureLocation_Key");

                    b.HasIndex("VentureKey", "LocationKey")
                        .IsUnique()
                        .HasName("IX_VentureLocation_All");

                    b.ToTable("VentureLocation","Locality");
                });
#pragma warning restore 612, 618
        }
    }
}
