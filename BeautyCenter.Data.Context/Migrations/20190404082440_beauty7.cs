using Microsoft.EntityFrameworkCore.Migrations;

namespace BeautyCenter.Data.Context.Migrations
{
    public partial class beauty7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AppointmentStatus",
                schema: "Appointment",
                table: "Appointment",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AppointmentStatus",
                schema: "Appointment",
                table: "Appointment");
        }
    }
}
