using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class TrainingIdIsOptional : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Exercises_Training_TrainingId",
                table: "Exercises");

            migrationBuilder.AlterColumn<int>(
                name: "TrainingId",
                table: "Exercises",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Exercises_Training_TrainingId",
                table: "Exercises",
                column: "TrainingId",
                principalTable: "Training",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Exercises_Training_TrainingId",
                table: "Exercises");

            migrationBuilder.AlterColumn<int>(
                name: "TrainingId",
                table: "Exercises",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Exercises_Training_TrainingId",
                table: "Exercises",
                column: "TrainingId",
                principalTable: "Training",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
