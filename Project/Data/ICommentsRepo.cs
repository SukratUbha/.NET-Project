using Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Data
{
    public interface ICommentsRepo
    {
        IEnumerable<comments> GetAllComments();
        comments GetCommentsByID(int id);
        comments AddComment(comments comment);
    }
}
