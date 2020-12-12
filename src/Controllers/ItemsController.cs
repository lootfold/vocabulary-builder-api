using System;
using System.Linq;
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
            return new OkObjectResult(this.dbContext.Items.OrderByDescending(i => i.Modified));
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

        [HttpDelete("{id:int}")]
        public IActionResult DeleteItem([FromRoute] int id)
        {
            var item = this.dbContext.Items.Single(i => i.Id == id);

            this.dbContext.Items.Remove(item);
            this.dbContext.SaveChanges();

            return new OkResult();
        }

        [HttpPut("{id:int}")]
        public IActionResult EditItem([FromRoute] int id, [FromBody] Item item)
        {
            var itemInDb = this.dbContext.Items.Single(i => i.Id == id);

            itemInDb.Word = item.Word;
            itemInDb.Meaning = item.Meaning;
            itemInDb.Modified = DateTime.Now;

            this.dbContext.SaveChanges();

            return new OkObjectResult(itemInDb);
        }
    }
}