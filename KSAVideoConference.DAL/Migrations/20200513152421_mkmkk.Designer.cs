﻿// <auto-generated />
using System;
using KSAVideoConference.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace KSAVideoConference.DAL.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20200513152421_mkmkk")]
    partial class mkmkk
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("KSAVideoConference.Entity.AppModel.AppStaticMessage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Key")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("LastModifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("AppStaticMessage");
                });

            modelBuilder.Entity("KSAVideoConference.Entity.AppModel.AppStaticMessageLang", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Fk_Language")
                        .HasColumnType("int");

                    b.Property<int>("Fk_Source")
                        .HasColumnType("int");

                    b.Property<DateTime>("LastModifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("Fk_Language");

                    b.HasIndex("Fk_Source");

                    b.ToTable("AppStaticMessageLang");
                });

            modelBuilder.Entity("KSAVideoConference.Entity.AppModel.AppStaticWord", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Key")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("LastModifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("AppStaticWord");
                });

            modelBuilder.Entity("KSAVideoConference.Entity.AppModel.AppStaticWordLang", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Fk_Language")
                        .HasColumnType("int");

                    b.Property<int>("Fk_Source")
                        .HasColumnType("int");

                    b.Property<DateTime>("LastModifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("Fk_Language");

                    b.HasIndex("Fk_Source");

                    b.ToTable("AppStaticWordLang");
                });

            modelBuilder.Entity("KSAVideoConference.Entity.AppModel.Attachment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AttachmentURL")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Fk_AttachmentType")
                        .HasColumnType("int");

                    b.Property<DateTime>("LastModifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("Fk_AttachmentType");

                    b.ToTable("Attachment");
                });

            modelBuilder.Entity("KSAVideoConference.Entity.AppModel.AttachmentType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("LastModifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("AttachmentType");
                });

            modelBuilder.Entity("KSAVideoConference.Entity.AppModel.Group", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Fk_Creator")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<DateTime>("LastModifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LogoURL")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MaxGroupCount")
                        .HasColumnType("int");

                    b.Property<int>("MaxStreamCount")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SessionId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("Fk_Creator");

                    b.ToTable("Group");
                });

            modelBuilder.Entity("KSAVideoConference.Entity.AppModel.GroupMember", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Fk_Group")
                        .HasColumnType("int");

                    b.Property<int>("Fk_MemberType")
                        .HasColumnType("int");

                    b.Property<int>("Fk_User")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<DateTime>("LastModifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("Fk_Group");

                    b.HasIndex("Fk_MemberType");

                    b.HasIndex("Fk_User");

                    b.ToTable("GroupMember");
                });

            modelBuilder.Entity("KSAVideoConference.Entity.AppModel.GroupMessage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Fk_Attachment")
                        .HasColumnType("int");

                    b.Property<int>("Fk_Group")
                        .HasColumnType("int");

                    b.Property<int>("Fk_User")
                        .HasColumnType("int");

                    b.Property<DateTime>("LastModifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("Fk_Attachment")
                        .IsUnique()
                        .HasFilter("[Fk_Attachment] IS NOT NULL");

                    b.HasIndex("Fk_Group");

                    b.HasIndex("Fk_User");

                    b.ToTable("GroupMessage");
                });

            modelBuilder.Entity("KSAVideoConference.Entity.AppModel.MemberType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("LastModifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("MemberType");
                });

            modelBuilder.Entity("KSAVideoConference.Entity.AppModel.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AppVersion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DeviceModel")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DeviceVersion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Fk_Language")
                        .HasColumnType("int");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageURL")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<DateTime>("LastModifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NotificationToken")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("Token")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("Fk_Language");

                    b.ToTable("User");
                });

            modelBuilder.Entity("KSAVideoConference.Entity.AppModel.UserContact", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Fk_Contact")
                        .HasColumnType("int");

                    b.Property<int>("Fk_User")
                        .HasColumnType("int");

                    b.Property<DateTime>("LastModifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("Fk_Contact");

                    b.HasIndex("Fk_User");

                    b.ToTable("UserContact");
                });

            modelBuilder.Entity("KSAVideoConference.Entity.AuthModel.AccessLevel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("LastModifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("AccessLevel");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedAt = new DateTime(2020, 5, 13, 17, 24, 20, 689, DateTimeKind.Unspecified).AddTicks(4571),
                            CreatedBy = "seed@app.com",
                            LastModifiedAt = new DateTime(2020, 5, 13, 17, 24, 20, 689, DateTimeKind.Unspecified).AddTicks(4707),
                            Name = "FullAccess"
                        },
                        new
                        {
                            Id = 2,
                            CreatedAt = new DateTime(2020, 5, 13, 17, 24, 20, 689, DateTimeKind.Unspecified).AddTicks(5890),
                            CreatedBy = "seed@app.com",
                            LastModifiedAt = new DateTime(2020, 5, 13, 17, 24, 20, 689, DateTimeKind.Unspecified).AddTicks(5957),
                            Name = "ControlAccess"
                        },
                        new
                        {
                            Id = 3,
                            CreatedAt = new DateTime(2020, 5, 13, 17, 24, 20, 689, DateTimeKind.Unspecified).AddTicks(5983),
                            CreatedBy = "seed@app.com",
                            LastModifiedAt = new DateTime(2020, 5, 13, 17, 24, 20, 689, DateTimeKind.Unspecified).AddTicks(5991),
                            Name = "ViewAccess"
                        });
                });

            modelBuilder.Entity("KSAVideoConference.Entity.AuthModel.ControlLevel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("LastModifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ControlLevel");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedAt = new DateTime(2020, 5, 13, 17, 24, 20, 689, DateTimeKind.Unspecified).AddTicks(7164),
                            CreatedBy = "seed@app.com",
                            LastModifiedAt = new DateTime(2020, 5, 13, 17, 24, 20, 689, DateTimeKind.Unspecified).AddTicks(7200),
                            Name = "All"
                        },
                        new
                        {
                            Id = 2,
                            CreatedAt = new DateTime(2020, 5, 13, 17, 24, 20, 689, DateTimeKind.Unspecified).AddTicks(7851),
                            CreatedBy = "seed@app.com",
                            LastModifiedAt = new DateTime(2020, 5, 13, 17, 24, 20, 689, DateTimeKind.Unspecified).AddTicks(7877),
                            Name = "Owner"
                        });
                });

            modelBuilder.Entity("KSAVideoConference.Entity.AuthModel.SystemUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("JopTitle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("LastModifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("SystemUser");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedAt = new DateTime(2020, 5, 13, 17, 24, 20, 690, DateTimeKind.Unspecified).AddTicks(705),
                            CreatedBy = "seed@app.com",
                            Email = "seed@app.com",
                            FullName = "Admin",
                            IsActive = true,
                            JopTitle = "Admin",
                            LastModifiedAt = new DateTime(2020, 5, 13, 17, 24, 20, 690, DateTimeKind.Unspecified).AddTicks(740),
                            Password = "qtkg4885qs"
                        });
                });

            modelBuilder.Entity("KSAVideoConference.Entity.AuthModel.SystemUserPermission", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Fk_AccessLevel")
                        .HasColumnType("int");

                    b.Property<int>("Fk_ControlLevel")
                        .HasColumnType("int");

                    b.Property<int>("Fk_SystemUser")
                        .HasColumnType("int");

                    b.Property<int>("Fk_SystemView")
                        .HasColumnType("int");

                    b.Property<DateTime>("LastModifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("Fk_AccessLevel");

                    b.HasIndex("Fk_ControlLevel");

                    b.HasIndex("Fk_SystemUser");

                    b.HasIndex("Fk_SystemView");

                    b.ToTable("SystemUserPermission");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedAt = new DateTime(2020, 5, 13, 17, 24, 20, 691, DateTimeKind.Unspecified).AddTicks(960),
                            CreatedBy = "seed@app.com",
                            Fk_AccessLevel = 1,
                            Fk_ControlLevel = 1,
                            Fk_SystemUser = 1,
                            Fk_SystemView = 1,
                            LastModifiedAt = new DateTime(2020, 5, 13, 17, 24, 20, 691, DateTimeKind.Unspecified).AddTicks(1013)
                        },
                        new
                        {
                            Id = 2,
                            CreatedAt = new DateTime(2020, 5, 13, 17, 24, 20, 691, DateTimeKind.Unspecified).AddTicks(3099),
                            CreatedBy = "seed@app.com",
                            Fk_AccessLevel = 1,
                            Fk_ControlLevel = 1,
                            Fk_SystemUser = 1,
                            Fk_SystemView = 2,
                            LastModifiedAt = new DateTime(2020, 5, 13, 17, 24, 20, 691, DateTimeKind.Unspecified).AddTicks(3130)
                        },
                        new
                        {
                            Id = 3,
                            CreatedAt = new DateTime(2020, 5, 13, 17, 24, 20, 691, DateTimeKind.Unspecified).AddTicks(3182),
                            CreatedBy = "seed@app.com",
                            Fk_AccessLevel = 1,
                            Fk_ControlLevel = 1,
                            Fk_SystemUser = 1,
                            Fk_SystemView = 3,
                            LastModifiedAt = new DateTime(2020, 5, 13, 17, 24, 20, 691, DateTimeKind.Unspecified).AddTicks(3189)
                        });
                });

            modelBuilder.Entity("KSAVideoConference.Entity.AuthModel.SystemView", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("LastModifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("SystemView");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedAt = new DateTime(2020, 5, 13, 17, 24, 20, 689, DateTimeKind.Unspecified).AddTicks(8750),
                            CreatedBy = "seed@app.com",
                            LastModifiedAt = new DateTime(2020, 5, 13, 17, 24, 20, 689, DateTimeKind.Unspecified).AddTicks(8778),
                            Name = "Home"
                        },
                        new
                        {
                            Id = 2,
                            CreatedAt = new DateTime(2020, 5, 13, 17, 24, 20, 689, DateTimeKind.Unspecified).AddTicks(9474),
                            CreatedBy = "seed@app.com",
                            LastModifiedAt = new DateTime(2020, 5, 13, 17, 24, 20, 689, DateTimeKind.Unspecified).AddTicks(9507),
                            Name = "SystemView"
                        },
                        new
                        {
                            Id = 3,
                            CreatedAt = new DateTime(2020, 5, 13, 17, 24, 20, 689, DateTimeKind.Unspecified).AddTicks(9539),
                            CreatedBy = "seed@app.com",
                            LastModifiedAt = new DateTime(2020, 5, 13, 17, 24, 20, 689, DateTimeKind.Unspecified).AddTicks(9552),
                            Name = "SystemUser"
                        });
                });

            modelBuilder.Entity("KSAVideoConference.Entity.Language", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("LastModifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Language");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedAt = new DateTime(2020, 5, 13, 17, 24, 20, 680, DateTimeKind.Unspecified).AddTicks(2963),
                            CreatedBy = "seed@app.com",
                            LastModifiedAt = new DateTime(2020, 5, 13, 17, 24, 20, 687, DateTimeKind.Unspecified).AddTicks(2027),
                            Name = "English"
                        },
                        new
                        {
                            Id = 2,
                            CreatedAt = new DateTime(2020, 5, 13, 17, 24, 20, 687, DateTimeKind.Unspecified).AddTicks(5418),
                            CreatedBy = "seed@app.com",
                            LastModifiedAt = new DateTime(2020, 5, 13, 17, 24, 20, 687, DateTimeKind.Unspecified).AddTicks(5468),
                            Name = "Arabic"
                        });
                });

            modelBuilder.Entity("KSAVideoConference.Entity.AppModel.AppStaticMessageLang", b =>
                {
                    b.HasOne("KSAVideoConference.Entity.Language", "Language")
                        .WithMany("AppStaticMessageLangs")
                        .HasForeignKey("Fk_Language")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("KSAVideoConference.Entity.AppModel.AppStaticMessage", "Source")
                        .WithMany("AppStaticWordLangs")
                        .HasForeignKey("Fk_Source")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("KSAVideoConference.Entity.AppModel.AppStaticWordLang", b =>
                {
                    b.HasOne("KSAVideoConference.Entity.Language", "Language")
                        .WithMany("AppStaticWordLangs")
                        .HasForeignKey("Fk_Language")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("KSAVideoConference.Entity.AppModel.AppStaticWord", "Source")
                        .WithMany("AppStaticWordLangs")
                        .HasForeignKey("Fk_Source")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("KSAVideoConference.Entity.AppModel.Attachment", b =>
                {
                    b.HasOne("KSAVideoConference.Entity.AppModel.AttachmentType", "AttachmentType")
                        .WithMany("Attachments")
                        .HasForeignKey("Fk_AttachmentType")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("KSAVideoConference.Entity.AppModel.Group", b =>
                {
                    b.HasOne("KSAVideoConference.Entity.AppModel.User", "Creator")
                        .WithMany("Groups")
                        .HasForeignKey("Fk_Creator")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("KSAVideoConference.Entity.AppModel.GroupMember", b =>
                {
                    b.HasOne("KSAVideoConference.Entity.AppModel.Group", "Group")
                        .WithMany("GroupMembers")
                        .HasForeignKey("Fk_Group")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("KSAVideoConference.Entity.AppModel.MemberType", "MemberType")
                        .WithMany("GroupMembers")
                        .HasForeignKey("Fk_MemberType")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("KSAVideoConference.Entity.AppModel.User", "User")
                        .WithMany("GroupMembers")
                        .HasForeignKey("Fk_User")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("KSAVideoConference.Entity.AppModel.GroupMessage", b =>
                {
                    b.HasOne("KSAVideoConference.Entity.AppModel.Attachment", "Attachment")
                        .WithOne("GroupMessage")
                        .HasForeignKey("KSAVideoConference.Entity.AppModel.GroupMessage", "Fk_Attachment");

                    b.HasOne("KSAVideoConference.Entity.AppModel.Group", "Group")
                        .WithMany("GroupMessages")
                        .HasForeignKey("Fk_Group")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("KSAVideoConference.Entity.AppModel.User", "User")
                        .WithMany("GroupMessages")
                        .HasForeignKey("Fk_User")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("KSAVideoConference.Entity.AppModel.User", b =>
                {
                    b.HasOne("KSAVideoConference.Entity.Language", "Language")
                        .WithMany("Users")
                        .HasForeignKey("Fk_Language")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("KSAVideoConference.Entity.AppModel.UserContact", b =>
                {
                    b.HasOne("KSAVideoConference.Entity.AppModel.User", "Contact")
                        .WithMany("MeInUserContacts")
                        .HasForeignKey("Fk_Contact")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("KSAVideoConference.Entity.AppModel.User", "User")
                        .WithMany("MyUserContacts")
                        .HasForeignKey("Fk_User")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("KSAVideoConference.Entity.AuthModel.SystemUserPermission", b =>
                {
                    b.HasOne("KSAVideoConference.Entity.AuthModel.AccessLevel", "AccessLevel")
                        .WithMany("SystemUserPermissions")
                        .HasForeignKey("Fk_AccessLevel")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("KSAVideoConference.Entity.AuthModel.ControlLevel", "ControlLevel")
                        .WithMany("SystemUserPermissions")
                        .HasForeignKey("Fk_ControlLevel")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("KSAVideoConference.Entity.AuthModel.SystemUser", "SystemUser")
                        .WithMany("SystemUserPermissions")
                        .HasForeignKey("Fk_SystemUser")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("KSAVideoConference.Entity.AuthModel.SystemView", "SystemView")
                        .WithMany("SystemUserPermissions")
                        .HasForeignKey("Fk_SystemView")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
