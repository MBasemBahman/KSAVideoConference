using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace KSAVideoConference.DAL.Migrations
{
    public partial class mkkkmk : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "UserContact",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "User",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "SystemView",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "SystemUserPermission",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "SystemUser",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "MemberType",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "Language",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "GroupMessage",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "GroupMember",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "Group",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "ControlLevel",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "AttachmentType",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "Attachment",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "AppStaticWordLang",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "AppStaticWord",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "AppStaticMessageLang",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "AppStaticMessage",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "AccessLevel",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "UserContact",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "User",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "SystemView",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "SystemUserPermission",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "SystemUser",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "MemberType",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "Language",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "GroupMessage",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "GroupMember",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "Group",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "ControlLevel",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "AttachmentType",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "Attachment",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "AppStaticWordLang",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "AppStaticWord",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "AppStaticMessageLang",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "AppStaticMessage",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "AccessLevel",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

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
    }
}
