using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ForAnimalsWithLove.Data.Migrations
{
    public partial class SetNullableHealth : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "Operations",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 8, 18, 18, 51, 39, 129, DateTimeKind.Utc).AddTicks(9430),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 8, 18, 11, 38, 0, 337, DateTimeKind.Utc).AddTicks(1659));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "Operations",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 8, 18, 11, 38, 0, 337, DateTimeKind.Utc).AddTicks(1659),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 8, 18, 18, 51, 39, 129, DateTimeKind.Utc).AddTicks(9430));
        }
    }
}
