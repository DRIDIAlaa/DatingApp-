using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Data.Migrations
{
    public partial class MessageEntityAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MessageId",
                table: "Likes",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MessageId1",
                table: "Likes",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Messages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SenderId = table.Column<int>(type: "INTEGER", nullable: false),
                    SenderUsername = table.Column<string>(type: "TEXT", nullable: true),
                    RecipientId = table.Column<int>(type: "INTEGER", nullable: false),
                    RecipientUsername = table.Column<string>(type: "TEXT", nullable: true),
                    Content = table.Column<string>(type: "TEXT", nullable: true),
                    DateRead = table.Column<DateTime>(type: "TEXT", nullable: true),
                    MessageSent = table.Column<DateTime>(type: "TEXT", nullable: false),
                    SenderDelete = table.Column<bool>(type: "INTEGER", nullable: false),
                    RecipientDelete = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Messages_Users_RecipientId",
                        column: x => x.RecipientId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Messages_Users_SenderId",
                        column: x => x.SenderId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Likes_MessageId",
                table: "Likes",
                column: "MessageId");

            migrationBuilder.CreateIndex(
                name: "IX_Likes_MessageId1",
                table: "Likes",
                column: "MessageId1");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_RecipientId",
                table: "Messages",
                column: "RecipientId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_SenderId",
                table: "Messages",
                column: "SenderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Likes_Messages_MessageId",
                table: "Likes",
                column: "MessageId",
                principalTable: "Messages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Likes_Messages_MessageId1",
                table: "Likes",
                column: "MessageId1",
                principalTable: "Messages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Likes_Messages_MessageId",
                table: "Likes");

            migrationBuilder.DropForeignKey(
                name: "FK_Likes_Messages_MessageId1",
                table: "Likes");

            migrationBuilder.DropTable(
                name: "Messages");

            migrationBuilder.DropIndex(
                name: "IX_Likes_MessageId",
                table: "Likes");

            migrationBuilder.DropIndex(
                name: "IX_Likes_MessageId1",
                table: "Likes");

            migrationBuilder.DropColumn(
                name: "MessageId",
                table: "Likes");

            migrationBuilder.DropColumn(
                name: "MessageId1",
                table: "Likes");
        }
    }
}
