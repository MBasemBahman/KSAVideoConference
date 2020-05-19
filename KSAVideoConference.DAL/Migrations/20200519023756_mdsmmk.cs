using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace KSAVideoConference.DAL.Migrations
{
    public partial class mdsmmk : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                columns: new[] { "CreatedAt", "Email", "FullName", "JopTitle", "LastModifiedAt", "Password" },
                values: new object[] { new DateTime(2020, 5, 19, 4, 37, 56, 35, DateTimeKind.Unspecified).AddTicks(879), "Developer@App.com", "Developer", "Developer", new DateTime(2020, 5, 19, 4, 37, 56, 35, DateTimeKind.Unspecified).AddTicks(901), "szrd7589xt" });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AccessLevel",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2020, 5, 19, 3, 47, 8, 989, DateTimeKind.Unspecified).AddTicks(6002), new DateTime(2020, 5, 19, 3, 47, 8, 989, DateTimeKind.Unspecified).AddTicks(6024) });

            migrationBuilder.UpdateData(
                table: "AccessLevel",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2020, 5, 19, 3, 47, 8, 989, DateTimeKind.Unspecified).AddTicks(6522), new DateTime(2020, 5, 19, 3, 47, 8, 989, DateTimeKind.Unspecified).AddTicks(6541) });

            migrationBuilder.UpdateData(
                table: "AccessLevel",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2020, 5, 19, 3, 47, 8, 989, DateTimeKind.Unspecified).AddTicks(6568), new DateTime(2020, 5, 19, 3, 47, 8, 989, DateTimeKind.Unspecified).AddTicks(6574) });

            migrationBuilder.UpdateData(
                table: "AppStaticMessage",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2020, 5, 19, 3, 47, 8, 983, DateTimeKind.Unspecified).AddTicks(503), new DateTime(2020, 5, 19, 3, 47, 8, 986, DateTimeKind.Unspecified).AddTicks(7568) });

            migrationBuilder.UpdateData(
                table: "AppStaticMessage",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2020, 5, 19, 3, 47, 8, 987, DateTimeKind.Unspecified).AddTicks(2816), new DateTime(2020, 5, 19, 3, 47, 8, 987, DateTimeKind.Unspecified).AddTicks(2822) });

            migrationBuilder.UpdateData(
                table: "AppStaticMessage",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2020, 5, 19, 3, 47, 8, 987, DateTimeKind.Unspecified).AddTicks(2805), new DateTime(2020, 5, 19, 3, 47, 8, 987, DateTimeKind.Unspecified).AddTicks(2810) });

            migrationBuilder.UpdateData(
                table: "AppStaticMessage",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2020, 5, 19, 3, 47, 8, 987, DateTimeKind.Unspecified).AddTicks(2658), new DateTime(2020, 5, 19, 3, 47, 8, 987, DateTimeKind.Unspecified).AddTicks(2665) });

            migrationBuilder.UpdateData(
                table: "AppStaticMessage",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2020, 5, 19, 3, 47, 8, 987, DateTimeKind.Unspecified).AddTicks(2781), new DateTime(2020, 5, 19, 3, 47, 8, 987, DateTimeKind.Unspecified).AddTicks(2787) });

            migrationBuilder.UpdateData(
                table: "AppStaticMessage",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2020, 5, 19, 3, 47, 8, 987, DateTimeKind.Unspecified).AddTicks(2683), new DateTime(2020, 5, 19, 3, 47, 8, 987, DateTimeKind.Unspecified).AddTicks(2689) });

            migrationBuilder.UpdateData(
                table: "AppStaticMessage",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2020, 5, 19, 3, 47, 8, 987, DateTimeKind.Unspecified).AddTicks(2672), new DateTime(2020, 5, 19, 3, 47, 8, 987, DateTimeKind.Unspecified).AddTicks(2677) });

            migrationBuilder.UpdateData(
                table: "AppStaticMessage",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2020, 5, 19, 3, 47, 8, 987, DateTimeKind.Unspecified).AddTicks(2794), new DateTime(2020, 5, 19, 3, 47, 8, 987, DateTimeKind.Unspecified).AddTicks(2799) });

            migrationBuilder.UpdateData(
                table: "AppStaticMessage",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2020, 5, 19, 3, 47, 8, 987, DateTimeKind.Unspecified).AddTicks(2535), new DateTime(2020, 5, 19, 3, 47, 8, 987, DateTimeKind.Unspecified).AddTicks(2592) });

            migrationBuilder.UpdateData(
                table: "ControlLevel",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2020, 5, 19, 3, 47, 8, 989, DateTimeKind.Unspecified).AddTicks(7211), new DateTime(2020, 5, 19, 3, 47, 8, 989, DateTimeKind.Unspecified).AddTicks(7232) });

            migrationBuilder.UpdateData(
                table: "ControlLevel",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2020, 5, 19, 3, 47, 8, 989, DateTimeKind.Unspecified).AddTicks(7694), new DateTime(2020, 5, 19, 3, 47, 8, 989, DateTimeKind.Unspecified).AddTicks(7713) });

            migrationBuilder.UpdateData(
                table: "Language",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2020, 5, 19, 3, 47, 8, 989, DateTimeKind.Unspecified).AddTicks(3989), new DateTime(2020, 5, 19, 3, 47, 8, 989, DateTimeKind.Unspecified).AddTicks(4244) });

            migrationBuilder.UpdateData(
                table: "Language",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2020, 5, 19, 3, 47, 8, 989, DateTimeKind.Unspecified).AddTicks(5195), new DateTime(2020, 5, 19, 3, 47, 8, 989, DateTimeKind.Unspecified).AddTicks(5226) });

            migrationBuilder.UpdateData(
                table: "SystemUser",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Email", "FullName", "JopTitle", "LastModifiedAt", "Password" },
                values: new object[] { new DateTime(2020, 5, 19, 3, 47, 8, 989, DateTimeKind.Unspecified).AddTicks(9898), "seed@app.com", "Admin", "Admin", new DateTime(2020, 5, 19, 3, 47, 8, 989, DateTimeKind.Unspecified).AddTicks(9918), "mvge2549bu" });

            migrationBuilder.UpdateData(
                table: "SystemUserPermission",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2020, 5, 19, 3, 47, 8, 993, DateTimeKind.Unspecified).AddTicks(3635), new DateTime(2020, 5, 19, 3, 47, 8, 993, DateTimeKind.Unspecified).AddTicks(3681) });

            migrationBuilder.UpdateData(
                table: "SystemUserPermission",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2020, 5, 19, 3, 47, 8, 993, DateTimeKind.Unspecified).AddTicks(4875), new DateTime(2020, 5, 19, 3, 47, 8, 993, DateTimeKind.Unspecified).AddTicks(4901) });

            migrationBuilder.UpdateData(
                table: "SystemUserPermission",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2020, 5, 19, 3, 47, 8, 993, DateTimeKind.Unspecified).AddTicks(4949), new DateTime(2020, 5, 19, 3, 47, 8, 993, DateTimeKind.Unspecified).AddTicks(4999) });

            migrationBuilder.UpdateData(
                table: "SystemView",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2020, 5, 19, 3, 47, 8, 989, DateTimeKind.Unspecified).AddTicks(8566), new DateTime(2020, 5, 19, 3, 47, 8, 989, DateTimeKind.Unspecified).AddTicks(8590) });

            migrationBuilder.UpdateData(
                table: "SystemView",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2020, 5, 19, 3, 47, 8, 989, DateTimeKind.Unspecified).AddTicks(9186), new DateTime(2020, 5, 19, 3, 47, 8, 989, DateTimeKind.Unspecified).AddTicks(9205) });

            migrationBuilder.UpdateData(
                table: "SystemView",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2020, 5, 19, 3, 47, 8, 989, DateTimeKind.Unspecified).AddTicks(9220), new DateTime(2020, 5, 19, 3, 47, 8, 989, DateTimeKind.Unspecified).AddTicks(9226) });
        }
    }
}
