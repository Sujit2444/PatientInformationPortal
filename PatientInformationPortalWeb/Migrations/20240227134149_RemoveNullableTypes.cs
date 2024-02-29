using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PatientInformationPortalWeb.Migrations
{
    /// <inheritdoc />
    public partial class RemoveNullableTypes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Allergies_Details_Allergies_AllergiesID",
                table: "Allergies_Details");

            migrationBuilder.DropForeignKey(
                name: "FK_NCD_Details_NCDs_NCDID",
                table: "NCD_Details");

            migrationBuilder.AlterColumn<int>(
                name: "NCDID",
                table: "NCD_Details",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AllergiesID",
                table: "Allergies_Details",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Allergies_Details_Allergies_AllergiesID",
                table: "Allergies_Details",
                column: "AllergiesID",
                principalTable: "Allergies",
                principalColumn: "AllergiesID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_NCD_Details_NCDs_NCDID",
                table: "NCD_Details",
                column: "NCDID",
                principalTable: "NCDs",
                principalColumn: "NCDID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Allergies_Details_Allergies_AllergiesID",
                table: "Allergies_Details");

            migrationBuilder.DropForeignKey(
                name: "FK_NCD_Details_NCDs_NCDID",
                table: "NCD_Details");

            migrationBuilder.AlterColumn<int>(
                name: "NCDID",
                table: "NCD_Details",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "AllergiesID",
                table: "Allergies_Details",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Allergies_Details_Allergies_AllergiesID",
                table: "Allergies_Details",
                column: "AllergiesID",
                principalTable: "Allergies",
                principalColumn: "AllergiesID");

            migrationBuilder.AddForeignKey(
                name: "FK_NCD_Details_NCDs_NCDID",
                table: "NCD_Details",
                column: "NCDID",
                principalTable: "NCDs",
                principalColumn: "NCDID");
        }
    }
}
