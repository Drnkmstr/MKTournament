using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MKTournament.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "players",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    NickName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    EmailAddress = table.Column<string>(type: "character varying(320)", maxLength: 320, nullable: false),
                    RegisteredOnUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    RegistrationToken = table.Column<string>(type: "text", nullable: false),
                    RegistrationTokenSentOnUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    EmailConfirmedOnUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IdentityId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_players", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_players_EmailAddress",
                table: "players",
                column: "EmailAddress",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_players_IdentityId",
                table: "players",
                column: "IdentityId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_players_NickName",
                table: "players",
                column: "NickName",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "players");
        }
    }
}
