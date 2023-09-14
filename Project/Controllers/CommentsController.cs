using Microsoft.AspNetCore.Mvc;
using Project.Data;
using Project.DTOs;
using Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;

namespace Project.Controllers
{

    [Route("api")]
    [ApiController]
    public class CommentsController : Controller
    {
        private readonly ICommentsRepo _repository;
        public CommentsController(ICommentsRepo repository)
        {
            _repository = repository;

        }

        public ActionResult<CommentOutDto> GetComment(int id)
        {
            comments c = _repository.GetCommentsByID(id);
            CommentOutDto comment = new CommentOutDto { Comment = c.Comment, Name = c.Name, ID = c.ID, Time = c.Time, IP = c.IP };
            return Ok(comment);
        }

        [HttpPost("WriteComment")]
        public string AddComment(CommentInputDto comment)
        //public string AddComment(CommentInputDto comment)
        {
            var ip = Request.HttpContext.Connection.RemoteIpAddress.ToString();
            var time = DateTime.Now.ToString("dd/MM/yyyy hh:mm tt");
            if (string.IsNullOrWhiteSpace(comment.Name))
            {
                comment.Name = "UNKNOWN";
            }
            //var time = DateTime.Now.ToString("hh:mm:ss tt");
            comments c = new comments { Comment = comment.Comment, Name = comment.Name,Time = time, IP = ip};
            comments addedComment = _repository.AddComment(c);
            CommentOutDto co = new CommentOutDto { ID = addedComment.ID, Name = addedComment.Name, Comment = addedComment.Comment, Time = addedComment.Time, IP = addedComment.IP};
            return comment.Comment;
            //return Ok(addedComment);
           // return Ok(co);
        }
        [HttpGet("GetComments")]
        public ContentResult GetComments()
        {
            string s = "";
            IEnumerable<comments> comment = _repository.GetAllComments();
            IEnumerable<CommentOutDto> c = comment.Select(e => new CommentOutDto
            {
                Name = e.Name,
                Comment = e.Comment
            });
            int cLength = c.Count();
            int reqLength = cLength - 5;
            int cnt = 0;
            string newString = "";
            foreach (CommentOutDto i in c)
            {
                if (cnt >= reqLength)
                {
                    if (i.Name == "UNKNOWN")
                    {
                        newString = String.Format("<p>{0}\n", i.Comment);
                        s += newString;
                    }
                    else
                    {
                        newString = String.Format("<p>{0} — {1}</p>\n", i.Comment, i.Name);
                        s += newString;
                    }
                }
                cnt++;
                continue;
            };
            return new ContentResult
            {
                ContentType = "text/html",
                Content = s
            };
        }


    }
}
