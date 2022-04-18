using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FormSender.Microservice.Data.Migrations
{
    public partial class RenameAndRemoveCreatedAtInEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Documents");

            migrationBuilder.RenameColumn(
                name: "DateUpdated",
                table: "MessageForms",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "DateCreated",
                table: "MessageForms",
                newName: "CreatedAt");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "MessageForms",
                newName: "DateUpdated");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "MessageForms",
                newName: "DateCreated");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Documents",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
