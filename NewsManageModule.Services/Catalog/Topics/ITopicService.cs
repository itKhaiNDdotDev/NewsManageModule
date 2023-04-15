using NewsManageModule.ViewModels.Catalog.Topics;
using NewsManageModule.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NewsManageModule.Services.Catalog.Topics
{
    public interface ITopicService
    {
        Task<PageResult<TopicViewModel>> GetAll();
        Task<TopicViewModel> GetByID(int tID);
        Task<int> AddTopic(string tName);
        Task<int> UpdateTopic(int tID, string tName);
        Task<int> DeleteTopic(int tID);
    }
}
