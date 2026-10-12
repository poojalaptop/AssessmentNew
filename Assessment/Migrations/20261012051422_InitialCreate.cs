using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Assessment.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Units",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Symbol = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Factor = table.Column<double>(type: "float", nullable: false),
                    Offset = table.Column<double>(type: "float", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Units", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Units_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Length" },
                    { 2, "Weight" },
                    { 3, "Temperature" },
                    { 4, "Volume" }
                });

            migrationBuilder.InsertData(
                table: "Units",
                columns: new[] { "Id", "CategoryId", "Factor", "Name", "Offset", "Symbol" },
                values: new object[,]
                {
                    { 1, 1, 1.0, "Meter", 0.0, "m" },
                    { 2, 1, 1000.0, "Kilometer", 0.0, "km" },
                    { 3, 1, 0.01, "Centimeter", 0.0, "cm" },
                    { 4, 1, 0.001, "Millimeter", 0.0, "mm" },
                    { 5, 1, 1609.3440000000001, "Mile", 0.0, "mi" },
                    { 6, 1, 0.91439999999999999, "Yard", 0.0, "yd" },
                    { 7, 1, 0.30480000000000002, "Foot", 0.0, "ft" },
                    { 8, 1, 0.025399999999999999, "Inch", 0.0, "in" },
                    { 9, 2, 1.0, "Kilogram", 0.0, "kg" },
                    { 10, 2, 0.001, "Gram", 0.0, "g" },
                    { 11, 2, 9.9999999999999995E-07, "Milligram", 0.0, "mg" },
                    { 12, 2, 1000.0, "Tonne", 0.0, "t" },
                    { 13, 2, 0.45359237000000002, "Pound", 0.0, "lb" },
                    { 14, 2, 0.028349523125000001, "Ounce", 0.0, "oz" },
                    { 15, 3, 1.0, "Kelvin", 0.0, "K" },
                    { 16, 3, 1.0, "Celsius", 273.14999999999998, "C" },
                    { 17, 3, 0.55555555555555558, "Fahrenheit", 459.67000000000002, "F" },
                    { 18, 4, 1.0, "Liter", 0.0, "L" },
                    { 19, 4, 0.001, "Milliliter", 0.0, "mL" },
                    { 20, 4, 1000.0, "Cubic meter", 0.0, "m3" },
                    { 21, 4, 3.7854117839999999, "US Gallon", 0.0, "gal" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Units_CategoryId",
                table: "Units",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Units_Symbol",
                table: "Units",
                column: "Symbol",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Units");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
