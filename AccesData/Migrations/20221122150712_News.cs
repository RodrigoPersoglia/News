using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AccesData.Migrations
{
    /// <inheritdoc />
    public partial class News : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categoria",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categoria", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tag",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tag", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false),
                    Foto = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Noticia",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechaHora = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Titulo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Subtitulo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Volanta = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Bajada = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Cuerpo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Imagen = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Epigrafe = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CategoriaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Noticia", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Noticia_Categoria_CategoriaId",
                        column: x => x.CategoriaId,
                        principalTable: "Categoria",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comentario",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechaHora = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Cuerpo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NoticiaId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ComentarioId = table.Column<int>(type: "int", nullable: true),
                    ComentarioOriginalId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comentario", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comentario_Comentario_ComentarioOriginalId",
                        column: x => x.ComentarioOriginalId,
                        principalTable: "Comentario",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Comentario_Noticia_NoticiaId",
                        column: x => x.NoticiaId,
                        principalTable: "Noticia",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Comentario_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Map_Noticia_Tag",
                columns: table => new
                {
                    NoticiasId = table.Column<int>(type: "int", nullable: false),
                    TagsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Map_Noticia_Tag", x => new { x.NoticiasId, x.TagsId });
                    table.ForeignKey(
                        name: "FK_Map_Noticia_Tag_Noticia_NoticiasId",
                        column: x => x.NoticiasId,
                        principalTable: "Noticia",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Map_Noticia_Tag_Tag_TagsId",
                        column: x => x.TagsId,
                        principalTable: "Tag",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reaccion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Like = table.Column<bool>(type: "bit", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ComentarioId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reaccion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reaccion_Comentario_ComentarioId",
                        column: x => x.ComentarioId,
                        principalTable: "Comentario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Reaccion_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comentario_ComentarioOriginalId",
                table: "Comentario",
                column: "ComentarioOriginalId");

            migrationBuilder.CreateIndex(
                name: "IX_Comentario_NoticiaId",
                table: "Comentario",
                column: "NoticiaId");

            migrationBuilder.CreateIndex(
                name: "IX_Comentario_UserId",
                table: "Comentario",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Map_Noticia_Tag_TagsId",
                table: "Map_Noticia_Tag",
                column: "TagsId");

            migrationBuilder.CreateIndex(
                name: "IX_Noticia_CategoriaId",
                table: "Noticia",
                column: "CategoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_Reaccion_ComentarioId",
                table: "Reaccion",
                column: "ComentarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Reaccion_UserId",
                table: "Reaccion",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Map_Noticia_Tag");

            migrationBuilder.DropTable(
                name: "Reaccion");

            migrationBuilder.DropTable(
                name: "Tag");

            migrationBuilder.DropTable(
                name: "Comentario");

            migrationBuilder.DropTable(
                name: "Noticia");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Categoria");
        }
    }
}
