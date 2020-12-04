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

        [HttpPost]
        public IActionResult AddItem([FromBody] Item newItem)
        {
            if (!ModelState.IsValid)
            {
                return new BadRequestObjectResult(ModelState);
            }

            newItem.Created = DateTime.Now;
            newItem.Modified = DateTime.Now;

            this.dbContext.Add(newItem);
            this.dbContext.SaveChanges();

            return new CreatedResult($"api/items/{newItem.Id}", newItem);
        }
    }
}