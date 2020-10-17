using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FeedBackCollection.Entities.Model;

namespace FeedBackCollection.API.Model
{
    public class PostVM:IMapFrom<Post>
    {
        
        public Guid Id { get; set; }

       
        public string Name { get; set; }

        public string CreatedBy { get; set; }

        public DateTime CreatedDate { get; set; }

        //public List<CommentVM> Comments { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Post, PostVM>();
            profile.CreateMap<PostVM, Post>();
            //profile.CreateMap<Post, PostVM>().ForMember(dest => dest.Comments, opt => opt.MapFrom(src =>
            //    src.Comments));




        }

    }
}
