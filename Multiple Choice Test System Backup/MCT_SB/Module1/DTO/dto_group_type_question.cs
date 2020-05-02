using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module1.DTO
{
    public class dto_group_type_question
    {
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string image { get; set; }
        public string statuss { get; set; }
        public int id_type_question { get; set; }
    }
}
