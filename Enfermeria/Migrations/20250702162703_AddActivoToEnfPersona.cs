using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Enfermeria.Migrations
{
    /// <inheritdoc />
    public partial class AddActivoToEnfPersona : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "enf_horarios",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fecha = table.Column<DateOnly>(type: "date", nullable: false),
                    hora = table.Column<TimeOnly>(type: "time", nullable: false),
                    estado = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    fecha_creacion = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    usuario_creacion = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    fecha_modificacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    usuario_modificacion = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__enf_hora__3213E83F51C162E5", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "enf_personas",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    cedula = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    nombre = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    telefono = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    email = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    usuario = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    password = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    departamento = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    tipo = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    seccion = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    fecha_nacimiento = table.Column<DateOnly>(type: "date", nullable: true),
                    sexo = table.Column<string>(type: "char(1)", unicode: false, fixedLength: true, maxLength: 1, nullable: false),
                    Activo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__enf_pers__3213E83F66577561", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "enf_citas",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_persona = table.Column<int>(type: "int", nullable: false),
                    id_horario = table.Column<int>(type: "int", nullable: false),
                    hora_llegada = table.Column<TimeOnly>(type: "time", nullable: true),
                    hora_salida = table.Column<TimeOnly>(type: "time", nullable: true),
                    id_profe_llegada = table.Column<int>(type: "int", nullable: true),
                    id_profe_salida = table.Column<int>(type: "int", nullable: true),
                    mensaje_llegada = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    mensaje_salida = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    estado = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false, defaultValue: "Creada"),
                    fecha_creacion = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    usuario_creacion = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    fecha_modificacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    usuario_modificacion = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__enf_cita__3213E83FD147CF3E", x => x.id);
                    table.ForeignKey(
                        name: "fk_cita_horario",
                        column: x => x.id_horario,
                        principalTable: "enf_horarios",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_cita_persona",
                        column: x => x.id_persona,
                        principalTable: "enf_personas",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_profe_llegada",
                        column: x => x.id_profe_llegada,
                        principalTable: "enf_personas",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_profe_salida",
                        column: x => x.id_profe_salida,
                        principalTable: "enf_personas",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_enf_citas_id_horario",
                table: "enf_citas",
                column: "id_horario");

            migrationBuilder.CreateIndex(
                name: "IX_enf_citas_id_persona",
                table: "enf_citas",
                column: "id_persona");

            migrationBuilder.CreateIndex(
                name: "IX_enf_citas_id_profe_llegada",
                table: "enf_citas",
                column: "id_profe_llegada");

            migrationBuilder.CreateIndex(
                name: "IX_enf_citas_id_profe_salida",
                table: "enf_citas",
                column: "id_profe_salida");

            migrationBuilder.CreateIndex(
                name: "UQ__enf_pers__415B7BE5E6660F4A",
                table: "enf_personas",
                column: "cedula",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ__enf_pers__9AFF8FC6FEAFC9F7",
                table: "enf_personas",
                column: "usuario",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ__enf_pers__AB6E6164C7166B98",
                table: "enf_personas",
                column: "email",
                unique: true,
                filter: "[email] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "enf_citas");

            migrationBuilder.DropTable(
                name: "enf_horarios");

            migrationBuilder.DropTable(
                name: "enf_personas");
        }
    }
}
