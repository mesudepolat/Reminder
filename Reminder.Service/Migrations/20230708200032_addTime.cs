using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Reminder.Service.Migrations
{
    /// <inheritdoc />
    public partial class addTime : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CreateDate",
                table: "Activities",
                newName: "Time");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Time",
                table: "Activities",
                newName: "CreateDate");
        }
    }
}
