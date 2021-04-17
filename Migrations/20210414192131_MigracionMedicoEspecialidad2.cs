using Microsoft.EntityFrameworkCore.Migrations;

namespace Turnos.Migrations
{
    public partial class MigracionMedicoEspecialidad2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MedicoEspecialidads_Especialidad_IdEspecialidad",
                table: "MedicoEspecialidads");

            migrationBuilder.DropForeignKey(
                name: "FK_MedicoEspecialidads_Medico_IdMedico",
                table: "MedicoEspecialidads");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MedicoEspecialidads",
                table: "MedicoEspecialidads");

            migrationBuilder.RenameTable(
                name: "MedicoEspecialidads",
                newName: "MedicoEspecialidad");

            migrationBuilder.RenameIndex(
                name: "IX_MedicoEspecialidads_IdEspecialidad",
                table: "MedicoEspecialidad",
                newName: "IX_MedicoEspecialidad_IdEspecialidad");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MedicoEspecialidad",
                table: "MedicoEspecialidad",
                columns: new[] { "IdMedico", "IdEspecialidad" });

            migrationBuilder.AddForeignKey(
                name: "FK_MedicoEspecialidad_Especialidad_IdEspecialidad",
                table: "MedicoEspecialidad",
                column: "IdEspecialidad",
                principalTable: "Especialidad",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MedicoEspecialidad_Medico_IdMedico",
                table: "MedicoEspecialidad",
                column: "IdMedico",
                principalTable: "Medico",
                principalColumn: "IdMedico",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MedicoEspecialidad_Especialidad_IdEspecialidad",
                table: "MedicoEspecialidad");

            migrationBuilder.DropForeignKey(
                name: "FK_MedicoEspecialidad_Medico_IdMedico",
                table: "MedicoEspecialidad");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MedicoEspecialidad",
                table: "MedicoEspecialidad");

            migrationBuilder.RenameTable(
                name: "MedicoEspecialidad",
                newName: "MedicoEspecialidads");

            migrationBuilder.RenameIndex(
                name: "IX_MedicoEspecialidad_IdEspecialidad",
                table: "MedicoEspecialidads",
                newName: "IX_MedicoEspecialidads_IdEspecialidad");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MedicoEspecialidads",
                table: "MedicoEspecialidads",
                columns: new[] { "IdMedico", "IdEspecialidad" });

            migrationBuilder.AddForeignKey(
                name: "FK_MedicoEspecialidads_Especialidad_IdEspecialidad",
                table: "MedicoEspecialidads",
                column: "IdEspecialidad",
                principalTable: "Especialidad",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MedicoEspecialidads_Medico_IdMedico",
                table: "MedicoEspecialidads",
                column: "IdMedico",
                principalTable: "Medico",
                principalColumn: "IdMedico",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
