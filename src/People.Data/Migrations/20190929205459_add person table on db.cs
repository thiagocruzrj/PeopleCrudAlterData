using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace People.Data.Migrations
{
    public partial class addpersontableondb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "People",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Nome = table.Column<string>(type: "varchar(70)", nullable: false),
                    Email = table.Column<string>(type: "varchar(100)", nullable: false),
                    Photo = table.Column<string>(type: "varchar(100)", nullable: true),
                    Birthdate = table.Column<DateTime>(nullable: false),
                    WhatsAppNumber = table.Column<string>(type: "varchar(14)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_People", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "People");
        }
    }
}
