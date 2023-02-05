using Microsoft.EntityFrameworkCore.Migrations;

namespace CapstoneProject_DataAccessLayer.Migrations
{
    public partial class m_3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserCounts",
                columns: table => new
                {
                    UserCountID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TotalUser = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserCounts", x => x.UserCountID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserCounts");
        }
    }
}
