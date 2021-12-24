using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ClassroomsInfo.Entities;
using System.ComponentModel.DataAnnotations;

namespace ClassroomsInfo.Web.views_layout.Models
{
    public class ClassroomEditingModel
    {
        public int Id { get; set; }
       
        [Display(Name = "Номер аудиторії")]
        [Required(ErrorMessage = "Потрібно заповнити поле \'Номер аудиторії\'")]
        [StringLength(70, MinimumLength = 1,
             ErrorMessage = "Номер аудиторії "
             + "повинна містити від 1 до 70 символів")]

        public int Number { get; set; }

        [Display(Name = "Ім'я професора")]
        public string ProfessorName { get; set; }

        [Display(Name = "Тип аудиторії")]
        public string TypeName { get; set; }

        [Display(Name = "Кількість місць")]
        [Range(0.1, 1000, ErrorMessage = "Значенння площі "
            + "повинно бути в межах від 25 до 72")]
        public int? Seats { get; set; }

        [Display(Name = "Примітка")]
        public string Note { get; set; }


        public static explicit operator ClassroomEditingModel(Classroom obj)
        {
            return new ClassroomEditingModel()
            {
                Id = obj.Id,
                Number = obj.Number,
                ProfessorName = obj.ProfessorName,
                TypeName = obj.TypeName,
                Seats = obj.Seats,
                Note = obj.Note,
               
            };
        }

        public static explicit operator Classroom(ClassroomEditingModel obj)
        {
            return new Classroom()
            {
                Id = obj.Id,
                Number = obj.Number,
                ProfessorName = obj.ProfessorName,
                TypeName = obj.TypeName,
                Seats = obj.Seats,
                Note = obj.Note,
            };
        }
    }
}