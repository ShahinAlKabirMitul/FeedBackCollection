using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FeedBackCollection.Entities.Model
{
  public  class LogInfo
    {
        [Column("LogId")]
        public Guid Id { get; set; }

        public string TaskName { get; set; }
        public string CreatedBy { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}
