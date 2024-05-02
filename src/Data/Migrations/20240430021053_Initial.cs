using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Conduit.Data.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    id = table
                        .Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    email = table.Column<string>(type: "TEXT", maxLength: 320, nullable: false),
                    password = table.Column<string>(type: "TEXT", maxLength: 64, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_users", x => x.id);
                }
            );

            migrationBuilder.CreateTable(
                name: "profile",
                columns: table => new
                {
                    id = table.Column<long>(type: "INTEGER", nullable: false),
                    username = table.Column<string>(type: "TEXT", maxLength: 32, nullable: false),
                    bio = table.Column<string>(type: "TEXT", maxLength: 150, nullable: true),
                    image_url = table.Column<string>(type: "TEXT", maxLength: 10000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_profile", x => x.id);
                    table.ForeignKey(
                        name: "fk_profile_users_id",
                        column: x => x.id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade
                    );
                }
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(name: "profile");

            migrationBuilder.DropTable(name: "users");
        }
    }
}
