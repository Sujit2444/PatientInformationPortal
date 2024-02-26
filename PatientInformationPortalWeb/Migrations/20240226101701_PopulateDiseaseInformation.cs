using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PatientInformationPortalWeb.Migrations
{
    /// <inheritdoc />
    public partial class PopulateDiseaseInformation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "DiseaseInformation",
                columns: new[] { "DiseaseID", "DiseaseName" },
                values: new object[,]
                {
                    { 1, "Hepatitis A" },
                    { 2, "Influenza (Flu)" },
                    { 3, "COVID-19" },
                    { 4, "Common Cold" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DiseaseInformation",
                keyColumn: "DiseaseID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "DiseaseInformation",
                keyColumn: "DiseaseID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "DiseaseInformation",
                keyColumn: "DiseaseID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "DiseaseInformation",
                keyColumn: "DiseaseID",
                keyValue: 4);
        }
    }
}
