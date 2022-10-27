using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskEtkinlik.Repository.Migrations
{
    public partial class five : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BasketTickets_AspNetUsers_AppUserId",
                table: "BasketTickets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BasketTickets",
                table: "BasketTickets");

            migrationBuilder.AlterColumn<string>(
                name: "AppUserId",
                table: "BasketTickets",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "AppUserName",
                table: "BasketTickets",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BasketTickets",
                table: "BasketTickets",
                columns: new[] { "AppUserName", "EventId" });

            migrationBuilder.CreateIndex(
                name: "IX_BasketTickets_AppUserId",
                table: "BasketTickets",
                column: "AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_BasketTickets_AspNetUsers_AppUserId",
                table: "BasketTickets",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BasketTickets_AspNetUsers_AppUserId",
                table: "BasketTickets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BasketTickets",
                table: "BasketTickets");

            migrationBuilder.DropIndex(
                name: "IX_BasketTickets_AppUserId",
                table: "BasketTickets");

            migrationBuilder.DropColumn(
                name: "AppUserName",
                table: "BasketTickets");

            migrationBuilder.AlterColumn<string>(
                name: "AppUserId",
                table: "BasketTickets",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_BasketTickets",
                table: "BasketTickets",
                columns: new[] { "AppUserId", "EventId" });

            migrationBuilder.AddForeignKey(
                name: "FK_BasketTickets_AspNetUsers_AppUserId",
                table: "BasketTickets",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
