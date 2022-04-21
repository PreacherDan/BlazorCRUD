using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazorCRUD.Server.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    YearlyBudget = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Salary = table.Column<int>(type: "int", nullable: false),
                    DepartmentID1 = table.Column<int>(type: "int", nullable: true),
                    DepartmentID = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Employees_Departments_DepartmentID1",
                        column: x => x.DepartmentID1,
                        principalTable: "Departments",
                        principalColumn: "ID");
                });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "ID", "Location", "Name", "YearlyBudget" },
                values: new object[,]
                {
                    { 1, "Cracow", "IT", 10000 },
                    { 2, "Warsaw", "Finance", 5000 },
                    { 3, "Cracow", "RD", 8000 },
                    { 4, "Warsaw", "Management", 7000 }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "ID", "DepartmentID", "DepartmentID1", "Name", "Salary", "Surname" },
                values: new object[,]
                {
                    { 1, (byte)1, null, "Forrest", 5000, "Gump" },
                    { 2, (byte)2, null, "Johnny", 5000, "Bravo" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_DepartmentID1",
                table: "Employees",
                column: "DepartmentID1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Departments");
        }
    }
}
