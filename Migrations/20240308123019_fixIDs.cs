using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TripLog_App.Migrations
{
    public partial class fixIDs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DestinationId",
                table: "Destination",
                newName: "DestinationID");

            migrationBuilder.RenameColumn(
                name: "ActivityId",
                table: "Activities",
                newName: "ActivityID");

            migrationBuilder.RenameColumn(
                name: "AccommodationId",
                table: "Accommodations",
                newName: "AccommodationID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DestinationID",
                table: "Destination",
                newName: "DestinationId");

            migrationBuilder.RenameColumn(
                name: "ActivityID",
                table: "Activities",
                newName: "ActivityId");

            migrationBuilder.RenameColumn(
                name: "AccommodationID",
                table: "Accommodations",
                newName: "AccommodationId");
        }
    }
}
