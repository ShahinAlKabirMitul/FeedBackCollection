using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FeedBackCollection.Entities.Model;

namespace FeedBackCollection.API.Model
{
    public class CommentVM:IMapFrom<Comment>
    {
      
        public Guid Id { get; set; }

     
        public string Name { get; set; }

        public string CreatedBy { get; set; }

        public DateTime CreatedDate { get; set; }

        public int NoOfLike { get; set; }

        public int NoOfDislike { get; set; }

     
        public Guid PostId { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Comment, CommentVM>();
        }

       
    }
}
