using NewsManageModule.ViewModels.Catalog.Posts;
using NewsManageModule.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NewsManageModule.Services.Catalog.Posts
{
    public interface IPublicPostService
    {
        Task<PageResult<ListPostsViewModel>> GetAll(PagingRequestBase request);
        Task<PageResult<PostViewModel>> GetAllByTopicID(GetPostPublicRequest request);
    }
}
