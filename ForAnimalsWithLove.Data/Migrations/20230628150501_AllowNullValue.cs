using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ForAnimalsWithLove.Migrations
{
    public partial class AllowNullValue : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HealthRecords_HospitalRecords_HospitalRecordId",
                table: "HealthRecords");

            migrationBuilder.AddForeignKey(
                name: "FK_HealthRecords_HospitalRecords_HospitalRecordId",
                table: "HealthRecords",
                column: "HospitalRecordId",
                principalTable: "HospitalRecords",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HealthRecords_HospitalRecords_HospitalRecordId",
                table: "HealthRecords");

            migrationBuilder.AddForeignKey(
                name: "FK_HealthRecords_HospitalRecords_HospitalRecordId",
                table: "HealthRecords",
                column: "HospitalRecordId",
                principalTable: "HospitalRecords",
                principalColumn: "Id");
        }
    }
}
