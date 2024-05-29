using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class addl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Remove",
                table: "ToDos",
                newName: "Done");

            migrationBuilder.AddColumn<bool>(
                name: "Delete",
                table: "ToDos",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Delete",
                table: "ToDos");

            migrationBuilder.RenameColumn(
                name: "Done",
                table: "ToDos",
                newName: "Remove");
        }
    }
}
