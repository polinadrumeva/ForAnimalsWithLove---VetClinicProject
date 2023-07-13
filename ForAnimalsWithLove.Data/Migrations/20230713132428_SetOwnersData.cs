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
                defaultValue: new DateTime(2023, 7, 13, 13, 24, 28, 385, DateTimeKind.Utc).AddTicks(2621),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 7, 10, 12, 41, 18, 47, DateTimeKind.Utc).AddTicks(2998));

            migrationBuilder.InsertData(
                table: "Owners",
                columns: new[] { "Id", "Address", "FirstName", "LastName", "MiddleName", "PhoneNumber" },
                values: new object[,]
                {
                    { new Guid("0f11b794-81b6-43e6-9df1-effe0c0f2242"), "Елин Пелин", "Стефан", "Петров", "Петров", "0989775680" },
                    { new Guid("1c664a30-3005-4a57-ac26-cded33ca9bd2"), "София", "Красимир", "Иванов", "Недялков", "0898268776" },
                    { new Guid("296f4d7a-8cf3-4975-b06d-fb79310fd04b"), "Ихтиман", "Марияна", "Иванова", "Георгиева", "0834772389" },
                    { new Guid("48e29fba-6797-483c-b38b-a718ff17f0d8"), "София", "Марин", "Велев", null, "098977283" },
                    { new Guid("48e9c90c-dd32-4c5d-9406-df940ec29a5f"), "София", "Станимир", "Хаджиев", null, "0898322211" },
                    { new Guid("4aa4a55b-7d71-4620-aa58-e019689518b9"), "Дупница", "Мария", "Кръстева", null, "0887334785" },
                    { new Guid("4c0ae8fc-8a1f-41b6-a039-d132bb3d8fa7"), "София", "Валентина", "Дюрова", null, "0885666218" },
                    { new Guid("4e34be8d-1762-4a0a-99d3-891310acdb0e"), "Дупница", "Галина", "Кръстева", "Недева", "0878611282" },
                    { new Guid("52c95f15-b276-4fed-86ac-75f8a8d89c96"), "Тетевен", "Ивета", "Манолова", null, "072826786" },
                    { new Guid("625c39b4-d085-4b06-bb0b-b5ac413ef2fd"), "Велико Търново", "Полина", "Друмева", null, "0878644619" },
                    { new Guid("823510a7-981e-4618-b75f-3ac3010aa54d"), "София", "Симона", "Иванова", null, "0885565213" },
                    { new Guid("94b4f8e2-1725-47a9-9dea-f1c592c8318a"), "София", "Росица", "Маринова", null, "0878221112" },
                    { new Guid("cd4f36ca-ded5-48e2-9d24-37dadbb87661"), "София", "Магдалена", "Иванова", null, "0887721356" },
                    { new Guid("e2239b43-afda-48c3-b90c-a54a8ee99ec8"), "София", "Мария", "Петрова", null, "0884788900" },
                    { new Guid("e4fb4934-7762-4318-a73f-cddb10f1176f"), "София", "Иван", "Валентинов", null, "0886755349" },
                    { new Guid("e803708f-6fdc-4993-bfd5-c8b5e2404504"), "София", "Йоанна", "Здравкова", null, "0888672662" },
                    { new Guid("eb0827fa-2479-4b76-b272-d7ebdca7670c"), "Самоков", "Деница", "Иванова", "Иванова", "0898217888" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Owners",
                keyColumn: "Id",
                keyValue: new Guid("0f11b794-81b6-43e6-9df1-effe0c0f2242"));

            migrationBuilder.DeleteData(
                table: "Owners",
                keyColumn: "Id",
                keyValue: new Guid("1c664a30-3005-4a57-ac26-cded33ca9bd2"));

            migrationBuilder.DeleteData(
                table: "Owners",
                keyColumn: "Id",
                keyValue: new Guid("296f4d7a-8cf3-4975-b06d-fb79310fd04b"));

            migrationBuilder.DeleteData(
                table: "Owners",
                keyColumn: "Id",
                keyValue: new Guid("48e29fba-6797-483c-b38b-a718ff17f0d8"));

            migrationBuilder.DeleteData(
                table: "Owners",
                keyColumn: "Id",
                keyValue: new Guid("48e9c90c-dd32-4c5d-9406-df940ec29a5f"));

            migrationBuilder.DeleteData(
                table: "Owners",
                keyColumn: "Id",
                keyValue: new Guid("4aa4a55b-7d71-4620-aa58-e019689518b9"));

            migrationBuilder.DeleteData(
                table: "Owners",
                keyColumn: "Id",
                keyValue: new Guid("4c0ae8fc-8a1f-41b6-a039-d132bb3d8fa7"));

            migrationBuilder.DeleteData(
                table: "Owners",
                keyColumn: "Id",
                keyValue: new Guid("4e34be8d-1762-4a0a-99d3-891310acdb0e"));

            migrationBuilder.DeleteData(
                table: "Owners",
                keyColumn: "Id",
                keyValue: new Guid("52c95f15-b276-4fed-86ac-75f8a8d89c96"));

            migrationBuilder.DeleteData(
                table: "Owners",
                keyColumn: "Id",
                keyValue: new Guid("625c39b4-d085-4b06-bb0b-b5ac413ef2fd"));

            migrationBuilder.DeleteData(
                table: "Owners",
                keyColumn: "Id",
                keyValue: new Guid("823510a7-981e-4618-b75f-3ac3010aa54d"));

            migrationBuilder.DeleteData(
                table: "Owners",
                keyColumn: "Id",
                keyValue: new Guid("94b4f8e2-1725-47a9-9dea-f1c592c8318a"));

            migrationBuilder.DeleteData(
                table: "Owners",
                keyColumn: "Id",
                keyValue: new Guid("cd4f36ca-ded5-48e2-9d24-37dadbb87661"));

            migrationBuilder.DeleteData(
                table: "Owners",
                keyColumn: "Id",
                keyValue: new Guid("e2239b43-afda-48c3-b90c-a54a8ee99ec8"));

            migrationBuilder.DeleteData(
                table: "Owners",
                keyColumn: "Id",
                keyValue: new Guid("e4fb4934-7762-4318-a73f-cddb10f1176f"));

            migrationBuilder.DeleteData(
                table: "Owners",
                keyColumn: "Id",
                keyValue: new Guid("e803708f-6fdc-4993-bfd5-c8b5e2404504"));

            migrationBuilder.DeleteData(
                table: "Owners",
                keyColumn: "Id",
                keyValue: new Guid("eb0827fa-2479-4b76-b272-d7ebdca7670c"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "Operations",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 10, 12, 41, 18, 47, DateTimeKind.Utc).AddTicks(2998),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 7, 13, 13, 24, 28, 385, DateTimeKind.Utc).AddTicks(2621));
        }
    }
}
