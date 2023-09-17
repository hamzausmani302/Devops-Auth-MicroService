using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Devops_Auth_MicroService.Migrations
{
    /// <inheritdoc />
    public partial class twelveth : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "userId",
                table: "TDL_USER");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "userId",
                table: "TDL_USER",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
