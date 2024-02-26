using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PatientInformationPortalWeb.Migrations
{
    /// <inheritdoc />
    public partial class InitialPatientInformationDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Allergies",
                columns: table => new
                {
                    AllergiesID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AllergiesName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Allergies", x => x.AllergiesID);
                });

            migrationBuilder.CreateTable(
                name: "DiseaseInformation",
                columns: table => new
                {
                    DiseaseID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DiseaseName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiseaseInformation", x => x.DiseaseID);
                });

            migrationBuilder.CreateTable(
                name: "NCDs",
                columns: table => new
                {
                    NCDID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NCDName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NCDs", x => x.NCDID);
                });

            migrationBuilder.CreateTable(
                name: "PatientsInformation",
                columns: table => new
                {
                    PatientID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EpilepsyStatus = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientsInformation", x => x.PatientID);
                });

            migrationBuilder.CreateTable(
                name: "Allergies_Details",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatientID = table.Column<int>(type: "int", nullable: false),
                    AllergiesID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Allergies_Details", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Allergies_Details_Allergies_AllergiesID",
                        column: x => x.AllergiesID,
                        principalTable: "Allergies",
                        principalColumn: "AllergiesID");
                    table.ForeignKey(
                        name: "FK_Allergies_Details_PatientsInformation_PatientID",
                        column: x => x.PatientID,
                        principalTable: "PatientsInformation",
                        principalColumn: "PatientID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NCD_Details",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatientID = table.Column<int>(type: "int", nullable: false),
                    NCDID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NCD_Details", x => x.ID);
                    table.ForeignKey(
                        name: "FK_NCD_Details_NCDs_NCDID",
                        column: x => x.NCDID,
                        principalTable: "NCDs",
                        principalColumn: "NCDID");
                    table.ForeignKey(
                        name: "FK_NCD_Details_PatientsInformation_PatientID",
                        column: x => x.PatientID,
                        principalTable: "PatientsInformation",
                        principalColumn: "PatientID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Allergies",
                columns: new[] { "AllergiesID", "AllergiesName" },
                values: new object[,]
                {
                    { 1, "Drugs - Penicillin" },
                    { 2, "Drugs - Others" },
                    { 3, "Animals" },
                    { 4, "Food" },
                    { 5, "Oniments" },
                    { 6, "Plant" },
                    { 7, "Sprays" },
                    { 8, "Others" },
                    { 9, "No Allergies" }
                });

            migrationBuilder.InsertData(
                table: "NCDs",
                columns: new[] { "NCDID", "NCDName" },
                values: new object[,]
                {
                    { 1, "Asthma" },
                    { 2, "Cancer" },
                    { 3, "Disorders of ear" },
                    { 4, "Disorders of eye" },
                    { 5, "Mental illness" },
                    { 6, "Our health problems" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Allergies_Details_AllergiesID",
                table: "Allergies_Details",
                column: "AllergiesID");

            migrationBuilder.CreateIndex(
                name: "IX_Allergies_Details_PatientID",
                table: "Allergies_Details",
                column: "PatientID");

            migrationBuilder.CreateIndex(
                name: "IX_NCD_Details_NCDID",
                table: "NCD_Details",
                column: "NCDID");

            migrationBuilder.CreateIndex(
                name: "IX_NCD_Details_PatientID",
                table: "NCD_Details",
                column: "PatientID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Allergies_Details");

            migrationBuilder.DropTable(
                name: "DiseaseInformation");

            migrationBuilder.DropTable(
                name: "NCD_Details");

            migrationBuilder.DropTable(
                name: "Allergies");

            migrationBuilder.DropTable(
                name: "NCDs");

            migrationBuilder.DropTable(
                name: "PatientsInformation");
        }
    }
}
