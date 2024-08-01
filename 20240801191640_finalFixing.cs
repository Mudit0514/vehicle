using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace vechicalManagement.Migrations
{
    /// <inheritdoc />
    public partial class finalFixing : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "VehicleId",
                table: "serviceRecords");

            migrationBuilder.AddColumn<string>(
                name: "vehicleName",
                table: "serviceRecords",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "vehicleName",
                table: "serviceRecords");

            migrationBuilder.AddColumn<int>(
                name: "VehicleId",
                table: "serviceRecords",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
