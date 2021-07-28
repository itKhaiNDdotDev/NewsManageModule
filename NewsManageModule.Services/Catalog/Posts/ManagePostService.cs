using NewsManageModule.Data.EF;
using NewsManageModule.Data.Entities;
using NewsManageModule.Helpers.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using NewsManageModule.ViewModels.Catalog.Posts;
using NewsManageModule.ViewModels.Common;
using Microsoft.AspNetCore.Http;
using System.Net.Http.Headers;
using System.IO;
using NewsManageModule.Services.Common;

namespace NewsManageModule.Services.Catalog.Posts
{
    public class ManagePostService : IManagePostService
    {
        private readonly NMMDbContext _context;
        private readonly IStorageService _storageService;
        public ManagePostService(NMMDbContext context, IStorageService storageService)
        {
            _context = context;
            _storageService = storageService;
        }

        public async Task AddViewCount(int ID)
        {
            //throw new NotImplementedException();
            var post = await _context.Posts.FindAsync(ID);
            if (post == null)
                throw new NMMException($"Post with ID = {ID} is not exist");
            post.ViewCount += 1;
            await _context.SaveChangesAsync();
        }

        public async Task<int> Create(PostCreateRequest request)
        {
            //throw new NotImplementedException();
            var post = new Post
            {
                Head = request.Head,
                Content = request.Content,
                Time = DateTime.Now,
                ViewCount = 0
                //UserId
                //TopicID
            };
            //Add Image
            if (request.Image != null)
            {
                int i = 0;
                post.Resources = new List<Resource>
                {
                    new Resource()
                    {
                        ID = post.ID,
                        Caption = "post_id: " + post.ID.ToString() + "image " + i++.ToString(),
                        FileSize = request.Image.Length,
                        ImportDate = DateTime.Now,
                        IsAvatar = (i == 0) ? true : false,
                        URL = await this.SaveFile(request.Image)
                    }
                };
                //_context.Resources.Add(post.Resources);
            }
            //Save to Db
            _context.Posts.Add(post);
            await _context.SaveChangesAsync();
            return post.ID;
        }

        public async Task<int> Delete(int ID)
        {
            //throw new NotImplementedException();
            var post = await _context.Posts.FindAsync(ID);
            if (post == null)
                throw new NMMException($"Post with ID = {ID} is not exist");
            var images = _context.Resources.Where(i => i.ID == ID);
            foreach (var image in images)
            {
                await _storageService.DeleteFileAsync(image.URL);
            }
            _context.Posts.Remove(post);
            return await _context.SaveChangesAsync();
        }

        public async Task<PageResult<ListPostsViewModel>> GetAll(PagingRequestBase request)
        {
            //throw new NotImplementedException();
            var allPosts = /*await*/
                from p in _context.Posts
                join pt in _context.PostsInTopics on p.ID equals pt.ID
                join t in _context.Topics on pt.TID equals t.TID
                //user
                select new { p, t};
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

        public async Task<PageResult<PostViewModel>> GetAllPaging(GetPostManageRequest request)
        {
            //throw new NotImplementedException();
            var query = from p in _context.Posts
                        join pt in _context.PostsInTopics on p.ID equals pt.ID
                        join t in _context.Topics on pt.TID equals t.TID
                        select new { p, pt };
            if (!string.IsNullOrEmpty(request.keyword))
                query = query.Where(r => (r.p.Head.Contains(request.keyword)) || (r.p.Content.Contains(request.keyword)));
            if (request.topicIDs.Count > 0)
                query = query.Where(p => request.topicIDs.Contains(p.pt.TID));
            int totalRow = await query.CountAsync();
            if (query == null || totalRow == 0)
                throw new NMMException("No result is found!");
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

        public async Task<PostViewModel> GetByID(int ID)
        {
            //throw new NotImplementedException();
            var post = await _context.Posts.FindAsync(ID);
            if (post == null)
                throw new NMMException($"Post with ID = {ID} is not exist");
            //var topics = await
            //    (from t in _context.Topics
            //     join pt in _context.PostsInTopics on t.TID equals pt.TID
            //     where pt.ID == post.ID
            //     select t.TName).ToListAsync();
            var postViewModel = new PostViewModel()
            {
                ID = post.ID,
                Head = post.Head,
                Content = post.Content,
                Time = post.Time,
                ViewCount = post.ViewCount
                //Topics = topics
            };
            return postViewModel;
        }

        public async Task<int> Update(PostUpdateRequest request)
        {
            //throw new NotImplementedException();
            var post = await _context.Posts.FindAsync(request.ID);
            if (post == null)
                throw new NMMException($"Post with ID = {request.ID} is not exist");
            //post.Histories = new List<History>
            //{
            //    new History
            //    {
            //        ID = request.ID,
            //        EditTime = DateTime.Now,
            //        OldHeader = post.Head,
            //        NewHeader = request.Head,
            //        OldContent = post.Content,
            //        NewContent = request.Content
            //    }
            //};
            post.Head = request.Head;
            post.Content = request.Content;
            //post.PostInTopics
            //_context.Histories.Add(post.Histories);
            //Update Images
            if (request.Image != null)
            {
                var image = await _context.Resources.FirstOrDefaultAsync(i => i.ID == request.ID);
                if(image != null)
                {
                    image.FileSize = request.Image.Length;
                    image.ImportDate = DateTime.Now;
                    image.URL = await this.SaveFile(request.Image);
                    _context.Resources.Update(image);
                }
            }
            _context.Posts.Update(post);
            return await _context.SaveChangesAsync();
        }

        private async Task<string> SaveFile(IFormFile file)
        {
            var originalFileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
            var fileName = $"{Guid.NewGuid()}{Path.GetExtension(originalFileName)}";
            await _storageService.SaveFileAsync(file.OpenReadStream(), fileName);
            return fileName;
        }
    }
}
