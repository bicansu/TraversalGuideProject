using Microsoft.EntityFrameworkCore.Migrations;

namespace CapstoneProject_DataAccessLayer.Migrations
{
    public partial class addmigrationmig_second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MailCode",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MailCode",
                table: "AspNetUsers");
        }
    }
}
