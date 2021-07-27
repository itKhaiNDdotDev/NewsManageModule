using NewsManageModule.ViewModels.Catalog.Posts;
using NewsManageModule.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NewsManageModule.Services.Catalog.Posts
{
    public interface IManagePostService
    {
        Task<PageResult<ListPostsViewModel>> GetAll(PagingRequestBase request);
        Task<PageResult<PostViewModel>> GetAllPaging(GetPostManageRequest request);
        Task<PostViewModel> GetByID(int ID);
        Task<int> Create(PostCreateRequest request);
        Task<int> Update(PostUpdateRequest request);
        Task AddViewCount(int ID);
        Task<int> Delete(int ID);
    }
}
