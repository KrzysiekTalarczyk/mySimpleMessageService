using Microsoft.EntityFrameworkCore.Migrations;

namespace mySimpleMessageService.Persistence.Migrations
{
    public partial class Contact_AddDeletedFlag : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "Contacts",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "Contacts");
        }
    }
}
