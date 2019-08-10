using Microsoft.EntityFrameworkCore.Migrations;

namespace Underwater.Migrations
{
    public partial class AlterColumnTypeNumberAquarium : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Number",
                table: "Aquariums",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.UpdateData(
                table: "Aquariums",
                keyColumn: "AquariumId",
                keyValue: 1,
                column: "Number",
                value: "818 - 392 - 0763");

            migrationBuilder.UpdateData(
                table: "Aquariums",
                keyColumn: "AquariumId",
                keyValue: 2,
                column: "Number",
                value: "310 - 643 - 0965");

            migrationBuilder.UpdateData(
                table: "Aquariums",
                keyColumn: "AquariumId",
                keyValue: 3,
                column: "Number",
                value: "336 - 209 - 6822");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Number",
                table: "Aquariums",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Aquariums",
                keyColumn: "AquariumId",
                keyValue: 1,
                column: "Number",
                value: -337);

            migrationBuilder.UpdateData(
                table: "Aquariums",
                keyColumn: "AquariumId",
                keyValue: 2,
                column: "Number",
                value: -1298);

            migrationBuilder.UpdateData(
                table: "Aquariums",
                keyColumn: "AquariumId",
                keyValue: 3,
                column: "Number",
                value: -6695);
        }
    }
}
