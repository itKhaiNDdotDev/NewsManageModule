using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewsManageModule.Services.Catalog.Posts;
using NewsManageModule.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsManageModule.BackendAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IPublicPostService _publicPostService;
        public PostController(IPublicPostService publicPostService)
        {
            _publicPostService = publicPostService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            //return Ok("Demo successed!");
            PagingRequestBase demoRequest = new PagingRequestBase()
            {
                pageIndex = 1,
                pageSize = 3
            };
            var posts = await _publicPostService.GetAll(demoRequest);
            return Ok(posts);
        }
    }
}
