using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace JournalMVC.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MonthlyRecords",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Month = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MonthlyRecords", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TimeIntervals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartActivity = table.Column<TimeSpan>(type: "time", nullable: false),
                    EndActivity = table.Column<TimeSpan>(type: "time", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimeIntervals", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TypeActivities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeActivities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DailyRecords",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Day = table.Column<int>(type: "int", nullable: false),
                    MonthlyRecordId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DailyRecords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DailyRecords_MonthlyRecords_MonthlyRecordId",
                        column: x => x.MonthlyRecordId,
                        principalTable: "MonthlyRecords",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Activities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeId = table.Column<int>(type: "int", nullable: false),
                    TimeIntervalId = table.Column<int>(type: "int", nullable: false),
                    DailyRecordId = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Activities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Activities_DailyRecords_DailyRecordId",
                        column: x => x.DailyRecordId,
                        principalTable: "DailyRecords",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Activities_TimeIntervals_TimeIntervalId",
                        column: x => x.TimeIntervalId,
                        principalTable: "TimeIntervals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Activities_TypeActivities_TypeId",
                        column: x => x.TypeId,
                        principalTable: "TypeActivities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "MonthlyRecords",
                columns: new[] { "Id", "Month" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 },
                    { 3, 3 },
                    { 4, 4 },
                    { 5, 5 },
                    { 6, 6 },
                    { 7, 7 },
                    { 8, 8 },
                    { 9, 9 },
                    { 10, 10 },
                    { 11, 11 },
                    { 12, 12 }
                });

            migrationBuilder.InsertData(
                table: "TimeIntervals",
                columns: new[] { "Id", "EndActivity", "StartActivity" },
                values: new object[,]
                {
                    { 1, new TimeSpan(0, 9, 0, 0, 0), new TimeSpan(0, 8, 0, 0, 0) },
                    { 2, new TimeSpan(0, 10, 0, 0, 0), new TimeSpan(0, 9, 0, 0, 0) },
                    { 3, new TimeSpan(0, 11, 0, 0, 0), new TimeSpan(0, 10, 0, 0, 0) },
                    { 4, new TimeSpan(0, 12, 0, 0, 0), new TimeSpan(0, 11, 0, 0, 0) },
                    { 5, new TimeSpan(0, 13, 0, 0, 0), new TimeSpan(0, 12, 0, 0, 0) },
                    { 6, new TimeSpan(0, 14, 0, 0, 0), new TimeSpan(0, 13, 0, 0, 0) },
                    { 7, new TimeSpan(0, 15, 0, 0, 0), new TimeSpan(0, 14, 0, 0, 0) },
                    { 8, new TimeSpan(0, 16, 0, 0, 0), new TimeSpan(0, 15, 0, 0, 0) },
                    { 9, new TimeSpan(0, 17, 0, 0, 0), new TimeSpan(0, 16, 0, 0, 0) },
                    { 10, new TimeSpan(0, 18, 0, 0, 0), new TimeSpan(0, 17, 0, 0, 0) }
                });

            migrationBuilder.InsertData(
                table: "TypeActivities",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Спорт" },
                    { 2, "Чтение" },
                    { 3, "Путешествия" },
                    { 4, "Искусство" },
                    { 5, "Музыка" },
                    { 6, "Кулинария" },
                    { 7, "Рукоделие" },
                    { 8, "Обучение" },
                    { 9, "Фотография" },
                    { 10, "Развлечения" }
                });

            migrationBuilder.InsertData(
                table: "DailyRecords",
                columns: new[] { "Id", "Day", "MonthlyRecordId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 15, 1 },
                    { 3, 30, 1 },
                    { 4, 7, 2 },
                    { 5, 18, 2 },
                    { 6, 28, 2 },
                    { 7, 3, 3 },
                    { 8, 19, 3 },
                    { 9, 31, 3 },
                    { 10, 5, 4 },
                    { 11, 20, 4 },
                    { 12, 29, 4 },
                    { 13, 8, 5 },
                    { 14, 16, 5 },
                    { 15, 25, 5 },
                    { 16, 4, 6 },
                    { 17, 17, 6 },
                    { 18, 27, 6 },
                    { 19, 9, 7 },
                    { 20, 21, 7 },
                    { 21, 30, 7 },
                    { 22, 6, 8 },
                    { 23, 19, 8 },
                    { 24, 31, 8 },
                    { 25, 5, 9 },
                    { 26, 18, 9 },
                    { 27, 29, 9 },
                    { 28, 7, 10 },
                    { 29, 16, 10 },
                    { 30, 27, 10 },
                    { 31, 8, 11 },
                    { 32, 20, 11 },
                    { 33, 28, 11 },
                    { 34, 3, 12 },
                    { 35, 15, 12 },
                    { 36, 25, 12 }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "DailyRecordId", "Description", "TimeIntervalId", "TypeId" },
                values: new object[,]
                {
                    { 3, 2, "Плавание", 3, 3 },
                    { 4, 2, "Посещение выставки", 4, 4 },
                    { 5, 2, "Игра на музыкальных инструментах", 5, 5 },
                    { 6, 3, "Приготовление пиццы", 6, 6 },
                    { 7, 3, "Вышивание крестиком", 7, 7 },
                    { 8, 4, "Изучение нового языка", 8, 8 },
                    { 9, 4, "Фотосъемка природы", 9, 9 },
                    { 10, 4, "Посещение парка развлечений", 10, 10 },
                    { 11, 5, "Футбол с друзьями", 1, 1 },
                    { 12, 5, "Чтение стихов", 2, 2 },
                    { 13, 7, "Утренняя пробежка", 3, 3 },
                    { 14, 7, "Посещение художественной галереи", 4, 4 },
                    { 15, 7, "Игра на фортепиано", 5, 5 },
                    { 16, 8, "Приготовление суши", 6, 6 },
                    { 17, 8, "Вязание шарфа", 7, 7 },
                    { 18, 10, "Уроки рисования", 8, 8 },
                    { 19, 10, "Фотосессия в городском парке", 9, 9 },
                    { 20, 10, "Посещение кинотеатра", 10, 10 },
                    { 21, 11, "Баскетбол на открытом воздухе", 1, 1 },
                    { 22, 11, "Чтение на скамейке в парке", 2, 2 },
                    { 23, 13, "Утренняя йога", 3, 3 },
                    { 24, 13, "Посещение музея истории", 4, 4 },
                    { 25, 13, "Игра на гитаре", 5, 5 },
                    { 26, 14, "Приготовление салатов", 6, 6 },
                    { 27, 14, "Вышивка крестом", 7, 7 },
                    { 28, 16, "Изучение программирования", 8, 8 },
                    { 29, 16, "Фотосъемка городского пейзажа", 9, 9 },
                    { 30, 16, "Посещение театра", 10, 10 },
                    { 31, 17, "Волейбол на пляже", 1, 1 },
                    { 32, 17, "Чтение комиксов", 2, 2 },
                    { 33, 19, "Утренняя пробежка по парку", 3, 3 },
                    { 34, 19, "Посещение выставки современного искусства", 4, 4 },
                    { 35, 19, "Игра на скрипке", 5, 5 },
                    { 36, 20, "Приготовление пасты", 6, 6 },
                    { 37, 20, "Вышивание ковра", 7, 7 },
                    { 38, 22, "Изучение фотографии", 8, 8 },
                    { 39, 22, "Фотосессия на природе", 9, 9 },
                    { 40, 22, "Поход в аквапарк", 10, 10 },
                    { 41, 23, "Футбольный матч с коллегами", 1, 1 },
                    { 42, 23, "Чтение журнала в кафе", 2, 2 },
                    { 43, 25, "Утренний забег по парку", 3, 3 },
                    { 44, 25, "Посещение галереи современного искусства", 4, 4 },
                    { 45, 25, "Игра на фортепиано", 5, 5 },
                    { 46, 26, "Приготовление суши дома", 6, 6 },
                    { 47, 26, "Вышивание картины по номерам", 7, 7 },
                    { 48, 28, "Изучение истории искусства", 8, 8 },
                    { 49, 28, "Фотосессия в парке осенних красок", 9, 9 },
                    { 50, 28, "Поход в кино на новый фильм", 10, 10 },
                    { 51, 29, "Волейбол на пляже с друзьями", 1, 1 },
                    { 52, 29, "Чтение книги в парке", 2, 2 },
                    { 53, 31, "Утренняя пробежка в парке", 3, 3 },
                    { 54, 31, "Посещение музея истории города", 4, 4 },
                    { 55, 31, "Игра на пианино", 5, 5 },
                    { 56, 32, "Приготовление горячего шоколада", 6, 6 },
                    { 57, 32, "Вышивание картины крестиком", 7, 7 },
                    { 58, 34, "Изучение астрономии", 8, 8 },
                    { 59, 34, "Ночная фотосъемка звездного неба", 9, 9 },
                    { 60, 34, "Посещение концерта классической музыки", 10, 10 },
                    { 61, 35, "Футбол на стадионе", 1, 1 },
                    { 62, 35, "Чтение книги у камина", 2, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Activities_DailyRecordId",
                table: "Activities",
                column: "DailyRecordId");

            migrationBuilder.CreateIndex(
                name: "IX_Activities_TimeIntervalId",
                table: "Activities",
                column: "TimeIntervalId");

            migrationBuilder.CreateIndex(
                name: "IX_Activities_TypeId",
                table: "Activities",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_DailyRecords_MonthlyRecordId",
                table: "DailyRecords",
                column: "MonthlyRecordId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Activities");

            migrationBuilder.DropTable(
                name: "DailyRecords");

            migrationBuilder.DropTable(
                name: "TimeIntervals");

            migrationBuilder.DropTable(
                name: "TypeActivities");

            migrationBuilder.DropTable(
                name: "MonthlyRecords");
        }
    }
}
