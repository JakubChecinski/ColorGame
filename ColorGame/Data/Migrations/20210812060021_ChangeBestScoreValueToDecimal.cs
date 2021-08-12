using Microsoft.EntityFrameworkCore.Migrations;

namespace ColorGame.Data.Migrations
{
    public partial class ChangeBestScoreValueToDecimal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Value",
                table: "BestScores",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Value",
                table: "BestScores",
                type: "int",
                nullable: false,
                oldClrType: typeof(decimal));
        }
    }
}
