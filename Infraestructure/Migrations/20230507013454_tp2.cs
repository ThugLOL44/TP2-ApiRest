using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class tp2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "Precio",
                table: "Mercaderia",
                type: "float",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<double>(
                name: "PrecioTotal",
                table: "Comanda",
                type: "float",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "Mercaderia",
                keyColumn: "MercaderiaId",
                keyValue: 1,
                column: "Precio",
                value: 600.0);

            migrationBuilder.UpdateData(
                table: "Mercaderia",
                keyColumn: "MercaderiaId",
                keyValue: 2,
                column: "Precio",
                value: 320.0);

            migrationBuilder.UpdateData(
                table: "Mercaderia",
                keyColumn: "MercaderiaId",
                keyValue: 3,
                column: "Precio",
                value: 1400.0);

            migrationBuilder.UpdateData(
                table: "Mercaderia",
                keyColumn: "MercaderiaId",
                keyValue: 4,
                column: "Precio",
                value: 1000.0);

            migrationBuilder.UpdateData(
                table: "Mercaderia",
                keyColumn: "MercaderiaId",
                keyValue: 5,
                column: "Precio",
                value: 1200.0);

            migrationBuilder.UpdateData(
                table: "Mercaderia",
                keyColumn: "MercaderiaId",
                keyValue: 6,
                column: "Precio",
                value: 1800.0);

            migrationBuilder.UpdateData(
                table: "Mercaderia",
                keyColumn: "MercaderiaId",
                keyValue: 7,
                column: "Precio",
                value: 2000.0);

            migrationBuilder.UpdateData(
                table: "Mercaderia",
                keyColumn: "MercaderiaId",
                keyValue: 8,
                column: "Precio",
                value: 600.0);

            migrationBuilder.UpdateData(
                table: "Mercaderia",
                keyColumn: "MercaderiaId",
                keyValue: 9,
                column: "Precio",
                value: 1500.0);

            migrationBuilder.UpdateData(
                table: "Mercaderia",
                keyColumn: "MercaderiaId",
                keyValue: 10,
                column: "Precio",
                value: 3400.0);

            migrationBuilder.UpdateData(
                table: "Mercaderia",
                keyColumn: "MercaderiaId",
                keyValue: 11,
                column: "Precio",
                value: 1000.0);

            migrationBuilder.UpdateData(
                table: "Mercaderia",
                keyColumn: "MercaderiaId",
                keyValue: 12,
                column: "Precio",
                value: 400.0);

            migrationBuilder.UpdateData(
                table: "Mercaderia",
                keyColumn: "MercaderiaId",
                keyValue: 13,
                column: "Precio",
                value: 1200.0);

            migrationBuilder.UpdateData(
                table: "Mercaderia",
                keyColumn: "MercaderiaId",
                keyValue: 14,
                column: "Precio",
                value: 1200.0);

            migrationBuilder.UpdateData(
                table: "Mercaderia",
                keyColumn: "MercaderiaId",
                keyValue: 15,
                column: "Precio",
                value: 600.0);

            migrationBuilder.UpdateData(
                table: "Mercaderia",
                keyColumn: "MercaderiaId",
                keyValue: 16,
                column: "Precio",
                value: 600.0);

            migrationBuilder.UpdateData(
                table: "Mercaderia",
                keyColumn: "MercaderiaId",
                keyValue: 17,
                column: "Precio",
                value: 1000.0);

            migrationBuilder.UpdateData(
                table: "Mercaderia",
                keyColumn: "MercaderiaId",
                keyValue: 18,
                column: "Precio",
                value: 1000.0);

            migrationBuilder.UpdateData(
                table: "Mercaderia",
                keyColumn: "MercaderiaId",
                keyValue: 19,
                column: "Precio",
                value: 1200.0);

            migrationBuilder.UpdateData(
                table: "Mercaderia",
                keyColumn: "MercaderiaId",
                keyValue: 20,
                column: "Precio",
                value: 1500.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Precio",
                table: "Mercaderia",
                type: "int",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<int>(
                name: "PrecioTotal",
                table: "Comanda",
                type: "int",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.UpdateData(
                table: "Mercaderia",
                keyColumn: "MercaderiaId",
                keyValue: 1,
                column: "Precio",
                value: 600);

            migrationBuilder.UpdateData(
                table: "Mercaderia",
                keyColumn: "MercaderiaId",
                keyValue: 2,
                column: "Precio",
                value: 320);

            migrationBuilder.UpdateData(
                table: "Mercaderia",
                keyColumn: "MercaderiaId",
                keyValue: 3,
                column: "Precio",
                value: 1400);

            migrationBuilder.UpdateData(
                table: "Mercaderia",
                keyColumn: "MercaderiaId",
                keyValue: 4,
                column: "Precio",
                value: 1000);

            migrationBuilder.UpdateData(
                table: "Mercaderia",
                keyColumn: "MercaderiaId",
                keyValue: 5,
                column: "Precio",
                value: 1200);

            migrationBuilder.UpdateData(
                table: "Mercaderia",
                keyColumn: "MercaderiaId",
                keyValue: 6,
                column: "Precio",
                value: 1800);

            migrationBuilder.UpdateData(
                table: "Mercaderia",
                keyColumn: "MercaderiaId",
                keyValue: 7,
                column: "Precio",
                value: 2000);

            migrationBuilder.UpdateData(
                table: "Mercaderia",
                keyColumn: "MercaderiaId",
                keyValue: 8,
                column: "Precio",
                value: 600);

            migrationBuilder.UpdateData(
                table: "Mercaderia",
                keyColumn: "MercaderiaId",
                keyValue: 9,
                column: "Precio",
                value: 1500);

            migrationBuilder.UpdateData(
                table: "Mercaderia",
                keyColumn: "MercaderiaId",
                keyValue: 10,
                column: "Precio",
                value: 3400);

            migrationBuilder.UpdateData(
                table: "Mercaderia",
                keyColumn: "MercaderiaId",
                keyValue: 11,
                column: "Precio",
                value: 1000);

            migrationBuilder.UpdateData(
                table: "Mercaderia",
                keyColumn: "MercaderiaId",
                keyValue: 12,
                column: "Precio",
                value: 400);

            migrationBuilder.UpdateData(
                table: "Mercaderia",
                keyColumn: "MercaderiaId",
                keyValue: 13,
                column: "Precio",
                value: 1200);

            migrationBuilder.UpdateData(
                table: "Mercaderia",
                keyColumn: "MercaderiaId",
                keyValue: 14,
                column: "Precio",
                value: 1200);

            migrationBuilder.UpdateData(
                table: "Mercaderia",
                keyColumn: "MercaderiaId",
                keyValue: 15,
                column: "Precio",
                value: 600);

            migrationBuilder.UpdateData(
                table: "Mercaderia",
                keyColumn: "MercaderiaId",
                keyValue: 16,
                column: "Precio",
                value: 600);

            migrationBuilder.UpdateData(
                table: "Mercaderia",
                keyColumn: "MercaderiaId",
                keyValue: 17,
                column: "Precio",
                value: 1000);

            migrationBuilder.UpdateData(
                table: "Mercaderia",
                keyColumn: "MercaderiaId",
                keyValue: 18,
                column: "Precio",
                value: 1000);

            migrationBuilder.UpdateData(
                table: "Mercaderia",
                keyColumn: "MercaderiaId",
                keyValue: 19,
                column: "Precio",
                value: 1200);

            migrationBuilder.UpdateData(
                table: "Mercaderia",
                keyColumn: "MercaderiaId",
                keyValue: 20,
                column: "Precio",
                value: 1500);
        }
    }
}
