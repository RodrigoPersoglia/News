using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AccesData.Migrations
{
    /// <inheritdoc />
    public partial class NoticiaTag : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Map_Noticia_Tag");

            migrationBuilder.CreateTable(
                name: "NoticiaTag",
                columns: table => new
                {
                    NoticiaId = table.Column<int>(type: "int", nullable: false),
                    TagId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NoticiaTag", x => new { x.NoticiaId, x.TagId });
                    table.ForeignKey(
                        name: "FK_NoticiaTag_Noticia_NoticiaId",
                        column: x => x.NoticiaId,
                        principalTable: "Noticia",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NoticiaTag_Tag_TagId",
                        column: x => x.TagId,
                        principalTable: "Tag",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_NoticiaTag_TagId",
                table: "NoticiaTag",
                column: "TagId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NoticiaTag");

            migrationBuilder.CreateTable(
                name: "Map_Noticia_Tag",
                columns: table => new
                {
                    NoticiaId = table.Column<int>(type: "int", nullable: false),
                    TagId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Map_Noticia_Tag", x => new { x.NoticiaId, x.TagId });
                    table.ForeignKey(
                        name: "FK_Map_Noticia_Tag_Noticia_NoticiaId",
                        column: x => x.NoticiaId,
                        principalTable: "Noticia",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Map_Noticia_Tag_Tag_TagId",
                        column: x => x.TagId,
                        principalTable: "Tag",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Map_Noticia_Tag_TagId",
                table: "Map_Noticia_Tag",
                column: "TagId");
        }
    }
}
