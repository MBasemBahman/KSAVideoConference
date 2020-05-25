using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace KSAVideoConference.DAL.Migrations
{
    public partial class dmkk : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "GroupMember");

            migrationBuilder.UpdateData(
                table: "AccessLevel",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2020, 5, 25, 22, 4, 33, 516, DateTimeKind.Unspecified).AddTicks(9750), new DateTime(2020, 5, 25, 22, 4, 33, 516, DateTimeKind.Unspecified).AddTicks(9774) });

            migrationBuilder.UpdateData(
                table: "AccessLevel",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2020, 5, 25, 22, 4, 33, 517, DateTimeKind.Unspecified).AddTicks(332), new DateTime(2020, 5, 25, 22, 4, 33, 517, DateTimeKind.Unspecified).AddTicks(352) });

            migrationBuilder.UpdateData(
                table: "AccessLevel",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2020, 5, 25, 22, 4, 33, 517, DateTimeKind.Unspecified).AddTicks(373), new DateTime(2020, 5, 25, 22, 4, 33, 517, DateTimeKind.Unspecified).AddTicks(379) });

            migrationBuilder.UpdateData(
                table: "AppStaticMessage",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2020, 5, 25, 22, 4, 33, 512, DateTimeKind.Unspecified).AddTicks(3513), new DateTime(2020, 5, 25, 22, 4, 33, 515, DateTimeKind.Unspecified).AddTicks(1485) });

            migrationBuilder.UpdateData(
                table: "AppStaticMessage",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2020, 5, 25, 22, 4, 33, 515, DateTimeKind.Unspecified).AddTicks(4043), new DateTime(2020, 5, 25, 22, 4, 33, 515, DateTimeKind.Unspecified).AddTicks(4047) });

            migrationBuilder.UpdateData(
                table: "AppStaticMessage",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2020, 5, 25, 22, 4, 33, 515, DateTimeKind.Unspecified).AddTicks(4029), new DateTime(2020, 5, 25, 22, 4, 33, 515, DateTimeKind.Unspecified).AddTicks(4036) });

            migrationBuilder.UpdateData(
                table: "AppStaticMessage",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2020, 5, 25, 22, 4, 33, 515, DateTimeKind.Unspecified).AddTicks(3939), new DateTime(2020, 5, 25, 22, 4, 33, 515, DateTimeKind.Unspecified).AddTicks(3945) });

            migrationBuilder.UpdateData(
                table: "AppStaticMessage",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2020, 5, 25, 22, 4, 33, 515, DateTimeKind.Unspecified).AddTicks(3972), new DateTime(2020, 5, 25, 22, 4, 33, 515, DateTimeKind.Unspecified).AddTicks(3977) });

            migrationBuilder.UpdateData(
                table: "AppStaticMessage",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2020, 5, 25, 22, 4, 33, 515, DateTimeKind.Unspecified).AddTicks(3962), new DateTime(2020, 5, 25, 22, 4, 33, 515, DateTimeKind.Unspecified).AddTicks(3967) });

            migrationBuilder.UpdateData(
                table: "AppStaticMessage",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2020, 5, 25, 22, 4, 33, 515, DateTimeKind.Unspecified).AddTicks(3951), new DateTime(2020, 5, 25, 22, 4, 33, 515, DateTimeKind.Unspecified).AddTicks(3956) });

            migrationBuilder.UpdateData(
                table: "AppStaticMessage",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2020, 5, 25, 22, 4, 33, 515, DateTimeKind.Unspecified).AddTicks(3982), new DateTime(2020, 5, 25, 22, 4, 33, 515, DateTimeKind.Unspecified).AddTicks(3987) });

            migrationBuilder.UpdateData(
                table: "AppStaticMessage",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2020, 5, 25, 22, 4, 33, 515, DateTimeKind.Unspecified).AddTicks(3860), new DateTime(2020, 5, 25, 22, 4, 33, 515, DateTimeKind.Unspecified).AddTicks(3889) });

            migrationBuilder.UpdateData(
                table: "ControlLevel",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2020, 5, 25, 22, 4, 33, 517, DateTimeKind.Unspecified).AddTicks(990), new DateTime(2020, 5, 25, 22, 4, 33, 517, DateTimeKind.Unspecified).AddTicks(1011) });

            migrationBuilder.UpdateData(
                table: "ControlLevel",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2020, 5, 25, 22, 4, 33, 517, DateTimeKind.Unspecified).AddTicks(1430), new DateTime(2020, 5, 25, 22, 4, 33, 517, DateTimeKind.Unspecified).AddTicks(1450) });

            migrationBuilder.UpdateData(
                table: "Language",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2020, 5, 25, 22, 4, 33, 516, DateTimeKind.Unspecified).AddTicks(8522), new DateTime(2020, 5, 25, 22, 4, 33, 516, DateTimeKind.Unspecified).AddTicks(8548) });

            migrationBuilder.UpdateData(
                table: "Language",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2020, 5, 25, 22, 4, 33, 516, DateTimeKind.Unspecified).AddTicks(9041), new DateTime(2020, 5, 25, 22, 4, 33, 516, DateTimeKind.Unspecified).AddTicks(9063) });

            migrationBuilder.UpdateData(
                table: "MemberType",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2020, 5, 25, 22, 4, 33, 516, DateTimeKind.Unspecified).AddTicks(6799), new DateTime(2020, 5, 25, 22, 4, 33, 516, DateTimeKind.Unspecified).AddTicks(6836) });

            migrationBuilder.UpdateData(
                table: "SystemUser",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LastModifiedAt", "Password" },
                values: new object[] { new DateTime(2020, 5, 25, 22, 4, 33, 517, DateTimeKind.Unspecified).AddTicks(3222), new DateTime(2020, 5, 25, 22, 4, 33, 517, DateTimeKind.Unspecified).AddTicks(3243), "rpew6722uv" });

            migrationBuilder.UpdateData(
                table: "SystemUserPermission",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2020, 5, 25, 22, 4, 33, 518, DateTimeKind.Unspecified).AddTicks(952), new DateTime(2020, 5, 25, 22, 4, 33, 518, DateTimeKind.Unspecified).AddTicks(986) });

            migrationBuilder.UpdateData(
                table: "SystemUserPermission",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2020, 5, 25, 22, 4, 33, 518, DateTimeKind.Unspecified).AddTicks(2080), new DateTime(2020, 5, 25, 22, 4, 33, 518, DateTimeKind.Unspecified).AddTicks(2102) });

            migrationBuilder.UpdateData(
                table: "SystemUserPermission",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2020, 5, 25, 22, 4, 33, 518, DateTimeKind.Unspecified).AddTicks(2146), new DateTime(2020, 5, 25, 22, 4, 33, 518, DateTimeKind.Unspecified).AddTicks(2243) });

            migrationBuilder.UpdateData(
                table: "SystemView",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2020, 5, 25, 22, 4, 33, 517, DateTimeKind.Unspecified).AddTicks(2061), new DateTime(2020, 5, 25, 22, 4, 33, 517, DateTimeKind.Unspecified).AddTicks(2082) });

            migrationBuilder.UpdateData(
                table: "SystemView",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2020, 5, 25, 22, 4, 33, 517, DateTimeKind.Unspecified).AddTicks(2484), new DateTime(2020, 5, 25, 22, 4, 33, 517, DateTimeKind.Unspecified).AddTicks(2505) });

            migrationBuilder.UpdateData(
                table: "SystemView",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2020, 5, 25, 22, 4, 33, 517, DateTimeKind.Unspecified).AddTicks(2520), new DateTime(2020, 5, 25, 22, 4, 33, 517, DateTimeKind.Unspecified).AddTicks(2526) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "GroupMember",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "AccessLevel",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2020, 5, 22, 17, 17, 32, 977, DateTimeKind.Unspecified).AddTicks(8430), new DateTime(2020, 5, 22, 17, 17, 32, 977, DateTimeKind.Unspecified).AddTicks(8452) });

            migrationBuilder.UpdateData(
                table: "AccessLevel",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2020, 5, 22, 17, 17, 32, 977, DateTimeKind.Unspecified).AddTicks(8886), new DateTime(2020, 5, 22, 17, 17, 32, 977, DateTimeKind.Unspecified).AddTicks(8905) });

            migrationBuilder.UpdateData(
                table: "AccessLevel",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2020, 5, 22, 17, 17, 32, 977, DateTimeKind.Unspecified).AddTicks(8932), new DateTime(2020, 5, 22, 17, 17, 32, 977, DateTimeKind.Unspecified).AddTicks(8937) });

            migrationBuilder.UpdateData(
                table: "AppStaticMessage",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2020, 5, 22, 17, 17, 32, 972, DateTimeKind.Unspecified).AddTicks(7961), new DateTime(2020, 5, 22, 17, 17, 32, 975, DateTimeKind.Unspecified).AddTicks(7879) });

            migrationBuilder.UpdateData(
                table: "AppStaticMessage",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2020, 5, 22, 17, 17, 32, 976, DateTimeKind.Unspecified).AddTicks(341), new DateTime(2020, 5, 22, 17, 17, 32, 976, DateTimeKind.Unspecified).AddTicks(346) });

            migrationBuilder.UpdateData(
                table: "AppStaticMessage",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2020, 5, 22, 17, 17, 32, 976, DateTimeKind.Unspecified).AddTicks(329), new DateTime(2020, 5, 22, 17, 17, 32, 976, DateTimeKind.Unspecified).AddTicks(335) });

            migrationBuilder.UpdateData(
                table: "AppStaticMessage",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2020, 5, 22, 17, 17, 32, 976, DateTimeKind.Unspecified).AddTicks(270), new DateTime(2020, 5, 22, 17, 17, 32, 976, DateTimeKind.Unspecified).AddTicks(276) });

            migrationBuilder.UpdateData(
                table: "AppStaticMessage",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2020, 5, 22, 17, 17, 32, 976, DateTimeKind.Unspecified).AddTicks(307), new DateTime(2020, 5, 22, 17, 17, 32, 976, DateTimeKind.Unspecified).AddTicks(312) });

            migrationBuilder.UpdateData(
                table: "AppStaticMessage",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2020, 5, 22, 17, 17, 32, 976, DateTimeKind.Unspecified).AddTicks(295), new DateTime(2020, 5, 22, 17, 17, 32, 976, DateTimeKind.Unspecified).AddTicks(301) });

            migrationBuilder.UpdateData(
                table: "AppStaticMessage",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2020, 5, 22, 17, 17, 32, 976, DateTimeKind.Unspecified).AddTicks(283), new DateTime(2020, 5, 22, 17, 17, 32, 976, DateTimeKind.Unspecified).AddTicks(288) });

            migrationBuilder.UpdateData(
                table: "AppStaticMessage",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2020, 5, 22, 17, 17, 32, 976, DateTimeKind.Unspecified).AddTicks(318), new DateTime(2020, 5, 22, 17, 17, 32, 976, DateTimeKind.Unspecified).AddTicks(323) });

            migrationBuilder.UpdateData(
                table: "AppStaticMessage",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2020, 5, 22, 17, 17, 32, 976, DateTimeKind.Unspecified).AddTicks(189), new DateTime(2020, 5, 22, 17, 17, 32, 976, DateTimeKind.Unspecified).AddTicks(220) });

            migrationBuilder.UpdateData(
                table: "ControlLevel",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2020, 5, 22, 17, 17, 32, 977, DateTimeKind.Unspecified).AddTicks(9549), new DateTime(2020, 5, 22, 17, 17, 32, 977, DateTimeKind.Unspecified).AddTicks(9569) });

            migrationBuilder.UpdateData(
                table: "ControlLevel",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2020, 5, 22, 17, 17, 32, 977, DateTimeKind.Unspecified).AddTicks(9990), new DateTime(2020, 5, 22, 17, 17, 32, 978, DateTimeKind.Unspecified).AddTicks(10) });

            migrationBuilder.UpdateData(
                table: "Language",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2020, 5, 22, 17, 17, 32, 977, DateTimeKind.Unspecified).AddTicks(7274), new DateTime(2020, 5, 22, 17, 17, 32, 977, DateTimeKind.Unspecified).AddTicks(7301) });

            migrationBuilder.UpdateData(
                table: "Language",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2020, 5, 22, 17, 17, 32, 977, DateTimeKind.Unspecified).AddTicks(7758), new DateTime(2020, 5, 22, 17, 17, 32, 977, DateTimeKind.Unspecified).AddTicks(7779) });

            migrationBuilder.UpdateData(
                table: "MemberType",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2020, 5, 22, 17, 17, 32, 977, DateTimeKind.Unspecified).AddTicks(6016), new DateTime(2020, 5, 22, 17, 17, 32, 977, DateTimeKind.Unspecified).AddTicks(6067) });

            migrationBuilder.UpdateData(
                table: "SystemUser",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LastModifiedAt", "Password" },
                values: new object[] { new DateTime(2020, 5, 22, 17, 17, 32, 978, DateTimeKind.Unspecified).AddTicks(1781), new DateTime(2020, 5, 22, 17, 17, 32, 978, DateTimeKind.Unspecified).AddTicks(1802), "mecw9858xm" });

            migrationBuilder.UpdateData(
                table: "SystemUserPermission",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2020, 5, 22, 17, 17, 32, 979, DateTimeKind.Unspecified).AddTicks(711), new DateTime(2020, 5, 22, 17, 17, 32, 979, DateTimeKind.Unspecified).AddTicks(749) });

            migrationBuilder.UpdateData(
                table: "SystemUserPermission",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2020, 5, 22, 17, 17, 32, 979, DateTimeKind.Unspecified).AddTicks(1981), new DateTime(2020, 5, 22, 17, 17, 32, 979, DateTimeKind.Unspecified).AddTicks(2004) });

            migrationBuilder.UpdateData(
                table: "SystemUserPermission",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2020, 5, 22, 17, 17, 32, 979, DateTimeKind.Unspecified).AddTicks(2048), new DateTime(2020, 5, 22, 17, 17, 32, 979, DateTimeKind.Unspecified).AddTicks(2054) });

            migrationBuilder.UpdateData(
                table: "SystemView",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2020, 5, 22, 17, 17, 32, 978, DateTimeKind.Unspecified).AddTicks(612), new DateTime(2020, 5, 22, 17, 17, 32, 978, DateTimeKind.Unspecified).AddTicks(632) });

            migrationBuilder.UpdateData(
                table: "SystemView",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2020, 5, 22, 17, 17, 32, 978, DateTimeKind.Unspecified).AddTicks(1045), new DateTime(2020, 5, 22, 17, 17, 32, 978, DateTimeKind.Unspecified).AddTicks(1064) });

            migrationBuilder.UpdateData(
                table: "SystemView",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2020, 5, 22, 17, 17, 32, 978, DateTimeKind.Unspecified).AddTicks(1077), new DateTime(2020, 5, 22, 17, 17, 32, 978, DateTimeKind.Unspecified).AddTicks(1083) });
        }
    }
}
