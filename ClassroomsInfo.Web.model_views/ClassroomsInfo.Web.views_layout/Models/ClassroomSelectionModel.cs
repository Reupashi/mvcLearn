using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using ClassroomsInfo.Entities;

namespace ClassroomsInfo.Web.views_layout.Models
{
    public class ClassroomSelectionModel
    {
        public int Id { get; set; }

        [Display(Name = "Номера аудиторії")] //анотація відображення даних Display
        public int Number { get; set; }

        [Display(Name = "Імя професора")]
        public string ProfessorName { get; set; }

        [Display(Name = "Площа, кв. м")]
        public string TypeName { get; set; }

        [Display(Name = "Ціна у $")]
        public int? Seats { get; set; }

        public static explicit operator ClassroomSelectionModel(Classroom obj)
        {
            return new ClassroomSelectionModel()
            {
                Id = obj.Id,
                Number = obj.Number,
                ProfessorName = obj.ProfessorName,
                TypeName = obj.TypeName,
                Seats = obj.Seats,
            };
        }
    }
}