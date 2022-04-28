using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ChamCong2.API.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "im_User",
                columns: table => new
                {
                    UserID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Phonenumber = table.Column<int>(type: "int", maxLength: 50, nullable: false),
                    EmployId = table.Column<int>(type: "int", maxLength: 50, nullable: false),
                    Passwword = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastLoginDate = table.Column<DateTime>(type: "datetime2", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_im_User", x => x.UserID);
                });

            migrationBuilder.CreateTable(
                name: "im_Plan",
                columns: table => new
                {
                    PlanId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsLate = table.Column<bool>(type: "bit", maxLength: 50, nullable: false),
                    CompletionPercentage = table.Column<float>(type: "real", maxLength: 50, nullable: false),
                    TotalTaskPlannedCount = table.Column<int>(type: "int", maxLength: 50, nullable: false),
                    TotalTaskComplete = table.Column<int>(type: "int", maxLength: 50, nullable: false),
                    TotalTaskOutStandingCount = table.Column<int>(type: "int", maxLength: 50, nullable: false),
                    TotalTimeWorkCount = table.Column<int>(type: "int", maxLength: 50, nullable: false),
                    TimeCheckIn = table.Column<DateTime>(type: "datetime2", maxLength: 50, nullable: false),
                    TimeCheckOut = table.Column<DateTime>(type: "datetime2", maxLength: 50, nullable: false),
                    UserId = table.Column<int>(type: "int", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_im_Plan", x => x.PlanId);
                    table.ForeignKey(
                        name: "FK_im_Plan_im_User_UserId",
                        column: x => x.UserId,
                        principalTable: "im_User",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "im_Task",
                columns: table => new
                {
                    TaskId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Note = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    TypeTask = table.Column<int>(type: "int", maxLength: 50, nullable: false),
                    IsComplete = table.Column<bool>(type: "bit", maxLength: 50, nullable: false),
                    PlanId = table.Column<int>(type: "int", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_im_Task", x => x.TaskId);
                    table.ForeignKey(
                        name: "FK_im_Task_im_Plan_PlanId",
                        column: x => x.PlanId,
                        principalTable: "im_Plan",
                        principalColumn: "PlanId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_im_Plan_UserId",
                table: "im_Plan",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_im_Task_PlanId",
                table: "im_Task",
                column: "PlanId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "im_Task");

            migrationBuilder.DropTable(
                name: "im_Plan");

            migrationBuilder.DropTable(
                name: "im_User");
        }
    }
}
