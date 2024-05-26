using JournalMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace JournalMVC.Data
{
    public class ApplicationContextSeed
    {
        private readonly ModelBuilder _modelBuilder;

        public ApplicationContextSeed(ModelBuilder modelBuilder)
        {
            _modelBuilder = modelBuilder;
        }

        public void Seed()
        {
            _modelBuilder.Entity<TypeActivity>().HasData(
                 new TypeActivity()
                 {
                     Id = 1,
                     Name = "Спорт"
                 },
                 new TypeActivity()
                 {
                     Id = 2,
                     Name = "Чтение"
                 },
                 new TypeActivity()
                 {
                     Id = 3,
                     Name = "Путешествия"
                 },
                 new TypeActivity()
                 {
                     Id = 4,
                     Name = "Искусство"
                 },
                 new TypeActivity()
                 {
                     Id = 5,
                     Name = "Музыка"
                 },
                 new TypeActivity()
                 {
                     Id = 6,
                     Name = "Кулинария"
                 },
                 new TypeActivity()
                 {
                     Id = 7,
                     Name = "Рукоделие"
                 },
                 new TypeActivity()
                 {
                     Id = 8,
                     Name = "Обучение"
                 },
                 new TypeActivity()
                 {
                     Id = 9,
                     Name = "Фотография"
                 },
                 new TypeActivity()
                 {
                     Id = 10,
                     Name = "Развлечения"
                 }
             );

            _modelBuilder.Entity<TimeInterval>().HasData(
                 new TimeInterval()
                 {
                     Id = 1,
                     StartActivity = new TimeSpan(8, 0, 0),
                     EndActivity = new TimeSpan(9, 0, 0)
                 },
                 new TimeInterval()
                 {
                     Id = 2,
                     StartActivity = new TimeSpan(9, 0, 0),
                     EndActivity = new TimeSpan(10, 0, 0)
                 },
                 new TimeInterval()
                 {
                     Id = 3,
                     StartActivity = new TimeSpan(10, 0, 0),
                     EndActivity = new TimeSpan(11, 0, 0)
                 },
                 new TimeInterval()
                 {
                     Id = 4,
                     StartActivity = new TimeSpan(11, 0, 0),
                     EndActivity = new TimeSpan(12, 0, 0)
                 },
                 new TimeInterval()
                 {
                     Id = 5,
                     StartActivity = new TimeSpan(12, 0, 0),
                     EndActivity = new TimeSpan(13, 0, 0)
                 },
                 new TimeInterval()
                 {
                     Id = 6,
                     StartActivity = new TimeSpan(13, 0, 0),
                     EndActivity = new TimeSpan(14, 0, 0)
                 },
                 new TimeInterval()
                 {
                     Id = 7,
                     StartActivity = new TimeSpan(14, 0, 0),
                     EndActivity = new TimeSpan(15, 0, 0)
                 },
                 new TimeInterval()
                 {
                     Id = 8,
                     StartActivity = new TimeSpan(15, 0, 0),
                     EndActivity = new TimeSpan(16, 0, 0)
                 },
                 new TimeInterval()
                 {
                     Id = 9,
                     StartActivity = new TimeSpan(16, 0, 0),
                     EndActivity = new TimeSpan(17, 0, 0)
                 },
                 new TimeInterval()
                 {
                     Id = 10,
                     StartActivity = new TimeSpan(17, 0, 0),
                     EndActivity = new TimeSpan(18, 0, 0)
                 }
             );

            _modelBuilder.Entity<MonthlyRecord>().HasData(
                 new MonthlyRecord()
                 {
                     Id = 1,
                     Month = 1
                 },
                 new MonthlyRecord()
                 {
                     Id = 2,
                     Month = 2
                 },
                 new MonthlyRecord()
                 {
                     Id = 3,
                     Month = 3
                 },
                 new MonthlyRecord()
                 {
                     Id = 4,
                     Month = 4
                 },
                 new MonthlyRecord()
                 {
                     Id = 5,
                     Month = 5
                 },
                 new MonthlyRecord()
                 {
                     Id = 6,
                     Month = 6
                 },
                 new MonthlyRecord()
                 {
                     Id = 7,
                     Month = 7
                 },
                 new MonthlyRecord()
                 {
                     Id = 8,
                     Month = 8
                 },
                 new MonthlyRecord()
                 {
                     Id = 9,
                     Month = 9
                 },
                 new MonthlyRecord()
                 {
                     Id = 10,
                     Month = 10
                 },
                 new MonthlyRecord()
                 {
                     Id = 11,
                     Month = 11
                 },
                 new MonthlyRecord()
                 {
                     Id = 12,
                     Month = 12
                 }
             );

            _modelBuilder.Entity<DailyRecord>().HasData(
                new DailyRecord()
                {
                    Id = 1,
                    MonthlyRecordId = 1,
                    Day = 1
                },
                new DailyRecord()
                {
                    Id = 2,
                    MonthlyRecordId = 1,
                    Day = 15
                },
                new DailyRecord()
                {
                    Id = 3,
                    MonthlyRecordId = 1,
                    Day = 30
                },

                new DailyRecord()
                {
                    Id = 4,
                    MonthlyRecordId = 2,
                    Day = 7
                },
                new DailyRecord()
                {
                    Id = 5,
                    MonthlyRecordId = 2,
                    Day = 18
                },
                new DailyRecord()
                {
                    Id = 6,
                    MonthlyRecordId = 2,
                    Day = 28
                },

                new DailyRecord()
                {
                    Id = 7,
                    MonthlyRecordId = 3,
                    Day = 3
                },
                new DailyRecord()
                {
                    Id = 8,
                    MonthlyRecordId = 3,
                    Day = 19
                },
                new DailyRecord()
                {
                    Id = 9,
                    MonthlyRecordId = 3,
                    Day = 31
                },

                new DailyRecord()
                {
                    Id = 10,
                    MonthlyRecordId = 4,
                    Day = 5
                },
                new DailyRecord()
                {
                    Id = 11,
                    MonthlyRecordId = 4,
                    Day = 20
                },
                new DailyRecord()
                {
                    Id = 12,
                    MonthlyRecordId = 4,
                    Day = 29
                },

                new DailyRecord()
                {
                    Id = 13,
                    MonthlyRecordId = 5,
                    Day = 8
                },
                new DailyRecord()
                {
                    Id = 14,
                    MonthlyRecordId = 5,
                    Day = 16
                },
                new DailyRecord()
                {
                    Id = 15,
                    MonthlyRecordId = 5,
                    Day = 25
                },

                new DailyRecord()
                {
                    Id = 16,
                    MonthlyRecordId = 6,
                    Day = 4
                },
                new DailyRecord()
                {
                    Id = 17,
                    MonthlyRecordId = 6,
                    Day = 17
                },
                new DailyRecord()
                {
                    Id = 18,
                    MonthlyRecordId = 6,
                    Day = 27
                },
                new DailyRecord()
                {
                    Id = 19,
                    MonthlyRecordId = 7,
                    Day = 9
                },
                new DailyRecord()
                {
                    Id = 20,
                    MonthlyRecordId = 7,
                    Day = 21
                },
                new DailyRecord()
                {
                    Id = 21,
                    MonthlyRecordId = 7,
                    Day = 30
                },

                new DailyRecord()
                {
                    Id = 22,
                    MonthlyRecordId = 8,
                    Day = 6
                },
                new DailyRecord()
                {
                    Id = 23,
                    MonthlyRecordId = 8,
                    Day = 19
                },
                new DailyRecord()
                {
                    Id = 24,
                    MonthlyRecordId = 8,
                    Day = 31
                },

                new DailyRecord()
                {
                    Id = 25,
                    MonthlyRecordId = 9,
                    Day = 5
                },
                new DailyRecord()
                {
                    Id = 26,
                    MonthlyRecordId = 9,
                    Day = 18
                },
                new DailyRecord()
                {
                    Id = 27,
                    MonthlyRecordId = 9,
                    Day = 29
                },

                new DailyRecord()
                {
                    Id = 28,
                    MonthlyRecordId = 10,
                    Day = 7
                },
                new DailyRecord()
                {
                    Id = 29,
                    MonthlyRecordId = 10,
                    Day = 16
                },
                new DailyRecord()
                {
                    Id = 30,
                    MonthlyRecordId = 10,
                    Day = 27
                },

                new DailyRecord()
                {
                    Id = 31,
                    MonthlyRecordId = 11,
                    Day = 8
                },
                new DailyRecord()
                {
                    Id = 32,
                    MonthlyRecordId = 11,
                    Day = 20
                },
                new DailyRecord()
                {
                    Id = 33,
                    MonthlyRecordId = 11,
                    Day = 28
                },

                new DailyRecord()
                {
                    Id = 34,
                    MonthlyRecordId = 12,
                    Day = 3
                },
                new DailyRecord()
                {
                    Id = 35,
                    MonthlyRecordId = 12,
                    Day = 15
                },
                new DailyRecord()
                {
                    Id = 36,
                    MonthlyRecordId = 12,
                    Day = 25
                }
            );

            _modelBuilder.Entity<Activity>().HasData(
                // Активности для января
                new Activity()
                {
                    Id = 3,
                    DailyRecordId = 2,
                    TypeId = 3,
                    TimeIntervalId = 3,
                    Description = "Плавание"
                },
                new Activity()
                {
                    Id = 4,
                    DailyRecordId = 2,
                    TypeId = 4,
                    TimeIntervalId = 4,
                    Description = "Посещение выставки"
                },
                new Activity()
                {
                    Id = 5,
                    DailyRecordId = 2,
                    TypeId = 5,
                    TimeIntervalId = 5,
                    Description = "Игра на музыкальных инструментах"
                },

                new Activity()
                {
                    Id = 6,
                    DailyRecordId = 3,
                    TypeId = 6,
                    TimeIntervalId = 6,
                    Description = "Приготовление пиццы"
                },
                new Activity()
                {
                    Id = 7,
                    DailyRecordId = 3,
                    TypeId = 7,
                    TimeIntervalId = 7,
                    Description = "Вышивание крестиком"
                },

                // Активности для февраля
                new Activity()
                {
                    Id = 8,
                    DailyRecordId = 4,
                    TypeId = 8,
                    TimeIntervalId = 8,
                    Description = "Изучение нового языка"
                },
                new Activity()
                {
                    Id = 9,
                    DailyRecordId = 4,
                    TypeId = 9,
                    TimeIntervalId = 9,
                    Description = "Фотосъемка природы"
                },
                new Activity()
                {
                    Id = 10,
                    DailyRecordId = 4,
                    TypeId = 10,
                    TimeIntervalId = 10,
                    Description = "Посещение парка развлечений"
                },

                new Activity()
                {
                    Id = 11,
                    DailyRecordId = 5,
                    TypeId = 1,
                    TimeIntervalId = 1,
                    Description = "Футбол с друзьями"
                },
                new Activity()
                {
                    Id = 12,
                    DailyRecordId = 5,
                    TypeId = 2,
                    TimeIntervalId = 2,
                    Description = "Чтение стихов"
                },

                // Активности для марта
                new Activity()
                {
                    Id = 13,
                    DailyRecordId = 7,
                    TypeId = 3,
                    TimeIntervalId = 3,
                    Description = "Утренняя пробежка"
                },
                new Activity()
                {
                    Id = 14,
                    DailyRecordId = 7,
                    TypeId = 4,
                    TimeIntervalId = 4,
                    Description = "Посещение художественной галереи"
                },
                new Activity()
                {
                    Id = 15,
                    DailyRecordId = 7,
                    TypeId = 5,
                    TimeIntervalId = 5,
                    Description = "Игра на фортепиано"
                },

                new Activity()
                {
                    Id = 16,
                    DailyRecordId = 8,
                    TypeId = 6,
                    TimeIntervalId = 6,
                    Description = "Приготовление суши"
                },
                new Activity()
                {
                    Id = 17,
                    DailyRecordId = 8,
                    TypeId = 7,
                    TimeIntervalId = 7,
                    Description = "Вязание шарфа"
                },

                // Активности для апреля
                new Activity()
                {
                    Id = 18,
                    DailyRecordId = 10,
                    TypeId = 8,
                    TimeIntervalId = 8,
                    Description = "Уроки рисования"
                },
                new Activity()
                {
                    Id = 19,
                    DailyRecordId = 10,
                    TypeId = 9,
                    TimeIntervalId = 9,
                    Description = "Фотосессия в городском парке"
                },
                new Activity()
                {
                    Id = 20,
                    DailyRecordId = 10,
                    TypeId = 10,
                    TimeIntervalId = 10,
                    Description = "Посещение кинотеатра"
                },

                new Activity()
                {
                    Id = 21,
                    DailyRecordId = 11,
                    TypeId = 1,
                    TimeIntervalId = 1,
                    Description = "Баскетбол на открытом воздухе"
                },
                new Activity()
                {
                    Id = 22,
                    DailyRecordId = 11,
                    TypeId = 2,
                    TimeIntervalId = 2,
                    Description = "Чтение на скамейке в парке"
                },

                // Активности для мая
                new Activity()
                {
                    Id = 23,
                    DailyRecordId = 13,
                    TypeId = 3,
                    TimeIntervalId = 3,
                    Description = "Утренняя йога"
                },
                new Activity()
                {
                    Id = 24,
                    DailyRecordId = 13,
                    TypeId = 4,
                    TimeIntervalId = 4,
                    Description = "Посещение музея истории"
                },
                new Activity()
                {
                    Id = 25,
                    DailyRecordId = 13,
                    TypeId = 5,
                    TimeIntervalId = 5,
                    Description = "Игра на гитаре"
                },

                new Activity()
                {
                    Id = 26,
                    DailyRecordId = 14,
                    TypeId = 6,
                    TimeIntervalId = 6,
                    Description = "Приготовление салатов"
                },
                new Activity()
                {
                    Id = 27,
                    DailyRecordId = 14,
                    TypeId = 7,
                    TimeIntervalId = 7,
                    Description = "Вышивка крестом"
                },

                // Активности для июня
                new Activity()
                {
                    Id = 28,
                    DailyRecordId = 16,
                    TypeId = 8,
                    TimeIntervalId = 8,
                    Description = "Изучение программирования"
                },
                new Activity()
                {
                    Id = 29,
                    DailyRecordId = 16,
                    TypeId = 9,
                    TimeIntervalId = 9,
                    Description = "Фотосъемка городского пейзажа"
                },
                new Activity()
                {
                    Id = 30,
                    DailyRecordId = 16,
                    TypeId = 10,
                    TimeIntervalId = 10,
                    Description = "Посещение театра"
                },

                new Activity()
                {
                    Id = 31,
                    DailyRecordId = 17,
                    TypeId = 1,
                    TimeIntervalId = 1,
                    Description = "Волейбол на пляже"
                },
                new Activity()
                {
                    Id = 32,
                    DailyRecordId = 17,
                    TypeId = 2,
                    TimeIntervalId = 2,
                    Description = "Чтение комиксов"
                },

                // Активности для июля
                new Activity()
                {
                    Id = 33,
                    DailyRecordId = 19,
                    TypeId = 3,
                    TimeIntervalId = 3,
                    Description = "Утренняя пробежка по парку"
                },
                new Activity()
                {
                    Id = 34,
                    DailyRecordId = 19,
                    TypeId = 4,
                    TimeIntervalId = 4,
                    Description = "Посещение выставки современного искусства"
                },
                new Activity()
                {
                    Id = 35,
                    DailyRecordId = 19,
                    TypeId = 5,
                    TimeIntervalId = 5,
                    Description = "Игра на скрипке"
                },

                new Activity()
                {
                    Id = 36,
                    DailyRecordId = 20,
                    TypeId = 6,
                    TimeIntervalId = 6,
                    Description = "Приготовление пасты"
                },
                new Activity()
                {
                    Id = 37,
                    DailyRecordId = 20,
                    TypeId = 7,
                    TimeIntervalId = 7,
                    Description = "Вышивание ковра"
                },

                // Активности для августа
                new Activity()
                {
                    Id = 38,
                    DailyRecordId = 22,
                    TypeId = 8,
                    TimeIntervalId = 8,
                    Description = "Изучение фотографии"
                },
                new Activity()
                {
                    Id = 39,
                    DailyRecordId = 22,
                    TypeId = 9,
                    TimeIntervalId = 9,
                    Description = "Фотосессия на природе"
                },
                new Activity()
                {
                    Id = 40,
                    DailyRecordId = 22,
                    TypeId = 10,
                    TimeIntervalId = 10,
                    Description = "Поход в аквапарк"
                },

                new Activity()
                {
                    Id = 41,
                    DailyRecordId = 23,
                    TypeId = 1,
                    TimeIntervalId = 1,
                    Description = "Футбольный матч с коллегами"
                },
                new Activity()
                {
                    Id = 42,
                    DailyRecordId = 23,
                    TypeId = 2,
                    TimeIntervalId = 2,
                    Description = "Чтение журнала в кафе"
                },

                // Активности для сентября
                new Activity()
                {
                    Id = 43,
                    DailyRecordId = 25,
                    TypeId = 3,
                    TimeIntervalId = 3,
                    Description = "Утренний забег по парку"
                },
                new Activity()
                {
                    Id = 44,
                    DailyRecordId = 25,
                    TypeId = 4,
                    TimeIntervalId = 4,
                    Description = "Посещение галереи современного искусства"
                },
                new Activity()
                {
                    Id = 45,
                    DailyRecordId = 25,
                    TypeId = 5,
                    TimeIntervalId = 5,
                    Description = "Игра на фортепиано"
                },

                new Activity()
                {
                    Id = 46,
                    DailyRecordId = 26,
                    TypeId = 6,
                    TimeIntervalId = 6,
                    Description = "Приготовление суши дома"
                },
                new Activity()
                {
                    Id = 47,
                    DailyRecordId = 26,
                    TypeId = 7,
                    TimeIntervalId = 7,
                    Description = "Вышивание картины по номерам"
                },

                // Активности для октября
                new Activity()
                {
                    Id = 48,
                    DailyRecordId = 28,
                    TypeId = 8,
                    TimeIntervalId = 8,
                    Description = "Изучение истории искусства"
                },
                new Activity()
                {
                    Id = 49,
                    DailyRecordId = 28,
                    TypeId = 9,
                    TimeIntervalId = 9,
                    Description = "Фотосессия в парке осенних красок"
                },
                new Activity()
                {
                    Id = 50,
                    DailyRecordId = 28,
                    TypeId = 10,
                    TimeIntervalId = 10,
                    Description = "Поход в кино на новый фильм"
                },

                new Activity()
                {
                    Id = 51,
                    DailyRecordId = 29,
                    TypeId = 1,
                    TimeIntervalId = 1,
                    Description = "Волейбол на пляже с друзьями"
                },
                new Activity()
                {
                    Id = 52,
                    DailyRecordId = 29,
                    TypeId = 2,
                    TimeIntervalId = 2,
                    Description = "Чтение книги в парке"
                },

                // Активности для ноября
                new Activity()
                {
                    Id = 53,
                    DailyRecordId = 31,
                    TypeId = 3,
                    TimeIntervalId = 3,
                    Description = "Утренняя пробежка в парке"
                },
                new Activity()
                {
                    Id = 54,
                    DailyRecordId = 31,
                    TypeId = 4,
                    TimeIntervalId = 4,
                    Description = "Посещение музея истории города"
                },
                new Activity()
                {
                    Id = 55,
                    DailyRecordId = 31,
                    TypeId = 5,
                    TimeIntervalId = 5,
                    Description = "Игра на пианино"
                },

                new Activity()
                {
                    Id = 56,
                    DailyRecordId = 32,
                    TypeId = 6,
                    TimeIntervalId = 6,
                    Description = "Приготовление горячего шоколада"
                },
                new Activity()
                {
                    Id = 57,
                    DailyRecordId = 32,
                    TypeId = 7,
                    TimeIntervalId = 7,
                    Description = "Вышивание картины крестиком"
                },

                // Активности для декабря
                new Activity()
                {
                    Id = 58,
                    DailyRecordId = 34,
                    TypeId = 8,
                    TimeIntervalId = 8,
                    Description = "Изучение астрономии"
                },
                new Activity()
                {
                    Id = 59,
                    DailyRecordId = 34,
                    TypeId = 9,
                    TimeIntervalId = 9,
                    Description = "Ночная фотосъемка звездного неба"
                },
                new Activity()
                {
                    Id = 60,
                    DailyRecordId = 34,
                    TypeId = 10,
                    TimeIntervalId = 10,
                    Description = "Посещение концерта классической музыки"
                },

                new Activity()
                {
                    Id = 61,
                    DailyRecordId = 35,
                    TypeId = 1,
                    TimeIntervalId = 1,
                    Description = "Футбол на стадионе"
                },
                new Activity()
                {
                    Id = 62,
                    DailyRecordId = 35,
                    TypeId = 2,
                    TimeIntervalId = 2,
                    Description = "Чтение книги у камина"
                }

            );
        }

    }
}
