using System;
using Microsoft.AspNetCore.Mvc;
using VocabularyBuilderApi.Models;

namespace VocabularyBuilderApi.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class ItemsController : ControllerBase
    {
        private readonly VocabularyBuilderDbContext dbContext;

        public ItemsController(VocabularyBuilderDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return new OkObjectResult(this.dbContext.Items);
        }
    }
}