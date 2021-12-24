using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassroomsInfo.Entities
{
   public class Classroom
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public string TypeName { get; set; }
        public string Name { get; set; }
        public int? Seats { get; set; }
        public string Note { get; set; }
        public string ProfessorName { get; set; }
    }
}
 