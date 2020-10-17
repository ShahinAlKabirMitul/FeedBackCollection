using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FeedBackCollection.Entities.Model
{
   public class Post
    {
        [Column("PostsId")] 
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Post  is a required field.")]
        public string Name { get; set; }

        public string CreatedBy { get; set; }

        public DateTime CreatedDate { get; set; }

        public ICollection<Comment> Comments { get; set; }

    }
}
