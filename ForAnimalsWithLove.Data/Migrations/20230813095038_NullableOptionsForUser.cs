using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ForAnimalsWithLove.Data.Migrations
{
    public partial class NullableOptionsForUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Doctors_AspNetUsers_UserId",
                table: "Doctors");

            migrationBuilder.DropForeignKey(
                name: "FK_Owners_AspNetUsers_UserId",
                table: "Owners");

            migrationBuilder.DropForeignKey(
                name: "FK_Trainers_AspNetUsers_UserId",
                table: "Trainers");

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "Trainers",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "Owners",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "Operations",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 8, 13, 9, 50, 38, 375, DateTimeKind.Utc).AddTicks(6632),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 8, 13, 8, 14, 7, 983, DateTimeKind.Utc).AddTicks(8379));

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "Doctors",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_Doctors_AspNetUsers_UserId",
                table: "Doctors",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Owners_AspNetUsers_UserId",
                table: "Owners",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Trainers_AspNetUsers_UserId",
                table: "Trainers",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Doctors_AspNetUsers_UserId",
                table: "Doctors");

            migrationBuilder.DropForeignKey(
                name: "FK_Owners_AspNetUsers_UserId",
                table: "Owners");

            migrationBuilder.DropForeignKey(
                name: "FK_Trainers_AspNetUsers_UserId",
                table: "Trainers");

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "Trainers",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "Owners",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "Operations",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 8, 13, 8, 14, 7, 983, DateTimeKind.Utc).AddTicks(8379),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 8, 13, 9, 50, 38, 375, DateTimeKind.Utc).AddTicks(6632));

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "Doctors",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Doctors_AspNetUsers_UserId",
                table: "Doctors",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Owners_AspNetUsers_UserId",
                table: "Owners",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Trainers_AspNetUsers_UserId",
                table: "Trainers",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
