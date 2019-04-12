using Microsoft.EntityFrameworkCore.Migrations;

namespace BeautyCenter.Data.Context.Migrations
{
    public partial class Beauty6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Appointment_ServiceId",
                schema: "Appointment",
                table: "Appointment");

            migrationBuilder.CreateIndex(
                name: "IX_Appointment_ServiceId",
                schema: "Appointment",
                table: "Appointment",
                column: "ServiceId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Appointment_ServiceId",
                schema: "Appointment",
                table: "Appointment");

            migrationBuilder.CreateIndex(
                name: "IX_Appointment_ServiceId",
                schema: "Appointment",
                table: "Appointment",
                column: "ServiceId",
                unique: true);
        }
    }
}
