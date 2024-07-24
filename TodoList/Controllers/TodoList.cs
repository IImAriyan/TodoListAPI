using System.Runtime.Intrinsics.X86;
using Humanizer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using TodoList.Entitys;

namespace TodoList.Controllers
{
    [Route("api/")]
    [ApiController]
    public class TodoList(ApplicationDbContext dbContext) : ControllerBase
    {
        
        // Add Function
        [HttpPost("Todo/Add")]
        public async Task<ActionResult<TodoEntity>> CreateTodo(TodoEntity dto)
        {
            dto.ID = Guid.NewGuid();
            EntityEntry Todo = await dbContext.AddAsync(dto); 
            await dbContext.SaveChangesAsync();
            return Ok(await dbContext.SaveChangesAsync());
        }
        
        
        // Show All Todos
        [HttpGet("Todo/List")]
        public ActionResult<IEnumerable<TodoEntity>> Show()
        {
            return dbContext.TodoList;
        }
        
        // Read By One ID
        [HttpGet("Todo/{id}")]
        public async Task<ActionResult<TodoEntity>> readByID(Guid id)
        {
            TodoEntity Todo = await dbContext.TodoList.FirstOrDefaultAsync(x => x.ID == id);
            if (Todo == null) return NotFound();
            return Ok(Todo);
        }

        // Update Function
        [HttpPost("Todo/Update/{id}")]
        public async Task<ActionResult<TodoEntity>> UpdateTodo(TodoEntity  dto , Guid id)
        {
            TodoEntity Todo = await dbContext.TodoList.FirstOrDefaultAsync(x => x.ID == id);
            if (Todo == null) return NotFound();
            Todo.ID = id;
            Todo.Title = dto.Title;
            Todo.Description = dto.Description;

            dbContext.Update(Todo);
            dbContext.SaveChangesAsync();
            return Ok(Todo);
        }
        
        // Delete Function
        [HttpDelete("Todo/Delete")]
        public async Task<ActionResult> Delete(Guid ID)
        {
            TodoEntity Todo = await dbContext.TodoList.FirstOrDefaultAsync(x => x.ID == ID);
            if (Todo == null) return NotFound();
            dbContext.Remove(Todo);
            await dbContext.SaveChangesAsync();
            return Ok(Todo);
        }
    }
}
