using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace caserandomuser.Migrations
{
    /// <inheritdoc />
    public partial class CriandoBanco : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Coordinateses",
                columns: table => new
                {
                    IdInt = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Latitude = table.Column<string>(type: "text", nullable: true),
                    Longitude = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coordinateses", x => x.IdInt);
                });

            migrationBuilder.CreateTable(
                name: "Dobs",
                columns: table => new
                {
                    IdInt = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Age = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dobs", x => x.IdInt);
                });

            migrationBuilder.CreateTable(
                name: "Ids",
                columns: table => new
                {
                    IdInt = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Value = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ids", x => x.IdInt);
                });

            migrationBuilder.CreateTable(
                name: "Logins",
                columns: table => new
                {
                    IdInt = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Uuid = table.Column<string>(type: "text", nullable: true),
                    Username = table.Column<string>(type: "text", nullable: true),
                    Password = table.Column<string>(type: "text", nullable: true),
                    Salt = table.Column<string>(type: "text", nullable: true),
                    Md5 = table.Column<string>(type: "text", nullable: true),
                    Sha1 = table.Column<string>(type: "text", nullable: true),
                    Sha256 = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Logins", x => x.IdInt);
                });

            migrationBuilder.CreateTable(
                name: "Names",
                columns: table => new
                {
                    IdInt = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "text", nullable: true),
                    First = table.Column<string>(type: "text", nullable: true),
                    Last = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Names", x => x.IdInt);
                });

            migrationBuilder.CreateTable(
                name: "Pictures",
                columns: table => new
                {
                    IdInt = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Large = table.Column<string>(type: "text", nullable: true),
                    Medium = table.Column<string>(type: "text", nullable: true),
                    Thumbnail = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pictures", x => x.IdInt);
                });

            migrationBuilder.CreateTable(
                name: "Registereds",
                columns: table => new
                {
                    IdInt = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Age = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Registereds", x => x.IdInt);
                });

            migrationBuilder.CreateTable(
                name: "Streets",
                columns: table => new
                {
                    IdInt = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Number = table.Column<string>(type: "text", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Streets", x => x.IdInt);
                });

            migrationBuilder.CreateTable(
                name: "Timezones",
                columns: table => new
                {
                    IdInt = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Offset = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Timezones", x => x.IdInt);
                });

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    IdInt = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    StreetEntityId = table.Column<int>(type: "integer", nullable: false),
                    City = table.Column<string>(type: "text", nullable: true),
                    State = table.Column<string>(type: "text", nullable: true),
                    Country = table.Column<string>(type: "text", nullable: true),
                    Postcode = table.Column<int>(type: "integer", nullable: false),
                    CoordinatesEntityId = table.Column<int>(type: "integer", nullable: false),
                    TimezoneEntityId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.IdInt);
                    table.ForeignKey(
                        name: "FK_Locations_Coordinateses_CoordinatesEntityId",
                        column: x => x.CoordinatesEntityId,
                        principalTable: "Coordinateses",
                        principalColumn: "IdInt",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Locations_Streets_StreetEntityId",
                        column: x => x.StreetEntityId,
                        principalTable: "Streets",
                        principalColumn: "IdInt",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Locations_Timezones_TimezoneEntityId",
                        column: x => x.TimezoneEntityId,
                        principalTable: "Timezones",
                        principalColumn: "IdInt",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cadastros",
                columns: table => new
                {
                    IdInt = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Gender = table.Column<string>(type: "text", nullable: true),
                    NameEntityId = table.Column<int>(type: "integer", nullable: false),
                    LocationEntityId = table.Column<int>(type: "integer", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: true),
                    LoginEntityId = table.Column<int>(type: "integer", nullable: false),
                    DobEntityId = table.Column<int>(type: "integer", nullable: false),
                    RegisteredEntityId = table.Column<int>(type: "integer", nullable: false),
                    Phone = table.Column<string>(type: "text", nullable: true),
                    Cell = table.Column<string>(type: "text", nullable: true),
                    IdEntityId = table.Column<int>(type: "integer", nullable: false),
                    PictureEntityId = table.Column<int>(type: "integer", nullable: false),
                    Nat = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cadastros", x => x.IdInt);
                    table.ForeignKey(
                        name: "FK_Cadastros_Dobs_DobEntityId",
                        column: x => x.DobEntityId,
                        principalTable: "Dobs",
                        principalColumn: "IdInt",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cadastros_Ids_IdEntityId",
                        column: x => x.IdEntityId,
                        principalTable: "Ids",
                        principalColumn: "IdInt",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cadastros_Locations_LocationEntityId",
                        column: x => x.LocationEntityId,
                        principalTable: "Locations",
                        principalColumn: "IdInt",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cadastros_Logins_LoginEntityId",
                        column: x => x.LoginEntityId,
                        principalTable: "Logins",
                        principalColumn: "IdInt",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cadastros_Names_NameEntityId",
                        column: x => x.NameEntityId,
                        principalTable: "Names",
                        principalColumn: "IdInt",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cadastros_Pictures_PictureEntityId",
                        column: x => x.PictureEntityId,
                        principalTable: "Pictures",
                        principalColumn: "IdInt",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cadastros_Registereds_RegisteredEntityId",
                        column: x => x.RegisteredEntityId,
                        principalTable: "Registereds",
                        principalColumn: "IdInt",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cadastros_DobEntityId",
                table: "Cadastros",
                column: "DobEntityId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cadastros_IdEntityId",
                table: "Cadastros",
                column: "IdEntityId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cadastros_LocationEntityId",
                table: "Cadastros",
                column: "LocationEntityId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cadastros_LoginEntityId",
                table: "Cadastros",
                column: "LoginEntityId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cadastros_NameEntityId",
                table: "Cadastros",
                column: "NameEntityId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cadastros_PictureEntityId",
                table: "Cadastros",
                column: "PictureEntityId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cadastros_RegisteredEntityId",
                table: "Cadastros",
                column: "RegisteredEntityId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Locations_CoordinatesEntityId",
                table: "Locations",
                column: "CoordinatesEntityId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Locations_StreetEntityId",
                table: "Locations",
                column: "StreetEntityId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Locations_TimezoneEntityId",
                table: "Locations",
                column: "TimezoneEntityId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cadastros");

            migrationBuilder.DropTable(
                name: "Dobs");

            migrationBuilder.DropTable(
                name: "Ids");

            migrationBuilder.DropTable(
                name: "Locations");

            migrationBuilder.DropTable(
                name: "Logins");

            migrationBuilder.DropTable(
                name: "Names");

            migrationBuilder.DropTable(
                name: "Pictures");

            migrationBuilder.DropTable(
                name: "Registereds");

            migrationBuilder.DropTable(
                name: "Coordinateses");

            migrationBuilder.DropTable(
                name: "Streets");

            migrationBuilder.DropTable(
                name: "Timezones");
        }
    }
}
