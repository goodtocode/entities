﻿// <auto-generated />
using System;
using GoodToCode.Subjects.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace GoodToCode.Shared.Infrastructure.Persistence.Migrations
{
    [DbContext(typeof(SubjectsDbContext))]
    partial class SubjectsDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("GoodToCode.Subjects.Models.Associate", b =>
                {
                    b.Property<Guid>("AssociateKey")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("AssociateKey");

                    b.HasIndex("AssociateKey")
                        .IsUnique()
                        .HasName("IX_AssociateLocation_Associate");

                    b.ToTable("Associate","Subjects");
                });

            modelBuilder.Entity("GoodToCode.Subjects.Models.AssociateDetail", b =>
                {
                    b.Property<Guid>("AssociateDetailKey")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AssociateKey")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("DetailKey")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("AssociateDetailKey");

                    b.HasIndex("AssociateDetailKey")
                        .IsUnique()
                        .HasName("IX_AssociateDetail_Key");

                    b.HasIndex("AssociateKey", "AssociateDetailKey")
                        .IsUnique()
                        .HasName("IX_AssociateDetail_All");

                    b.ToTable("AssociateDetail","Subjects");
                });

            modelBuilder.Entity("GoodToCode.Subjects.Models.AssociateOption", b =>
                {
                    b.Property<Guid>("AssociateOptionKey")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AssociateKey")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("OptionKey")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("AssociateOptionKey");

                    b.HasIndex("AssociateKey", "OptionKey")
                        .IsUnique()
                        .HasName("IX_AssociateOption_All");

                    b.ToTable("AssociateOption","Subjects");
                });

            modelBuilder.Entity("GoodToCode.Subjects.Models.Business", b =>
                {
                    b.Property<Guid>("BusinessKey")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("BusinessName")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("TaxNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.HasKey("BusinessKey");

                    b.HasIndex("BusinessKey")
                        .IsUnique()
                        .HasName("IX_Business_Key");

                    b.ToTable("Business","Subjects");
                });

            modelBuilder.Entity("GoodToCode.Subjects.Models.Detail", b =>
                {
                    b.Property<Guid>("DetailKey")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("DetailData")
                        .IsRequired()
                        .HasColumnType("nvarchar(2000)")
                        .HasMaxLength(2000);

                    b.Property<Guid>("DetailTypeKey")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("DetailKey");

                    b.HasIndex("DetailKey")
                        .IsUnique()
                        .HasName("IX_Detail_Key");

                    b.ToTable("Detail","Subjects");
                });

            modelBuilder.Entity("GoodToCode.Subjects.Models.DetailType", b =>
                {
                    b.Property<Guid>("DetailTypeKey")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("DetailTypeDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(250)")
                        .HasMaxLength(250);

                    b.Property<string>("DetailTypeName")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("DetailTypeKey");

                    b.HasIndex("DetailTypeKey")
                        .IsUnique()
                        .HasName("IX_DetailType_Key");

                    b.ToTable("DetailType","Subjects");
                });

            modelBuilder.Entity("GoodToCode.Subjects.Models.Gender", b =>
                {
                    b.Property<Guid>("GenderKey")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("GenderCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(10)")
                        .HasMaxLength(10);

                    b.Property<string>("GenderName")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("GenderKey");

                    b.HasIndex("GenderCode")
                        .IsUnique()
                        .HasName("IX_Gender_Code");

                    b.HasIndex("GenderKey")
                        .IsUnique()
                        .HasName("IX_Gender_Key");

                    b.ToTable("Gender","Subjects");

                    b.HasCheckConstraint("CC_Gender_GenderCode", "GenderCode in ('M', 'F', 'N/A', 'U/K')");
                });

            modelBuilder.Entity("GoodToCode.Subjects.Models.Government", b =>
                {
                    b.Property<Guid>("GovernmentKey")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("GovernmentName")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("GovernmentKey");

                    b.HasIndex("GovernmentKey")
                        .IsUnique()
                        .HasName("IX_Government_Associate");

                    b.ToTable("Government","Subjects");
                });

            modelBuilder.Entity("GoodToCode.Subjects.Models.Item", b =>
                {
                    b.Property<Guid>("ItemKey")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ItemDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(2000)")
                        .HasMaxLength(2000);

                    b.Property<string>("ItemName")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<Guid>("ItemTypeKey")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ItemKey");

                    b.HasIndex("ItemKey")
                        .IsUnique();

                    b.ToTable("Item","Subjects");
                });

            modelBuilder.Entity("GoodToCode.Subjects.Models.ItemGroup", b =>
                {
                    b.Property<Guid>("ItemGroupKey")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ItemGroupDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(250)")
                        .HasMaxLength(250);

                    b.Property<string>("ItemGroupName")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("ItemGroupKey");

                    b.HasIndex("ItemGroupKey")
                        .IsUnique()
                        .HasName("IX_ItemGroup_Key");

                    b.ToTable("ItemGroup","Subjects");
                });

            modelBuilder.Entity("GoodToCode.Subjects.Models.ItemType", b =>
                {
                    b.Property<Guid>("ItemTypeKey")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ItemGroupKey")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ItemTypeDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(250)")
                        .HasMaxLength(250);

                    b.Property<string>("ItemTypeName")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("ItemTypeKey");

                    b.HasIndex("ItemTypeKey")
                        .IsUnique()
                        .HasName("IX_ItemType_Key");

                    b.ToTable("ItemType","Subjects");
                });

            modelBuilder.Entity("GoodToCode.Subjects.Models.Option", b =>
                {
                    b.Property<Guid>("OptionKey")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("OptionCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(10)")
                        .HasMaxLength(10);

                    b.Property<string>("OptionDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(250)")
                        .HasMaxLength(250);

                    b.Property<Guid>("OptionGroupKey")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("OptionName")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<int>("SortOrder")
                        .HasColumnType("int");

                    b.HasKey("OptionKey");

                    b.HasIndex("OptionKey")
                        .IsUnique();

                    b.HasIndex("OptionGroupKey", "OptionCode")
                        .IsUnique()
                        .HasName("IX_Option_OptionCode");

                    b.ToTable("Option","Subjects");
                });

            modelBuilder.Entity("GoodToCode.Subjects.Models.OptionGroup", b =>
                {
                    b.Property<Guid>("OptionGroupKey")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("OptionGroupCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(10)")
                        .HasMaxLength(10);

                    b.Property<string>("OptionGroupDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(250)")
                        .HasMaxLength(250);

                    b.Property<string>("OptionGroupName")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("OptionGroupKey");

                    b.HasIndex("OptionGroupCode")
                        .IsUnique()
                        .HasName("IX_Option_OptionGroupCode");

                    b.HasIndex("OptionGroupKey")
                        .IsUnique()
                        .HasName("IX_Option_OptionGroupKey");

                    b.ToTable("OptionGroup","Subjects");
                });

            modelBuilder.Entity("GoodToCode.Subjects.Models.Person", b =>
                {
                    b.Property<Guid>("PersonKey")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("GenderCode")
                        .HasColumnType("nvarchar(3)")
                        .HasMaxLength(3);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("MiddleName")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("PersonKey");

                    b.HasIndex("PersonKey")
                        .IsUnique()
                        .HasName("IX_Person_Associate");

                    b.HasIndex("FirstName", "MiddleName", "LastName", "BirthDate")
                        .HasName("IX_Person_All");

                    b.ToTable("Person","Subjects");

                    b.HasCheckConstraint("CC_Person_GenderCode", "GenderCode in ('M', 'F', 'N/A', 'U/K')");
                });

            modelBuilder.Entity("GoodToCode.Subjects.Models.Resource", b =>
                {
                    b.Property<Guid>("ResourceKey")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ResourceDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(250)")
                        .HasMaxLength(250);

                    b.Property<string>("ResourceName")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("ResourceKey");

                    b.HasIndex("ResourceKey")
                        .IsUnique();

                    b.ToTable("Resource","Subjects");
                });

            modelBuilder.Entity("GoodToCode.Subjects.Models.ResourceItem", b =>
                {
                    b.Property<Guid>("ResourceItemKey")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ItemKey")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ResourceKey")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ResourceItemKey");

                    b.HasIndex("ItemKey")
                        .HasName("IX_ResourceItem_Item");

                    b.HasIndex("ResourceItemKey")
                        .IsUnique()
                        .HasName("IX_ResourceItem_Key");

                    b.HasIndex("ResourceKey")
                        .HasName("IX_ResourceItem_Resource");

                    b.HasIndex("ResourceKey", "ItemKey")
                        .IsUnique()
                        .HasName("IX_ResourceItem_All");

                    b.ToTable("ResourceItem","Subjects");
                });

            modelBuilder.Entity("GoodToCode.Subjects.Models.ResourcePerson", b =>
                {
                    b.Property<Guid>("ResourcePersonKey")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("PersonKey")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ResourceKey")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ResourcePersonKey");

                    b.HasIndex("PersonKey")
                        .HasName("IX_ResourcePerson_Person");

                    b.HasIndex("ResourceKey")
                        .HasName("IX_ResourcePerson_Resource");

                    b.HasIndex("ResourcePersonKey")
                        .IsUnique()
                        .HasName("IX_ResourcePerson_Key");

                    b.HasIndex("ResourceKey", "PersonKey")
                        .IsUnique()
                        .HasName("IX_ResourcePerson_All");

                    b.ToTable("ResourcePerson","Subjects");
                });

            modelBuilder.Entity("GoodToCode.Subjects.Models.ResourceType", b =>
                {
                    b.Property<Guid>("ResourceTypeKey")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ResourceTypeDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(250)")
                        .HasMaxLength(250);

                    b.Property<string>("ResourceTypeName")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("ResourceTypeKey");

                    b.HasIndex("ResourceTypeKey")
                        .IsUnique()
                        .HasName("IX_ResourceType_Key");

                    b.ToTable("ResourceType","Subjects");
                });

            modelBuilder.Entity("GoodToCode.Subjects.Models.Venture", b =>
                {
                    b.Property<Guid>("VentureKey")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("VentureDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(250)")
                        .HasMaxLength(250);

                    b.Property<Guid?>("VentureGroupKey")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("VentureName")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("VentureSlogan")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<Guid?>("VentureTypeKey")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("VentureKey");

                    b.HasIndex("VentureKey")
                        .IsUnique();

                    b.ToTable("Venture","Subjects");
                });

            modelBuilder.Entity("GoodToCode.Subjects.Models.VentureAssociateOption", b =>
                {
                    b.Property<Guid>("VentureAssociateOptionKey")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AssociateKey")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("OptionKey")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("VentureKey")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("VentureAssociateOptionKey");

                    b.HasIndex("VentureAssociateOptionKey")
                        .IsUnique()
                        .HasName("IX_VentureAssociateOption_Key");

                    b.ToTable("VentureAssociateOption","Subjects");
                });

            modelBuilder.Entity("GoodToCode.Subjects.Models.VentureDetail", b =>
                {
                    b.Property<Guid>("VentureDetailKey")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("DetailKey")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("VentureKey")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("VentureDetailKey");

                    b.HasIndex("VentureDetailKey")
                        .IsUnique()
                        .HasName("IX_VentureDetail_Key");

                    b.HasIndex("VentureKey", "VentureDetailKey")
                        .IsUnique()
                        .HasName("IX_VentureDetail_All");

                    b.ToTable("VentureDetail","Subjects");
                });

            modelBuilder.Entity("GoodToCode.Subjects.Models.VentureOption", b =>
                {
                    b.Property<Guid>("VentureOptionKey")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("OptionKey")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("VentureKey")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("VentureOptionKey");

                    b.HasIndex("VentureKey", "OptionKey")
                        .IsUnique()
                        .HasName("IX_VentureOption_All");

                    b.ToTable("VentureOption","Subjects");
                });

            modelBuilder.Entity("GoodToCode.Subjects.Models.VentureResource", b =>
                {
                    b.Property<Guid>("VentureResourceKey")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ResourceKey")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ResourceTypeKey")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("VentureKey")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("VentureResourceKey");

                    b.HasIndex("VentureResourceKey")
                        .IsUnique()
                        .HasName("IX_VentureResource_Key");

                    b.HasIndex("VentureKey", "ResourceKey")
                        .IsUnique()
                        .HasName("IX_VentureResource_All");

                    b.ToTable("VentureResource","Subjects");
                });
#pragma warning restore 612, 618
        }
    }
}
