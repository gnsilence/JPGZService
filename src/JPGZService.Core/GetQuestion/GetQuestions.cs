using System;
using System.Collections.Generic;
using System.Text;

namespace JPGZService.GetQuestion
{
 public   class GetQuestions
    {
        public int ID { get; set; }
        public int Subject { get; set; }
        public string PgName { get; set; }
        public string PgCreateUser { get; set; }
        public DateTime AddTime { get; set; }
        public int MCCount { get; set; }
        public int MCFraction { get; set; }
        public int MCQCount { get; set; }
        public int MCQFraction { get; set; }
        public int JudgmentCount { get; set; }
        public int JudgmentFraction { get; set; }
        public int TrainIsPassFration { get; set; }
        public int PageDuration { get; set; }
    }
}
