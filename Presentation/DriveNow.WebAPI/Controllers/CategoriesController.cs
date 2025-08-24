using DriveNow.Application.Features.CQRS.Commands.CategoryCommands;
using DriveNow.Application.Features.CQRS.Handlers.CategoryHandlers.CategoryReadHandlers;
using DriveNow.Application.Features.CQRS.Handlers.CategoryHandlers.CategoryWriteHandlers;
using DriveNow.Application.Features.CQRS.Queries.CategoryQueries;
using Microsoft.AspNetCore.Mvc;

namespace DriveNow.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController
        (CreateCategoryCommandHandler _createCategoryCommandHandler,
         RemoveCategoryCommandHandler _removeCategoryCommandHandler,
    UpdateCategoryCommandHandler _updateCategoryCommandHandler,
         GetCategoryByIdQueryHandler _getCategoryByIdQueryHandler,
         GetCategoryQueryHandler _getCategoryQueryHandler) : ControllerBase

    {

        [HttpGet]
        public async Task<IActionResult> CategoryList()
        {
            var result = await _getCategoryQueryHandler.Handle(new GetCategoryQuery());
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategoryById(Guid id)
        {
            var query = new GetCategoryByIdQuery(id);
            var result = await _getCategoryByIdQueryHandler.Handle(query);

            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory([FromBody] CreateCategoryCommand command)
        {
            if (command == null)
            {
                return BadRequest("Invalid data.");
            }


            var createdCategory = await _createCategoryCommandHandler.Handle(command);
            return CreatedAtAction(
                nameof(GetCategoryById),
                new { id = createdCategory.CategoryId },
                createdCategory);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveCategory(Guid id)
        {
            await _removeCategoryCommandHandler.Handle(new RemoveCategoryCommand(id));
            return NoContent();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCategory([FromBody] UpdateCategoryCommand command)
        {
            if (command == null)
            {
                return BadRequest("Invalid data.");
            }


            var updatedCategory = await _updateCategoryCommandHandler.Handle(command);


            if (updatedCategory == null)
            {
                return NotFound();
            }


            return Ok(updatedCategory);
        }


    }
}
