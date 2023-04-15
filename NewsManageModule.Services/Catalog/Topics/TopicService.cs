using NewsManageModule.Data.EF;
using NewsManageModule.Data.Entities;
using NewsManageModule.Helpers.Exceptions;
using NewsManageModule.ViewModels.Catalog.Topics;
using NewsManageModule.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NewsManageModule.Services.Catalog.Topics
{
    public class TopicService : ITopicService
    {
        private readonly NMMDbContext _context;
        public TopicService(NMMDbContext context)
        {
            _context = context;
        }

        public async Task<int> AddTopic(string tName)
        {
            //throw new NotImplementedException();
            var topic = new Topic()
            {
                TName = tName
            };
            _context.Topics.Add(topic);
            await _context.SaveChangesAsync();
            return topic.TID;
        }

        public async Task<int> DeleteTopic(int tID)
        {
            //throw new NotImplementedException();
            var topic = await _context.Topics.FindAsync(tID);
            if (topic == null)
                throw new NMMException($"Topic with ID = {tID} is not exist");
            _context.Topics.Remove(topic);
            return await _context.SaveChangesAsync();
        }

        public /*async*/ Task<PageResult<TopicViewModel>> GetAll()
        {
            throw new NotImplementedException();
            //var topics = from t in _context.Topics
            //             join pt in _context.PostsInTopics on t.TID equals pt.TID
            //             select new { t, pt };
            
        }

        public async Task<TopicViewModel> GetByID(int tID)
        {
            //throw new NotImplementedException();
            var topic = await _context.Topics.FindAsync(tID);
            if (topic == null)
                throw new NMMException($"Topic with ID = {tID} is not exist");
            var topicVM = new TopicViewModel()
            {
                TID = topic.TID,
                TName = topic.TName
            };
            return topicVM;
        }

        public async Task<int> UpdateTopic(int tID, string tName)
        {
            //throw new NotImplementedException();
            var topic = await _context.Topics.FindAsync(tID);
            if (topic == null)
                throw new NMMException($"Topic with ID = {tID} is not exist");
            topic.TName = tName;
            _context.Topics.Update(topic);
            return await _context.SaveChangesAsync();
        }
    }
}
