using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class RemoveIgnore : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Exercises_TrainingId",
                table: "Exercises",
                column: "TrainingId");

            migrationBuilder.CreateIndex(
                name: "IX_ExerciseRecords_TrainingId",
                table: "ExerciseRecords",
                column: "TrainingId");

            migrationBuilder.AddForeignKey(
                name: "FK_ExerciseRecords_TrainingRecords_TrainingId",
                table: "ExerciseRecords",
                column: "TrainingId",
                principalTable: "TrainingRecords",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Exercises_Training_TrainingId",
                table: "Exercises",
                column: "TrainingId",
                principalTable: "Training",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExerciseRecords_TrainingRecords_TrainingId",
                table: "ExerciseRecords");

            migrationBuilder.DropForeignKey(
                name: "FK_Exercises_Training_TrainingId",
                table: "Exercises");

            migrationBuilder.DropIndex(
                name: "IX_Exercises_TrainingId",
                table: "Exercises");

            migrationBuilder.DropIndex(
                name: "IX_ExerciseRecords_TrainingId",
                table: "ExerciseRecords");
        }
    }
}
