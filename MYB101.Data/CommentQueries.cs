using MYB101.Data.Pocos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Core;
using Umbraco.Core.Persistence;

namespace MYB101.Data
{
    public class CommentQueries
    {
        private UmbracoDatabase db = null;
        public CommentQueries()
        {
            db = ApplicationContext.Current.DatabaseContext.Database;
        }
        public List<UserComment> AddComment(int MemberId, string Name, UserComment comment, UserDetails details)
        {
            var sql = db.Query<UserDetails>("SELECT * FROM UserDetails WHERE MemberId = @0", MemberId).Take(1);
            if (sql.ToArray().Length == 0)
            {
                db.Insert(details);
            }
            else
            {
                db.Update<UserDetails>("SET Name = @1, Avatar = @2 WHERE MemberId = @0 ", MemberId, Name, details.Avatar);
            }
            db.Insert(comment);
            var Id = comment.Id;
            var results = db.Fetch<UserComment>("SELECT UserComments.Id as Id, UserComments.MemberId, UserComments.ContentId, UserComments.Comment, UserComments.DateOP, UserDetails.Name, UserDetails.Avatar as Avatar FROM UserComments LEFT JOIN UserDetails ON UserComments.MemberId = UserDetails.MemberId WHERE UserComments.Id = @0", Id);

            return results;
        }
        public List<UserComment> GetComments(int contentId)
        {
            var results = db.Query<UserComment>("SELECT UserComments.Id as Id, UserComments.MemberId, UserComments.ContentId, UserComments.Comment, UserComments.DateOP, UserDetails.Name, UserDetails.Avatar as Avatar FROM UserComments LEFT JOIN UserDetails ON UserComments.MemberId = UserDetails.MemberId WHERE ContentId = @0", contentId).ToList();

            return results;
        }
        public List<UserComment> UpdateComment(int memberId, int Id, string comment, string sqlFormattedDate)
        {
            var updatedComment = db.Update<UserComment>("SET Comment = @2, DateOP = @3 WHERE MemberId = @0 AND Id = @1", memberId, Id, comment, sqlFormattedDate);

            var result = db.Query<UserComment>("SELECT * FROM UserComments WHERE Id = @0", Id).ToList();

            return result;
        }
        public void DeleteComment(int id)
        {
            db.Delete<UserComment>("WHERE Id = @0", id);
            db.Delete<UserReply>("WHERE CommentId = @0", id);
        }

        public List<UserReply> GetArticleReply(int contentId)
        {
            var results = db.Query<UserReply>("SELECT UserReplys.Id as Id, UserReplys.MemberId, UserReplys.CommentId, UserReplys.RepliedComment, UserReplys.DateOP, UserDetails.Name, UserDetails.Avatar as Avatar FROM UserReplys LEFT JOIN UserDetails ON UserReplys.MemberId = UserDetails.MemberId WHERE UserReplys.ContentId = @0", contentId).ToList();

            return results;
        }
        public List<UserReply> InsertReplyComment(int MemberId, string Name, UserReply replycomment, UserDetails details)
        {
            var sql = db.Query<UserDetails>("SELECT * FROM UserDetails WHERE MemberId = @0", MemberId).Take(1);
            if (sql.ToArray().Length == 0)
            {
                db.Insert(details);
            }
            else
            {
                db.Update<UserDetails>("SET Name = @1, Avatar = @2 WHERE MemberId = @0 ", MemberId, Name, details.Avatar);
            }
            db.Insert(replycomment);
            var Id = replycomment.Id;
            var results = db.Fetch<UserReply>("SELECT UserReplys.Id as Id, UserReplys.MemberId, UserReplys.CommentId, UserReplys.RepliedComment, UserReplys.DateOP, UserDetails.Name, UserDetails.Avatar as Avatar FROM UserReplys LEFT JOIN UserDetails ON UserReplys.MemberId = UserDetails.MemberId WHERE UserReplys.Id = @0", Id);

            return results;
        }
        public List<UserReply> UpdateReplyComment(int memberId, int CommentId, string RepliedComment, string sqlFormattedDate)
        {
            var updatedComment = db.Update<UserReply>("SET RepliedComment = @2, DateOP = @3 WHERE MemberId = @0 AND Id = @1", memberId, CommentId, RepliedComment, sqlFormattedDate);

            var result = db.Query<UserReply>("SELECT * FROM UserReplys WHERE Id = @0", CommentId).ToList();

            return result;
        }
        public void DeleteReplyComment(int id)
        {
            var result = db.SingleOrDefault<UserReply>("SELECT * FROM UserReplys WHERE Id = @0", id);
            db.Delete("UserReplys", "Id", result);
        }
    }
}