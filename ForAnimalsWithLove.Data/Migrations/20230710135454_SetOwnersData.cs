using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ForAnimalsWithLove.Data.Migrations
{
    public partial class SetOwnersData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "Operations",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 10, 13, 54, 53, 791, DateTimeKind.Utc).AddTicks(119),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 7, 10, 12, 41, 18, 47, DateTimeKind.Utc).AddTicks(2998));

            migrationBuilder.InsertData(
                table: "Owners",
                columns: new[] { "Id", "Address", "FirstName", "LastName", "MiddleName", "PhoneNumber" },
                values: new object[,]
                {
                    { new Guid("251cff84-1067-447f-88e1-071fd802ed16"), "Самоков", "Деница", "Иванова", "Иванова", "0898217888" },
                    { new Guid("3cfb5f9a-d5aa-4949-8037-a1956061430f"), "София", "Росица", "Маринова", null, "0878221112" },
                    { new Guid("5a59a1c0-dc04-4af1-84d5-f9fe623c6068"), "София", "Симона", "Иванова", null, "0885565213" },
                    { new Guid("61d265a4-4a0a-4d49-b6df-2a68f9a6dde7"), "Дупница", "Мария", "Кръстева", null, "0887334785" },
                    { new Guid("647f35a8-87e5-455b-a233-30e835e70aa2"), "София", "Иван", "Валентинов", null, "0886755349" },
                    { new Guid("75378afe-3b3a-4a31-ab4e-5bc9671cdc28"), "Тетевен", "Ивета", "Манолова", null, "072826786" },
                    { new Guid("7867b0c8-a1c7-41bc-b783-764336b04ed6"), "София", "Йоанна", "Здравкова", null, "0888672662" },
                    { new Guid("82853a05-7f15-4636-86a2-8c08cd400baf"), "София", "Мария", "Петрова", null, "0884788900" },
                    { new Guid("840ea3f5-6147-4535-a2e9-5a2d696a56d5"), "София", "Валентина", "Дюрова", null, "0885666218" },
                    { new Guid("96cf5fa4-b230-4c7a-802f-dea17a7a229c"), "София", "Марин", "Велев", null, "098977283" },
                    { new Guid("a69e4ee8-70be-487c-bc89-a539265aa4c0"), "София", "Магдалена", "Иванова", null, "0887721356" },
                    { new Guid("abe0f2e6-17f3-428d-b7ea-cc3ef2b855cd"), "Елин Пелин", "Стефан", "Петров", "Петров", "0989775680" },
                    { new Guid("c3356b8f-8570-428b-8e79-0a09975d947d"), "Велико Търново", "Полина", "Друмева", null, "0878644619" },
                    { new Guid("d0381673-62b4-4298-b47d-a489e1cd12c0"), "Ихтиман", "Марияна", "Иванова", "Георгиева", "0834772389" },
                    { new Guid("d4e17efd-c288-4535-99f7-3dce589e7602"), "Дупница", "Галина", "Кръстева", "Недева", "0878611282" },
                    { new Guid("f4c4a26e-3dab-4bd7-9ab7-f5aafc78b0fb"), "София", "Станимир", "Хаджиев", null, "0898322211" },
                    { new Guid("fa4970ab-2221-404a-9afb-a976d210dcbb"), "София", "Красимир", "Иванов", "Недялков", "0898268776" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Owners",
                keyColumn: "Id",
                keyValue: new Guid("251cff84-1067-447f-88e1-071fd802ed16"));

            migrationBuilder.DeleteData(
                table: "Owners",
                keyColumn: "Id",
                keyValue: new Guid("3cfb5f9a-d5aa-4949-8037-a1956061430f"));

            migrationBuilder.DeleteData(
                table: "Owners",
                keyColumn: "Id",
                keyValue: new Guid("5a59a1c0-dc04-4af1-84d5-f9fe623c6068"));

            migrationBuilder.DeleteData(
                table: "Owners",
                keyColumn: "Id",
                keyValue: new Guid("61d265a4-4a0a-4d49-b6df-2a68f9a6dde7"));

            migrationBuilder.DeleteData(
                table: "Owners",
                keyColumn: "Id",
                keyValue: new Guid("647f35a8-87e5-455b-a233-30e835e70aa2"));

            migrationBuilder.DeleteData(
                table: "Owners",
                keyColumn: "Id",
                keyValue: new Guid("75378afe-3b3a-4a31-ab4e-5bc9671cdc28"));

            migrationBuilder.DeleteData(
                table: "Owners",
                keyColumn: "Id",
                keyValue: new Guid("7867b0c8-a1c7-41bc-b783-764336b04ed6"));

            migrationBuilder.DeleteData(
                table: "Owners",
                keyColumn: "Id",
                keyValue: new Guid("82853a05-7f15-4636-86a2-8c08cd400baf"));

            migrationBuilder.DeleteData(
                table: "Owners",
                keyColumn: "Id",
                keyValue: new Guid("840ea3f5-6147-4535-a2e9-5a2d696a56d5"));

            migrationBuilder.DeleteData(
                table: "Owners",
                keyColumn: "Id",
                keyValue: new Guid("96cf5fa4-b230-4c7a-802f-dea17a7a229c"));

            migrationBuilder.DeleteData(
                table: "Owners",
                keyColumn: "Id",
                keyValue: new Guid("a69e4ee8-70be-487c-bc89-a539265aa4c0"));

            migrationBuilder.DeleteData(
                table: "Owners",
                keyColumn: "Id",
                keyValue: new Guid("abe0f2e6-17f3-428d-b7ea-cc3ef2b855cd"));

            migrationBuilder.DeleteData(
                table: "Owners",
                keyColumn: "Id",
                keyValue: new Guid("c3356b8f-8570-428b-8e79-0a09975d947d"));

            migrationBuilder.DeleteData(
                table: "Owners",
                keyColumn: "Id",
                keyValue: new Guid("d0381673-62b4-4298-b47d-a489e1cd12c0"));

            migrationBuilder.DeleteData(
                table: "Owners",
                keyColumn: "Id",
                keyValue: new Guid("d4e17efd-c288-4535-99f7-3dce589e7602"));

            migrationBuilder.DeleteData(
                table: "Owners",
                keyColumn: "Id",
                keyValue: new Guid("f4c4a26e-3dab-4bd7-9ab7-f5aafc78b0fb"));

            migrationBuilder.DeleteData(
                table: "Owners",
                keyColumn: "Id",
                keyValue: new Guid("fa4970ab-2221-404a-9afb-a976d210dcbb"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "Operations",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 10, 12, 41, 18, 47, DateTimeKind.Utc).AddTicks(2998),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 7, 10, 13, 54, 53, 791, DateTimeKind.Utc).AddTicks(119));
        }
    }
}
