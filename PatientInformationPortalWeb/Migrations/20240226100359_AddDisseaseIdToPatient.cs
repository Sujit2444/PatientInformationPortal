using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PatientInformationPortalWeb.Migrations
{
    /// <inheritdoc />
    public partial class AddDisseaseIdToPatient : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DiseaseID",
                table: "PatientsInformation",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_PatientsInformation_DiseaseID",
                table: "PatientsInformation",
                column: "DiseaseID");

            migrationBuilder.AddForeignKey(
                name: "FK_PatientsInformation_DiseaseInformation_DiseaseID",
                table: "PatientsInformation",
                column: "DiseaseID",
                principalTable: "DiseaseInformation",
                principalColumn: "DiseaseID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PatientsInformation_DiseaseInformation_DiseaseID",
                table: "PatientsInformation");

            migrationBuilder.DropIndex(
                name: "IX_PatientsInformation_DiseaseID",
                table: "PatientsInformation");

            migrationBuilder.DropColumn(
                name: "DiseaseID",
                table: "PatientsInformation");
        }
    }
}
