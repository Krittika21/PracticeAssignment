using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SportsApplication.Migrations
{
    public partial class Migrate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Athletes",
                columns: table => new
                {
                    AthletesID = table.Column<int>(nullable: false),
                    ParticipantName = table.Column<string>(nullable: true),
                    Distance = table.Column<double>(nullable: false),
                    Fitness = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Athletes", x => x.AthletesID);
                });

            migrationBuilder.CreateTable(
                name: "Tests",
                columns: table => new
                {
                    TestsID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TestType = table.Column<string>(nullable: true),
                    TestDate = table.Column<DateTime>(nullable: false),
                    ParticipantCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tests", x => x.TestsID);
                });

            migrationBuilder.CreateTable(
                name: "Enrollment",
                columns: table => new
                {
                    EnrollmentID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TestsID = table.Column<int>(nullable: false),
                    AthletesID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enrollment", x => x.EnrollmentID);
                    table.ForeignKey(
                        name: "FK_Enrollment_Athletes_AthletesID",
                        column: x => x.AthletesID,
                        principalTable: "Athletes",
                        principalColumn: "AthletesID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Enrollment_Tests_TestsID",
                        column: x => x.TestsID,
                        principalTable: "Tests",
                        principalColumn: "TestsID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Enrollment_AthletesID",
                table: "Enrollment",
                column: "AthletesID");

            migrationBuilder.CreateIndex(
                name: "IX_Enrollment_TestsID",
                table: "Enrollment",
                column: "TestsID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Enrollment");

            migrationBuilder.DropTable(
                name: "Athletes");

            migrationBuilder.DropTable(
                name: "Tests");
        }
    }
}
