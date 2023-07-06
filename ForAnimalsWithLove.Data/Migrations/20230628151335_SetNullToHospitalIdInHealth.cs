using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ForAnimalsWithLove.Migrations
{
    public partial class SetNullToHospitalIdInHealth : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HealthRecords_HospitalRecords_HospitalRecordId",
                table: "HealthRecords");

            migrationBuilder.DropIndex(
                name: "IX_HealthRecords_HospitalRecordId",
                table: "HealthRecords");

            migrationBuilder.AlterColumn<int>(
                name: "HospitalRecordId",
                table: "HealthRecords",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HealthRecords_HospitalRecords_HospitalRecordId",
                table: "HealthRecords");

            migrationBuilder.DropIndex(
                name: "IX_HealthRecords_HospitalRecordId",
                table: "HealthRecords");

            migrationBuilder.AlterColumn<int>(
                name: "HospitalRecordId",
                table: "HealthRecords",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_HealthRecords_HospitalRecordId",
                table: "HealthRecords",
                column: "HospitalRecordId",
                unique: true,
                filter: "[HospitalRecordId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_HealthRecords_HospitalRecords_HospitalRecordId",
                table: "HealthRecords",
                column: "HospitalRecordId",
                principalTable: "HospitalRecords",
                principalColumn: "Id");
        }
    }
}
