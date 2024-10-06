using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ServerLibrary.Data.Migrations
{
    /// <inheritdoc />
    public partial class Second_Time : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ResourceValue",
                table: "LocaleStringResources",
                newName: "Value");

            migrationBuilder.RenameColumn(
                name: "ResourceKey",
                table: "LocaleStringResources",
                newName: "Key");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Value",
                table: "LocaleStringResources",
                newName: "ResourceValue");

            migrationBuilder.RenameColumn(
                name: "Key",
                table: "LocaleStringResources",
                newName: "ResourceKey");
        }
    }
}
