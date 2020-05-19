using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace KSAVideoConference.DAL.Migrations
{
    public partial class kmmkm : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SystemUserPermission_ControlLevel_Fk_ControlLevel",
                table: "SystemUserPermission");

            migrationBuilder.DropIndex(
                name: "IX_SystemUserPermission_Fk_ControlLevel",
                table: "SystemUserPermission");

            migrationBuilder.DropColumn(
                name: "Fk_ControlLevel",
                table: "SystemUserPermission");

            migrationBuilder.AddColumn<int>(
                name: "Fk_ControlLevel",
                table: "SystemUser",
                nullable: false,
                defaultValue: 0);

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
                columns: new[] { "CreatedAt", "Fk_ControlLevel", "LastModifiedAt", "Password" },
                values: new object[] { new DateTime(2020, 5, 19, 3, 47, 8, 989, DateTimeKind.Unspecified).AddTicks(9898), 1, new DateTime(2020, 5, 19, 3, 47, 8, 989, DateTimeKind.Unspecified).AddTicks(9918), "mvge2549bu" });

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

            migrationBuilder.CreateIndex(
                name: "IX_SystemUser_Fk_ControlLevel",
                table: "SystemUser",
                column: "Fk_ControlLevel");

            migrationBuilder.AddForeignKey(
                name: "FK_SystemUser_ControlLevel_Fk_ControlLevel",
                table: "SystemUser",
                column: "Fk_ControlLevel",
                principalTable: "ControlLevel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SystemUser_ControlLevel_Fk_ControlLevel",
                table: "SystemUser");

            migrationBuilder.DropIndex(
                name: "IX_SystemUser_Fk_ControlLevel",
                table: "SystemUser");

            migrationBuilder.DropColumn(
                name: "Fk_ControlLevel",
                table: "SystemUser");

            migrationBuilder.AddColumn<int>(
                name: "Fk_ControlLevel",
                table: "SystemUserPermission",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AccessLevel",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2020, 5, 17, 11, 37, 27, 706, DateTimeKind.Unspecified).AddTicks(9482), new DateTime(2020, 5, 17, 11, 37, 27, 706, DateTimeKind.Unspecified).AddTicks(9512) });

            migrationBuilder.UpdateData(
                table: "AccessLevel",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2020, 5, 17, 11, 37, 27, 707, DateTimeKind.Unspecified).AddTicks(19), new DateTime(2020, 5, 17, 11, 37, 27, 707, DateTimeKind.Unspecified).AddTicks(39) });

            migrationBuilder.UpdateData(
                table: "AccessLevel",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2020, 5, 17, 11, 37, 27, 707, DateTimeKind.Unspecified).AddTicks(65), new DateTime(2020, 5, 17, 11, 37, 27, 707, DateTimeKind.Unspecified).AddTicks(71) });

            migrationBuilder.UpdateData(
                table: "AppStaticMessage",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2020, 5, 17, 11, 37, 27, 701, DateTimeKind.Unspecified).AddTicks(6895), new DateTime(2020, 5, 17, 11, 37, 27, 705, DateTimeKind.Unspecified).AddTicks(774) });

            migrationBuilder.UpdateData(
                table: "AppStaticMessage",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2020, 5, 17, 11, 37, 27, 705, DateTimeKind.Unspecified).AddTicks(3707), new DateTime(2020, 5, 17, 11, 37, 27, 705, DateTimeKind.Unspecified).AddTicks(3712) });

            migrationBuilder.UpdateData(
                table: "AppStaticMessage",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2020, 5, 17, 11, 37, 27, 705, DateTimeKind.Unspecified).AddTicks(3697), new DateTime(2020, 5, 17, 11, 37, 27, 705, DateTimeKind.Unspecified).AddTicks(3702) });

            migrationBuilder.UpdateData(
                table: "AppStaticMessage",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2020, 5, 17, 11, 37, 27, 705, DateTimeKind.Unspecified).AddTicks(3556), new DateTime(2020, 5, 17, 11, 37, 27, 705, DateTimeKind.Unspecified).AddTicks(3562) });

            migrationBuilder.UpdateData(
                table: "AppStaticMessage",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2020, 5, 17, 11, 37, 27, 705, DateTimeKind.Unspecified).AddTicks(3589), new DateTime(2020, 5, 17, 11, 37, 27, 705, DateTimeKind.Unspecified).AddTicks(3594) });

            migrationBuilder.UpdateData(
                table: "AppStaticMessage",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2020, 5, 17, 11, 37, 27, 705, DateTimeKind.Unspecified).AddTicks(3579), new DateTime(2020, 5, 17, 11, 37, 27, 705, DateTimeKind.Unspecified).AddTicks(3584) });

            migrationBuilder.UpdateData(
                table: "AppStaticMessage",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2020, 5, 17, 11, 37, 27, 705, DateTimeKind.Unspecified).AddTicks(3568), new DateTime(2020, 5, 17, 11, 37, 27, 705, DateTimeKind.Unspecified).AddTicks(3573) });

            migrationBuilder.UpdateData(
                table: "AppStaticMessage",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2020, 5, 17, 11, 37, 27, 705, DateTimeKind.Unspecified).AddTicks(3685), new DateTime(2020, 5, 17, 11, 37, 27, 705, DateTimeKind.Unspecified).AddTicks(3691) });

            migrationBuilder.UpdateData(
                table: "AppStaticMessage",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2020, 5, 17, 11, 37, 27, 705, DateTimeKind.Unspecified).AddTicks(3468), new DateTime(2020, 5, 17, 11, 37, 27, 705, DateTimeKind.Unspecified).AddTicks(3496) });

            migrationBuilder.UpdateData(
                table: "ControlLevel",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2020, 5, 17, 11, 37, 27, 707, DateTimeKind.Unspecified).AddTicks(731), new DateTime(2020, 5, 17, 11, 37, 27, 707, DateTimeKind.Unspecified).AddTicks(752) });

            migrationBuilder.UpdateData(
                table: "ControlLevel",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2020, 5, 17, 11, 37, 27, 707, DateTimeKind.Unspecified).AddTicks(1408), new DateTime(2020, 5, 17, 11, 37, 27, 707, DateTimeKind.Unspecified).AddTicks(1430) });

            migrationBuilder.UpdateData(
                table: "Language",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2020, 5, 17, 11, 37, 27, 706, DateTimeKind.Unspecified).AddTicks(7658), new DateTime(2020, 5, 17, 11, 37, 27, 706, DateTimeKind.Unspecified).AddTicks(7701) });

            migrationBuilder.UpdateData(
                table: "Language",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2020, 5, 17, 11, 37, 27, 706, DateTimeKind.Unspecified).AddTicks(8249), new DateTime(2020, 5, 17, 11, 37, 27, 706, DateTimeKind.Unspecified).AddTicks(8273) });

            migrationBuilder.UpdateData(
                table: "SystemUser",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LastModifiedAt", "Password" },
                values: new object[] { new DateTime(2020, 5, 17, 11, 37, 27, 707, DateTimeKind.Unspecified).AddTicks(3468), new DateTime(2020, 5, 17, 11, 37, 27, 707, DateTimeKind.Unspecified).AddTicks(3490), "dbsh2398xr" });

            migrationBuilder.UpdateData(
                table: "SystemUserPermission",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Fk_ControlLevel", "LastModifiedAt" },
                values: new object[] { new DateTime(2020, 5, 17, 11, 37, 27, 708, DateTimeKind.Unspecified).AddTicks(1583), 1, new DateTime(2020, 5, 17, 11, 37, 27, 708, DateTimeKind.Unspecified).AddTicks(1616) });

            migrationBuilder.UpdateData(
                table: "SystemUserPermission",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "Fk_ControlLevel", "LastModifiedAt" },
                values: new object[] { new DateTime(2020, 5, 17, 11, 37, 27, 708, DateTimeKind.Unspecified).AddTicks(3115), 1, new DateTime(2020, 5, 17, 11, 37, 27, 708, DateTimeKind.Unspecified).AddTicks(3137) });

            migrationBuilder.UpdateData(
                table: "SystemUserPermission",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "Fk_ControlLevel", "LastModifiedAt" },
                values: new object[] { new DateTime(2020, 5, 17, 11, 37, 27, 708, DateTimeKind.Unspecified).AddTicks(3184), 1, new DateTime(2020, 5, 17, 11, 37, 27, 708, DateTimeKind.Unspecified).AddTicks(3190) });

            migrationBuilder.UpdateData(
                table: "SystemView",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2020, 5, 17, 11, 37, 27, 707, DateTimeKind.Unspecified).AddTicks(2251), new DateTime(2020, 5, 17, 11, 37, 27, 707, DateTimeKind.Unspecified).AddTicks(2272) });

            migrationBuilder.UpdateData(
                table: "SystemView",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2020, 5, 17, 11, 37, 27, 707, DateTimeKind.Unspecified).AddTicks(2728), new DateTime(2020, 5, 17, 11, 37, 27, 707, DateTimeKind.Unspecified).AddTicks(2749) });

            migrationBuilder.UpdateData(
                table: "SystemView",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2020, 5, 17, 11, 37, 27, 707, DateTimeKind.Unspecified).AddTicks(2764), new DateTime(2020, 5, 17, 11, 37, 27, 707, DateTimeKind.Unspecified).AddTicks(2770) });

            migrationBuilder.CreateIndex(
                name: "IX_SystemUserPermission_Fk_ControlLevel",
                table: "SystemUserPermission",
                column: "Fk_ControlLevel");

            migrationBuilder.AddForeignKey(
                name: "FK_SystemUserPermission_ControlLevel_Fk_ControlLevel",
                table: "SystemUserPermission",
                column: "Fk_ControlLevel",
                principalTable: "ControlLevel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
