using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Inteliventas.Erp.Migrations
{
    public partial class Created_Pedido_Entity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AppPedidos",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ExtraProperties = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(maxLength: 40, nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorId = table.Column<Guid>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierId = table.Column<Guid>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    ClienteId = table.Column<Guid>(nullable: false),
                    VendedorId = table.Column<Guid>(nullable: false),
                    Total = table.Column<float>(nullable: false, defaultValue: 0f),
                    TotalProductos = table.Column<int>(nullable: false, defaultValue: 0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppPedidos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppPedidos_AppClientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "AppClientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AppPedidos_AppVendedores_VendedorId",
                        column: x => x.VendedorId,
                        principalTable: "AppVendedores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppPedidos_ClienteId",
                table: "AppPedidos",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_AppPedidos_VendedorId",
                table: "AppPedidos",
                column: "VendedorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppPedidos");
        }
    }
}
