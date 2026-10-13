using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskFlow.Insfrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddTenant : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UpdatedBy",
                table: "Tenant",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "UpdatedBy",
                table: "Projects",
                newName: "UpdatedAt");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "Tenant",
                newName: "UpdatedBy");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "Projects",
                newName: "UpdatedBy");
        }
    }
}
