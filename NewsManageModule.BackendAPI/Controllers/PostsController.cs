using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewsManageModule.Services.Catalog.Posts;
using NewsManageModule.ViewModels.Catalog.Posts;
using NewsManageModule.ViewModels.Catalog.Resources;
using NewsManageModule.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsManageModule.BackendAPI.Controllers
{
    // ./api/posts/
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly IPublicPostService _publicPostService;
        private readonly IManagePostService _managePostService;
        public PostsController(IPublicPostService publicPostService, IManagePostService managePostService)
        {
            _publicPostService = publicPostService;
            _managePostService = managePostService;
        }

        //// Get all Posts exist: ./api/posts
        //[HttpGet]
        //public async Task<IActionResult> Get()
        //{
        //    //return Ok("Demo successed!");
        //    PagingRequestBase demoRequest = new PagingRequestBase()
        //    {
        //        pageIndex = 1,  //demo
        //        pageSize = 3    //demo
        //    };
        //    var posts = await _publicPostService.GetAll(demoRequest);
        //    return Ok(posts);
        //}

        //// Get list posts by Topic ID: ./api/posts/public-by-topic
        //[HttpGet("public-by-topic")]
        //public async Task<IActionResult> GetGetAllByTopicID([FromQuery] GetPostPublicRequest request)
        //{
        //    var posts = await _publicPostService.GetAllByTopicID(request);
        //    return Ok(posts);
        //}

        // Get post detail by ID: ./api/posts/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByID(int id)
        {
            var post = await _managePostService.GetByID(id);
            if (post == null)
                return BadRequest($"Can not find post by ID = {id}");
            return Ok(post);
        }

        // Create a new post: ./api/posts
        [HttpPost]
        public async Task<IActionResult> Create([FromForm] PostCreateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var postID = await _managePostService.Create(request);
            if (postID == 0)
                return BadRequest();
            var post = await _managePostService.GetByID(postID);
            //return Created(nameof(GetByID), post);
            return CreatedAtAction(nameof(GetByID), new { id = postID }, post);
            //return Ok(postID);
        }

        // Update (Edit) a post: ./api/posts
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] PostUpdateRequest request)
        {
            var changed = await _managePostService.Update(request);
            if (changed == 0)
                return BadRequest();
            var post = await _managePostService.GetByID(request.ID);
            return Ok(post);
        }

        // Delete a post: ./api/posts/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _managePostService.Delete(id);
            if (deleted == 0)
                return BadRequest();
            return Ok();
        }

        //// Get list posts paging by keyword and topicID: ./api/post/get-search-allpaging
        //[HttpGet("get-search-allpaging")]
        //public async Task<IActionResult> GetSearchAllPaging([FromQuery] GetPostManageRequest request)
        //{
        //    var posts = await _managePostService.GetAllPaging(request);
        //    if (posts == null || posts.TotalRecord == 0)
        //        return BadRequest("No result");
        //    return Ok(posts);
        //}
        // Get list posts paging by keyword and topicID: ./api/post
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GetPostManageRequest request)
        {
            var posts = await _managePostService.GetAllPaging(request);
            if (posts == null || posts.TotalRecord == 0)
                return BadRequest("No result");
            return Ok(posts);
        }

        // Add +1 to View Count of post: ./api/add-view-count/{id}
        [HttpPatch("add-view-count/{id}")]
        public async Task<IActionResult> AddViewCount(/*[FromQuery]*/ int id)
        {
            await _managePostService.AddViewCount(id);
            return Ok();
        }

        // Get image by iamgeID (RID): ./api/posts/{id?}/images/{rid}
        [HttpGet("{id?}/images/{rid}")]
        public async Task<IActionResult> GetImageByID(int rid)
        {
            var image = await _managePostService.GetResourceByID(rid);
            if (image == null)
                return BadRequest($"Can not find post by ID = {rid}");
            return Ok(image);
        }

        // Add a image to a post: ./api/posts/{id}/image
        [HttpPost("{id}/image")]
        public async Task<IActionResult> AddImage(int id, [FromForm] PostImageAddRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var imageID = await _managePostService.AddImage(id, request);
            if (imageID == 0)
                return BadRequest();
            var image = await _managePostService.GetResourceByID(imageID);
            return CreatedAtAction(nameof(GetImageByID), new { id = imageID }, image);
        }

        // Update a image: ./api/posts/{id}/image/{rid}
        [HttpPut("{id}/image/{rid}")]
        public async Task<IActionResult> UpdateImage(/*int id,*/ int rid, [FromForm] PostImageUpdateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var changed = await _managePostService.UpdateImage(rid, request);
            if (changed == 0)
                return BadRequest();
            var image = await _managePostService.GetResourceByID(rid);
            return Ok(image);
        }

        // Remove a image: ./api/posts/{id}/image/{rid}
        [HttpDelete("{id}/image/{rid}")]
        public async Task<IActionResult> RemoveImage(/*int id,*/ int rid)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var changed = await _managePostService.RemoveImage(rid);
            if (changed == 0)
                return BadRequest();
            return Ok();
        }

        // Get list all images in a post: ./api/posts/{id}/images
        [HttpGet("{id}/images")]
        public async Task<IActionResult> GetListImages(int id)
        {
            var images = await _managePostService.GetListImages(id);
            return Ok(images);
        }

        // Get list edit histories of post: ./api/posts/{id}/histories
        [HttpGet("{id}/histories")]
        public async Task<IActionResult> GetEditHistory(int id)
        {
            var histories = await _managePostService.GetEditHistories(id);
            return Ok(histories);
        }
    }
}
