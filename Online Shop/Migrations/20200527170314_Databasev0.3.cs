using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Online_Shop.Migrations
{
    public partial class Databasev03 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserBaskets_Users_UserLogin1",
                table: "UserBaskets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserBaskets",
                table: "UserBaskets");

            migrationBuilder.DropIndex(
                name: "IX_UserBaskets_UserLogin1",
                table: "UserBaskets");

            migrationBuilder.DropColumn(
                name: "UserLogin1",
                table: "UserBaskets");

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "Users",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<string>(
                name: "UserLogin",
                table: "UserBaskets",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<Guid>(
                name: "UserID",
                table: "UserBaskets",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "GoodsID",
                table: "UserBaskets",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserBaskets",
                table: "UserBaskets",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_UserBaskets_GoodsID",
                table: "UserBaskets",
                column: "GoodsID");

            migrationBuilder.CreateIndex(
                name: "IX_UserBaskets_UserLogin",
                table: "UserBaskets",
                column: "UserLogin");

            migrationBuilder.AddForeignKey(
                name: "FK_UserBaskets_Items_GoodsID",
                table: "UserBaskets",
                column: "GoodsID",
                principalTable: "Items",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserBaskets_Users_UserLogin",
                table: "UserBaskets",
                column: "UserLogin",
                principalTable: "Users",
                principalColumn: "Login",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserBaskets_Items_GoodsID",
                table: "UserBaskets");

            migrationBuilder.DropForeignKey(
                name: "FK_UserBaskets_Users_UserLogin",
                table: "UserBaskets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserBaskets",
                table: "UserBaskets");

            migrationBuilder.DropIndex(
                name: "IX_UserBaskets_GoodsID",
                table: "UserBaskets");

            migrationBuilder.DropIndex(
                name: "IX_UserBaskets_UserLogin",
                table: "UserBaskets");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "UserID",
                table: "UserBaskets");

            migrationBuilder.DropColumn(
                name: "GoodsID",
                table: "UserBaskets");

            migrationBuilder.AlterColumn<string>(
                name: "UserLogin",
                table: "UserBaskets",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<string>(
                name: "UserLogin1",
                table: "UserBaskets",
                type: "nvarchar(20)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserBaskets",
                table: "UserBaskets",
                column: "UserLogin");

            migrationBuilder.CreateIndex(
                name: "IX_UserBaskets_UserLogin1",
                table: "UserBaskets",
                column: "UserLogin1");

            migrationBuilder.AddForeignKey(
                name: "FK_UserBaskets_Users_UserLogin1",
                table: "UserBaskets",
                column: "UserLogin1",
                principalTable: "Users",
                principalColumn: "Login",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
