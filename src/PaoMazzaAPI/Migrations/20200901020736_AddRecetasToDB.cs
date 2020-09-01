using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace PaoMazzaAPI.Migrations
{
    public partial class AddRecetasToDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Recetas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nombre = table.Column<string>(maxLength: 100, nullable: false),
                    Notas = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recetas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UnidadTipos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Tipo = table.Column<string>(maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UnidadTipos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Unidades",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nombre = table.Column<string>(maxLength: 100, nullable: false),
                    Abrev = table.Column<string>(maxLength: 10, nullable: false),
                    TipoId = table.Column<int>(nullable: false),
                    RelBase = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Unidades", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Unidades_UnidadTipos_TipoId",
                        column: x => x.TipoId,
                        principalTable: "UnidadTipos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ingredientes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nombre = table.Column<string>(maxLength: 150, nullable: false),
                    Stock = table.Column<float>(nullable: false),
                    UnidadId = table.Column<int>(nullable: false),
                    Costo = table.Column<float>(nullable: false),
                    CostoUnidadId = table.Column<int>(nullable: false),
                    Notas = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingredientes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ingredientes_Unidades_CostoUnidadId",
                        column: x => x.CostoUnidadId,
                        principalTable: "Unidades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ingredientes_Unidades_UnidadId",
                        column: x => x.UnidadId,
                        principalTable: "Unidades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RecetaIngredientes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RecetaId = table.Column<int>(nullable: false),
                    IngredienteId = table.Column<int>(nullable: false),
                    Cantidad = table.Column<float>(nullable: false),
                    UnidadId = table.Column<int>(nullable: false),
                    Notas = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecetaIngredientes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RecetaIngredientes_Ingredientes_IngredienteId",
                        column: x => x.IngredienteId,
                        principalTable: "Ingredientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RecetaIngredientes_Recetas_RecetaId",
                        column: x => x.RecetaId,
                        principalTable: "Recetas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RecetaIngredientes_Unidades_UnidadId",
                        column: x => x.UnidadId,
                        principalTable: "Unidades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ingredientes_CostoUnidadId",
                table: "Ingredientes",
                column: "CostoUnidadId");

            migrationBuilder.CreateIndex(
                name: "IX_Ingredientes_UnidadId",
                table: "Ingredientes",
                column: "UnidadId");

            migrationBuilder.CreateIndex(
                name: "IX_RecetaIngredientes_IngredienteId",
                table: "RecetaIngredientes",
                column: "IngredienteId");

            migrationBuilder.CreateIndex(
                name: "IX_RecetaIngredientes_RecetaId",
                table: "RecetaIngredientes",
                column: "RecetaId");

            migrationBuilder.CreateIndex(
                name: "IX_RecetaIngredientes_UnidadId",
                table: "RecetaIngredientes",
                column: "UnidadId");

            migrationBuilder.CreateIndex(
                name: "IX_Unidades_TipoId",
                table: "Unidades",
                column: "TipoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RecetaIngredientes");

            migrationBuilder.DropTable(
                name: "Ingredientes");

            migrationBuilder.DropTable(
                name: "Recetas");

            migrationBuilder.DropTable(
                name: "Unidades");

            migrationBuilder.DropTable(
                name: "UnidadTipos");
        }
    }
}
