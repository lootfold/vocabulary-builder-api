using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VocabularyBuilderApi.Migrations
{
    public partial class InitialModelForItem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Word = table.Column<string>(nullable: true),
                    Meaning = table.Column<string>(nullable: true),
                    Example = table.Column<string>(nullable: true),
                    DictionaryUrl = table.Column<string>(nullable: true),
                    ThesaurusUrl = table.Column<string>(nullable: true),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Items");
        }
    }
}
