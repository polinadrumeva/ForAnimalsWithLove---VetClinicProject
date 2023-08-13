using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ForAnimalsWithLove.Data.Migrations
{
    public partial class DeleteAmountColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Amount",
                table: "HospitalRecords");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "Operations",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 8, 13, 13, 36, 28, 917, DateTimeKind.Utc).AddTicks(6838),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 8, 13, 9, 50, 38, 375, DateTimeKind.Utc).AddTicks(6632));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "Operations",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 8, 13, 9, 50, 38, 375, DateTimeKind.Utc).AddTicks(6632),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 8, 13, 13, 36, 28, 917, DateTimeKind.Utc).AddTicks(6838));

            migrationBuilder.AddColumn<decimal>(
                name: "Amount",
                table: "HospitalRecords",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
