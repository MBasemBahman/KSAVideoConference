using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace KSAVideoConference.DAL.Migrations
{
    public partial class mkmkmk : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Fk_Language",
                table: "User",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AccessLevel",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2020, 5, 12, 21, 42, 8, 847, DateTimeKind.Unspecified).AddTicks(7624), new DateTime(2020, 5, 12, 21, 42, 8, 847, DateTimeKind.Unspecified).AddTicks(7660) });

            migrationBuilder.UpdateData(
                table: "AccessLevel",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2020, 5, 12, 21, 42, 8, 847, DateTimeKind.Unspecified).AddTicks(8190), new DateTime(2020, 5, 12, 21, 42, 8, 847, DateTimeKind.Unspecified).AddTicks(8211) });

            migrationBuilder.UpdateData(
                table: "AccessLevel",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2020, 5, 12, 21, 42, 8, 847, DateTimeKind.Unspecified).AddTicks(8226), new DateTime(2020, 5, 12, 21, 42, 8, 847, DateTimeKind.Unspecified).AddTicks(8232) });

            migrationBuilder.UpdateData(
                table: "ControlLevel",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2020, 5, 12, 21, 42, 8, 847, DateTimeKind.Unspecified).AddTicks(8930), new DateTime(2020, 5, 12, 21, 42, 8, 847, DateTimeKind.Unspecified).AddTicks(8951) });

            migrationBuilder.UpdateData(
                table: "ControlLevel",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2020, 5, 12, 21, 42, 8, 847, DateTimeKind.Unspecified).AddTicks(9416), new DateTime(2020, 5, 12, 21, 42, 8, 847, DateTimeKind.Unspecified).AddTicks(9437) });

            migrationBuilder.UpdateData(
                table: "Language",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2020, 5, 12, 21, 42, 8, 843, DateTimeKind.Unspecified).AddTicks(4855), new DateTime(2020, 5, 12, 21, 42, 8, 846, DateTimeKind.Unspecified).AddTicks(2940) });

            migrationBuilder.UpdateData(
                table: "Language",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2020, 5, 12, 21, 42, 8, 846, DateTimeKind.Unspecified).AddTicks(4798), new DateTime(2020, 5, 12, 21, 42, 8, 846, DateTimeKind.Unspecified).AddTicks(4827) });

            migrationBuilder.UpdateData(
                table: "SystemUser",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LastModifiedAt", "Password" },
                values: new object[] { new DateTime(2020, 5, 12, 21, 42, 8, 848, DateTimeKind.Unspecified).AddTicks(1249), new DateTime(2020, 5, 12, 21, 42, 8, 848, DateTimeKind.Unspecified).AddTicks(1270), "zgeg5772aq" });

            migrationBuilder.UpdateData(
                table: "SystemUserPermission",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2020, 5, 12, 21, 42, 8, 848, DateTimeKind.Unspecified).AddTicks(9238), new DateTime(2020, 5, 12, 21, 42, 8, 848, DateTimeKind.Unspecified).AddTicks(9272) });

            migrationBuilder.UpdateData(
                table: "SystemUserPermission",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2020, 5, 12, 21, 42, 8, 849, DateTimeKind.Unspecified).AddTicks(765), new DateTime(2020, 5, 12, 21, 42, 8, 849, DateTimeKind.Unspecified).AddTicks(788) });

            migrationBuilder.UpdateData(
                table: "SystemUserPermission",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2020, 5, 12, 21, 42, 8, 849, DateTimeKind.Unspecified).AddTicks(825), new DateTime(2020, 5, 12, 21, 42, 8, 849, DateTimeKind.Unspecified).AddTicks(831) });

            migrationBuilder.UpdateData(
                table: "SystemView",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2020, 5, 12, 21, 42, 8, 848, DateTimeKind.Unspecified).AddTicks(76), new DateTime(2020, 5, 12, 21, 42, 8, 848, DateTimeKind.Unspecified).AddTicks(96) });

            migrationBuilder.UpdateData(
                table: "SystemView",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2020, 5, 12, 21, 42, 8, 848, DateTimeKind.Unspecified).AddTicks(540), new DateTime(2020, 5, 12, 21, 42, 8, 848, DateTimeKind.Unspecified).AddTicks(559) });

            migrationBuilder.UpdateData(
                table: "SystemView",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2020, 5, 12, 21, 42, 8, 848, DateTimeKind.Unspecified).AddTicks(575), new DateTime(2020, 5, 12, 21, 42, 8, 848, DateTimeKind.Unspecified).AddTicks(581) });

            migrationBuilder.CreateIndex(
                name: "IX_User_Fk_Language",
                table: "User",
                column: "Fk_Language");

            migrationBuilder.AddForeignKey(
                name: "FK_User_Language_Fk_Language",
                table: "User",
                column: "Fk_Language",
                principalTable: "Language",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_Language_Fk_Language",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_User_Fk_Language",
                table: "User");

            migrationBuilder.DropColumn(
                name: "Fk_Language",
                table: "User");

            migrationBuilder.UpdateData(
                table: "AccessLevel",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2020, 5, 12, 21, 30, 29, 83, DateTimeKind.Unspecified).AddTicks(4522), new DateTime(2020, 5, 12, 21, 30, 29, 83, DateTimeKind.Unspecified).AddTicks(4559) });

            migrationBuilder.UpdateData(
                table: "AccessLevel",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2020, 5, 12, 21, 30, 29, 83, DateTimeKind.Unspecified).AddTicks(5115), new DateTime(2020, 5, 12, 21, 30, 29, 83, DateTimeKind.Unspecified).AddTicks(5137) });

            migrationBuilder.UpdateData(
                table: "AccessLevel",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2020, 5, 12, 21, 30, 29, 83, DateTimeKind.Unspecified).AddTicks(5153), new DateTime(2020, 5, 12, 21, 30, 29, 83, DateTimeKind.Unspecified).AddTicks(5159) });

            migrationBuilder.UpdateData(
                table: "ControlLevel",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2020, 5, 12, 21, 30, 29, 83, DateTimeKind.Unspecified).AddTicks(5891), new DateTime(2020, 5, 12, 21, 30, 29, 83, DateTimeKind.Unspecified).AddTicks(5915) });

            migrationBuilder.UpdateData(
                table: "ControlLevel",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2020, 5, 12, 21, 30, 29, 83, DateTimeKind.Unspecified).AddTicks(6399), new DateTime(2020, 5, 12, 21, 30, 29, 83, DateTimeKind.Unspecified).AddTicks(6420) });

            migrationBuilder.UpdateData(
                table: "Language",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2020, 5, 12, 21, 30, 29, 77, DateTimeKind.Unspecified).AddTicks(6887), new DateTime(2020, 5, 12, 21, 30, 29, 81, DateTimeKind.Unspecified).AddTicks(9156) });

            migrationBuilder.UpdateData(
                table: "Language",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2020, 5, 12, 21, 30, 29, 82, DateTimeKind.Unspecified).AddTicks(1142), new DateTime(2020, 5, 12, 21, 30, 29, 82, DateTimeKind.Unspecified).AddTicks(1172) });

            migrationBuilder.UpdateData(
                table: "SystemUser",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LastModifiedAt", "Password" },
                values: new object[] { new DateTime(2020, 5, 12, 21, 30, 29, 83, DateTimeKind.Unspecified).AddTicks(8361), new DateTime(2020, 5, 12, 21, 30, 29, 83, DateTimeKind.Unspecified).AddTicks(8384), "zmwr1651uu" });

            migrationBuilder.UpdateData(
                table: "SystemUserPermission",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2020, 5, 12, 21, 30, 29, 84, DateTimeKind.Unspecified).AddTicks(7751), new DateTime(2020, 5, 12, 21, 30, 29, 84, DateTimeKind.Unspecified).AddTicks(7811) });

            migrationBuilder.UpdateData(
                table: "SystemUserPermission",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2020, 5, 12, 21, 30, 29, 84, DateTimeKind.Unspecified).AddTicks(9456), new DateTime(2020, 5, 12, 21, 30, 29, 84, DateTimeKind.Unspecified).AddTicks(9479) });

            migrationBuilder.UpdateData(
                table: "SystemUserPermission",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2020, 5, 12, 21, 30, 29, 84, DateTimeKind.Unspecified).AddTicks(9522), new DateTime(2020, 5, 12, 21, 30, 29, 84, DateTimeKind.Unspecified).AddTicks(9528) });

            migrationBuilder.UpdateData(
                table: "SystemView",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2020, 5, 12, 21, 30, 29, 83, DateTimeKind.Unspecified).AddTicks(7105), new DateTime(2020, 5, 12, 21, 30, 29, 83, DateTimeKind.Unspecified).AddTicks(7128) });

            migrationBuilder.UpdateData(
                table: "SystemView",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2020, 5, 12, 21, 30, 29, 83, DateTimeKind.Unspecified).AddTicks(7605), new DateTime(2020, 5, 12, 21, 30, 29, 83, DateTimeKind.Unspecified).AddTicks(7626) });

            migrationBuilder.UpdateData(
                table: "SystemView",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2020, 5, 12, 21, 30, 29, 83, DateTimeKind.Unspecified).AddTicks(7642), new DateTime(2020, 5, 12, 21, 30, 29, 83, DateTimeKind.Unspecified).AddTicks(7648) });
        }
    }
}
