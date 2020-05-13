using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace KSAVideoConference.DAL.Migrations
{
    public partial class mm : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AccessLevel",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: false),
                    LastModifiedAt = table.Column<DateTime>(nullable: false),
                    LastModifiedBy = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccessLevel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppStaticMessage",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: false),
                    LastModifiedAt = table.Column<DateTime>(nullable: false),
                    LastModifiedBy = table.Column<string>(nullable: true),
                    Key = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppStaticMessage", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppStaticWord",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: false),
                    LastModifiedAt = table.Column<DateTime>(nullable: false),
                    LastModifiedBy = table.Column<string>(nullable: true),
                    Key = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppStaticWord", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AttachmentType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: false),
                    LastModifiedAt = table.Column<DateTime>(nullable: false),
                    LastModifiedBy = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttachmentType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ControlLevel",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: false),
                    LastModifiedAt = table.Column<DateTime>(nullable: false),
                    LastModifiedBy = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ControlLevel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Language",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: false),
                    LastModifiedAt = table.Column<DateTime>(nullable: false),
                    LastModifiedBy = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Language", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MemberType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: false),
                    LastModifiedAt = table.Column<DateTime>(nullable: false),
                    LastModifiedBy = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MemberType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SystemUser",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: false),
                    LastModifiedAt = table.Column<DateTime>(nullable: false),
                    LastModifiedBy = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: false),
                    Password = table.Column<string>(nullable: false),
                    FullName = table.Column<string>(nullable: false),
                    JopTitle = table.Column<string>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SystemUser", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SystemView",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: false),
                    LastModifiedAt = table.Column<DateTime>(nullable: false),
                    LastModifiedBy = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SystemView", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: false),
                    LastModifiedAt = table.Column<DateTime>(nullable: false),
                    LastModifiedBy = table.Column<string>(nullable: true),
                    FullName = table.Column<string>(nullable: false),
                    Phone = table.Column<string>(nullable: false),
                    ImageURL = table.Column<string>(nullable: true),
                    Token = table.Column<Guid>(nullable: false),
                    AppVersion = table.Column<string>(nullable: false),
                    DeviceVersion = table.Column<string>(nullable: false),
                    DeviceModel = table.Column<string>(nullable: false),
                    NotificationToken = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Attachment",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: false),
                    LastModifiedAt = table.Column<DateTime>(nullable: false),
                    LastModifiedBy = table.Column<string>(nullable: true),
                    AttachmentURL = table.Column<string>(nullable: false),
                    Fk_AttachmentType = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attachment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Attachment_AttachmentType_Fk_AttachmentType",
                        column: x => x.Fk_AttachmentType,
                        principalTable: "AttachmentType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AppStaticMessageLang",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: false),
                    LastModifiedAt = table.Column<DateTime>(nullable: false),
                    LastModifiedBy = table.Column<string>(nullable: true),
                    Fk_Source = table.Column<int>(nullable: false),
                    Fk_Language = table.Column<int>(nullable: false),
                    Value = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppStaticMessageLang", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppStaticMessageLang_Language_Fk_Language",
                        column: x => x.Fk_Language,
                        principalTable: "Language",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AppStaticMessageLang_AppStaticMessage_Fk_Source",
                        column: x => x.Fk_Source,
                        principalTable: "AppStaticMessage",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AppStaticWordLang",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: false),
                    LastModifiedAt = table.Column<DateTime>(nullable: false),
                    LastModifiedBy = table.Column<string>(nullable: true),
                    Fk_Source = table.Column<int>(nullable: false),
                    Fk_Language = table.Column<int>(nullable: false),
                    Value = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppStaticWordLang", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppStaticWordLang_Language_Fk_Language",
                        column: x => x.Fk_Language,
                        principalTable: "Language",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AppStaticWordLang_AppStaticWord_Fk_Source",
                        column: x => x.Fk_Source,
                        principalTable: "AppStaticWord",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SystemUserPermission",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: false),
                    LastModifiedAt = table.Column<DateTime>(nullable: false),
                    LastModifiedBy = table.Column<string>(nullable: true),
                    Fk_SystemView = table.Column<int>(nullable: false),
                    Fk_SystemUser = table.Column<int>(nullable: false),
                    Fk_AccessLevel = table.Column<int>(nullable: false),
                    Fk_ControlLevel = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SystemUserPermission", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SystemUserPermission_AccessLevel_Fk_AccessLevel",
                        column: x => x.Fk_AccessLevel,
                        principalTable: "AccessLevel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SystemUserPermission_ControlLevel_Fk_ControlLevel",
                        column: x => x.Fk_ControlLevel,
                        principalTable: "ControlLevel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SystemUserPermission_SystemUser_Fk_SystemUser",
                        column: x => x.Fk_SystemUser,
                        principalTable: "SystemUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SystemUserPermission_SystemView_Fk_SystemView",
                        column: x => x.Fk_SystemView,
                        principalTable: "SystemView",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Group",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: false),
                    LastModifiedAt = table.Column<DateTime>(nullable: false),
                    LastModifiedBy = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: false),
                    LogoURL = table.Column<string>(nullable: true),
                    MaxGroupCount = table.Column<int>(nullable: false),
                    MaxStreamCount = table.Column<int>(nullable: false),
                    SessionId = table.Column<string>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    Fk_Creator = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Group", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Group_User_Fk_Creator",
                        column: x => x.Fk_Creator,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserContact",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: false),
                    LastModifiedAt = table.Column<DateTime>(nullable: false),
                    LastModifiedBy = table.Column<string>(nullable: true),
                    Fk_User = table.Column<int>(nullable: false),
                    Fk_Contact = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserContact", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserContact_User_Fk_Contact",
                        column: x => x.Fk_Contact,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserContact_User_Fk_User",
                        column: x => x.Fk_User,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GroupMember",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: false),
                    LastModifiedAt = table.Column<DateTime>(nullable: false),
                    LastModifiedBy = table.Column<string>(nullable: true),
                    Fk_User = table.Column<int>(nullable: false),
                    Fk_Group = table.Column<int>(nullable: false),
                    Fk_MemberType = table.Column<int>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupMember", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GroupMember_Group_Fk_Group",
                        column: x => x.Fk_Group,
                        principalTable: "Group",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GroupMember_MemberType_Fk_MemberType",
                        column: x => x.Fk_MemberType,
                        principalTable: "MemberType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GroupMember_User_Fk_User",
                        column: x => x.Fk_User,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GroupMessage",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: false),
                    LastModifiedAt = table.Column<DateTime>(nullable: false),
                    LastModifiedBy = table.Column<string>(nullable: true),
                    Fk_User = table.Column<int>(nullable: false),
                    Fk_Group = table.Column<int>(nullable: false),
                    Message = table.Column<string>(nullable: false),
                    Fk_Attachment = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupMessage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GroupMessage_Attachment_Fk_Attachment",
                        column: x => x.Fk_Attachment,
                        principalTable: "Attachment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GroupMessage_Group_Fk_Group",
                        column: x => x.Fk_Group,
                        principalTable: "Group",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GroupMessage_User_Fk_User",
                        column: x => x.Fk_User,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "AccessLevel",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "LastModifiedAt", "LastModifiedBy", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2020, 5, 12, 21, 30, 29, 83, DateTimeKind.Unspecified).AddTicks(4522), "seed@app.com", new DateTime(2020, 5, 12, 21, 30, 29, 83, DateTimeKind.Unspecified).AddTicks(4559), null, "FullAccess" },
                    { 2, new DateTime(2020, 5, 12, 21, 30, 29, 83, DateTimeKind.Unspecified).AddTicks(5115), "seed@app.com", new DateTime(2020, 5, 12, 21, 30, 29, 83, DateTimeKind.Unspecified).AddTicks(5137), null, "ControlAccess" },
                    { 3, new DateTime(2020, 5, 12, 21, 30, 29, 83, DateTimeKind.Unspecified).AddTicks(5153), "seed@app.com", new DateTime(2020, 5, 12, 21, 30, 29, 83, DateTimeKind.Unspecified).AddTicks(5159), null, "ViewAccess" }
                });

            migrationBuilder.InsertData(
                table: "ControlLevel",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "LastModifiedAt", "LastModifiedBy", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2020, 5, 12, 21, 30, 29, 83, DateTimeKind.Unspecified).AddTicks(5891), "seed@app.com", new DateTime(2020, 5, 12, 21, 30, 29, 83, DateTimeKind.Unspecified).AddTicks(5915), null, "All" },
                    { 2, new DateTime(2020, 5, 12, 21, 30, 29, 83, DateTimeKind.Unspecified).AddTicks(6399), "seed@app.com", new DateTime(2020, 5, 12, 21, 30, 29, 83, DateTimeKind.Unspecified).AddTicks(6420), null, "Owner" }
                });

            migrationBuilder.InsertData(
                table: "Language",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "LastModifiedAt", "LastModifiedBy", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2020, 5, 12, 21, 30, 29, 77, DateTimeKind.Unspecified).AddTicks(6887), "seed@app.com", new DateTime(2020, 5, 12, 21, 30, 29, 81, DateTimeKind.Unspecified).AddTicks(9156), null, "English" },
                    { 2, new DateTime(2020, 5, 12, 21, 30, 29, 82, DateTimeKind.Unspecified).AddTicks(1142), "seed@app.com", new DateTime(2020, 5, 12, 21, 30, 29, 82, DateTimeKind.Unspecified).AddTicks(1172), null, "Arabic" }
                });

            migrationBuilder.InsertData(
                table: "SystemUser",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "Email", "FullName", "IsActive", "JopTitle", "LastModifiedAt", "LastModifiedBy", "Password" },
                values: new object[] { 1, new DateTime(2020, 5, 12, 21, 30, 29, 83, DateTimeKind.Unspecified).AddTicks(8361), "seed@app.com", "seed@app.com", "Admin", true, "Admin", new DateTime(2020, 5, 12, 21, 30, 29, 83, DateTimeKind.Unspecified).AddTicks(8384), null, "zmwr1651uu" });

            migrationBuilder.InsertData(
                table: "SystemView",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "LastModifiedAt", "LastModifiedBy", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2020, 5, 12, 21, 30, 29, 83, DateTimeKind.Unspecified).AddTicks(7105), "seed@app.com", new DateTime(2020, 5, 12, 21, 30, 29, 83, DateTimeKind.Unspecified).AddTicks(7128), null, "Home" },
                    { 2, new DateTime(2020, 5, 12, 21, 30, 29, 83, DateTimeKind.Unspecified).AddTicks(7605), "seed@app.com", new DateTime(2020, 5, 12, 21, 30, 29, 83, DateTimeKind.Unspecified).AddTicks(7626), null, "SystemView" },
                    { 3, new DateTime(2020, 5, 12, 21, 30, 29, 83, DateTimeKind.Unspecified).AddTicks(7642), "seed@app.com", new DateTime(2020, 5, 12, 21, 30, 29, 83, DateTimeKind.Unspecified).AddTicks(7648), null, "SystemUser" }
                });

            migrationBuilder.InsertData(
                table: "SystemUserPermission",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "Fk_AccessLevel", "Fk_ControlLevel", "Fk_SystemUser", "Fk_SystemView", "LastModifiedAt", "LastModifiedBy" },
                values: new object[] { 1, new DateTime(2020, 5, 12, 21, 30, 29, 84, DateTimeKind.Unspecified).AddTicks(7751), "seed@app.com", 1, 1, 1, 1, new DateTime(2020, 5, 12, 21, 30, 29, 84, DateTimeKind.Unspecified).AddTicks(7811), null });

            migrationBuilder.InsertData(
                table: "SystemUserPermission",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "Fk_AccessLevel", "Fk_ControlLevel", "Fk_SystemUser", "Fk_SystemView", "LastModifiedAt", "LastModifiedBy" },
                values: new object[] { 2, new DateTime(2020, 5, 12, 21, 30, 29, 84, DateTimeKind.Unspecified).AddTicks(9456), "seed@app.com", 1, 1, 1, 2, new DateTime(2020, 5, 12, 21, 30, 29, 84, DateTimeKind.Unspecified).AddTicks(9479), null });

            migrationBuilder.InsertData(
                table: "SystemUserPermission",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "Fk_AccessLevel", "Fk_ControlLevel", "Fk_SystemUser", "Fk_SystemView", "LastModifiedAt", "LastModifiedBy" },
                values: new object[] { 3, new DateTime(2020, 5, 12, 21, 30, 29, 84, DateTimeKind.Unspecified).AddTicks(9522), "seed@app.com", 1, 1, 1, 3, new DateTime(2020, 5, 12, 21, 30, 29, 84, DateTimeKind.Unspecified).AddTicks(9528), null });

            migrationBuilder.CreateIndex(
                name: "IX_AppStaticMessageLang_Fk_Language",
                table: "AppStaticMessageLang",
                column: "Fk_Language");

            migrationBuilder.CreateIndex(
                name: "IX_AppStaticMessageLang_Fk_Source",
                table: "AppStaticMessageLang",
                column: "Fk_Source");

            migrationBuilder.CreateIndex(
                name: "IX_AppStaticWordLang_Fk_Language",
                table: "AppStaticWordLang",
                column: "Fk_Language");

            migrationBuilder.CreateIndex(
                name: "IX_AppStaticWordLang_Fk_Source",
                table: "AppStaticWordLang",
                column: "Fk_Source");

            migrationBuilder.CreateIndex(
                name: "IX_Attachment_Fk_AttachmentType",
                table: "Attachment",
                column: "Fk_AttachmentType");

            migrationBuilder.CreateIndex(
                name: "IX_Group_Fk_Creator",
                table: "Group",
                column: "Fk_Creator");

            migrationBuilder.CreateIndex(
                name: "IX_GroupMember_Fk_Group",
                table: "GroupMember",
                column: "Fk_Group");

            migrationBuilder.CreateIndex(
                name: "IX_GroupMember_Fk_MemberType",
                table: "GroupMember",
                column: "Fk_MemberType");

            migrationBuilder.CreateIndex(
                name: "IX_GroupMember_Fk_User",
                table: "GroupMember",
                column: "Fk_User");

            migrationBuilder.CreateIndex(
                name: "IX_GroupMessage_Fk_Attachment",
                table: "GroupMessage",
                column: "Fk_Attachment",
                unique: true,
                filter: "[Fk_Attachment] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_GroupMessage_Fk_Group",
                table: "GroupMessage",
                column: "Fk_Group");

            migrationBuilder.CreateIndex(
                name: "IX_GroupMessage_Fk_User",
                table: "GroupMessage",
                column: "Fk_User");

            migrationBuilder.CreateIndex(
                name: "IX_SystemUserPermission_Fk_AccessLevel",
                table: "SystemUserPermission",
                column: "Fk_AccessLevel");

            migrationBuilder.CreateIndex(
                name: "IX_SystemUserPermission_Fk_ControlLevel",
                table: "SystemUserPermission",
                column: "Fk_ControlLevel");

            migrationBuilder.CreateIndex(
                name: "IX_SystemUserPermission_Fk_SystemUser",
                table: "SystemUserPermission",
                column: "Fk_SystemUser");

            migrationBuilder.CreateIndex(
                name: "IX_SystemUserPermission_Fk_SystemView",
                table: "SystemUserPermission",
                column: "Fk_SystemView");

            migrationBuilder.CreateIndex(
                name: "IX_UserContact_Fk_Contact",
                table: "UserContact",
                column: "Fk_Contact");

            migrationBuilder.CreateIndex(
                name: "IX_UserContact_Fk_User",
                table: "UserContact",
                column: "Fk_User");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppStaticMessageLang");

            migrationBuilder.DropTable(
                name: "AppStaticWordLang");

            migrationBuilder.DropTable(
                name: "GroupMember");

            migrationBuilder.DropTable(
                name: "GroupMessage");

            migrationBuilder.DropTable(
                name: "SystemUserPermission");

            migrationBuilder.DropTable(
                name: "UserContact");

            migrationBuilder.DropTable(
                name: "AppStaticMessage");

            migrationBuilder.DropTable(
                name: "Language");

            migrationBuilder.DropTable(
                name: "AppStaticWord");

            migrationBuilder.DropTable(
                name: "MemberType");

            migrationBuilder.DropTable(
                name: "Attachment");

            migrationBuilder.DropTable(
                name: "Group");

            migrationBuilder.DropTable(
                name: "AccessLevel");

            migrationBuilder.DropTable(
                name: "ControlLevel");

            migrationBuilder.DropTable(
                name: "SystemUser");

            migrationBuilder.DropTable(
                name: "SystemView");

            migrationBuilder.DropTable(
                name: "AttachmentType");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
