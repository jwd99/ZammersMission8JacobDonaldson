using Microsoft.EntityFrameworkCore.Migrations;

namespace Zammers.Migrations
{
    public partial class shipped : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Shipped",
                table: "CheckoutInfos",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Shipped",
                table: "CheckoutInfos");
        }
    }
}
