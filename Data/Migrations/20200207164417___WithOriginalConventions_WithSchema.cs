using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class __WithOriginalConventions_WithSchema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "customschema");

            migrationBuilder.CreateTable(
                name: "entities",
                schema: "customschema",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    discriminator = table.Column<string>(nullable: false),
                    some_derived_string_property = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_entities", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "entities",
                schema: "customschema");
        }
    }
}
