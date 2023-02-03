using Microsoft.EntityFrameworkCore.Migrations;

namespace CapstoneProject_DataAccessLayer.Migrations
{
    public partial class fixourinfo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Adress",
                table: "OurInfos",
                newName: "Address");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Address",
                table: "OurInfos",
                newName: "Adress");
        }
    }
}
