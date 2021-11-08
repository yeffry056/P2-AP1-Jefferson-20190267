using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace P2_AP1_Jefferson_20190267.Migrations
{
    public partial class Migracion_Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Proyecto",
                columns: table => new
                {
                    ProyectoId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Fecha = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Descripcion = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proyecto", x => x.ProyectoId);
                });

            migrationBuilder.CreateTable(
                name: "TipoTarea",
                columns: table => new
                {
                    TipoId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TipoTareaa = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoTarea", x => x.TipoId);
                });

            migrationBuilder.CreateTable(
                name: "DetalleTarea",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Requerimiento = table.Column<string>(type: "TEXT", nullable: true),
                    Tiempo = table.Column<int>(type: "INTEGER", nullable: false),
                    TiempoTotal = table.Column<int>(type: "INTEGER", nullable: false),
                    ProyectoId = table.Column<int>(type: "INTEGER", nullable: false),
                    TipoId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetalleTarea", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DetalleTarea_Proyecto_ProyectoId",
                        column: x => x.ProyectoId,
                        principalTable: "Proyecto",
                        principalColumn: "ProyectoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DetalleTarea_TipoTarea_TipoId",
                        column: x => x.TipoId,
                        principalTable: "TipoTarea",
                        principalColumn: "TipoId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "TipoTarea",
                columns: new[] { "TipoId", "TipoTareaa" },
                values: new object[] { 1, "Analisis" });

            migrationBuilder.InsertData(
                table: "TipoTarea",
                columns: new[] { "TipoId", "TipoTareaa" },
                values: new object[] { 2, "Diseño" });

            migrationBuilder.InsertData(
                table: "TipoTarea",
                columns: new[] { "TipoId", "TipoTareaa" },
                values: new object[] { 3, "Programacion" });

            migrationBuilder.InsertData(
                table: "TipoTarea",
                columns: new[] { "TipoId", "TipoTareaa" },
                values: new object[] { 4, "Prueba" });

            migrationBuilder.CreateIndex(
                name: "IX_DetalleTarea_ProyectoId",
                table: "DetalleTarea",
                column: "ProyectoId");

            migrationBuilder.CreateIndex(
                name: "IX_DetalleTarea_TipoId",
                table: "DetalleTarea",
                column: "TipoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DetalleTarea");

            migrationBuilder.DropTable(
                name: "Proyecto");

            migrationBuilder.DropTable(
                name: "TipoTarea");
        }
    }
}
