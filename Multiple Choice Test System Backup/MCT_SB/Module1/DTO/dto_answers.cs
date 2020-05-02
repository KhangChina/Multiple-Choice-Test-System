using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module1.DTO
{
    public class dto_answers
    {
        public int id { get; set; }
        public string description { get; set; }
        public Nullable<float> jamming_level { get; set; }
        public bool statuss { get; set; }
        public int id_question { get; set; }
    }
}
