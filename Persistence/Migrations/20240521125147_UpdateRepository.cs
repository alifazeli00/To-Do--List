using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class UpdateRepository : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                table: "ToDos",
                newName: "Remove");

            migrationBuilder.RenameColumn(
                name: "InsertTime",
                table: "ToDos",
                newName: "createDate");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "createDate",
                table: "ToDos",
                newName: "InsertTime");

            migrationBuilder.RenameColumn(
                name: "Remove",
                table: "ToDos",
                newName: "IsDeleted");
        }
    }
}
