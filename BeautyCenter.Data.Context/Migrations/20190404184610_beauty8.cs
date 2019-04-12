using Microsoft.EntityFrameworkCore.Migrations;

namespace BeautyCenter.Data.Context.Migrations
{
    public partial class beauty8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Department",
                schema: "Operation",
                table: "Operation");

            migrationBuilder.AddColumn<int>(
                name: "ServiceId",
                schema: "Operation",
                table: "Operation",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Operation_ServiceId",
                schema: "Operation",
                table: "Operation",
                column: "ServiceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Operation_Service_ServiceId",
                schema: "Operation",
                table: "Operation",
                column: "ServiceId",
                principalSchema: "Service",
                principalTable: "Service",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Operation_Service_ServiceId",
                schema: "Operation",
                table: "Operation");

            migrationBuilder.DropIndex(
                name: "IX_Operation_ServiceId",
                schema: "Operation",
                table: "Operation");

            migrationBuilder.DropColumn(
                name: "ServiceId",
                schema: "Operation",
                table: "Operation");

            migrationBuilder.AddColumn<string>(
                name: "Department",
                schema: "Operation",
                table: "Operation",
                type: "varchar(150)",
                nullable: false,
                defaultValue: "");
        }
    }
}
