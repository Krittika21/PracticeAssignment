using Microsoft.EntityFrameworkCore.Migrations;

namespace SportsApplication.Migrations
{
    public partial class NewMigrate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SAthleteID",
                table: "Enrollment",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SAthletesID",
                table: "Enrollment",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "SAthletes",
                columns: table => new
                {
                    SAthletesID = table.Column<int>(nullable: false),
                    Ranking = table.Column<string>(nullable: true),
                    Seconds = table.Column<double>(nullable: false),
                    FitnessRating = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SAthletes", x => x.SAthletesID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Enrollment_SAthletesID",
                table: "Enrollment",
                column: "SAthletesID");

            migrationBuilder.AddForeignKey(
                name: "FK_Enrollment_SAthletes_SAthletesID",
                table: "Enrollment",
                column: "SAthletesID",
                principalTable: "SAthletes",
                principalColumn: "SAthletesID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Enrollment_SAthletes_SAthletesID",
                table: "Enrollment");

            migrationBuilder.DropTable(
                name: "SAthletes");

            migrationBuilder.DropIndex(
                name: "IX_Enrollment_SAthletesID",
                table: "Enrollment");

            migrationBuilder.DropColumn(
                name: "SAthleteID",
                table: "Enrollment");

            migrationBuilder.DropColumn(
                name: "SAthletesID",
                table: "Enrollment");
        }
    }
}
