using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Messenger.Data.Migrations
{
    public partial class Employees : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FullNames",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    MiddleName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FullNames", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WorkingPlaces",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyName = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkingPlaces", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Employes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullNameId = table.Column<int>(nullable: false),
                    Position = table.Column<string>(nullable: true),
                    WorkingPlaceId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employes_FullNames_FullNameId",
                        column: x => x.FullNameId,
                        principalTable: "FullNames",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Employes_WorkingPlaces_WorkingPlaceId",
                        column: x => x.WorkingPlaceId,
                        principalTable: "WorkingPlaces",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Messages",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Text = table.Column<string>(nullable: true),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: true),
                    EmployeeId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Messages_Employes_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "FullNames",
                columns: new[] { "Id", "FirstName", "LastName", "MiddleName" },
                values: new object[] { 1, "Alexandr", "Digilevich", "Grigorievich" });

            migrationBuilder.InsertData(
                table: "WorkingPlaces",
                columns: new[] { "Id", "Address", "CompanyName" },
                values: new object[] { 1, "Minsk, Smolyachkova 16", "Microsoft Company" });

            migrationBuilder.InsertData(
                table: "Employes",
                columns: new[] { "Id", "FullNameId", "Position", "WorkingPlaceId" },
                values: new object[] { 1, 1, "Developer", 1 });

            migrationBuilder.CreateIndex(
                name: "IX_Employes_FullNameId",
                table: "Employes",
                column: "FullNameId");

            migrationBuilder.CreateIndex(
                name: "IX_Employes_WorkingPlaceId",
                table: "Employes",
                column: "WorkingPlaceId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_EmployeeId",
                table: "Messages",
                column: "EmployeeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Messages");

            migrationBuilder.DropTable(
                name: "Employes");

            migrationBuilder.DropTable(
                name: "FullNames");

            migrationBuilder.DropTable(
                name: "WorkingPlaces");
        }
    }
}
