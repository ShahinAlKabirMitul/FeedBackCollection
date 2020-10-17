using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FeedBackCollection.Entities.Model
{
   public class Vote
    {
        [Column("VoteId")]
        public Guid Id { get; set; }

       
        public string CreatedBy { get; set; }

        public DateTime CreatedDate { get; set; }

        public bool IsLike { get; set; }

      

        [ForeignKey(nameof(Comment))]
        public Guid CommentId { get; set; }

        public Comment Comment { get; set; }
    }
}
