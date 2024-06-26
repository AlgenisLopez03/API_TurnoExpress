using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GestorDeTurnos.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class EmpleadosAndEstablecimientos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EstablishmentId = table.Column<int>(type: "int", nullable: false),
                    Availabe = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(25)", nullable: false, defaultValue: "System"),
                    Created = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "GetDate()"),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employees_Establishments_EstablishmentId",
                        column: x => x.EstablishmentId,
                        principalTable: "Establishments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EstablishmentTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(25)", nullable: false, defaultValue: "System"),
                    Created = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "GetDate()"),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstablishmentTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeServices",
                columns: table => new
                {
                    EmployeesId = table.Column<int>(type: "int", nullable: false),
                    ServicesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeServices", x => new { x.EmployeesId, x.ServicesId });
                    table.ForeignKey(
                        name: "FK_EmployeeServices_Employees_EmployeesId",
                        column: x => x.EmployeesId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeServices_Services_ServicesId",
                        column: x => x.ServicesId,
                        principalTable: "Services",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EstablishmentRoles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EstablishmentTypeId = table.Column<int>(type: "int", nullable: false),
                    RoleName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(25)", nullable: false, defaultValue: "System"),
                    Created = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "GetDate()"),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstablishmentRoles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EstablishmentRoles_EstablishmentTypes_EstablishmentTypeId",
                        column: x => x.EstablishmentTypeId,
                        principalTable: "EstablishmentTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeEstablishmentRoles",
                columns: table => new
                {
                    EmployeesId = table.Column<int>(type: "int", nullable: false),
                    EstablishmentRolesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeEstablishmentRoles", x => new { x.EmployeesId, x.EstablishmentRolesId });
                    table.ForeignKey(
                        name: "FK_EmployeeEstablishmentRoles_Employees_EmployeesId",
                        column: x => x.EmployeesId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeEstablishmentRoles_EstablishmentRoles_EstablishmentRolesId",
                        column: x => x.EstablishmentRolesId,
                        principalTable: "EstablishmentRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "JobApplications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EstablishmentId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(25)", nullable: false, defaultValue: "System"),
                    Created = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "GetDate()"),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobApplications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_JobApplications_EstablishmentRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "EstablishmentRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_JobApplications_Establishments_EstablishmentId",
                        column: x => x.EstablishmentId,
                        principalTable: "Establishments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "EstablishmentTypes",
                columns: new[] { "Id", "LastModified", "LastModifiedBy", "TypeName" },
                values: new object[,]
                {
                    { 1, null, null, "Barberías" },
                    { 2, null, null, "Salones de belleza" },
                    { 3, null, null, "Spas y centros de bienestar" },
                    { 4, null, null, "Consultorios médicos" },
                    { 5, null, null, "Clínicas de salud" },
                    { 6, null, null, "Servicios de masajes" },
                    { 7, null, null, "Estudios de tatuajes y piercing" },
                    { 8, null, null, "Gimnasios" },
                    { 9, null, null, "Centros de tutoría o academias" },
                    { 10, null, null, "Oficinas gubernamentales" },
                    { 11, null, null, "Agencias de viaje" },
                    { 12, null, null, "Talleres mecánicos" },
                    { 13, null, null, "Oficinas de servicios financieros" },
                    { 14, null, null, "Restaurantes y bares" },
                    { 15, null, null, "Clínicas veterinarias" },
                    { 16, null, null, "Centros de Rehabilitacion" }
                });

            migrationBuilder.InsertData(
                table: "EstablishmentRoles",
                columns: new[] { "Id", "EstablishmentTypeId", "LastModified", "LastModifiedBy", "RoleName" },
                values: new object[,]
                {
                    { 1, 1, null, null, "Barbero" },
                    { 2, 1, null, null, "Estilista" },
                    { 3, 1, null, null, "Asistente de Barbero" },
                    { 4, 1, null, null, "Recepcionista" },
                    { 5, 1, null, null, "Gerente de Barbería" },
                    { 6, 2, null, null, "Estilista de Cabello" },
                    { 7, 2, null, null, "Maquillador/a" },
                    { 8, 2, null, null, "Manicurista" },
                    { 9, 2, null, null, "Esteticista" },
                    { 10, 2, null, null, "Gerente de Salón" },
                    { 11, 3, null, null, "Terapeuta de Masajes" },
                    { 12, 3, null, null, "Terapeuta de Spa" },
                    { 13, 3, null, null, "Recepcionista de Spa" },
                    { 14, 3, null, null, "Entrenador/a Personal" },
                    { 15, 3, null, null, "Gerente de Spa" },
                    { 16, 4, null, null, "Médico General" },
                    { 17, 4, null, null, "Especialista" },
                    { 18, 4, null, null, "Enfermero/a" },
                    { 19, 4, null, null, "Recepcionista de Consultorio" },
                    { 20, 4, null, null, "Administrador/a de Consultorio" },
                    { 21, 5, null, null, "Técnico de Laboratorio" },
                    { 22, 5, null, null, "Radiólogo/a" },
                    { 23, 5, null, null, "Asistente de Enfermería" },
                    { 24, 5, null, null, "Administrador/a de Clínica" },
                    { 25, 5, null, null, "Recepcionista de Clínica" },
                    { 26, 6, null, null, "Terapeuta de Masajes Terapéuticos" },
                    { 27, 6, null, null, "Terapeuta de Masajes Relajantes" },
                    { 28, 6, null, null, "Recepcionista de Servicios de Masajes" },
                    { 29, 6, null, null, "Administrador/a de Centro de Masajes" },
                    { 30, 6, null, null, "Entrenador/a Personal" },
                    { 31, 7, null, null, "Tatuador/a" },
                    { 32, 7, null, null, "Piercer" },
                    { 33, 7, null, null, "Asistente de Tatuador/Piercer" },
                    { 34, 7, null, null, "Recepcionista de Estudio de Tatuajes/Piercing" },
                    { 35, 7, null, null, "Gerente de Estudio de Tatuajes/Piercing" },
                    { 36, 8, null, null, "Entrenador Personal" },
                    { 37, 8, null, null, "Instructor/a de Clases Grupales" },
                    { 38, 8, null, null, "Recepcionista de Gimnasio" },
                    { 39, 8, null, null, "Gerente de Gimnasio" },
                    { 40, 8, null, null, "Limpiador/a de Gimnasio" },
                    { 41, 9, null, null, "Tutor/a Académico/a" },
                    { 42, 9, null, null, "Profesor/a Particular" },
                    { 43, 9, null, null, "Administrador/a de Academia" },
                    { 44, 9, null, null, "Recepcionista de Academia" },
                    { 45, 9, null, null, "Director/a de Academia" },
                    { 46, 10, null, null, "Oficial de Servicio al Cliente" },
                    { 47, 10, null, null, "Asistente de Oficina" },
                    { 48, 10, null, null, "Secretario/a Administrativo/a" },
                    { 49, 10, null, null, "Gerente de Oficina Gubernamental" },
                    { 50, 10, null, null, "Recepcionista de Oficina Gubernamental" },
                    { 51, 11, null, null, "Agente de Viajes" },
                    { 52, 11, null, null, "Asesor/a de Viajes" },
                    { 53, 11, null, null, "Especialista en Reservas" },
                    { 54, 11, null, null, "Gerente de Agencia de Viajes" },
                    { 55, 11, null, null, "Recepcionista de Agencia de Viajes" },
                    { 56, 12, null, null, "Mecánico/a" },
                    { 57, 12, null, null, "Asistente de Mecánico/a" },
                    { 58, 12, null, null, "Recepcionista de Taller Mecánico" },
                    { 59, 12, null, null, "Gerente de Taller Mecánico" },
                    { 60, 12, null, null, "Administrador/a de Taller Mecánico" },
                    { 61, 13, null, null, "Ejecutivo/a de Cuentas" },
                    { 62, 13, null, null, "Asesor/a Financiero/a" },
                    { 63, 13, null, null, "Cajero/a" },
                    { 64, 13, null, null, "Gerente de Oficina Financiera" },
                    { 65, 13, null, null, "Recepcionista de Oficina Financiera" },
                    { 66, 14, null, null, "Chef" },
                    { 67, 14, null, null, "Camarero/a" },
                    { 68, 14, null, null, "Bartender" },
                    { 69, 14, null, null, "Host/Hostess" },
                    { 70, 14, null, null, "Gerente de Restaurante/Bar" },
                    { 71, 15, null, null, "Veterinario/a" },
                    { 72, 15, null, null, "Asistente Veterinario/a" },
                    { 73, 15, null, null, "Recepcionista de Clínica Veterinaria" },
                    { 74, 15, null, null, "Gerente de Clínica Veterinaria" },
                    { 75, 15, null, null, "Auxiliar de Clínica Veterinaria" },
                    { 76, 16, null, null, "Terapeuta Físico/a" },
                    { 77, 16, null, null, "Consejero/a" },
                    { 78, 16, null, null, "Asistente de Rehabilitación" },
                    { 79, 16, null, null, "Recepcionista de Centro de Rehabilitación" },
                    { 80, 16, null, null, "Gerente de Centro de Rehabilitación" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeEstablishmentRoles_EstablishmentRolesId",
                table: "EmployeeEstablishmentRoles",
                column: "EstablishmentRolesId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_EstablishmentId",
                table: "Employees",
                column: "EstablishmentId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeServices_ServicesId",
                table: "EmployeeServices",
                column: "ServicesId");

            migrationBuilder.CreateIndex(
                name: "IX_EstablishmentRoles_EstablishmentTypeId",
                table: "EstablishmentRoles",
                column: "EstablishmentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_JobApplications_EstablishmentId",
                table: "JobApplications",
                column: "EstablishmentId");

            migrationBuilder.CreateIndex(
                name: "IX_JobApplications_RoleId",
                table: "JobApplications",
                column: "RoleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeeEstablishmentRoles");

            migrationBuilder.DropTable(
                name: "EmployeeServices");

            migrationBuilder.DropTable(
                name: "JobApplications");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "EstablishmentRoles");

            migrationBuilder.DropTable(
                name: "EstablishmentTypes");
        }
    }
}
