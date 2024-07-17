using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HomeworkAi.Modules.Persistence.DAL.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ClosedAnswerExercises",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ExerciseHeaderInMotherLanguage = table.Column<bool>(type: "boolean", nullable: false),
                    MotherLanguage = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    TargetLanguage = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    TargetLanguageLevel = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    TopicsOfSentences = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    GrammarSection = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    AmountOfSentences = table.Column<int>(type: "integer", nullable: true),
                    TranslateFromMotherLanguage = table.Column<bool>(type: "boolean", nullable: true),
                    QuestionsInMotherLanguage = table.Column<bool>(type: "boolean", nullable: true),
                    ZeroConditional = table.Column<bool>(type: "boolean", nullable: true),
                    FirstConditional = table.Column<bool>(type: "boolean", nullable: true),
                    SecondConditional = table.Column<bool>(type: "boolean", nullable: true),
                    ThirdConditional = table.Column<bool>(type: "boolean", nullable: true),
                    DescriptionInMotherLanguage = table.Column<bool>(type: "boolean", nullable: true),
                    ExerciseType = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    ExerciseJson = table.Column<string>(type: "jsonb", nullable: false),
                    CheckedByTeacher = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClosedAnswerExercises", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OpenAnswerExercises",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ExerciseHeaderInMotherLanguage = table.Column<bool>(type: "boolean", nullable: false),
                    MotherLanguage = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    TargetLanguage = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    TargetLanguageLevel = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    TopicsOfSentences = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    GrammarSection = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    AmountOfSentences = table.Column<int>(type: "integer", nullable: true),
                    TranslateFromMotherLanguage = table.Column<bool>(type: "boolean", nullable: true),
                    QuestionsInMotherLanguage = table.Column<bool>(type: "boolean", nullable: true),
                    ZeroConditional = table.Column<bool>(type: "boolean", nullable: true),
                    FirstConditional = table.Column<bool>(type: "boolean", nullable: true),
                    SecondConditional = table.Column<bool>(type: "boolean", nullable: true),
                    ThirdConditional = table.Column<bool>(type: "boolean", nullable: true),
                    ShowMotherLanguage = table.Column<bool>(type: "boolean", nullable: true),
                    ShowFirstForm = table.Column<bool>(type: "boolean", nullable: true),
                    ExerciseType = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    ExerciseJson = table.Column<string>(type: "jsonb", nullable: false),
                    CheckedByTeacher = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OpenAnswerExercises", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OpenFormExercises",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ExerciseHeaderInMotherLanguage = table.Column<bool>(type: "boolean", nullable: false),
                    MotherLanguage = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    TargetLanguage = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    TargetLanguageLevel = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    TopicsOfSentences = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    GrammarSection = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    ExerciseType = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    ExerciseJson = table.Column<string>(type: "jsonb", nullable: false),
                    CheckedByTeacher = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OpenFormExercises", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SuspiciousPrompts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Reason = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SuspiciousPrompts", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "ClosedAnswer_NcIx_ExerciseType",
                table: "ClosedAnswerExercises",
                column: "ExerciseType");

            migrationBuilder.CreateIndex(
                name: "OpenAnswer_NcIx_ExerciseType",
                table: "OpenAnswerExercises",
                column: "ExerciseType");

            migrationBuilder.CreateIndex(
                name: "OpenForm_NcIx_ExerciseType",
                table: "OpenFormExercises",
                column: "ExerciseType");

            migrationBuilder.CreateIndex(
                name: "SuspiciousPrompt_NcIx_Reason",
                table: "SuspiciousPrompts",
                column: "Reason");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClosedAnswerExercises");

            migrationBuilder.DropTable(
                name: "OpenAnswerExercises");

            migrationBuilder.DropTable(
                name: "OpenFormExercises");

            migrationBuilder.DropTable(
                name: "SuspiciousPrompts");
        }
    }
}
