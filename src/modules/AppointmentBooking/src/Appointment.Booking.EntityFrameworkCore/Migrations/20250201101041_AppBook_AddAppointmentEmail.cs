using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Appointment.Booking.Migrations
{
    /// <inheritdoc />
    public partial class AppBook_AddAppointmentEmail : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PatientEmail",
                table: "Appointments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PatientEmail",
                table: "Appointments");
        }
    }
}
