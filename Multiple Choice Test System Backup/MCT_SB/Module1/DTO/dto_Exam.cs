using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module1.DTO
{
    public class dto_Exam
    {
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string create_at { get; set; }
        public int create_by { get; set; }
        public Nullable<int> approve_by { get; set; }
        public string time_limit { get; set; }
        public Nullable<float> Reliability { get; set; }
        public Nullable<float> level_of_dificult { get; set; }
        public string exam_date { get; set; }
        public string start_time { get; set; }
        public string end_time { get; set; }
        public string statuss { get; set; }
    }
}