
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;


namespace ToDoList_GSG.Controllers
{
    [ApiController]
    public class ItemController : ApiBaseController
    {
        private IItemManager _ItemManager;
        private readonly ILogger<UserController> _logger;

        public ItemController(ILogger<UserController> logger,
                              IItemManager ItemManager)
        {
            _logger = logger;
            _ItemManager = ItemManager;
        }

        [Route("api/item")]
        [HttpGet]
        public IActionResult GetBlogs(int page = 1, int pageSize = 5, string sortColumn = "", string sortDirection = "ascending", string searchText = "")
        {
            var result = _ItemManager.GetBItems(page, pageSize, sortColumn, sortDirection, searchText);
            return Ok(result);
        }

        private IActionResult Ok(object result)
        {
            throw new NotImplementedException();
        }

        [Route("api/blog/{id}")]
        [HttpGet]
        public IActionResult GetItem(int id)
        {
            var result = _ItemManager.GetItem(id);
            return Ok(result);
        }


        [Route("api/Item/{id}")]
        [HttpDelete]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        
        public IActionResult ArchiveItem(int id)
        {
            _ItemManager.ArchiveItemBlog(LoggedInUser, id);
            return Ok();
        }

        private IActionResult Ok()
        {
            throw new NotImplementedException();
        }

        [Route("api/Item")]
        [HttpPut]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
       
        public IActionResult PutItems(ItemRequest ItemRequest)
        {
            var result = _ItemManager.PutBlog(LoggedInUser, ItemRequest);
            return Ok(result);
        }

    }
}
