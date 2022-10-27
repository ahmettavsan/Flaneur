using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskEtkinlik.Repository.Migrations
{
    public partial class three : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BasketTickets_AspNetUsers_AppUserId1",
                table: "BasketTickets");

            migrationBuilder.DropForeignKey(
                name: "FK_BasketTickets_Tickets_TicketId",
                table: "BasketTickets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BasketTickets",
                table: "BasketTickets");

            migrationBuilder.DropIndex(
                name: "IX_BasketTickets_AppUserId1",
                table: "BasketTickets");

            migrationBuilder.DropIndex(
                name: "IX_BasketTickets_TicketId",
                table: "BasketTickets");

            migrationBuilder.DropColumn(
                name: "TicketId",
                table: "BasketTickets");

            migrationBuilder.DropColumn(
                name: "Amount",
                table: "BasketTickets");

            migrationBuilder.DropColumn(
                name: "AppUserId1",
                table: "BasketTickets");

            migrationBuilder.RenameColumn(
                name: "Price",
                table: "BasketTickets",
                newName: "EventId");

            migrationBuilder.AlterColumn<string>(
                name: "AppUserId",
                table: "BasketTickets",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "BasketTickets",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BasketTickets",
                table: "BasketTickets",
                columns: new[] { "UserId", "EventId" });

            migrationBuilder.CreateIndex(
                name: "IX_BasketTickets_AppUserId",
                table: "BasketTickets",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_BasketTickets_EventId",
                table: "BasketTickets",
                column: "EventId");

            migrationBuilder.AddForeignKey(
                name: "FK_BasketTickets_AspNetUsers_AppUserId",
                table: "BasketTickets",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BasketTickets_Events_EventId",
                table: "BasketTickets",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BasketTickets_AspNetUsers_AppUserId",
                table: "BasketTickets");

            migrationBuilder.DropForeignKey(
                name: "FK_BasketTickets_Events_EventId",
                table: "BasketTickets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BasketTickets",
                table: "BasketTickets");

            migrationBuilder.DropIndex(
                name: "IX_BasketTickets_AppUserId",
                table: "BasketTickets");

            migrationBuilder.DropIndex(
                name: "IX_BasketTickets_EventId",
                table: "BasketTickets");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "BasketTickets");

            migrationBuilder.RenameColumn(
                name: "EventId",
                table: "BasketTickets",
                newName: "Price");

            migrationBuilder.AlterColumn<int>(
                name: "AppUserId",
                table: "BasketTickets",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TicketId",
                table: "BasketTickets",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Amount",
                table: "BasketTickets",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "AppUserId1",
                table: "BasketTickets",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_BasketTickets",
                table: "BasketTickets",
                columns: new[] { "AppUserId", "TicketId" });

            migrationBuilder.CreateIndex(
                name: "IX_BasketTickets_AppUserId1",
                table: "BasketTickets",
                column: "AppUserId1");

            migrationBuilder.CreateIndex(
                name: "IX_BasketTickets_TicketId",
                table: "BasketTickets",
                column: "TicketId");

            migrationBuilder.AddForeignKey(
                name: "FK_BasketTickets_AspNetUsers_AppUserId1",
                table: "BasketTickets",
                column: "AppUserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BasketTickets_Tickets_TicketId",
                table: "BasketTickets",
                column: "TicketId",
                principalTable: "Tickets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
