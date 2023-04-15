using NewsManageModule.Data.EF;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using NewsManageModule.Helpers.Exceptions;
using NewsManageModule.ViewModels.Catalog.Posts;
using NewsManageModule.ViewModels.Common;

namespace NewsManageModule.Services.Catalog.Posts
{
    public class PublicPostService : IPublicPostService
    {
        private readonly NMMDbContext _context;
        public PublicPostService(NMMDbContext context)
        {
            _context = context;
        }
///
        public async Task<PageResult<ListPostsViewModel>> GetAll(PagingRequestBase request)
        {
            //throw new NotImplementedException();
            var allPosts = /*await*/
                from p in _context.Posts
                join pt in _context.PostsInTopics on p.ID equals pt.ID
                join t in _context.Topics on pt.TID equals t.TID
                //user
                select new { p, t };
            int totalRow = await allPosts.CountAsync();
            if (allPosts == null || totalRow == 0)
                throw new NMMException("No content exists on the system!");
            var data = await allPosts.Skip((request.pageIndex - 1) * (request.pageSize)).Take(request.pageSize)
                .Select(l => new ListPostsViewModel()
                {
                    ID = l.p.ID,
                    Head = l.p.Head,
                    TID = l.t.TID,
                    TName = l.t.TName
                }).ToListAsync();
            var pageResults = new PageResult<ListPostsViewModel>
            {
                TotalRecord = totalRow,
                Items = data
            };
            return pageResults;
        }

        public async Task<PageResult<PostViewModel>> GetAllByTopicID(GetPostPublicRequest request)
        {
            //throw new NotImplementedException();
            var query = from p in _context.Posts
                        join pt in _context.PostsInTopics on p.ID equals pt.ID
                        join t in _context.Topics on pt.TID equals t.TID
                        select new { p, pt };
            if (request.topicID.HasValue && request.topicID.Value > 0)
                query = query.Where(p => p.pt.TID == request.topicID);
            int totalRow = await query.CountAsync();
            var data = await query.Skip((request.pageIndex - 1) * (request.pageSize)).Take(request.pageSize)
                .Select(x => new PostViewModel()
                {
                    ID = x.p.ID,
                    Head = x.p.Head,
                    Content = x.p.Content,
                    Time = x.p.Time,
                    ViewCount = x.p.ViewCount
                    //UserID, /Topic?/
                }).ToListAsync();
            var pageResult = new PageResult<PostViewModel>
            {
                TotalRecord = totalRow,
                Items = data
            };
            return pageResult;
        }
    }
}
