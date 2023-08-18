using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ForAnimalsWithLove.Data.Migrations
{
    public partial class SetNullableToHealthRecord : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "Operations",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 8, 18, 11, 38, 0, 337, DateTimeKind.Utc).AddTicks(1659),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 8, 16, 19, 52, 44, 556, DateTimeKind.Utc).AddTicks(9903));

            migrationBuilder.AlterColumn<Guid>(
                name: "HealthRecordId",
                table: "Animals",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "Operations",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 8, 16, 19, 52, 44, 556, DateTimeKind.Utc).AddTicks(9903),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 8, 18, 11, 38, 0, 337, DateTimeKind.Utc).AddTicks(1659));

            migrationBuilder.AlterColumn<Guid>(
                name: "HealthRecordId",
                table: "Animals",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);
        }
    }
}
