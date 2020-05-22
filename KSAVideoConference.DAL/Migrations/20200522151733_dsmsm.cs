using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace KSAVideoConference.DAL.Migrations
{
    public partial class dsmsm : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.InsertData(
                table: "MemberType",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "LastModifiedAt", "LastModifiedBy", "Name" },
                values: new object[] { 1, new DateTime(2020, 5, 22, 17, 17, 32, 977, DateTimeKind.Unspecified).AddTicks(6016), "seed@app.com", new DateTime(2020, 5, 22, 17, 17, 32, 977, DateTimeKind.Unspecified).AddTicks(6067), null, "عضو" });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "MemberType",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.UpdateData(
                table: "AccessLevel",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2020, 5, 19, 4, 37, 56, 34, DateTimeKind.Unspecified).AddTicks(7208), new DateTime(2020, 5, 19, 4, 37, 56, 34, DateTimeKind.Unspecified).AddTicks(7233) });

            migrationBuilder.UpdateData(
                table: "AccessLevel",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2020, 5, 19, 4, 37, 56, 34, DateTimeKind.Unspecified).AddTicks(7879), new DateTime(2020, 5, 19, 4, 37, 56, 34, DateTimeKind.Unspecified).AddTicks(7899) });

            migrationBuilder.UpdateData(
                table: "AccessLevel",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2020, 5, 19, 4, 37, 56, 34, DateTimeKind.Unspecified).AddTicks(7922), new DateTime(2020, 5, 19, 4, 37, 56, 34, DateTimeKind.Unspecified).AddTicks(7928) });

            migrationBuilder.UpdateData(
                table: "AppStaticMessage",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2020, 5, 19, 4, 37, 56, 29, DateTimeKind.Unspecified).AddTicks(5447), new DateTime(2020, 5, 19, 4, 37, 56, 32, DateTimeKind.Unspecified).AddTicks(8428) });

            migrationBuilder.UpdateData(
                table: "AppStaticMessage",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2020, 5, 19, 4, 37, 56, 33, DateTimeKind.Unspecified).AddTicks(863), new DateTime(2020, 5, 19, 4, 37, 56, 33, DateTimeKind.Unspecified).AddTicks(868) });

            migrationBuilder.UpdateData(
                table: "AppStaticMessage",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2020, 5, 19, 4, 37, 56, 33, DateTimeKind.Unspecified).AddTicks(851), new DateTime(2020, 5, 19, 4, 37, 56, 33, DateTimeKind.Unspecified).AddTicks(857) });

            migrationBuilder.UpdateData(
                table: "AppStaticMessage",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2020, 5, 19, 4, 37, 56, 33, DateTimeKind.Unspecified).AddTicks(792), new DateTime(2020, 5, 19, 4, 37, 56, 33, DateTimeKind.Unspecified).AddTicks(798) });

            migrationBuilder.UpdateData(
                table: "AppStaticMessage",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2020, 5, 19, 4, 37, 56, 33, DateTimeKind.Unspecified).AddTicks(828), new DateTime(2020, 5, 19, 4, 37, 56, 33, DateTimeKind.Unspecified).AddTicks(834) });

            migrationBuilder.UpdateData(
                table: "AppStaticMessage",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2020, 5, 19, 4, 37, 56, 33, DateTimeKind.Unspecified).AddTicks(817), new DateTime(2020, 5, 19, 4, 37, 56, 33, DateTimeKind.Unspecified).AddTicks(822) });

            migrationBuilder.UpdateData(
                table: "AppStaticMessage",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2020, 5, 19, 4, 37, 56, 33, DateTimeKind.Unspecified).AddTicks(805), new DateTime(2020, 5, 19, 4, 37, 56, 33, DateTimeKind.Unspecified).AddTicks(810) });

            migrationBuilder.UpdateData(
                table: "AppStaticMessage",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2020, 5, 19, 4, 37, 56, 33, DateTimeKind.Unspecified).AddTicks(840), new DateTime(2020, 5, 19, 4, 37, 56, 33, DateTimeKind.Unspecified).AddTicks(845) });

            migrationBuilder.UpdateData(
                table: "AppStaticMessage",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2020, 5, 19, 4, 37, 56, 33, DateTimeKind.Unspecified).AddTicks(714), new DateTime(2020, 5, 19, 4, 37, 56, 33, DateTimeKind.Unspecified).AddTicks(744) });

            migrationBuilder.UpdateData(
                table: "ControlLevel",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2020, 5, 19, 4, 37, 56, 34, DateTimeKind.Unspecified).AddTicks(8598), new DateTime(2020, 5, 19, 4, 37, 56, 34, DateTimeKind.Unspecified).AddTicks(8620) });

            migrationBuilder.UpdateData(
                table: "ControlLevel",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2020, 5, 19, 4, 37, 56, 34, DateTimeKind.Unspecified).AddTicks(9065), new DateTime(2020, 5, 19, 4, 37, 56, 34, DateTimeKind.Unspecified).AddTicks(9085) });

            migrationBuilder.UpdateData(
                table: "Language",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2020, 5, 19, 4, 37, 56, 34, DateTimeKind.Unspecified).AddTicks(5167), new DateTime(2020, 5, 19, 4, 37, 56, 34, DateTimeKind.Unspecified).AddTicks(5242) });

            migrationBuilder.UpdateData(
                table: "Language",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2020, 5, 19, 4, 37, 56, 34, DateTimeKind.Unspecified).AddTicks(6053), new DateTime(2020, 5, 19, 4, 37, 56, 34, DateTimeKind.Unspecified).AddTicks(6085) });

            migrationBuilder.UpdateData(
                table: "SystemUser",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LastModifiedAt", "Password" },
                values: new object[] { new DateTime(2020, 5, 19, 4, 37, 56, 35, DateTimeKind.Unspecified).AddTicks(879), new DateTime(2020, 5, 19, 4, 37, 56, 35, DateTimeKind.Unspecified).AddTicks(901), "szrd7589xt" });

            migrationBuilder.UpdateData(
                table: "SystemUserPermission",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2020, 5, 19, 4, 37, 56, 36, DateTimeKind.Unspecified).AddTicks(6501), new DateTime(2020, 5, 19, 4, 37, 56, 36, DateTimeKind.Unspecified).AddTicks(6598) });

            migrationBuilder.UpdateData(
                table: "SystemUserPermission",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2020, 5, 19, 4, 37, 56, 36, DateTimeKind.Unspecified).AddTicks(8098), new DateTime(2020, 5, 19, 4, 37, 56, 36, DateTimeKind.Unspecified).AddTicks(8126) });

            migrationBuilder.UpdateData(
                table: "SystemUserPermission",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2020, 5, 19, 4, 37, 56, 36, DateTimeKind.Unspecified).AddTicks(8177), new DateTime(2020, 5, 19, 4, 37, 56, 36, DateTimeKind.Unspecified).AddTicks(8183) });

            migrationBuilder.UpdateData(
                table: "SystemView",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2020, 5, 19, 4, 37, 56, 34, DateTimeKind.Unspecified).AddTicks(9708), new DateTime(2020, 5, 19, 4, 37, 56, 34, DateTimeKind.Unspecified).AddTicks(9729) });

            migrationBuilder.UpdateData(
                table: "SystemView",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2020, 5, 19, 4, 37, 56, 35, DateTimeKind.Unspecified).AddTicks(156), new DateTime(2020, 5, 19, 4, 37, 56, 35, DateTimeKind.Unspecified).AddTicks(175) });

            migrationBuilder.UpdateData(
                table: "SystemView",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2020, 5, 19, 4, 37, 56, 35, DateTimeKind.Unspecified).AddTicks(191), new DateTime(2020, 5, 19, 4, 37, 56, 35, DateTimeKind.Unspecified).AddTicks(197) });
        }
    }
}
