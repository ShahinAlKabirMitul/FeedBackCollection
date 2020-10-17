using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FeedBackCollection.Entities.Model
{
   public class Comment
    {
        [Column("CommentId")]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Comment  is a required field.")]
        public string Name { get; set; }

        public string CreatedBy { get; set; }

        public DateTime CreatedDate { get; set; }

        public int NoOfLike { get; set; }

        public int NoOfDislike { get; set; }

        [ForeignKey(nameof(Post))] 
        public Guid PostId { get; set; }

        public Post Post { get; set; }
    }
}
