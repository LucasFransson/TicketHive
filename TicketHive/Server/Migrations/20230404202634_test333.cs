using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TicketHive.Server.Migrations
{
    /// <inheritdoc />
    public partial class test333 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Events_Countries_CountryName",
                table: "Events");

            migrationBuilder.AlterColumn<string>(
                name: "CountryName",
                table: "Events",
                type: "nvarchar(100)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Events_Countries_CountryName",
                table: "Events",
                column: "CountryName",
                principalTable: "Countries",
                principalColumn: "Name",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Events_Countries_CountryName",
                table: "Events");

            migrationBuilder.AlterColumn<string>(
                name: "CountryName",
                table: "Events",
                type: "nvarchar(100)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)");

            migrationBuilder.AddForeignKey(
                name: "FK_Events_Countries_CountryName",
                table: "Events",
                column: "CountryName",
                principalTable: "Countries",
                principalColumn: "Name");
        }
    }
}
