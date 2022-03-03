using Microsoft.EntityFrameworkCore.Migrations;

namespace Zammers.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
           

            migrationBuilder.CreateTable(
                name: "CheckoutInfos",
                columns: table => new
                {
                    CheckoutId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: false),
                    Address1 = table.Column<string>(nullable: false),
                    Address2 = table.Column<string>(nullable: true),
                    Address3 = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: false),
                    State = table.Column<string>(nullable: false),
                    ZipCode = table.Column<string>(nullable: true),
                    Country = table.Column<string>(nullable: false),
                    Notes = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CheckoutInfos", x => x.CheckoutId);
                });

            migrationBuilder.CreateTable(
                name: "BasketLineItem",
                columns: table => new
                {
                    LineID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    BookId = table.Column<int>(nullable: true),
                    Quantity = table.Column<int>(nullable: false),
                    SubTotal = table.Column<double>(nullable: false),
                    Total = table.Column<double>(nullable: false),
                    checkoutInfoCheckoutId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BasketLineItem", x => x.LineID);
                    table.ForeignKey(
                        name: "FK_BasketLineItem_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "BookId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BasketLineItem_CheckoutInfos_checkoutInfoCheckoutId",
                        column: x => x.checkoutInfoCheckoutId,
                        principalTable: "CheckoutInfos",
                        principalColumn: "CheckoutId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BasketLineItem_BookId",
                table: "BasketLineItem",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_BasketLineItem_checkoutInfoCheckoutId",
                table: "BasketLineItem",
                column: "checkoutInfoCheckoutId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BasketLineItem");

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "CheckoutInfos");
        }
    }
}
