using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PichinchaCoreAPI.Migrations
{
    /// <inheritdoc />
    public partial class FechaMovimientos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Fecha",
                table: "Movimientos",
                type: "DateTime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "Date");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Fecha",
                table: "Movimientos",
                type: "Date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "DateTime");
        }
    }
}
