using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ForAnimalsWithLove.Migrations
{
    public partial class AddNewEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HealthRecords_HospitalRecords_HospitalRecordId",
                table: "HealthRecords");

            migrationBuilder.DropIndex(
                name: "IX_HealthRecords_HospitalRecordId",
                table: "HealthRecords");

            migrationBuilder.CreateIndex(
                name: "IX_HospitalRecords_HealthRecordId",
                table: "HospitalRecords",
                column: "HealthRecordId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_HospitalRecords_HealthRecords_HealthRecordId",
                table: "HospitalRecords",
                column: "HealthRecordId",
                principalTable: "HealthRecords",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HospitalRecords_HealthRecords_HealthRecordId",
                table: "HospitalRecords");

            migrationBuilder.DropIndex(
                name: "IX_HospitalRecords_HealthRecordId",
                table: "HospitalRecords");

            migrationBuilder.CreateIndex(
                name: "IX_HealthRecords_HospitalRecordId",
                table: "HealthRecords",
                column: "HospitalRecordId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_HealthRecords_HospitalRecords_HospitalRecordId",
                table: "HealthRecords",
                column: "HospitalRecordId",
                principalTable: "HospitalRecords",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
