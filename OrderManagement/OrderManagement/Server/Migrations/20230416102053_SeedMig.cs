using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace OrderManagement.Server.Migrations
{
    /// <inheritdoc />
    public partial class SeedMig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "Order",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Window",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Window", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Window_Order_OrderId",
                        column: x => x.OrderId,
                        principalSchema: "dbo",
                        principalTable: "Order",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Subelement",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WindowId = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Width = table.Column<int>(type: "int", nullable: false),
                    Height = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subelement", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Subelement_Window_WindowId",
                        column: x => x.WindowId,
                        principalSchema: "dbo",
                        principalTable: "Window",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Order",
                columns: new[] { "Id", "Name", "State" },
                values: new object[,]
                {
                    { 1, "New York Building 1", "NY" },
                    { 2, "California Hotel AJK", "CA" }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Window",
                columns: new[] { "Id", "Name", "OrderId", "Quantity" },
                values: new object[,]
                {
                    { 1, "A51", 1, 4 },
                    { 2, "C Zone 5", 1, 2 },
                    { 3, "GLB", 2, 3 },
                    { 4, "OHF", 2, 10 }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Subelement",
                columns: new[] { "Id", "Height", "Type", "Width", "WindowId" },
                values: new object[,]
                {
                    { 1, 1850, "Doors", 1200, 1 },
                    { 2, 1850, "Window", 800, 1 },
                    { 3, 1850, "Window", 700, 1 },
                    { 4, 2000, "Window", 1500, 2 },
                    { 5, 2200, "Doors", 1400, 3 },
                    { 6, 2200, "Window", 600, 3 },
                    { 7, 2000, "Window", 1500, 4 },
                    { 8, 2000, "Window", 1500, 4 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Subelement_WindowId",
                schema: "dbo",
                table: "Subelement",
                column: "WindowId");

            migrationBuilder.CreateIndex(
                name: "IX_Window_OrderId",
                schema: "dbo",
                table: "Window",
                column: "OrderId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Subelement",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Window",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Order",
                schema: "dbo");
        }
    }
}
