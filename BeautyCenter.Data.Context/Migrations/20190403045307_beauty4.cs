using Microsoft.EntityFrameworkCore.Migrations;

namespace BeautyCenter.Data.Context.Migrations
{
    public partial class beauty4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ServiceId",
                schema: "Appointment",
                table: "Appointment",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Appointment_ServiceId",
                schema: "Appointment",
                table: "Appointment",
                column: "ServiceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointment_Service_ServiceId",
                schema: "Appointment",
                table: "Appointment",
                column: "ServiceId",
                principalSchema: "Service",
                principalTable: "Service",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointment_Service_ServiceId",
                schema: "Appointment",
                table: "Appointment");

            migrationBuilder.DropIndex(
                name: "IX_Appointment_ServiceId",
                schema: "Appointment",
                table: "Appointment");

            migrationBuilder.DropColumn(
                name: "ServiceId",
                schema: "Appointment",
                table: "Appointment");
        }
    }
}
