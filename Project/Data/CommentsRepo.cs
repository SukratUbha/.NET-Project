using Microsoft.EntityFrameworkCore.ChangeTracking;
using Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Data
{
    public class CommentsRepo : ICommentsRepo
    {
        private readonly StaffDbContext _dbContext;
        public CommentsRepo(StaffDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public comments AddComment(comments comment)
        {
            EntityEntry<comments> e = _dbContext.Comments.Add(comment);
            comments commentMade = e.Entity;
            _dbContext.SaveChanges();
            return commentMade;
        }

        public IEnumerable<comments> GetAllComments()
        {
            IEnumerable<comments> comment = _dbContext.Comments.ToList<comments>();
            return comment;
        }

        public comments GetCommentsByID(int id)
        {
            comments comment = _dbContext.Comments.FirstOrDefault(e => e.ID == id);
            return comment;
        }
    }
}
