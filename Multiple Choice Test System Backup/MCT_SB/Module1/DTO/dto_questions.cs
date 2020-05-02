using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module1.DTO
{
    public class dto_questions
    {
        public int id { get; set; }
        public string description { get; set; }
        public Nullable<float> level_of_dificult { get; set; }
        public Nullable<float> distinctiveness { get; set; }
        public string image { get; set; }
        public string statuss { get; set; }
        public int id_group_type_question { get; set; }
        public int id_part { get; set; }
    }
}
