using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace KSAVideoConference.DAL.Migrations
{
    public partial class dkdms : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attachment_AttachmentType_Fk_AttachmentType",
                table: "Attachment");

            migrationBuilder.DropTable(
                name: "AttachmentType");

            migrationBuilder.DropIndex(
                name: "IX_Attachment_Fk_AttachmentType",
                table: "Attachment");

            migrationBuilder.DropColumn(
                name: "Fk_AttachmentType",
                table: "Attachment");

            migrationBuilder.AddColumn<long>(
                name: "Length",
                table: "Attachment",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Attachment",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "Attachment",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AccessLevel",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2020, 5, 15, 5, 45, 21, 512, DateTimeKind.Unspecified).AddTicks(4749), new DateTime(2020, 5, 15, 5, 45, 21, 512, DateTimeKind.Unspecified).AddTicks(4833) });

            migrationBuilder.UpdateData(
                table: "AccessLevel",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2020, 5, 15, 5, 45, 21, 512, DateTimeKind.Unspecified).AddTicks(5876), new DateTime(2020, 5, 15, 5, 45, 21, 512, DateTimeKind.Unspecified).AddTicks(5924) });

            migrationBuilder.UpdateData(
                table: "AccessLevel",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2020, 5, 15, 5, 45, 21, 512, DateTimeKind.Unspecified).AddTicks(5963), new DateTime(2020, 5, 15, 5, 45, 21, 512, DateTimeKind.Unspecified).AddTicks(5971) });

            migrationBuilder.InsertData(
                table: "AppStaticMessage",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "Key", "LastModifiedAt", "LastModifiedBy", "Value" },
                values: new object[,]
                {
                    { 2, new DateTime(2020, 5, 15, 5, 45, 21, 509, DateTimeKind.Unspecified).AddTicks(1919), "seed@app.com", "UnAuth", new DateTime(2020, 5, 15, 5, 45, 21, 509, DateTimeKind.Unspecified).AddTicks(1938), null, "لم يتم التعرف على حسابك!" },
                    { 3, new DateTime(2020, 5, 15, 5, 45, 21, 509, DateTimeKind.Unspecified).AddTicks(1888), "seed@app.com", "UnActive", new DateTime(2020, 5, 15, 5, 45, 21, 509, DateTimeKind.Unspecified).AddTicks(1905), null, "حسابك غير نشط!" },
                    { 8, new DateTime(2020, 5, 15, 5, 45, 21, 509, DateTimeKind.Unspecified).AddTicks(1843), "seed@app.com", "OwnerCantExit", new DateTime(2020, 5, 15, 5, 45, 21, 509, DateTimeKind.Unspecified).AddTicks(1854), null, "!لا يمكنك الخروج لأنك مدير المجموعه" },
                    { 1, new DateTime(2020, 5, 15, 5, 45, 21, 503, DateTimeKind.Unspecified).AddTicks(1984), "seed@app.com", "Common", new DateTime(2020, 5, 15, 5, 45, 21, 508, DateTimeKind.Unspecified).AddTicks(5677), null, "خطأ! الرجاء المحاوله مره اخري." },
                    { 6, new DateTime(2020, 5, 15, 5, 45, 21, 509, DateTimeKind.Unspecified).AddTicks(1785), "seed@app.com", "NotActiveGroup", new DateTime(2020, 5, 15, 5, 45, 21, 509, DateTimeKind.Unspecified).AddTicks(1805), null, "المجموعه غير نشطه!" },
                    { 7, new DateTime(2020, 5, 15, 5, 45, 21, 509, DateTimeKind.Unspecified).AddTicks(1732), "seed@app.com", "JoinGroup", new DateTime(2020, 5, 15, 5, 45, 21, 509, DateTimeKind.Unspecified).AddTicks(1748), null, "يرجي الانضمام الى المجموعه!" },
                    { 4, new DateTime(2020, 5, 15, 5, 45, 21, 509, DateTimeKind.Unspecified).AddTicks(1680), "seed@app.com", "InCompleteData", new DateTime(2020, 5, 15, 5, 45, 21, 509, DateTimeKind.Unspecified).AddTicks(1715), null, "يرجي التأكد من اتمام كل البيانات!" },
                    { 9, new DateTime(2020, 5, 15, 5, 45, 21, 509, DateTimeKind.Unspecified).AddTicks(1489), "seed@app.com", "DuplicateNumber", new DateTime(2020, 5, 15, 5, 45, 21, 509, DateTimeKind.Unspecified).AddTicks(1574), null, "رقم الجوال مسجل من قبل!" },
                    { 5, new DateTime(2020, 5, 15, 5, 45, 21, 509, DateTimeKind.Unspecified).AddTicks(1818), "seed@app.com", "NotOwner", new DateTime(2020, 5, 15, 5, 45, 21, 509, DateTimeKind.Unspecified).AddTicks(1830), null, "ليس لديك الصلاحيه على التعديل!" }
                });

            migrationBuilder.UpdateData(
                table: "ControlLevel",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2020, 5, 15, 5, 45, 21, 512, DateTimeKind.Unspecified).AddTicks(7269), new DateTime(2020, 5, 15, 5, 45, 21, 512, DateTimeKind.Unspecified).AddTicks(7323) });

            migrationBuilder.UpdateData(
                table: "ControlLevel",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2020, 5, 15, 5, 45, 21, 512, DateTimeKind.Unspecified).AddTicks(8548), new DateTime(2020, 5, 15, 5, 45, 21, 512, DateTimeKind.Unspecified).AddTicks(8598) });

            migrationBuilder.UpdateData(
                table: "Language",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2020, 5, 15, 5, 45, 21, 512, DateTimeKind.Unspecified).AddTicks(1421), new DateTime(2020, 5, 15, 5, 45, 21, 512, DateTimeKind.Unspecified).AddTicks(1554) });

            migrationBuilder.UpdateData(
                table: "Language",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2020, 5, 15, 5, 45, 21, 512, DateTimeKind.Unspecified).AddTicks(2854), new DateTime(2020, 5, 15, 5, 45, 21, 512, DateTimeKind.Unspecified).AddTicks(2916) });

            migrationBuilder.UpdateData(
                table: "SystemUser",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LastModifiedAt", "Password" },
                values: new object[] { new DateTime(2020, 5, 15, 5, 45, 21, 513, DateTimeKind.Unspecified).AddTicks(2666), new DateTime(2020, 5, 15, 5, 45, 21, 513, DateTimeKind.Unspecified).AddTicks(2717), "ktuz9265fw" });

            migrationBuilder.UpdateData(
                table: "SystemUserPermission",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2020, 5, 15, 5, 45, 21, 515, DateTimeKind.Unspecified).AddTicks(2505), new DateTime(2020, 5, 15, 5, 45, 21, 515, DateTimeKind.Unspecified).AddTicks(2648) });

            migrationBuilder.UpdateData(
                table: "SystemUserPermission",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2020, 5, 15, 5, 45, 21, 515, DateTimeKind.Unspecified).AddTicks(7558), new DateTime(2020, 5, 15, 5, 45, 21, 515, DateTimeKind.Unspecified).AddTicks(7635) });

            migrationBuilder.UpdateData(
                table: "SystemUserPermission",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2020, 5, 15, 5, 45, 21, 515, DateTimeKind.Unspecified).AddTicks(7861), new DateTime(2020, 5, 15, 5, 45, 21, 515, DateTimeKind.Unspecified).AddTicks(7900) });

            migrationBuilder.UpdateData(
                table: "SystemView",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2020, 5, 15, 5, 45, 21, 512, DateTimeKind.Unspecified).AddTicks(9980), new DateTime(2020, 5, 15, 5, 45, 21, 513, DateTimeKind.Unspecified).AddTicks(32) });

            migrationBuilder.UpdateData(
                table: "SystemView",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2020, 5, 15, 5, 45, 21, 513, DateTimeKind.Unspecified).AddTicks(1117), new DateTime(2020, 5, 15, 5, 45, 21, 513, DateTimeKind.Unspecified).AddTicks(1164) });

            migrationBuilder.UpdateData(
                table: "SystemView",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2020, 5, 15, 5, 45, 21, 513, DateTimeKind.Unspecified).AddTicks(1194), new DateTime(2020, 5, 15, 5, 45, 21, 513, DateTimeKind.Unspecified).AddTicks(1209) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AppStaticMessage",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AppStaticMessage",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "AppStaticMessage",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "AppStaticMessage",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "AppStaticMessage",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "AppStaticMessage",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "AppStaticMessage",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "AppStaticMessage",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "AppStaticMessage",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DropColumn(
                name: "Length",
                table: "Attachment");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Attachment");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Attachment");

            migrationBuilder.AddColumn<int>(
                name: "Fk_AttachmentType",
                table: "Attachment",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "AttachmentType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttachmentType", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "AccessLevel",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2020, 5, 13, 17, 26, 34, 952, DateTimeKind.Unspecified).AddTicks(7824), new DateTime(2020, 5, 13, 17, 26, 34, 952, DateTimeKind.Unspecified).AddTicks(7935) });

            migrationBuilder.UpdateData(
                table: "AccessLevel",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2020, 5, 13, 17, 26, 34, 952, DateTimeKind.Unspecified).AddTicks(8709), new DateTime(2020, 5, 13, 17, 26, 34, 952, DateTimeKind.Unspecified).AddTicks(8743) });

            migrationBuilder.UpdateData(
                table: "AccessLevel",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2020, 5, 13, 17, 26, 34, 952, DateTimeKind.Unspecified).AddTicks(8773), new DateTime(2020, 5, 13, 17, 26, 34, 952, DateTimeKind.Unspecified).AddTicks(8784) });

            migrationBuilder.UpdateData(
                table: "ControlLevel",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2020, 5, 13, 17, 26, 34, 952, DateTimeKind.Unspecified).AddTicks(9930), new DateTime(2020, 5, 13, 17, 26, 34, 953, DateTimeKind.Unspecified).AddTicks(96) });

            migrationBuilder.UpdateData(
                table: "ControlLevel",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2020, 5, 13, 17, 26, 34, 953, DateTimeKind.Unspecified).AddTicks(1554), new DateTime(2020, 5, 13, 17, 26, 34, 953, DateTimeKind.Unspecified).AddTicks(1598) });

            migrationBuilder.UpdateData(
                table: "Language",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2020, 5, 13, 17, 26, 34, 946, DateTimeKind.Unspecified).AddTicks(1334), new DateTime(2020, 5, 13, 17, 26, 34, 950, DateTimeKind.Unspecified).AddTicks(4011) });

            migrationBuilder.UpdateData(
                table: "Language",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2020, 5, 13, 17, 26, 34, 950, DateTimeKind.Unspecified).AddTicks(6972), new DateTime(2020, 5, 13, 17, 26, 34, 950, DateTimeKind.Unspecified).AddTicks(7023) });

            migrationBuilder.UpdateData(
                table: "SystemUser",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LastModifiedAt", "Password" },
                values: new object[] { new DateTime(2020, 5, 13, 17, 26, 34, 954, DateTimeKind.Unspecified).AddTicks(4788), new DateTime(2020, 5, 13, 17, 26, 34, 954, DateTimeKind.Unspecified).AddTicks(4826), "hwgk3225xl" });

            migrationBuilder.UpdateData(
                table: "SystemUserPermission",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2020, 5, 13, 17, 26, 34, 955, DateTimeKind.Unspecified).AddTicks(7285), new DateTime(2020, 5, 13, 17, 26, 34, 955, DateTimeKind.Unspecified).AddTicks(7377) });

            migrationBuilder.UpdateData(
                table: "SystemUserPermission",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2020, 5, 13, 17, 26, 34, 955, DateTimeKind.Unspecified).AddTicks(9627), new DateTime(2020, 5, 13, 17, 26, 34, 955, DateTimeKind.Unspecified).AddTicks(9674) });

            migrationBuilder.UpdateData(
                table: "SystemUserPermission",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2020, 5, 13, 17, 26, 34, 955, DateTimeKind.Unspecified).AddTicks(9763), new DateTime(2020, 5, 13, 17, 26, 34, 955, DateTimeKind.Unspecified).AddTicks(9775) });

            migrationBuilder.UpdateData(
                table: "SystemView",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2020, 5, 13, 17, 26, 34, 954, DateTimeKind.Unspecified).AddTicks(2194), new DateTime(2020, 5, 13, 17, 26, 34, 954, DateTimeKind.Unspecified).AddTicks(2305) });

            migrationBuilder.UpdateData(
                table: "SystemView",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2020, 5, 13, 17, 26, 34, 954, DateTimeKind.Unspecified).AddTicks(3302), new DateTime(2020, 5, 13, 17, 26, 34, 954, DateTimeKind.Unspecified).AddTicks(3345) });

            migrationBuilder.UpdateData(
                table: "SystemView",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2020, 5, 13, 17, 26, 34, 954, DateTimeKind.Unspecified).AddTicks(3378), new DateTime(2020, 5, 13, 17, 26, 34, 954, DateTimeKind.Unspecified).AddTicks(3389) });

            migrationBuilder.CreateIndex(
                name: "IX_Attachment_Fk_AttachmentType",
                table: "Attachment",
                column: "Fk_AttachmentType");

            migrationBuilder.AddForeignKey(
                name: "FK_Attachment_AttachmentType_Fk_AttachmentType",
                table: "Attachment",
                column: "Fk_AttachmentType",
                principalTable: "AttachmentType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
