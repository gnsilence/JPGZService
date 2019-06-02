using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace JPGZService.GetQuestion
{
    [Table("tb_Questions_AnswerCount")]
    public class Questions_AnswerCount : Entity
    {
        public int QuestionId { get; set; }

        public int AnswerCount { get; set; }

        public int ErrorCount { get; set; }
    }
}
