using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Inteliventas.Erp.Migrations
{
    public partial class Created_Vendedores_Entity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AppVendedores",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ExtraProperties = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(maxLength: 40, nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorId = table.Column<Guid>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierId = table.Column<Guid>(nullable: true),
                    Nombre = table.Column<string>(maxLength: 50, nullable: false),
                    Ruc = table.Column<string>(fixedLength: true, maxLength: 11, nullable: true),
                    Dni = table.Column<string>(fixedLength: true, maxLength: 8, nullable: true),
                    Ce = table.Column<string>(fixedLength: true, maxLength: 12, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppVendedores", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppVendedores");
        }
    }
}
