using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace publy.infra.Migrations
{
    public partial class CreateGroupEntityAndRelationshipWithCollaborator : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "groups",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "uuid_generate_v4()"),
                    name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_groups", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "collaborators_groups",
                columns: table => new
                {
                    collaborator_id = table.Column<Guid>(type: "uuid", nullable: false),
                    group_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_collaborators_groups", x => new { x.collaborator_id, x.group_id });
                    table.ForeignKey(
                        name: "FK_collaborators_groups_collaborators_collaborator_id",
                        column: x => x.collaborator_id,
                        principalTable: "collaborators",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_collaborators_groups_groups_group_id",
                        column: x => x.group_id,
                        principalTable: "groups",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_collaborators_groups_group_id",
                table: "collaborators_groups",
                column: "group_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "collaborators_groups");

            migrationBuilder.DropTable(
                name: "groups");
        }
    }
}
