using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoreAngApp.Migrations.DataSync
{
    /// <inheritdoc />
    public partial class DatasyncOpt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SyncTableEntries",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TablePKId = table.Column<string>(type: "TEXT", nullable: true),
                    JsonObject = table.Column<string>(type: "TEXT", nullable: true),
                    TableName = table.Column<string>(type: "TEXT", nullable: true),
                    FullTableName = table.Column<string>(type: "TEXT", nullable: true),
                    Assembly = table.Column<string>(type: "TEXT", nullable: true),
                    IsSync = table.Column<bool>(type: "INTEGER", nullable: false),
                    SyncMode = table.Column<int>(type: "INTEGER", nullable: false),
                    TenantId = table.Column<int>(type: "INTEGER", nullable: false),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false),
                    Cancelled = table.Column<bool>(type: "INTEGER", nullable: false),
                    CreatedBy = table.Column<long>(type: "INTEGER", nullable: false),
                    ModifiedBy = table.Column<long>(type: "INTEGER", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SyncTableEntries", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SyncTableEntries");
        }
    }
}
