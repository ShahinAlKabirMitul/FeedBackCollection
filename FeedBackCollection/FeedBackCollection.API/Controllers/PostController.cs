using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Contracts;
using FeedBackCollection.API.Model;
using FeedBackCollection.Entities.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FeedBackCollection.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : BaseController
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;

        public PostController(IRepositoryManager repository,IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [ActionName("GetPosts")]
        public IActionResult GetPosts([FromQuery]string keyword="",[FromQuery]int pageNo=1,[FromQuery]int pageSize=Int32.MaxValue)
        {

            try
            {
                var posts = _repository.Post.GetAllPosts(keyword,pageNo,pageSize,false).ToList();
               
                return OkResult(posts);
            }
            catch (Exception ex)
            {

                return ExceptionResult(ex);
            }
        }


        [HttpPost]
        [ActionName("CreatePost")]
        public IActionResult CreatePost([FromBody] Post post)
        {
            try
            {
                if (post == null)
                {

                    return BadRequest("post object is null");
                }

                _repository.Post.CreatePost(post);

                LogInfo info=new LogInfo();
                info.TaskName = "Post";
                info.CreatedBy = post.CreatedBy;
                info.CreatedDate=DateTime.Now;
                _repository.Log.LogInfo(info);
                _repository.Save();
                return OkResult(post);
            }
            catch (Exception ex)
            {

                return ExceptionResult(ex);
            }
        }


    }
}
