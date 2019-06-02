using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace JPGZService.GetQuestion
{
    [Table("tb_Questions_ErrorCount")]
    public class Questions_ErrorCount : Entity
    {
        public int QuestionId { get; set; }
        public int AnswerUer { get; set; }
        public DateTime AnswerTime { get; set; }

    }
}
