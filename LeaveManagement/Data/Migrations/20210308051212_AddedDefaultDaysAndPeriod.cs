using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LeaveManagement.Data.Migrations
{
    public partial class AddedDefaultDaysAndPeriod : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FristName",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<int>(
                name: "DefaultDays",
                table: "LeaveTypes",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Period",
                table: "LeaveAllocations",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "DetailsLeaveTypeViewModel",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DefaultDays",
                table: "LeaveTypes");

            migrationBuilder.DropColumn(
                name: "Period",
                table: "LeaveAllocations");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "DetailsLeaveTypeViewModel",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FristName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
