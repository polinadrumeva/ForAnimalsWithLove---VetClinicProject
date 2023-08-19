using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ForAnimalsWithLove.Data.Migrations
{
    public partial class SetFirstNameToApplicationUSer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "Operations",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 8, 19, 18, 37, 41, 792, DateTimeKind.Utc).AddTicks(7111),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 8, 19, 14, 14, 38, 196, DateTimeKind.Utc).AddTicks(8167));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "Operations",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 8, 19, 14, 14, 38, 196, DateTimeKind.Utc).AddTicks(8167),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 8, 19, 18, 37, 41, 792, DateTimeKind.Utc).AddTicks(7111));
        }
    }
}
