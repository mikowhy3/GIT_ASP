using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebApp.Migrations
{
    /// <inheritdoc />
    public partial class Organizations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OrganizationEntityId",
                table: "Contacts",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OrganizationId",
                table: "Contacts",
                type: "INTEGER",
                nullable: false,
                defaultValue: 101);

            migrationBuilder.CreateTable(
                name: "Organizations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    NIP = table.Column<string>(type: "TEXT", nullable: false),
                    REGON = table.Column<string>(type: "TEXT", nullable: false),
                    Adress_City = table.Column<string>(type: "TEXT", nullable: false),
                    Adress_Street = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organizations", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Contacts",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "OrganizationEntityId", "OrganizationId" },
                values: new object[] { new DateTime(2024, 11, 13, 11, 12, 13, 329, DateTimeKind.Local).AddTicks(3058), null, 101 });

            migrationBuilder.UpdateData(
                table: "Contacts",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Created", "OrganizationEntityId", "OrganizationId" },
                values: new object[] { new DateTime(2024, 11, 13, 11, 12, 13, 329, DateTimeKind.Local).AddTicks(3105), null, 101 });

            migrationBuilder.InsertData(
                table: "Organizations",
                columns: new[] { "Id", "Adress_City", "Adress_Street", "NIP", "Name", "REGON" },
                values: new object[,]
                {
                    { 101, "Kraków", "Św.Filipa", "321312321", "Wsei", "321312321" },
                    { 102, "Kraków", "ŚW Igora", "232332323", "Firma", "2342342423" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_OrganizationEntityId",
                table: "Contacts",
                column: "OrganizationEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Contacts_Organizations_OrganizationEntityId",
                table: "Contacts",
                column: "OrganizationEntityId",
                principalTable: "Organizations",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contacts_Organizations_OrganizationEntityId",
                table: "Contacts");

            migrationBuilder.DropTable(
                name: "Organizations");

            migrationBuilder.DropIndex(
                name: "IX_Contacts_OrganizationEntityId",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "OrganizationEntityId",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "OrganizationId",
                table: "Contacts");

            migrationBuilder.UpdateData(
                table: "Contacts",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2024, 11, 6, 11, 40, 3, 702, DateTimeKind.Local).AddTicks(4218));

            migrationBuilder.UpdateData(
                table: "Contacts",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2024, 11, 6, 11, 40, 3, 702, DateTimeKind.Local).AddTicks(4270));
        }
    }
}
