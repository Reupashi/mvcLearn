using ClassroomsInfo.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassroomsInfo.Web.tests_navigation.Tests.Controller
{
  public static class TestClassroomsData
  {
    public static List<Classroom> Objects = new List<Classroom>
        {
            new Classroom() {
            Name = "Лабораторія",
            ProfessorName = "Ігнатьєв В'ячеслав Робертович",
            },
            new Classroom()
            {
             Name = "Навчальна аудиторія",
             ProfessorName = "Фомічова Агнеса Наумівна",
            },
            new Classroom()
            {
                Name = "Лабораторія ",
                ProfessorName = "Рябова Весняна Михайлівна",
            },
            new Classroom() {
            Name = "Приёмное отделение",
            ProfessorName = "Ігнатьєв В'ячеслав Робертович",
            },
            new Classroom() {
            Name = "Приёмное отделение",
            ProfessorName = "Василий В'ячеслав Робертович",
            },
        };
       
    }
}
