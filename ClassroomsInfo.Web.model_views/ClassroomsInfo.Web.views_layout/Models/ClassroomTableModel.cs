using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using ClassroomsInfo.Entities;


namespace ClassroomsInfo.Web.Models
{
    public class ClassroomTableModel
    {
        public int Id { get; set; }

        [Display(Name = "Номер Аудиторії")]
        public int? Number { get; set; }

        [Display(Name = "Імя професора")]
        public string ProfessorName { get; set; }

        [Display(Name = "Тип аудиторії")]
        public string TypeName { get; set; }

        [Display(Name = "Кількість місць")]
        public int? Seats { get; set; }

        [Display(Name = "Кількість місць")]
        public string Name { get; set; }

        [Display(Name = "Примітка")]
        public string Note { get; set; }

        [ScaffoldColumn(false)]
        public bool HasInfo { get; set; }

        public string[] Info { get; private set; }
        public double Area { get; internal set; }

        private static string[] CreateInfo(Classroom obj)
        {
            string s = null;
            if (!string.IsNullOrWhiteSpace(obj.Note))
            {
                s += "Примітка: " + obj.Note + "\n";
            }
            if (!string.IsNullOrWhiteSpace(obj.Note))
            {
                s += "Опис\n" + obj.Note;
            }
            string[] info = null;
            if (s != null)
            {
                info = s.Split(new[] { '\n' },
                    StringSplitOptions.RemoveEmptyEntries).ToArray();
            }
            return info;
        }

        public static explicit operator ClassroomTableModel(Classroom obj)
        {
            return new ClassroomTableModel()
            {
                Id = obj.Id,
                Number = obj.Number,
                TypeName = obj.TypeName,
                Name = obj.Name,
                Seats = obj.Seats,
                ProfessorName = obj.ProfessorName,
                Note = obj.Note,
                HasInfo = !string.IsNullOrWhiteSpace(obj.Note),
                Info = CreateInfo(obj),
            };
        }
    }
}
   