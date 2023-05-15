using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CodeJitsu.Migrations
{
    /// <inheritdoc />
    public partial class defaultDiscriminatorAbpUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Discriminator",
                table: "AbpUsers",
                nullable: false,
                defaultValue: "AppUser");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
