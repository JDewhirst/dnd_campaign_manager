using Microsoft.EntityFrameworkCore.Migrations;

namespace CampaignManagerData.Migrations
{
    public partial class AddDiceToRandEncounters : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RandomEncounters",
                columns: table => new
                {
                    RandEncounterTableId = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    RandEncounter = table.Column<string>(type: "varchar(8000)", unicode: false, maxLength: 8000, nullable: true),
                    Dice = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__RandomEn__4E4421BCA6E8210A", x => x.RandEncounterTableId);
                });

            migrationBuilder.CreateTable(
                name: "TerrainDetails",
                columns: table => new
                {
                    TerrainID = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    TerrainDescription = table.Column<string>(type: "varchar(8000)", unicode: false, maxLength: 8000, nullable: true),
                    TerrainTravelSpeed = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__TerrainD__79EED1AF3A5CC519", x => x.TerrainID);
                });

            migrationBuilder.CreateTable(
                name: "Provinces",
                columns: table => new
                {
                    Coordinates = table.Column<int>(type: "int", nullable: false),
                    ProvinceName = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    TerrainID = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    ObviousFeature = table.Column<string>(type: "varchar(8000)", unicode: false, maxLength: 8000, nullable: true),
                    HiddenFeature = table.Column<string>(type: "varchar(8000)", unicode: false, maxLength: 8000, nullable: true),
                    RandEncounterTableId = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Province__1764066FA4A88ED1", x => x.Coordinates);
                    table.ForeignKey(
                        name: "FK__Provinces__RandE__33D4B598",
                        column: x => x.RandEncounterTableId,
                        principalTable: "RandomEncounters",
                        principalColumn: "RandEncounterTableId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__Provinces__Terra__32E0915F",
                        column: x => x.TerrainID,
                        principalTable: "TerrainDetails",
                        principalColumn: "TerrainID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Characters",
                columns: table => new
                {
                    CharacterID = table.Column<int>(type: "int", nullable: false),
                    CharacterName = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: true),
                    IsPlayerCharacter = table.Column<bool>(type: "bit", nullable: true),
                    CharacterDescription = table.Column<string>(type: "varchar(8000)", unicode: false, maxLength: 8000, nullable: true),
                    Coordinates = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Characters", x => x.CharacterID);
                    table.ForeignKey(
                        name: "FK__Character__Coord__36B12243",
                        column: x => x.Coordinates,
                        principalTable: "Provinces",
                        principalColumn: "Coordinates",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Characters_Coordinates",
                table: "Characters",
                column: "Coordinates");

            migrationBuilder.CreateIndex(
                name: "IX_Provinces_RandEncounterTableId",
                table: "Provinces",
                column: "RandEncounterTableId");

            migrationBuilder.CreateIndex(
                name: "IX_Provinces_TerrainID",
                table: "Provinces",
                column: "TerrainID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Characters");

            migrationBuilder.DropTable(
                name: "Provinces");

            migrationBuilder.DropTable(
                name: "RandomEncounters");

            migrationBuilder.DropTable(
                name: "TerrainDetails");
        }
    }
}
