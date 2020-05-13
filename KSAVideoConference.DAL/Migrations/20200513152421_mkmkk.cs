using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace KSAVideoConference.DAL.Migrations
{
    public partial class mkmkk : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "User",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "AccessLevel",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2020, 5, 13, 17, 24, 20, 689, DateTimeKind.Unspecified).AddTicks(4571), new DateTime(2020, 5, 13, 17, 24, 20, 689, DateTimeKind.Unspecified).AddTicks(4707) });

            migrationBuilder.UpdateData(
                table: "AccessLevel",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2020, 5, 13, 17, 24, 20, 689, DateTimeKind.Unspecified).AddTicks(5890), new DateTime(2020, 5, 13, 17, 24, 20, 689, DateTimeKind.Unspecified).AddTicks(5957) });

            migrationBuilder.UpdateData(
                table: "AccessLevel",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2020, 5, 13, 17, 24, 20, 689, DateTimeKind.Unspecified).AddTicks(5983), new DateTime(2020, 5, 13, 17, 24, 20, 689, DateTimeKind.Unspecified).AddTicks(5991) });

            migrationBuilder.UpdateData(
                table: "ControlLevel",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2020, 5, 13, 17, 24, 20, 689, DateTimeKind.Unspecified).AddTicks(7164), new DateTime(2020, 5, 13, 17, 24, 20, 689, DateTimeKind.Unspecified).AddTicks(7200) });

            migrationBuilder.UpdateData(
                table: "ControlLevel",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2020, 5, 13, 17, 24, 20, 689, DateTimeKind.Unspecified).AddTicks(7851), new DateTime(2020, 5, 13, 17, 24, 20, 689, DateTimeKind.Unspecified).AddTicks(7877) });

            migrationBuilder.UpdateData(
                table: "Language",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2020, 5, 13, 17, 24, 20, 680, DateTimeKind.Unspecified).AddTicks(2963), new DateTime(2020, 5, 13, 17, 24, 20, 687, DateTimeKind.Unspecified).AddTicks(2027) });

            migrationBuilder.UpdateData(
                table: "Language",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2020, 5, 13, 17, 24, 20, 687, DateTimeKind.Unspecified).AddTicks(5418), new DateTime(2020, 5, 13, 17, 24, 20, 687, DateTimeKind.Unspecified).AddTicks(5468) });

            migrationBuilder.UpdateData(
                table: "SystemUser",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LastModifiedAt", "Password" },
                values: new object[] { new DateTime(2020, 5, 13, 17, 24, 20, 690, DateTimeKind.Unspecified).AddTicks(705), new DateTime(2020, 5, 13, 17, 24, 20, 690, DateTimeKind.Unspecified).AddTicks(740), "qtkg4885qs" });

            migrationBuilder.UpdateData(
                table: "SystemUserPermission",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2020, 5, 13, 17, 24, 20, 691, DateTimeKind.Unspecified).AddTicks(960), new DateTime(2020, 5, 13, 17, 24, 20, 691, DateTimeKind.Unspecified).AddTicks(1013) });

            migrationBuilder.UpdateData(
                table: "SystemUserPermission",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2020, 5, 13, 17, 24, 20, 691, DateTimeKind.Unspecified).AddTicks(3099), new DateTime(2020, 5, 13, 17, 24, 20, 691, DateTimeKind.Unspecified).AddTicks(3130) });

            migrationBuilder.UpdateData(
                table: "SystemUserPermission",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2020, 5, 13, 17, 24, 20, 691, DateTimeKind.Unspecified).AddTicks(3182), new DateTime(2020, 5, 13, 17, 24, 20, 691, DateTimeKind.Unspecified).AddTicks(3189) });

            migrationBuilder.UpdateData(
                table: "SystemView",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2020, 5, 13, 17, 24, 20, 689, DateTimeKind.Unspecified).AddTicks(8750), new DateTime(2020, 5, 13, 17, 24, 20, 689, DateTimeKind.Unspecified).AddTicks(8778) });

            migrationBuilder.UpdateData(
                table: "SystemView",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2020, 5, 13, 17, 24, 20, 689, DateTimeKind.Unspecified).AddTicks(9474), new DateTime(2020, 5, 13, 17, 24, 20, 689, DateTimeKind.Unspecified).AddTicks(9507) });

            migrationBuilder.UpdateData(
                table: "SystemView",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2020, 5, 13, 17, 24, 20, 689, DateTimeKind.Unspecified).AddTicks(9539), new DateTime(2020, 5, 13, 17, 24, 20, 689, DateTimeKind.Unspecified).AddTicks(9552) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "User");

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
        }
    }
}
