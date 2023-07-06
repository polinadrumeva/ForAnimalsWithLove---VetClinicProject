using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ForAnimalsWithLove.Migrations
{
    public partial class AddFirstAnimal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Animals",
                columns: new[] { "Id", "Age", "Birthdate", "Breed", "Color", "DoesHasOwner", "GroomingId", "HealthRecordId", "KindOfAnimal", "Name", "OwnerId", "Photo", "SearchHomeId", "Sex" },
                values: new object[] { 1, 2, new DateTime(2022, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Сиамска", "Сив", true, 0, 1, "Котка", "Пешо", 1, "~/images/peshocat.jpg", null, "M" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Animals",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
