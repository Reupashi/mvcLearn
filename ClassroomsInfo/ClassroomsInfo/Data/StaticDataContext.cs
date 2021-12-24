using System;
using System.Collections.Generic;
using ClassroomsInfo.Entities;

namespace ClassroomsInfo.Data
{
    public static partial class StaticDataContext
    {

        public static List<Classroom> classrooms;
        public static List<ProfessorName> professorsNames;

        static StaticDataContext()
        {
            CreateTestingData();
            
        }

        public static void CreateTestingData()
        {
            CreateNewProfessor(" g ");
            CreateProfessors();
            CreateClassrooms();
        }

        private static void CreateClassrooms()
        {
            classrooms = new List<Classroom>
        {
            new Classroom()
            {
                Id = 1,
                Number = 102,
                TypeName = "Лабораторія Куликова",
                Name = "Лабораторія",
                Seats = 50,
                Note = "Лабортаторія для проведення лабораторних робіт на велику кількість аудиторії",
                ProfessorName = "Ігнатьєв В'ячеслав Робертович",
            },
            new Classroom()
            {
                Id = 2,
                Number = 401,
                TypeName = "Аудиторія Куликова",
                Name = "Навчальна аудиторія",
                Seats = 72,
                Note = "Потокова аудиторія для читання лекціій",
                ProfessorName = "Фомічова Агнеса Наумівна",
            },
            new Classroom()
            {
                Id = 3,
                Number = 419,
                TypeName = "Лабораторія Соколовського",
                Name = "Лабораторія",
                Seats = 50,
                Note = "Лабортаторія для проведення лабораторних робіт на велику кількість аудиторії",
                ProfessorName = "Рябова Весняна Михайлівна",
            },
            new Classroom()
            {
                Id = 4,
                Number = 214,
                TypeName = "Аудиторія Стрілецького",
                Name = "Навчальна аудиторія",
                Seats = 31,
                Note = "Звичайна аудиторія для читання лекціій 1 групи",
                ProfessorName = "Гришин Нінель Мелсовіч",
            },
            new Classroom()
            {
                Id = 5,
                Number = 256,
                TypeName = "Лабораторія Іванова",
                Name = "Лабораторія ",
                Seats = 41,
                Note = "Лабортаторія для проведення лабораторних робіт на велику кількість аудиторії",
                ProfessorName = "Павлов Донат Максович",
            },
            new Classroom()
            {
                Id = 6,
                Number = 362,
                TypeName = "Аудиторія Смірнова",
                Name = "Навчальна аудиторія",
                Seats = 27,
                Note = "Звичайна аудиторія для читання лекціій 1 групи",
                ProfessorName = "Павлов Донат Максович",
            },
            new Classroom()
            {
                Id = 7,
                Number = 127,
                TypeName = "Лабораторія Кузніцова",
                Name = "Лабораторія ",
                Seats = 25,
                Note = "Лабортаторія для проведення лабораторних робіт для 1 групи",
                ProfessorName = "Павлов Донат Максович",
            },
            new Classroom()
            {
                Id = 8,
                Number = 173,
                TypeName = "Аудиторія Попова",
                Name = "Навчальна аудиторія",
                Seats = 41,
                Note = "Потокова аудиторія для читання лекціій",
                ProfessorName = "Павлов Донат Максович",
            },
            new Classroom()
            {
                Id = 9,
                Number = 147,
                TypeName = "Лабораторія Петрова",
                Name = "Лабораторія",
                Seats = 52,
                Note = "Лабортаторія для проведення лабораторних робіт на велику кількість аудиторії",
                ProfessorName = "Рябова Весняна Михайлівна",
            },
            new Classroom()
            {
                Id = 10,
                Number = 425,
                TypeName = "Аудиторія Соколова",
                Name = "Навчальна аудиторія ",
                Seats = 63,
                Note = "Потокова аудиторія для читання лекціій",
                ProfessorName = "Гришин Нінель Мелсовіч",
            },
            new Classroom()
            {
                Id = 11,
                Number = 384,
                TypeName = "Лабораторія Михайлова",
                Name = "Лабораторія ",
                Seats = 34,
                Note = "Лабортаторія для проведення лабораторних робіт для 1 групи",
                ProfessorName = "Фомічова Агнеса Наумівна",
            },
        };

           

        }
        public static void CreateNewProfessor(string newName)
        {
            professorsNames = new List<ProfessorName> {
                new ProfessorName() {
                    NameP = newName,

                }, };
        }
        private static void CreateProfessors()
        {
            professorsNames = new List<ProfessorName> {
                new ProfessorName() {
                    Id = 1,
                    NameP = "Ігнатьєв В'ячеслав Робертович",
                    PhoneNumber = "0975369855",

                },
                new ProfessorName(){
                    Id = 2,
                    NameP = "Фомічова Агнеса Наумівна",
                    PhoneNumber = "978132423",
                },
                new ProfessorName(){
                    Id = 3,
                    NameP = "Рябова Весняна Михайлівна",

                    PhoneNumber = "0968554988",
                    Note = "54 роки",
                },
                new ProfessorName(){
                    Id = 4,
                    NameP = "Гришин Нінель Мелсовіч",
                    PhoneNumber = "0534689548",
                },
                new ProfessorName() {
                    Id = 5,
                    NameP = "Павлов Донат Максович",
                    PhoneNumber = "986044459",
                },
                new ProfessorName() {
                    Id = 6,
                    NameP = "Котова Маргарита Мартинівна",
                    PhoneNumber = "0972684596",
                },
                

            };
        }

    }

}

