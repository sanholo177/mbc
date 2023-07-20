using MYB101.Data;
using MYB101.Data.Pocos;
using MYB101.Logic.Models;
using SafeMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MYB101.Logic.Services
{
    public class CommentsService
    {
        public List<Comments> AddComment(int MemberId, string Name, Comments comm, Detail details)
        {
            //try
            //{
            using (var context = new DataContext())
            {
                var comment = SafeMap.Convert<Comments, UserComment>(comm);
                var userdetails = SafeMap.Convert<Detail, UserDetails>(details);

                var comments = context.CommentQueries.AddComment(MemberId, Name, comment, userdetails);

                return SafeMap.Convert<List<UserComment>, List<Comments>>(comments);

                //return new ActionResponse()
                //{
                //    Success = true,
                //    ErrorMessage = id.ToString()
                //};
            }

            //}
            //catch (Exception ex)
            //{
            //    return new ActionResponse()
            //    {
            //        Success = true,
            //        ErrorMessage = ex.Message
            //    };
            //}
        }
        public List<Comments> GetComments(int contentId)
        {
            using (var context = new DataContext())
            {
                var comments = context.CommentQueries.GetComments(contentId);

                return SafeMap.Convert<List<UserComment>, List<Comments>>(comments);
            }
        }
        public List<Comments> EditComment(int memberId, int Id, string comment, string sqlFormattedDate)
        {
            using (var context = new DataContext())
            {
                var comments = context.CommentQueries.UpdateComment(memberId, Id, comment, sqlFormattedDate);

                return SafeMap.Convert<List<UserComment>, List<Comments>>(comments);
            }
        }
        public ActionResponse DeleteComment(int id)
        {
            try
            {
                using (var context = new DataContext())
                {
                    context.CommentQueries.DeleteComment(id);
                }
                return new ActionResponse()
                {
                    Success = true
                };
            }
            catch (Exception ex)
            {
                return new ActionResponse()
                {
                    Success = false,
                    ErrorMessage = ex.Message
                };
            }

        }
        public List<Reply> GetReply(int contentId)
        {
            using (var context = new DataContext())
            {
                var replys = context.CommentQueries.GetArticleReply(contentId);

                return SafeMap.Convert<List<UserReply>, List<Reply>>(replys);
            }
        }
        public List<Reply> AddReplyComment(int MemberId, string Name, Reply rep, Detail details)
        {
            //try
            //{
            using (var context = new DataContext())
            {
                var replycomment = SafeMap.Convert<Reply, UserReply>(rep);
                var userdetails = SafeMap.Convert<Detail, UserDetails>(details);
                //var id = 

                //var comment = SafeMap.Convert<Comments, UserComment>(comm);
                //var userdetails = SafeMap.Convert<Detail, UserDetails>(details);

                //var comments = context.CommentQueries.AddComment(MemberId, Name, comment, userdetails);

                    
                    
                var reply = context.CommentQueries.InsertReplyComment(MemberId, Name, replycomment, userdetails);

                return SafeMap.Convert<List<UserReply>, List<Reply>>(reply);
            //return new ActionResponse()
            //{
            //    Success = true,
            //    ErrorMessage = id.ToString()
            //};
            }

            //}
            //catch (Exception ex)
            //{
            //    return new ActionResponse()
            //    {
            //        Success = true,
            //        ErrorMessage = ex.Message
            //    };
            //}
        }
        public List<Reply> UpdateReply(int memberId, int CommentId, string RepliedComment, string sqlFormattedDate)
        {
            using (var context = new DataContext())
            {
                var reply = context.CommentQueries.UpdateReplyComment(memberId, CommentId, RepliedComment, sqlFormattedDate);

                return SafeMap.Convert<List<UserReply>, List<Reply>>(reply);
            }
        }

        public ActionResponse DeleteReply(int id)
        {
            try
            {
                using (var context = new DataContext())
                {
                    context.CommentQueries.DeleteReplyComment(id);
                }
                return new ActionResponse()
                {
                    Success = true
                };
            }
            catch (Exception ex)
            {
                return new ActionResponse()
                {
                    Success = false,
                    ErrorMessage = ex.Message
                };
            }

        }
    }
}