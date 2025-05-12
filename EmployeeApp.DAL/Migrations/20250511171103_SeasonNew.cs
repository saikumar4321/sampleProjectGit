using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmployeeApp.DAL.Migrations
{
    /// <inheritdoc />
    public partial class SeasonNew : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
               name: "Season_Master",
               columns: table => new
               {
                   Id = table.Column<int>(type: "int", nullable: false)
                       .Annotation("SqlServer:Identity", "1, 1"),
                   Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
               },
               constraints: table =>
               {
                   table.PrimaryKey("PK_Season_Master", x => x.Id);
               });

            migrationBuilder.CreateTable(
                name: "CropMaster",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CropName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SeasonId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CropMaster", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CropMaster_Season_Master_SeasonId",
                        column: x => x.SeasonId,
                        principalTable: "Season_Master",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductMaster",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CropId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductMaster", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ProductMaster_CropMaster_CropId",
                        column: x => x.CropId,
                        principalTable: "CropMaster",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CropMaster_SeasonId",
                table: "CropMaster",
                column: "SeasonId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductMaster_CropId",
                table: "ProductMaster",
                column: "CropId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
