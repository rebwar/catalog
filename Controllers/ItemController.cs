using catalog.Dtos;
using catalog.Entities;
using catalog.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace catalog.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ItemController : ControllerBase
    {
        private readonly IItemRepository repository;
        public ItemController(IItemRepository repository)
        {
            this.repository = repository;

        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ItemDto>>> GetItemsAsync()
        {
            var items =(await repository.GetItemsAsync())
                        .Select(item => item.AsDto());
            return Ok(items);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ItemDto>> GetItem(Guid id)
        {
            var item =(await repository.GetItemAsync(id)).AsDto();
            if (item is null)
            {
                return NotFound();
            }
            return Ok(item);
        }

        [HttpPost]
        public async Task<ActionResult> CreateItem(CreateItemDto itemDto)
        {
            if (ModelState.IsValid)
            {
                var item = new Item
                {
                    Id = Guid.NewGuid(),
                    Name = itemDto.Name,
                    Price = itemDto.Price,
                    CreateDate = DateTimeOffset.UtcNow
                };
               await repository.CreateItemAsync(item);
                return CreatedAtAction(nameof(GetItem), new { id = item.Id }, item);
            }
            else
            {
                return BadRequest();
            }

        }

        [HttpPut("{id}")]
        public async Task<ActionResult> EditItem(Guid id, EditItemDto itemDto)
        {
            var existingItem =await repository.GetItemAsync(id);
            if (existingItem is null)
            {
                return NotFound();
            }
            Item newItem = existingItem with
            {
                Name = itemDto.Name,
                Price = itemDto.Price
            };
           await repository.EditItemAsync(newItem);
            return NoContent();

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteItem(Guid id)
        {
            var existingItem =await repository.GetItemAsync(id);
            if (existingItem is not null)
            {
               await repository.DeleteItemAsync(id);
                return NoContent();
            }
            return NotFound();

        }
    }

}
