using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RedditClone.Api.Migrations
{
    /// <inheritdoc />
    public partial class SplitPostContentIntoTextAndUrl : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Content",
                table: "Posts");

            migrationBuilder.AddColumn<string>(
                name: "Text",
                table: "Posts",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Url",
                table: "Posts",
                type: "TEXT",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Text",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "Url",
                table: "Posts");

            migrationBuilder.AddColumn<string>(
                name: "Content",
                table: "Posts",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }
    }
}
