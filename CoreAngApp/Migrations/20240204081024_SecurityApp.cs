﻿using Microsoft.EntityFrameworkCore.Migrations;
using System;

#nullable disable

namespace CoreAngApp.Migrations
{
	/// <inheritdoc />
	public partial class SecurityApp : Migration
	{
		/// <inheritdoc />
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.CreateTable(
				name: "AspNetRoles",
				columns: table => new
				{
					Id = table.Column<long>(type: "INTEGER", nullable: false)
						.Annotation("Sqlite:Autoincrement", true),
					SetupCode = table.Column<string>(type: "TEXT", nullable: true),
					Name = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
					NormalizedName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
					ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_AspNetRoles", x => x.Id);
				});

			migrationBuilder.CreateTable(
				name: "AspNetUsers",
				columns: table => new
				{
					Id = table.Column<long>(type: "INTEGER", nullable: false)
						.Annotation("Sqlite:Autoincrement", true),
					FirstName = table.Column<string>(type: "TEXT", nullable: true),
					LastName = table.Column<string>(type: "TEXT", nullable: true),
					IsEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
					ConfirmationCode = table.Column<string>(type: "TEXT", nullable: true),
					TenantId = table.Column<string>(type: "TEXT", nullable: true),
					UserName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
					NormalizedUserName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
					Email = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
					NormalizedEmail = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
					EmailConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
					PasswordHash = table.Column<string>(type: "TEXT", nullable: true),
					SecurityStamp = table.Column<string>(type: "TEXT", nullable: true),
					ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: true),
					PhoneNumber = table.Column<string>(type: "TEXT", nullable: true),
					PhoneNumberConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
					TwoFactorEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
					LockoutEnd = table.Column<DateTimeOffset>(type: "TEXT", nullable: true),
					LockoutEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
					AccessFailedCount = table.Column<int>(type: "INTEGER", nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_AspNetUsers", x => x.Id);
				});

			migrationBuilder.CreateTable(
				name: "Privileges",
				columns: table => new
				{
					Id = table.Column<long>(type: "INTEGER", nullable: false)
						.Annotation("Sqlite:Autoincrement", true),
					Name = table.Column<string>(type: "TEXT", nullable: true),
					Description = table.Column<string>(type: "TEXT", nullable: true),
					URL = table.Column<string>(type: "TEXT", nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Privileges", x => x.Id);
				});

			migrationBuilder.CreateTable(
				name: "AspNetRoleClaims",
				columns: table => new
				{
					Id = table.Column<int>(type: "INTEGER", nullable: false)
						.Annotation("Sqlite:Autoincrement", true),
					RoleId = table.Column<long>(type: "INTEGER", nullable: false),
					ClaimType = table.Column<string>(type: "TEXT", nullable: true),
					ClaimValue = table.Column<string>(type: "TEXT", nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
					table.ForeignKey(
						name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
						column: x => x.RoleId,
						principalTable: "AspNetRoles",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
				});

			migrationBuilder.CreateTable(
				name: "AspNetUserClaims",
				columns: table => new
				{
					Id = table.Column<int>(type: "INTEGER", nullable: false)
						.Annotation("Sqlite:Autoincrement", true),
					UserId = table.Column<long>(type: "INTEGER", nullable: false),
					ClaimType = table.Column<string>(type: "TEXT", nullable: true),
					ClaimValue = table.Column<string>(type: "TEXT", nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
					table.ForeignKey(
						name: "FK_AspNetUserClaims_AspNetUsers_UserId",
						column: x => x.UserId,
						principalTable: "AspNetUsers",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
				});

			migrationBuilder.CreateTable(
				name: "AspNetUserLogins",
				columns: table => new
				{
					LoginProvider = table.Column<string>(type: "TEXT", nullable: false),
					ProviderKey = table.Column<string>(type: "TEXT", nullable: false),
					ProviderDisplayName = table.Column<string>(type: "TEXT", nullable: true),
					UserId = table.Column<long>(type: "INTEGER", nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
					table.ForeignKey(
						name: "FK_AspNetUserLogins_AspNetUsers_UserId",
						column: x => x.UserId,
						principalTable: "AspNetUsers",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
				});

			migrationBuilder.CreateTable(
				name: "AspNetUserRoles",
				columns: table => new
				{
					UserId = table.Column<long>(type: "INTEGER", nullable: false),
					RoleId = table.Column<long>(type: "INTEGER", nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
					table.ForeignKey(
						name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
						column: x => x.RoleId,
						principalTable: "AspNetRoles",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
					table.ForeignKey(
						name: "FK_AspNetUserRoles_AspNetUsers_UserId",
						column: x => x.UserId,
						principalTable: "AspNetUsers",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
				});

			migrationBuilder.CreateTable(
				name: "AspNetUserTokens",
				columns: table => new
				{
					UserId = table.Column<long>(type: "INTEGER", nullable: false),
					LoginProvider = table.Column<string>(type: "TEXT", nullable: false),
					Name = table.Column<string>(type: "TEXT", nullable: false),
					Value = table.Column<string>(type: "TEXT", nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
					table.ForeignKey(
						name: "FK_AspNetUserTokens_AspNetUsers_UserId",
						column: x => x.UserId,
						principalTable: "AspNetUsers",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
				});

			migrationBuilder.CreateTable(
				name: "RefreshToken",
				columns: table => new
				{
					Id = table.Column<int>(type: "INTEGER", nullable: false)
						.Annotation("Sqlite:Autoincrement", true),
					Token = table.Column<string>(type: "TEXT", nullable: true),
					Expiry = table.Column<DateTime>(type: "TEXT", nullable: false),
					Created = table.Column<DateTime>(type: "TEXT", nullable: false),
					CreatedByIp = table.Column<string>(type: "TEXT", nullable: true),
					Revoked = table.Column<DateTime>(type: "TEXT", nullable: true),
					RevokedByIp = table.Column<string>(type: "TEXT", nullable: true),
					ReplacedByToken = table.Column<string>(type: "TEXT", nullable: true),
					UserId = table.Column<string>(type: "TEXT", nullable: true),
					ApplicationUserId = table.Column<long>(type: "INTEGER", nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_RefreshToken", x => x.Id);
					table.ForeignKey(
						name: "FK_RefreshToken_AspNetUsers_ApplicationUserId",
						column: x => x.ApplicationUserId,
						principalTable: "AspNetUsers",
						principalColumn: "Id");
				});

			migrationBuilder.CreateTable(
				name: "ApplicationRolePrivileges",
				columns: table => new
				{
					RoleId = table.Column<long>(type: "INTEGER", nullable: false),
					PrivilegeId = table.Column<long>(type: "INTEGER", nullable: false),
					Id = table.Column<long>(type: "INTEGER", nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_ApplicationRolePrivileges", x => new { x.RoleId, x.PrivilegeId });
					table.ForeignKey(
						name: "FK_ApplicationRolePrivileges_AspNetRoles_RoleId",
						column: x => x.RoleId,
						principalTable: "AspNetRoles",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
					table.ForeignKey(
						name: "FK_ApplicationRolePrivileges_Privileges_PrivilegeId",
						column: x => x.PrivilegeId,
						principalTable: "Privileges",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
				});

			migrationBuilder.CreateIndex(
				name: "IX_ApplicationRolePrivileges_PrivilegeId",
				table: "ApplicationRolePrivileges",
				column: "PrivilegeId");

			migrationBuilder.CreateIndex(
				name: "IX_AspNetRoleClaims_RoleId",
				table: "AspNetRoleClaims",
				column: "RoleId");

			migrationBuilder.CreateIndex(
				name: "RoleNameIndex",
				table: "AspNetRoles",
				column: "NormalizedName",
				unique: true);

			migrationBuilder.CreateIndex(
				name: "IX_AspNetUserClaims_UserId",
				table: "AspNetUserClaims",
				column: "UserId");

			migrationBuilder.CreateIndex(
				name: "IX_AspNetUserLogins_UserId",
				table: "AspNetUserLogins",
				column: "UserId");

			migrationBuilder.CreateIndex(
				name: "IX_AspNetUserRoles_RoleId",
				table: "AspNetUserRoles",
				column: "RoleId");

			migrationBuilder.CreateIndex(
				name: "EmailIndex",
				table: "AspNetUsers",
				column: "NormalizedEmail");

			migrationBuilder.CreateIndex(
				name: "UserNameIndex",
				table: "AspNetUsers",
				column: "NormalizedUserName",
				unique: true);

			migrationBuilder.CreateIndex(
				name: "IX_RefreshToken_ApplicationUserId",
				table: "RefreshToken",
				column: "ApplicationUserId");
		}

		/// <inheritdoc />
		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropTable(
				name: "ApplicationRolePrivileges");

			migrationBuilder.DropTable(
				name: "AspNetRoleClaims");

			migrationBuilder.DropTable(
				name: "AspNetUserClaims");

			migrationBuilder.DropTable(
				name: "AspNetUserLogins");

			migrationBuilder.DropTable(
				name: "AspNetUserRoles");

			migrationBuilder.DropTable(
				name: "AspNetUserTokens");

			migrationBuilder.DropTable(
				name: "RefreshToken");

			migrationBuilder.DropTable(
				name: "Privileges");

			migrationBuilder.DropTable(
				name: "AspNetRoles");

			migrationBuilder.DropTable(
				name: "AspNetUsers");
		}
	}
}
