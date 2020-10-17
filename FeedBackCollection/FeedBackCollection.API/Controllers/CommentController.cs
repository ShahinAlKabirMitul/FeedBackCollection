using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts;
using FeedBackCollection.Entities.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FeedBackCollection.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : BaseController
    {
        private readonly IRepositoryManager _repository;

        public CommentController(IRepositoryManager repository)
        {
            _repository = repository;
        }

        //[HttpGet]
        //public IActionResult GetComments([FromQuery] string keyword, [FromQuery] int pageNo, [FromQuery] int pageSize)
        //{

        //    try
        //    {
        //        var posts = _repository.Post.GetAllPosts(keyword, pageNo, pageSize, false);
        //        return OkResult(posts);
        //    }
        //    catch (Exception ex)
        //    {

        //        return ExceptionResult(ex);
        //    }
        //}


        [HttpPut]
       
        public IActionResult UpdateRating([FromQuery] Guid id, [FromQuery]  bool isLike, [FromQuery] string user)
        {
            try
            {

                var vote= _repository.Vote.FindVote(id, user);
                if (vote==null)
                {
                    Vote newVote=new Vote();
                    newVote.CreatedBy = user;
                    newVote.CommentId = id;
                    newVote.CreatedDate=DateTime.Now;
                    newVote.IsLike = isLike;
                    _repository.Vote.CreateVote(newVote);
                    _repository.Comment.UpdateRating(id, isLike);

                }
                else
                {
                    if (vote.IsLike!=isLike)
                    {
                        vote.IsLike = isLike;
                        _repository.Vote.UpdateVote(vote);
                        _repository.Comment.UpdateRating(id, isLike,true);
                    }
                    else
                    {
                        return ExceptionResult(new Exception("Vote already given"));
                    }
                }

               


                var result = _repository.Save();
                return OkResult(result);
            }
            catch (Exception ex)
            {

                return ExceptionResult(ex);
            }
        }


        [HttpPost]
        [ActionName("CreateComment")]
        public IActionResult CreatePost([FromBody] Comment comment)
        {
            try
            {
                if (comment == null)
                {

                    return BadRequest("Comment object is null");
                }

                LogInfo info = new LogInfo();
                info.TaskName = "Comment";
                info.CreatedBy = comment.CreatedBy;
                info.CreatedDate = DateTime.Now;
                _repository.Log.LogInfo(info);

                _repository.Comment.CreateCommentForPost(comment);


                _repository.Save();
                return OkResult(comment);
            }
            catch (Exception ex)
            {

                return ExceptionResult(ex);
            }
        }
    }
}
