using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebsiteTMDT.Data.Migrations
{
    public partial class updatActiv : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "tb_Product",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "tb_Post",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "tb_New",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "tb_Category",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "tb_Product");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "tb_Post");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "tb_New");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "tb_Category");
        }
    }
}
