using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module1.DTO
{
    public class dto_Result
    {
        public int id { get; set; }
        public Nullable<int> total_score { get; set; }
        public int id_exam_code { get; set; }
        public int id_candidate { get; set; }
    }
}