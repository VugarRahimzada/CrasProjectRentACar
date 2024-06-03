using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class cofiguration_fixed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Cars_CarId1",
                table: "Bookings");

            migrationBuilder.DropForeignKey(
                name: "FK_Cars_Bodys_BodyId1",
                table: "Cars");

            migrationBuilder.DropForeignKey(
                name: "FK_Cars_Brands_BrandId1",
                table: "Cars");

            migrationBuilder.DropForeignKey(
                name: "FK_Cars_Doors_DoorId1",
                table: "Cars");

            migrationBuilder.DropForeignKey(
                name: "FK_Cars_Fuels_FuelId1",
                table: "Cars");

            migrationBuilder.DropForeignKey(
                name: "FK_Cars_Transmissions_TransmissionId1",
                table: "Cars");

            migrationBuilder.DropIndex(
                name: "IX_Cars_BodyId1",
                table: "Cars");

            migrationBuilder.DropIndex(
                name: "IX_Cars_BrandId1",
                table: "Cars");

            migrationBuilder.DropIndex(
                name: "IX_Cars_DoorId1",
                table: "Cars");

            migrationBuilder.DropIndex(
                name: "IX_Cars_FuelId1",
                table: "Cars");

            migrationBuilder.DropIndex(
                name: "IX_Cars_TransmissionId1",
                table: "Cars");

            migrationBuilder.DropIndex(
                name: "IX_Bookings_CarId1",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "BodyId1",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "BrandId1",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "DoorId1",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "FuelId1",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "TransmissionId1",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "CarId1",
                table: "Bookings");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BodyId1",
                table: "Cars",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BrandId1",
                table: "Cars",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DoorId1",
                table: "Cars",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FuelId1",
                table: "Cars",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TransmissionId1",
                table: "Cars",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CarId1",
                table: "Bookings",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cars_BodyId1",
                table: "Cars",
                column: "BodyId1");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_BrandId1",
                table: "Cars",
                column: "BrandId1");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_DoorId1",
                table: "Cars",
                column: "DoorId1");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_FuelId1",
                table: "Cars",
                column: "FuelId1");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_TransmissionId1",
                table: "Cars",
                column: "TransmissionId1");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_CarId1",
                table: "Bookings",
                column: "CarId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Cars_CarId1",
                table: "Bookings",
                column: "CarId1",
                principalTable: "Cars",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_Bodys_BodyId1",
                table: "Cars",
                column: "BodyId1",
                principalTable: "Bodys",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_Brands_BrandId1",
                table: "Cars",
                column: "BrandId1",
                principalTable: "Brands",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_Doors_DoorId1",
                table: "Cars",
                column: "DoorId1",
                principalTable: "Doors",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_Fuels_FuelId1",
                table: "Cars",
                column: "FuelId1",
                principalTable: "Fuels",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_Transmissions_TransmissionId1",
                table: "Cars",
                column: "TransmissionId1",
                principalTable: "Transmissions",
                principalColumn: "Id");
        }
    }
}
