using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Servicios_Prestamos.Server.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    UsuarioId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Correo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.UsuarioId);
                });

            migrationBuilder.CreateTable(
                name: "Solicitudes",
                columns: table => new
                {
                    SolicitudId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Monto_Prestamo = table.Column<int>(type: "int", nullable: false),
                    Fecha_Solicitud = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Estado_Solicitud = table.Column<bool>(type: "bit", nullable: false),
                    Tasa_Interes = table.Column<int>(type: "int", nullable: false),
                    Plazo_meses = table.Column<int>(type: "int", nullable: false),
                    UsuarioId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Solicitudes", x => x.SolicitudId);
                    table.ForeignKey(
                        name: "FK_Solicitudes_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "UsuarioId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pagos",
                columns: table => new
                {
                    PagoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Monto_Pago = table.Column<int>(type: "int", nullable: false),
                    Fecha_Pago = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SolicitudId = table.Column<int>(type: "int", nullable: false),
                    Solicitud_PrestamoSolicitudId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pagos", x => x.PagoId);
                    table.ForeignKey(
                        name: "FK_Pagos_Solicitudes_Solicitud_PrestamoSolicitudId",
                        column: x => x.Solicitud_PrestamoSolicitudId,
                        principalTable: "Solicitudes",
                        principalColumn: "SolicitudId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pagos_Solicitud_PrestamoSolicitudId",
                table: "Pagos",
                column: "Solicitud_PrestamoSolicitudId");

            migrationBuilder.CreateIndex(
                name: "IX_Solicitudes_UsuarioId",
                table: "Solicitudes",
                column: "UsuarioId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pagos");

            migrationBuilder.DropTable(
                name: "Solicitudes");

            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}
