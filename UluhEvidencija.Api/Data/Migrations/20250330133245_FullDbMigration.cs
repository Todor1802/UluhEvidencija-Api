using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UluhEvidencija.Api.Data.Migrations
{
    /// <inheritdoc />
    public partial class FullDbMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Author",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Biography = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nationality = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeathDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ProfilePhotoPath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatorId = table.Column<int>(type: "int", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EditorId = table.Column<int>(type: "int", nullable: true),
                    DateEdited = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Author", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Exhibition",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CoverImagePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    LocationID = table.Column<int>(type: "int", nullable: false),
                    CreatorId = table.Column<int>(type: "int", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EditorId = table.Column<int>(type: "int", nullable: true),
                    DateEdited = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exhibition", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Exhibition_Location_LocationID",
                        column: x => x.LocationID,
                        principalTable: "Location",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Format",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WidthCm = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    HeightCm = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreatorId = table.Column<int>(type: "int", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EditorId = table.Column<int>(type: "int", nullable: true),
                    DateEdited = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Format", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Technique",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatorId = table.Column<int>(type: "int", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EditorId = table.Column<int>(type: "int", nullable: true),
                    DateEdited = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Technique", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Painting",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false),
                    PhotoPath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AuthorID = table.Column<int>(type: "int", nullable: true),
                    TechniqueID = table.Column<int>(type: "int", nullable: true),
                    FormatID = table.Column<int>(type: "int", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatorId = table.Column<int>(type: "int", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EditorId = table.Column<int>(type: "int", nullable: true),
                    DateEdited = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Painting", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Painting_Author_AuthorID",
                        column: x => x.AuthorID,
                        principalTable: "Author",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Painting_Format_FormatID",
                        column: x => x.FormatID,
                        principalTable: "Format",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Painting_Technique_TechniqueID",
                        column: x => x.TechniqueID,
                        principalTable: "Technique",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "ExhibitionPainting",
                columns: table => new
                {
                    ExhibitionID = table.Column<int>(type: "int", nullable: false),
                    PaintingID = table.Column<int>(type: "int", nullable: false),
                    DisplayOrder = table.Column<int>(type: "int", nullable: true),
                    CreatorId = table.Column<int>(type: "int", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EditorId = table.Column<int>(type: "int", nullable: true),
                    DateEdited = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExhibitionPainting", x => new { x.ExhibitionID, x.PaintingID });
                    table.ForeignKey(
                        name: "FK_ExhibitionPainting_Exhibition_ExhibitionID",
                        column: x => x.ExhibitionID,
                        principalTable: "Exhibition",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExhibitionPainting_Painting_PaintingID",
                        column: x => x.PaintingID,
                        principalTable: "Painting",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Exhibition_LocationID",
                table: "Exhibition",
                column: "LocationID");

            migrationBuilder.CreateIndex(
                name: "IX_ExhibitionPainting_PaintingID",
                table: "ExhibitionPainting",
                column: "PaintingID");

            migrationBuilder.CreateIndex(
                name: "IX_Painting_AuthorID",
                table: "Painting",
                column: "AuthorID");

            migrationBuilder.CreateIndex(
                name: "IX_Painting_FormatID",
                table: "Painting",
                column: "FormatID");

            migrationBuilder.CreateIndex(
                name: "IX_Painting_TechniqueID",
                table: "Painting",
                column: "TechniqueID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExhibitionPainting");

            migrationBuilder.DropTable(
                name: "Exhibition");

            migrationBuilder.DropTable(
                name: "Painting");

            migrationBuilder.DropTable(
                name: "Author");

            migrationBuilder.DropTable(
                name: "Format");

            migrationBuilder.DropTable(
                name: "Technique");
        }
    }
}
