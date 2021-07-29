using catalog.Dtos;
using catalog.Entities;
using catalog.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

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
        public ActionResult<IEnumerable<ItemDto>> GetItems()
        {
            var items = repository.GetItems().Select(item => item.AsDto());
            return Ok(items);
        }

        [HttpGet("{id}")]
        public ActionResult<ItemDto> GetItem(Guid id)
        {
            var item = repository.GetItem(id).AsDto();
            if (item is null)
            {
                return NotFound();
            }
            return Ok(item);
        }

        [HttpPost]
        public ActionResult CreateItem(CreateItemDto itemDto)
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
                repository.CreateItem(item);
                return CreatedAtAction(nameof(GetItem), new { id = item.Id }, item);
            }
            else
            {
                return BadRequest();
            }

        }

        [HttpPut("{id}")]
        public ActionResult EditItem(Guid id, EditItemDto itemDto)
        {
            var existingItem = repository.GetItem(id);
            if (existingItem is null)
            {
                return NotFound();
            }
            Item newItem = existingItem with
            {
                Name = itemDto.Name,
                Price = itemDto.Price
            };
            repository.EditItem(newItem);
            return NoContent();

        }

        [HttpDelete("{id}")]
        public ActionResult DeleteItem(Guid id)
        {
            var existingItem = repository.GetItem(id);
            if (existingItem is not null)
            {
                repository.DeleteItem(id);
                return NoContent();
            }
            return NotFound();

        }
    }

}
