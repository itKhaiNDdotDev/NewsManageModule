using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewsManageModule.Services.Catalog.Topics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsManageModule.BackendAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TopicsController : ControllerBase
    {
        private readonly ITopicService _topicService;
        public TopicsController(ITopicService topicService)
        {
            _topicService = topicService;
        }

        // Get All Topic: ./api/topics
        [HttpGet]
        //[]
        public async Task<IActionResult> Get()
        {
            var topics = await _topicService.GetAll();
            return Ok(topics);
        }

        // Get topic detail by ID: ./api/topics/{tid}
        [HttpGet("{tid}")]
        public async Task<IActionResult> GetByID(int tid)
        {
            var topic = await _topicService.GetByID(tid);
            if (topic == null)
                return BadRequest($"Can not find topic by ID = {tid}");
            return Ok(topic);
        }

        // Add a new topic: ./api/topics
        [HttpPost]
        public async Task<IActionResult> Create([FromForm] string tName)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var topicID = await _topicService.AddTopic(tName);
            if (topicID == 0)
                return BadRequest();
            var topic = await _topicService.GetByID(topicID);
            //return Created(nameof(GetByID), post);
            return CreatedAtAction(nameof(GetByID), new { id = topicID }, topic);
            //return Ok(postID);
        }

        // Update (Edit) a topic: ./api/topics
        [HttpPut]
        public async Task<IActionResult> Update(int tID, string tName)
        {
            var changed = await _topicService.UpdateTopic(tID, tName);
            if (changed == 0)
                return BadRequest();
            var topic = await _topicService.GetByID(tID);
            return Ok(topic);
        }

        // Delete a topic: ./api/topics/{id}
        [HttpDelete("{tid}")]
        public async Task<IActionResult> Delete(int tid)
        {
            var deleted = await _topicService.DeleteTopic(tid);
            if (deleted == 0)
                return BadRequest();
            return Ok();
        }
    }
}
