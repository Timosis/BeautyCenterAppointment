﻿// <auto-generated />
using System;
using BeautyCenter.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BeautyCenter.Data.Context.Migrations
{
    [DbContext(typeof(BeautyCenterContext))]
    [Migration("20190404082440_beauty7")]
    partial class beauty7
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.2-servicing-10034")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BeautyCenter.Data.Entities.Appointments.Appointment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AppointmentStatus");

                    b.Property<string>("Color")
                        .IsRequired()
                        .HasColumnType("varchar(150)")
                        .HasMaxLength(150);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime");

                    b.Property<int>("CreatedBy");

                    b.Property<int>("CustomerId");

                    b.Property<string>("Description");

                    b.Property<DateTime>("EndTime")
                        .HasColumnType("datetime");

                    b.Property<bool>("IsDeleted");

                    b.Property<bool>("IsFullDay")
                        .HasColumnType("bit");

                    b.Property<DateTime>("ModifiedAt");

                    b.Property<int>("ModifiedBy");

                    b.Property<int>("ServiceId");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("datetime");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("varchar(150)")
                        .HasMaxLength(150);

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("ServiceId");

                    b.ToTable("Appointment","Appointment");
                });

            modelBuilder.Entity("BeautyCenter.Data.Entities.Customers.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime");

                    b.Property<int>("CreatedBy");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(150)")
                        .HasMaxLength(150);

                    b.Property<string>("Firstname")
                        .IsRequired()
                        .HasColumnType("varchar(150)")
                        .HasMaxLength(150);

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("Lastname")
                        .IsRequired()
                        .HasColumnType("varchar(150)")
                        .HasMaxLength(150);

                    b.Property<DateTime>("ModifiedAt");

                    b.Property<int>("ModifiedBy");

                    b.Property<DateTime>("RegisteredDate");

                    b.Property<string>("Telephone")
                        .IsRequired()
                        .HasColumnType("varchar(150)")
                        .HasMaxLength(150);

                    b.HasKey("Id");

                    b.ToTable("Customer","Customer");
                });

            modelBuilder.Entity("BeautyCenter.Data.Entities.Identity.Function", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime");

                    b.Property<int>("CreatedBy");

                    b.Property<string>("Description")
                        .HasColumnType("varchar(150)")
                        .HasMaxLength(250);

                    b.Property<byte>("FunctionStatus");

                    b.Property<bool>("IsDeleted");

                    b.Property<DateTime>("ModifiedAt");

                    b.Property<int>("ModifiedBy");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(150)")
                        .HasMaxLength(150);

                    b.Property<string>("UniqueName")
                        .IsRequired()
                        .HasColumnType("varchar(150)")
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.ToTable("Function","Identity");
                });

            modelBuilder.Entity("BeautyCenter.Data.Entities.Identity.ResetPassword", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime");

                    b.Property<int>("CreatedBy");

                    b.Property<DateTime>("ExpireDate");

                    b.Property<bool>("IsDeleted");

                    b.Property<DateTime>("ModifiedAt");

                    b.Property<int>("ModifiedBy");

                    b.Property<string>("UniqueId");

                    b.Property<DateTime?>("UsedDate");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("ResetPassword","Identity");
                });

            modelBuilder.Entity("BeautyCenter.Data.Entities.Identity.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime");

                    b.Property<int>("CreatedBy");

                    b.Property<string>("Description")
                        .HasColumnType("varchar(150)")
                        .HasMaxLength(250);

                    b.Property<bool>("IsDeleted");

                    b.Property<DateTime>("ModifiedAt");

                    b.Property<int>("ModifiedBy");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(150)")
                        .HasMaxLength(150);

                    b.Property<byte>("RoleStatus");

                    b.Property<string>("UniqueName")
                        .IsRequired()
                        .HasColumnType("varchar(150)")
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.ToTable("Role","Identity");
                });

            modelBuilder.Entity("BeautyCenter.Data.Entities.Identity.RoleFunction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime");

                    b.Property<int>("CreatedBy");

                    b.Property<int>("FunctionId");

                    b.Property<bool>("IsDeleted");

                    b.Property<DateTime>("ModifiedAt");

                    b.Property<int>("ModifiedBy");

                    b.Property<byte>("RoleFunctionStatus");

                    b.Property<int>("RoleId");

                    b.HasKey("Id");

                    b.HasIndex("FunctionId");

                    b.HasIndex("RoleId");

                    b.ToTable("RoleFunction","Identity");
                });

            modelBuilder.Entity("BeautyCenter.Data.Entities.Identity.TwoFactorAuth", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime");

                    b.Property<int>("CreatedBy");

                    b.Property<DateTime>("ExpireDate");

                    b.Property<bool>("IsDeleted");

                    b.Property<DateTime>("ModifiedAt");

                    b.Property<int>("ModifiedBy");

                    b.Property<byte>("TwoFactorType");

                    b.Property<string>("UniqueId");

                    b.Property<DateTime?>("UsedDate");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("TwoFactorAuth","Identity");
                });

            modelBuilder.Entity("BeautyCenter.Data.Entities.Identity.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime");

                    b.Property<int>("CreatedBy");

                    b.Property<string>("Email")
                        .HasMaxLength(50);

                    b.Property<bool>("IsDeleted");

                    b.Property<DateTime>("ModifiedAt");

                    b.Property<int>("ModifiedBy");

                    b.Property<string>("Password")
                        .HasMaxLength(1000);

                    b.Property<byte>("PasswordHashAlgorithm");

                    b.Property<string>("PasswordSalt")
                        .HasMaxLength(1000);

                    b.Property<Guid>("UniqueId");

                    b.Property<byte>("UserStatus");

                    b.Property<byte>("UserType");

                    b.HasKey("Id");

                    b.ToTable("User","Identity");
                });

            modelBuilder.Entity("BeautyCenter.Data.Entities.Identity.UserRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime");

                    b.Property<int>("CreatedBy");

                    b.Property<bool>("IsDeleted");

                    b.Property<DateTime>("ModifiedAt");

                    b.Property<int>("ModifiedBy");

                    b.Property<int>("RoleId");

                    b.Property<int>("UserId");

                    b.Property<byte>("UserRoleStatus");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.HasIndex("UserId");

                    b.ToTable("UserRole","Identity");
                });

            modelBuilder.Entity("BeautyCenter.Data.Entities.Identity.UserSession", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedAt");

                    b.Property<int>("CreatedBy");

                    b.Property<bool>("IsDeleted");

                    b.Property<DateTime>("ModifiedAt");

                    b.Property<int>("ModifiedBy");

                    b.Property<int>("RoleId");

                    b.Property<int>("UserId");

                    b.Property<byte>("UserRoleStatus");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.HasIndex("UserId");

                    b.ToTable("UserSession");
                });

            modelBuilder.Entity("BeautyCenter.Data.Entities.Installments.Installment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime");

                    b.Property<int>("CreatedBy");

                    b.Property<int?>("CustomerId");

                    b.Property<DateTime>("InstallmentDate")
                        .HasColumnType("datetime");

                    b.Property<bool>("IsDeleted");

                    b.Property<bool>("IsPaid");

                    b.Property<DateTime>("ModifiedAt");

                    b.Property<int>("ModifiedBy");

                    b.Property<decimal>("TotalAmount")
                        .HasConversion(new ValueConverter<decimal, decimal>(v => default(decimal), v => default(decimal), new ConverterMappingHints(precision: 38, scale: 17)))
                        .HasColumnType("decimal");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.ToTable("Installment","Installement");
                });

            modelBuilder.Entity("BeautyCenter.Data.Entities.Installments.InstallmentDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Amount")
                        .HasConversion(new ValueConverter<decimal, decimal>(v => default(decimal), v => default(decimal), new ConverterMappingHints(precision: 38, scale: 17)))
                        .HasColumnType("decimal");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime");

                    b.Property<int>("CreatedBy");

                    b.Property<DateTime>("InstallmentDate")
                        .HasColumnType("datetime");

                    b.Property<int?>("InstallmentId");

                    b.Property<bool>("IsDeleted");

                    b.Property<DateTime>("ModifiedAt");

                    b.Property<int>("ModifiedBy");

                    b.Property<int>("PaymentState")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("InstallmentId");

                    b.ToTable("InstallmentDetail","Installement");
                });

            modelBuilder.Entity("BeautyCenter.Data.Entities.Operations.Operation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("Amount")
                        .HasColumnType("float");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime");

                    b.Property<int>("CreatedBy");

                    b.Property<int?>("CustomerId");

                    b.Property<DateTime>("Datetime")
                        .HasColumnType("datetime");

                    b.Property<string>("Department")
                        .IsRequired()
                        .HasColumnType("varchar(150)");

                    b.Property<bool>("IsDeleted");

                    b.Property<bool>("IsPaid")
                        .HasColumnType("bit");

                    b.Property<DateTime>("ModifiedAt");

                    b.Property<int>("ModifiedBy");

                    b.Property<int>("PaymentType");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.ToTable("Operation","Operation");
                });

            modelBuilder.Entity("BeautyCenter.Data.Entities.Operations.OperationDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Area")
                        .IsRequired()
                        .HasColumnType("varchar(150)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime");

                    b.Property<int>("CreatedBy");

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("datetime");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("varchar(150)");

                    b.Property<bool>("IsDeleted");

                    b.Property<DateTime>("ModifiedAt");

                    b.Property<int>("ModifiedBy");

                    b.Property<int?>("OperationId");

                    b.Property<int>("SeanceType");

                    b.Property<double>("ShotDose")
                        .HasColumnType("float");

                    b.Property<int>("ShotNumber")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("OperationId");

                    b.ToTable("OperationDetail","Operation");
                });

            modelBuilder.Entity("BeautyCenter.Data.Entities.Payments.Payment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime");

                    b.Property<int>("CreatedBy");

                    b.Property<int>("CustomerId");

                    b.Property<bool>("IsDeleted");

                    b.Property<DateTime>("ModifiedAt");

                    b.Property<int>("ModifiedBy");

                    b.Property<decimal>("PaymentAmount")
                        .HasConversion(new ValueConverter<decimal, decimal>(v => default(decimal), v => default(decimal), new ConverterMappingHints(precision: 38, scale: 17)))
                        .HasColumnType("decimal");

                    b.Property<DateTime>("PaymentDate")
                        .HasColumnType("datetime");

                    b.Property<int>("PaymentType");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.ToTable("Payment","Payment");
                });

            modelBuilder.Entity("BeautyCenter.Data.Entities.ProductsAndServices.Service", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal")
                        .HasMaxLength(150);

                    b.Property<string>("ColorClass")
                        .IsRequired()
                        .HasColumnType("varchar(150)")
                        .HasMaxLength(150);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime");

                    b.Property<int>("CreatedBy");

                    b.Property<int>("Duration")
                        .HasColumnType("int")
                        .HasMaxLength(150);

                    b.Property<bool>("IsDeleted");

                    b.Property<DateTime>("ModifiedAt");

                    b.Property<int>("ModifiedBy");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(150)")
                        .HasMaxLength(150);

                    b.HasKey("Id");

                    b.ToTable("Service","Service");
                });

            modelBuilder.Entity("BeautyCenter.Data.Entities.Appointments.Appointment", b =>
                {
                    b.HasOne("BeautyCenter.Data.Entities.Customers.Customer", "Customer")
                        .WithMany("Appointments")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("BeautyCenter.Data.Entities.ProductsAndServices.Service", "Service")
                        .WithMany()
                        .HasForeignKey("ServiceId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("BeautyCenter.Data.Entities.Identity.ResetPassword", b =>
                {
                    b.HasOne("BeautyCenter.Data.Entities.Identity.User", "User")
                        .WithMany("ResetPasswords")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("BeautyCenter.Data.Entities.Identity.RoleFunction", b =>
                {
                    b.HasOne("BeautyCenter.Data.Entities.Identity.Function", "Function")
                        .WithMany("RoleFunctions")
                        .HasForeignKey("FunctionId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("BeautyCenter.Data.Entities.Identity.Role", "Role")
                        .WithMany("RoleFunctions")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("BeautyCenter.Data.Entities.Identity.TwoFactorAuth", b =>
                {
                    b.HasOne("BeautyCenter.Data.Entities.Identity.User", "User")
                        .WithMany("TwoFactorAuths")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("BeautyCenter.Data.Entities.Identity.UserRole", b =>
                {
                    b.HasOne("BeautyCenter.Data.Entities.Identity.Role", "Role")
                        .WithMany("UserRoles")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("BeautyCenter.Data.Entities.Identity.User", "User")
                        .WithMany("UserRoles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("BeautyCenter.Data.Entities.Identity.UserSession", b =>
                {
                    b.HasOne("BeautyCenter.Data.Entities.Identity.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("BeautyCenter.Data.Entities.Identity.User", "User")
                        .WithMany("UserSessions")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("BeautyCenter.Data.Entities.Installments.Installment", b =>
                {
                    b.HasOne("BeautyCenter.Data.Entities.Customers.Customer")
                        .WithMany("Installments")
                        .HasForeignKey("CustomerId");
                });

            modelBuilder.Entity("BeautyCenter.Data.Entities.Installments.InstallmentDetail", b =>
                {
                    b.HasOne("BeautyCenter.Data.Entities.Installments.Installment", "Installment")
                        .WithMany("InstallmentDetails")
                        .HasForeignKey("InstallmentId");
                });

            modelBuilder.Entity("BeautyCenter.Data.Entities.Operations.Operation", b =>
                {
                    b.HasOne("BeautyCenter.Data.Entities.Customers.Customer")
                        .WithMany("Operations")
                        .HasForeignKey("CustomerId");
                });

            modelBuilder.Entity("BeautyCenter.Data.Entities.Operations.OperationDetail", b =>
                {
                    b.HasOne("BeautyCenter.Data.Entities.Operations.Operation", "Operation")
                        .WithMany("OperationDetails")
                        .HasForeignKey("OperationId");
                });

            modelBuilder.Entity("BeautyCenter.Data.Entities.Payments.Payment", b =>
                {
                    b.HasOne("BeautyCenter.Data.Entities.Customers.Customer", "Customer")
                        .WithMany("Payments")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
