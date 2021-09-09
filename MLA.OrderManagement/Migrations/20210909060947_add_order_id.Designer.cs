﻿// <auto-generated />
using System;
using MLA.OrderManagement.Infrustructure.Persistance;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MLA.OrderManagement.Infrustructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20210909060947_add_order_id")]
    partial class add_order_id
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("NewOrderMgt")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.9")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MLA.ClientOrder.Domain.Entities.Clients", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Client_ID")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Client_name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Contact_Person")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Contact_person_Email_Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Contact_person_Phone_Number")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("CreatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Industry_sector")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<Guid?>("LastModifiedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("LastModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Registration_Date")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Client");
                });

            modelBuilder.Entity("MLA.ClientOrder.Domain.Entities.Lawyers", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CreatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<Guid?>("LastModifiedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("LastModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("OrdersId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Role")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("OrdersId");

                    b.ToTable("Layers");
                });

            modelBuilder.Entity("MLA.ClientOrder.Domain.Entities.Orders", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ClientId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CompletedDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("CreatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("CroossJudiciaryExistt")
                        .HasColumnType("bit");

                    b.Property<string>("IdustrySector")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsConfidential")
                        .HasColumnType("bit");

                    b.Property<bool>("IsLawFirmInvolved")
                        .HasColumnType("bit");

                    b.Property<Guid?>("LastModifiedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("LastModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("LeadLayerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("MatterDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OrderId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProjectStatus")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Remark")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("StartedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("TransactionDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TransactionType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("TransactionValue")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.HasIndex("LeadLayerId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("MLA.ClientOrder.Domain.Entities.Clients", b =>
                {
                    b.OwnsOne("MLA.ClientOrder.Domain.ValueObjects.Address", "Address", b1 =>
                        {
                            b1.Property<Guid>("ClientsId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("AddressDescription")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("City")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("Country")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("State")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("ZipCode")
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("ClientsId");

                            b1.ToTable("Client");

                            b1.WithOwner()
                                .HasForeignKey("ClientsId");
                        });

                    b.Navigation("Address");
                });

            modelBuilder.Entity("MLA.ClientOrder.Domain.Entities.Lawyers", b =>
                {
                    b.HasOne("MLA.ClientOrder.Domain.Entities.Orders", null)
                        .WithMany("OtherLayers")
                        .HasForeignKey("OrdersId");
                });

            modelBuilder.Entity("MLA.ClientOrder.Domain.Entities.Orders", b =>
                {
                    b.HasOne("MLA.ClientOrder.Domain.Entities.Clients", "Client")
                        .WithMany()
                        .HasForeignKey("ClientId");

                    b.HasOne("MLA.ClientOrder.Domain.Entities.Lawyers", "LeadLayer")
                        .WithMany()
                        .HasForeignKey("LeadLayerId");

                    b.OwnsMany("MLA.ClientOrder.Domain.ValueObjects.CrossJudiciaries", "CrossJudiciaries", b1 =>
                        {
                            b1.Property<Guid>("OrdersId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<int>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int")
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<string>("Judiciaries")
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("OrdersId", "Id");

                            b1.ToTable("CrossJudiciaries");

                            b1.WithOwner()
                                .HasForeignKey("OrdersId");
                        });

                    b.OwnsMany("MLA.ClientOrder.Domain.Values.LawFirmInvolved", "LawFirmInvolved", b1 =>
                        {
                            b1.Property<Guid>("OrdersId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<int>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int")
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<string>("LawFirm")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("Role")
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("OrdersId", "Id");

                            b1.ToTable("LawFirmInvolved");

                            b1.WithOwner()
                                .HasForeignKey("OrdersId");
                        });

                    b.Navigation("Client");

                    b.Navigation("CrossJudiciaries");

                    b.Navigation("LawFirmInvolved");

                    b.Navigation("LeadLayer");
                });

            modelBuilder.Entity("MLA.ClientOrder.Domain.Entities.Orders", b =>
                {
                    b.Navigation("OtherLayers");
                });
#pragma warning restore 612, 618
        }
    }
}
